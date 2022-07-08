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
        public Timer debugWriteTimer;
        GameVersion gameVersion;

        public bool pointersInitialized;

        private SubnauticaSettings settings;
        internal SubnauticaSplitter(SubnauticaSettings _settings)
        {
            this.settings = _settings;
        }
        internal void DebugWrites(object o)
        {
            //if (settings != null)
            //{
            //    WriteDebug("Settings not null");
            //}
            //else
            //{
            //    WriteDebug("Settings are null");
            //}
            //WriteDebug($"intro active: {isIntroActiveWatcher.Current}");
        }

        internal bool StartSplitSetting
        {
            get
            {
                if (settings != null)
                    return settings.StartSplit;
                return true;
            }
        }
        internal bool EndSplitSetting
        {
            get
            {
                if (settings != null)
                    return settings.EndSplit;
                return true;
            }
        }

        public void Update()
        {
            //Debug.WriteLine("Update");
            Debug.WriteLineIf(game == null, $"game null");
            Debug.WriteLineIf(!pointersInitialized, $"pointers not intialized");
            if (game != null && pointersInitialized)
            {
                isIntroActiveWatcher.Update(game);
                launchStartedWatcher.Update(game);
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
                    InitPointers();
                }
            }
        }

        public static MemoryWatcher<bool> isIntroActiveWatcher = new MemoryWatcher<bool>(IntPtr.Zero);

        public static MemoryWatcher<bool> launchStartedWatcher = new MemoryWatcher<bool>(IntPtr.Zero);

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

        public void InitPointers()
        {
            DeepPointer introPtr;
            DeepPointer launchPtr;
            switch (gameVersion)
            {
                case GameVersion.Sept2018:
                    introPtr = new DeepPointer("Subnautica.exe", 0x142b908, 0x188, 0x150, 0xd0, 0x18, 0x1e8, 0x28, 0x86);
                    launchPtr = new DeepPointer("mono.dll", 0x27EAD8, 0x40, 0x70, 0x50, 0x90, 0x30, 0x8, 0x80);
                    break;

                default:
                    introPtr = new DeepPointer("UnityPlayer.dll", 0x16d0400, 0x68, 0x140, 0xa8, 0x18, 0x60, 0x28, 0x86);
                    launchPtr = new DeepPointer("UnityPlayer.dll", 0x1678148, 0x40, 0x5f0, 0x424, 0x8, 0xd8, 0x40, 0x80);
                    break;
            }
            isIntroActiveWatcher = new MemoryWatcher<bool>(introPtr);
            launchStartedWatcher = new MemoryWatcher<bool>(launchPtr);
            Debug.WriteLine("Pointers initialized");
            pointersInitialized = true;
        }
        
        #endregion

        #region Logic
        public bool ShouldSplit(LiveSplitState state)
        {
            if (EndSplitSetting && game != null)
            {
                if (launchStartedWatcher.Current == true && launchStartedWatcher.Old == false)
                    return true;
            }
            return false;
        }

        public bool ShouldReset(LiveSplitState state)
        {
            return false;
        }
        
        public bool ShouldStart(LiveSplitState state)
        {
            if (game == null)
            {
                GetGameProcess();
                if (!(game == null))
                {
                    WriteDebug("Starting timers");
                    debugWriteTimer = new Timer(DebugWrites, null, 0, 500);
                }
                return false;
            }
            if (StartSplitSetting && game != null)
            {
                if (isIntroActiveWatcher.Current == false && isIntroActiveWatcher.Old == true)
                    return true;
            }
            return false;
        }

        public bool IsGameTimePaused(LiveSplitState state) { return false; }
        public TimeSpan? GetGameTime(LiveSplitState state) { return null; }

        #endregion Logic

        private void WriteDebug(string message)
        {
            Debug.WriteLine($"[Subnautica Splitter] {message}");
        }
    }

    internal enum GameVersion
    {
        CurrentPatch,
        Sept2018
    }
}
