state("Subnautica") {}

startup
{
	vars.Dbg = (Action<dynamic>) ((output) => print("[Subnautica ASL] " + output));

	settings.Add("end", true, "Split on rocket launch");
	settings.Add("gunDeactivate", false, "Split on gun deactivation");
}

init
{
	string module;
	int[] monoOffsets;
	Dictionary<string, Dictionary<string, int>> classes;

	switch (game.MainModule.ModuleMemorySize)
	{
		case 0xA4000:
		{
			version = "April 2021";
			module = "mono-2.0-bdwgc.dll";
			monoOffsets = new[] { 0x4950C0, 0x4D8, 0x4E0, 0x108, 0x58, 0xD0 };
			classes = new Dictionary<string, Dictionary<string, int>>
			{
				{ "Player", new Dictionary<string, int>
					{
						{ "token", 0x2000390 },
						{ "data", 0x90 },
						{ "cinematicModeActive", 0x248 },
						{ "biomeString", 0x1D8 }
					}
				},
				{ "EscapePod", new Dictionary<string, int>
					{
						{ "token", 0x200023C },
						{ "data", 0x80 },
						{ "introCinematic", 0x28 },
						{ "cinematicModeActive", 0x86 }
					}
				},
				{ "LaunchRocket", new Dictionary<string, int>
					{
						{ "token", 0x20002FE },
						{ "data", 0x80 }
					}
				}
			};
			break;
		}

		case 0x16B3000:
		{
			version = "September 2018";
			module = "mono.dll";
			monoOffsets = new[] { 0x265750, 0x3E8, 0x3F0, 0x100, 0x58, 0xF8 };
			classes = new Dictionary<string, Dictionary<string, int>>
			{
				{ "Player", new Dictionary<string, int>
					{
						{ "token", 0x2000562 },
						{ "data", 0x18 },
						{ "cinematicModeActive", 0x240 },
						{ "biomeString", 0x1D0 }
					}
				},
				{ "EscapePod", new Dictionary<string, int>
					{
						{ "token", 0x20003A8 },
						{ "data", 0x18 },
						{ "introCinematic", 0x28 },
						{ "cinematicModeActive", 0x86 }
					}
				},
				{ "LaunchRocket", new Dictionary<string, int>
					{
						{ "token", 0x200049A },
						{ "data", 0x18 }
					}
				}
			};
			break;
		}

		default:
		{
			version = "Unknown!";
			return;
		}
	}

	vars.TokenSource = new CancellationTokenSource();
	vars.MonoThread = new Thread(() =>
	{
		vars.Dbg("Starting mono thread.");

		bool moduleFound = false;
		var token = vars.TokenSource.Token;
		while (!token.IsCancellationRequested)
		{
			if (!moduleFound && !(moduleFound = game.ModulesWow64Safe().FirstOrDefault(m => m.ModuleName == module) != null))
			{
				vars.Dbg("Mono module could not be resolved. Retrying.");
				Thread.Sleep(2000);
				continue;
			}

			var size = new DeepPointer(module, monoOffsets[0], 0x18).Deref<int>(game);
			var cache = new DeepPointer(module, monoOffsets[0], 0x10, 0x8 * (int)(0xFA381AED % size)).Deref<IntPtr>(game);
			for (; cache != IntPtr.Zero; cache = game.ReadPointer(cache + 0x10))
			{
				if (new DeepPointer(cache, 0x0).DerefString(game, 32) != "Assembly-CSharp") continue;
				size = new DeepPointer(cache + 0x8, monoOffsets[1]).Deref<int>(game);
				cache = new DeepPointer(cache + 0x8, monoOffsets[2]).Deref<IntPtr>(game);
				break;
			}

			var mono = new Dictionary<string, IntPtr>();
			foreach (var entry in classes)
			{
				var klass = game.ReadPointer(cache + 0x8 * (int)(entry.Value["token"] % size));
				for (int i = 0; klass != IntPtr.Zero && i < 10; klass = game.ReadPointer(klass + monoOffsets[3]))
				{
					++i;
					if (new DeepPointer(klass + monoOffsets[4]).Deref<int>(game) != entry.Value["token"]) continue;
					mono[entry.Key] = new DeepPointer(klass + monoOffsets[5], 0x8).Deref<IntPtr>(game) + entry.Value["data"];
					vars.Dbg(entry.Key + ": " + mono[entry.Key].ToString("X"));
					break;
				}
			}

			if (mono.Count == 0 || mono.Values.Any(ptr => ptr == IntPtr.Zero))
			{
				vars.Dbg("Not all pointers resolved. Retrying.");
				Thread.Sleep(5000);
				continue;
			}

			vars.rocketLaunching = new DeepPointer(mono["LaunchRocket"]);
			vars.introCinematicActive = new DeepPointer(mono["EscapePod"], 0x0, classes["EscapePod"]["introCinematic"], classes["EscapePod"]["cinematicModeActive"]);
			vars.playerCinematicActive = new DeepPointer(mono["Player"], 0x8, classes["Player"]["cinematicModeActive"]);
			vars.biomeString = new DeepPointer(mono["Player"], 0x8, classes["Player"]["biomeString"], 0x14);

			vars.Dbg("All pointers found successfully.");
			break;
		}

		vars.Dbg("Exiting mono thread.");
	});

	vars.MonoThread.Start();
}

update
{
	if (vars.MonoThread.IsAlive || version == "Unknown!") return false;

	current.rocketLaunching = vars.rocketLaunching.Deref<bool>(game);
	current.introCine = vars.introCinematicActive.Deref<bool>(game);
	current.playerCine = vars.playerCinematicActive.Deref<bool>(game);
	current.biome = vars.biomeString.DerefString(game, 128);
}

start
{
	return old.introCine && !current.introCine;
}

split
{
	return !old.rocketLaunching && current.rocketLaunching && settings["end"] ||
	       !old.playerCine && current.playerCine && current.biome == "Precursor_Gun_ControlRoom" && settings["gunDeactivate"];
}

exit
{
	vars.TokenSource.Cancel();
}

shutdown
{
	vars.TokenSource.Cancel();
}