using LiveSplit.ComponentUtil;
using LiveSplit.Model;
using LiveSplit.UI.Components.AutoSplit;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
        internal bool GunSplitSetting
        {
            get
            {
                if (settings != null)
                    return settings.GunSplit;
                return false;
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
                //IntPtr testAddr = new IntPtr(0x1dd7e4ac);
                //WriteDebug($"string {IntPtrToString(testAddr, 128)} at {testAddr.ToString("X")}");
                playerBiomePtr.Update(game);
                biomeString = IntPtrToString(playerBiomePtr.Current + 0x14, 64);
                playerCinematicActive.Update(game);
                inventoryDictionaryPtr.Update(game);
                WriteDebug($"inv dictionary at {inventoryDictionaryPtr.Current.ToString("X")}");
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

        public static MemoryWatcher<bool> playerCinematicActive = new MemoryWatcher<bool>(IntPtr.Zero);

        // pointer to the beginning of the string
        public static MemoryWatcher<IntPtr> playerBiomePtr = new MemoryWatcher<IntPtr>(IntPtr.Zero);
        public static string biomeString;

        public static MemoryWatcher<IntPtr> inventoryDictionaryPtr = new MemoryWatcher<IntPtr>(IntPtr.Zero);

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
            DeepPointer biomePtr;
            DeepPointer playerCinematicPtr;
            DeepPointer inventoryPtr;
            switch (gameVersion)
            {
                case GameVersion.Sept2018:
                    introPtr = new DeepPointer("Subnautica.exe", 0x142b908, 0x188, 0x150, 0xd0, 0x18, 0x1e8, 0x28, 0x86);
                    launchPtr = new DeepPointer("mono.dll", 0x27EAD8, 0x40, 0x70, 0x50, 0x90, 0x30, 0x8, 0x80);
                    biomePtr = new DeepPointer("Subnautica.exe", 0x142b908, 0x180, 0x128, 0x80, 0x1d0, 0x8, 0x248, 0x1d0);
                    playerCinematicPtr = new DeepPointer("Subnautica.exe", 0x142b908, 0x180, 0x128, 0x80, 0x1d0, 0x8, 0x248, 0x240);
                    inventoryPtr = new DeepPointer("mono.dll", 0x00296bc8, 0x20, 0xa40, 0x0, 0x40, 0x58, 0x20);
                    break;

                default:
                    introPtr = new DeepPointer("UnityPlayer.dll", 0x16d0400, 0x68, 0x140, 0xa8, 0x18, 0x60, 0x28, 0x86);
                    launchPtr = new DeepPointer("UnityPlayer.dll", 0x1678148, 0x40, 0x5f0, 0x424, 0x8, 0xd8, 0x40, 0x80);
                    biomePtr = new DeepPointer("UnityPlayer.dll", 0x1690cd0, 0x8, 0x10, 0x30, 0x678, 0x58, 0x188, 0x1d8);
                    playerCinematicPtr = new DeepPointer("UnityPlayer.dll", 0x1690cd0, 0x8, 0x10, 0x30, 0x678, 0x58, 0x188, 0x248);
                    inventoryPtr = new DeepPointer("UnityPlayer.dll", 0x01691ce0, 0x8, 0x4f8, 0x160, 0x188, 0x40, 0x58, 0x18);
                    break;
            }
            isIntroActiveWatcher = new MemoryWatcher<bool>(introPtr);
            launchStartedWatcher = new MemoryWatcher<bool>(launchPtr);
            playerBiomePtr = new MemoryWatcher<IntPtr>(biomePtr);
            playerCinematicActive = new MemoryWatcher<bool>(playerCinematicPtr);
            inventoryDictionaryPtr = new MemoryWatcher<IntPtr>(inventoryPtr);
            Debug.WriteLine("Pointers initialized");
            pointersInitialized = true;
        }

        #region Mem utils

        public string IntPtrToString(IntPtr ptr, int maxLen)
        {
            StringBuilder strBuilder = new StringBuilder();
            if (game != null)
            {
                byte[] bytes;
                //WriteDebug($"Converting {ptr.ToString("X")} to string");
                if (!game.ReadBytes(ptr, maxLen * 2, out bytes))
                {
                    return strBuilder.ToString();
                }

                for (int i = 0; i < maxLen; i += 2)
                {
                    if (bytes[i] != 0 || bytes[i + 1] != 0)
                    {
                        byte[] charBytes = { bytes[i], bytes[i + 1] };
                        char ch = BitConverter.ToChar(bytes, i);
                        //WriteDebug($"{bytes[i]}{bytes[i+1]} is {ch}");
                        strBuilder.Append(ch);
                    }
                    else
                    {
                        //WriteDebug("String ended");
                        break;
                    }
                }
            }

            return strBuilder.ToString();
        }

        

        #endregion

        #endregion

        #region Logic
        public bool ShouldSplit(LiveSplitState state)
        {
            if (game != null)
            {
                if (EndSplitSetting)
                {
                    if (launchStartedWatcher.Current == true && launchStartedWatcher.Old == false)
                        return true;
                }
                if (GunSplitSetting)
                {
                    if (playerCinematicActive.Current == true && playerCinematicActive.Old == false && biomeString.Trim(' ') == "Precursor_Gun_ControlRoom")
                        return true;
                }
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
