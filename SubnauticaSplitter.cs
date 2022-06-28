using LiveSplit.ComponentUtil;
using LiveSplit.Model;
using LiveSplit.UI.Components.AutoSplit;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace SubnauticaAutosplitter
{
    public class SubnauticaSplitter : IAutoSplitter
    {
        public Process game;
        public Timer lifepodCheckTimer;
        public Timer rocketCheckTimer;
        public bool lifepodCodeloaded = false;
        public bool launchRocketCodeLoaded = false;
        GameVersion gameVersion;

        #region Signature declarations
        const string CPLifepodSig = "48 B9 ?? ?? ?? ?? ?? ?? ?? ?? 49 BB ?? ?? ?? ?? ?? ?? ?? ?? 41 FF D3 48 8B 45 90 48 8B 75 F8 48 8D 65 00";
        const int CPLifepodOffset = 2;
        SigScanTarget CPLifepodTarget = new SigScanTarget(CPLifepodOffset, CPLifepodSig);
        const string CPLaunchSig = "48 B8 ?? ?? ?? ?? ?? ?? ?? ?? 0F B6 00 85 C0 0F 84 ?? ?? ?? ?? F3 0F 10 86";
        const int CPLaunchOffset = 2;
        SigScanTarget CPLaunchTarget = new SigScanTarget(CPLaunchOffset, CPLaunchSig);

        const string DownPatchLifepodSig = "48 83 c4 20 b8 ?? ?? ?? ?? 48 89 30 48 8d 65 f0 5f 5e c9 c3";
        const int DownPatchLifepodOffset = 5;
        SigScanTarget DownPatchLifepodTarget = new SigScanTarget(DownPatchLifepodOffset, DownPatchLifepodSig);
        const string DownPatchLaunchSig = "b8 ?? ?? ?? ?? 48 0fb6 00 85 c0 0f84 ?? ?? ?? ?? f3 0f10 86";
        const int DownPatchLaunchOffset = 1;
        SigScanTarget DownPatchLaunchTarget = new SigScanTarget(DownPatchLaunchOffset, DownPatchLaunchSig);
        #endregion

        private readonly SubnauticaSettings settings;
        internal SubnauticaSplitter(SubnauticaSettings settings)
        {
            this.settings = settings;
        }

        public void Update()
        {
            if (lifepodCodeloaded)
                isIntroActiveWatcher.Update(game);

            if (game.HasExited)
            {
                lifepodCodeloaded = false;
                launchRocketCodeLoaded = false;
            }
        }

        #region Memory & Such
        public void GetGameProcess()
        {
            if (game == null)
            {
                WriteDebug("Getting game");
                game = Process.GetProcessesByName("Subnautica").FirstOrDefault(p => !p.HasExited);
                if (game != null)
                {
                    WriteDebug("Game found");
                    GetGameVersion();
                }
            }
        }

        IntPtr lifepodScanResult = IntPtr.Zero;
        public static MemoryWatcher<IntPtr> lifepodFieldWatcher;
        public static MemoryWatcher<bool> isIntroActiveWatcher = new MemoryWatcher<bool>(IntPtr.Zero);

        public void CheckLifepod(object o)
        {
            if (!lifepodCodeloaded)
            {
                WriteDebug("Scanning Lifepod");
                foreach (var page in game.MemoryPages())
                {
                    var scanner = new SignatureScanner(game, page.BaseAddress, (int)page.RegionSize);
                    IntPtr ptr = IntPtr.Zero;
                    if (gameVersion == GameVersion.CurrentPatch)
                    {
                        ptr = scanner.Scan(CPLifepodTarget);
                    }
                    else //sept 2018
                    {
                        ptr = scanner.Scan(DownPatchLifepodTarget);
                    }
                    if (ptr != IntPtr.Zero)
                    {
                        lifepodCodeloaded = true;
                        lifepodScanResult = ptr;

                        IntPtr escapePodStaticAddress = game.ReadPointer(lifepodScanResult); //pointer to the escape pod static field;

                        lifepodFieldWatcher = new MemoryWatcher<IntPtr>(escapePodStaticAddress);
                        lifepodFieldWatcher.Update(game);

                        IntPtr cinematicController = game.ReadPointer(lifepodFieldWatcher.Current + 0x28);
                        isIntroActiveWatcher = new MemoryWatcher<bool>(cinematicController + 0x86);
                        WriteDebug("Lifepod found");
                        WriteDebug($"Current lifepod static field at {escapePodStaticAddress.ToString("X")}");
                        WriteDebug($"isIntroActive at {(cinematicController + 0x86).ToString("X")}");
                        break;
                    }
                }
            }
            if (lifepodCodeloaded)
            {
                lifepodFieldWatcher.Update(game);
                if (lifepodFieldWatcher.Changed)
                {
                    WriteDebug("New lifepod obj, updating");
                    IntPtr cinematicController = game.ReadPointer(lifepodFieldWatcher.Current + 0x28);
                    WriteDebug($"IsIntroActive now at {(cinematicController + 0x86).ToString("X")}");
                    isIntroActiveWatcher = new MemoryWatcher<bool>(cinematicController + 0x86);
                }
            }
        }

        public void CheckRocket(object o)
        {
            if (!launchRocketCodeLoaded)
            {
                foreach (var page in game.MemoryPages())
                {

                }
            }
        }

        public void GetGameVersion()
        {
            ProcessModule firstModule = game.Modules.Cast<ProcessModule>().FirstOrDefault();
            int moduleLen = firstModule.ModuleMemorySize;
            switch (moduleLen)
            {
                case 23801856:
                    gameVersion = GameVersion.Sept2018;
                    WriteDebug("Game version Sept 2018");
                    break;

                case 671744:
                    gameVersion = GameVersion.CurrentPatch;
                    WriteDebug("Game version Current Patch");
                    break;

                default:
                    gameVersion = GameVersion.Sept2018;
                    WriteDebug($"Module length {moduleLen} does not match a version, defaulting to sept 2018");
                    break;
            }
        }
        
        #endregion

        #region Logic
        public bool ShouldSplit(LiveSplitState state)
        {
            throw new NotImplementedException();
        }

        public bool ShouldReset(LiveSplitState state)
        {
            throw new NotImplementedException();
        }
        
        public bool ShouldStart(LiveSplitState state)
        {
            if (game == null)
            {
                GetGameProcess();
                if (!(game == null))
                {
                    WriteDebug("Starting timers");
                    lifepodCheckTimer = new Timer(CheckLifepod, null, 0, 6000);
                    rocketCheckTimer = new Timer(CheckRocket, null, 0, 20000);
                }
                return false;
            }
            if (lifepodCodeloaded)
            {
                if (isIntroActiveWatcher.Current == false && isIntroActiveWatcher.Old == true)
                    return true;
            }
            return false;
        }

        public bool IsGameTimePaused(LiveSplitState state) { return false; }
        public TimeSpan? GetGameTime(LiveSplitState state) { return null; }

        #endregion Logic

        internal void WriteDebug(string message)
        {
            Debug.WriteLine($"[Sub Autosplit] {message}");
        }
    }

    internal enum GameVersion
    {
        CurrentPatch,
        Sept2018
    }
}
