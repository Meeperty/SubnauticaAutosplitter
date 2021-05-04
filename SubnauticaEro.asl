// This auto splitter was generated using Ero's 'Unity ASL Generator'.
// More infos here: https://github.com/just-ero/Unity-ASL-Generator.

state("Subnautica") {}

startup
{
	// var SplitScenes = new HashSet<string>
	// {
	// 	"StartScreen",
	// 	"XMenu",
	// 	"Cleaner",
	// 	"Main",
	// 	"EscapePod",
	// 	"Aurora",
	// 	"Cyclops",
	// 	"MenuEnvironment",
	// 	"Essentials",
	// 	"EmptyScene",
	// 	"RocketSpace",
	// 	"EndCredits",
	// 	"EndCreditsSceneCleaner"
	// };
}

init
{
	var UnityPlayer = modules.Single(m => m.ModuleName == "UnityPlayer.dll");
	var UnityPlayerScanner = new SignatureScanner(game, UnityPlayer.BaseAddress, UnityPlayer.ModuleMemorySize);

	Func<IntPtr, int, int, IntPtr> PtrFromOpcode = (ptr, targetOperandOffset, totalSize) =>
	{
		byte[] bytes = game.ReadBytes(ptr + targetOperandOffset, 4);
		if (bytes == null) return IntPtr.Zero;

		Array.Reverse(bytes);
		int offset = Convert.ToInt32(BitConverter.ToString(bytes).Replace("-", ""), 16);
		return IntPtr.Add(ptr + totalSize, offset);
	};

	var SceneManagerSig = new SigScanTarget("48 8B 0D ???????? 48 8D 55 ?? 89 45 ?? 0F B6 85");
	SceneManagerSig.OnFound = (p, s, ptr) => PtrFromOpcode(ptr, 3, 7);
	var LaunchRocketSig = new SigScanTarget("48 8B 3D ???????? 48 8B 5F ?? 48 3B 5F");
	LaunchRocketSig.OnFound = (p, s, ptr) => PtrFromOpcode(ptr, 3, 7);

	IntPtr SceneManager = IntPtr.Zero, LaunchRocket = IntPtr.Zero;

	int iteration = 0;
	while (iteration++ < 50)
	{
		SceneManager = UnityPlayerScanner.Scan(SceneManagerSig);
		LaunchRocket = UnityPlayerScanner.Scan(LaunchRocketSig);

		if (vars.SigsFound = new[] { SceneManager, LaunchRocket }.All(a => a != IntPtr.Zero)) break;
	}

	if (!vars.SigsFound) return;

	Func<string, string> PathToName = (path) =>
	{
		if (String.IsNullOrEmpty(path)) return null;

		int from = path.LastIndexOf('/') + 1;
		int to = path.LastIndexOf(".unity");
		return path.Substring(from, to - from);
	};

	vars.UpdateScenes = (Action) (() =>
	{
		current.ThisScene = PathToName(new DeepPointer(SceneManager, 0x48, 0x10, 0x0).DerefString(game, 256)) ?? old.ThisScene;
		current.NextScene = PathToName(new DeepPointer(SceneManager, 0x28, 0x0, 0x10, 0x0).DerefString(game, 256)) ?? old.NextScene;
	});

	vars.LaunchStarted = new MemoryWatcher<bool>(new DeepPointer(LaunchRocket, 0x8, 0x88, 0x288, 0x198, 0x38, 0x0, 0x78, 0x0));
}

update
{
	if (!vars.SigsFound) return false;
	vars.UpdateScenes();
	vars.LaunchStarted.Update(game);
}