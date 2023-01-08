using LiveSplit.ComponentUtil;
using LiveSplit.Model;
using LiveSplit.UI.Components.AutoSplit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            //try
            //{
            //    WriteDebug("start inv");
            //    List<string> tech = knownTech.ConvertAll<string>(x => x.ToString());
            //    tech.Sort();
            //    foreach (var t in knownTech)
            //    {
            //        WriteDebug(t.ToString());
            //    }
            //}
            //catch (NullReferenceException)
            //{

            //}
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
        internal bool ToothSplitSetting
        {
            get
            {
                if (settings != null)
                    return settings.ToothSplit;
                return false;
            }
        }
        internal bool toothSplitTriggered = false;
        internal bool RocketSplitSetting
        {
            get
            {
                if (settings != null)
                    return settings.RocketSplit;
                return false;
            }
        }
        internal bool MountainSplitSetting
        {
            get
            {
                if (settings != null)
                    return settings.MountainSplit;
                return false;
            }
        }
        internal bool mountainSplitTriggered = false;
        internal bool IonSplitSetting
        {
            get
            {
                if (settings != null)
                    return settings.IonSplit;
                return false;
            }
        }
        internal bool SparseSplitSetting
        {
            get
            {
                if (settings != null)
                    return settings.SparseSplit;
                return false;
            }
        }

        public void Update()
        {
            //Debug.WriteLine("Update");
            Debug.WriteLineIf(game == null, $"[Subnautica Autosplitter] game null");
            Debug.WriteLineIf(!pointersInitialized, $"[Subnautica Autosplitter] pointers not intialized");
            if (game != null && pointersInitialized)
            {
                isIntroActiveWatcher.Update(game);
                
                launchStartedWatcher.Update(game);
                
                playerBiomePtr.Update(game);
                biomeStringOld = biomeString;
                biomeString = IntPtrToString(playerBiomePtr.Current + 0x14, 64).Trim(' ');
                
                
                playerCinematicActive.Update(game);
                
                //inventoryDictionaryPtr.Update(game);
                //Task refreshInventory = new Task(GetInventory, null);
                //refreshInventory.Start();
                GetInventory(null);
                
                //knownTechPtr.Update(game);
                //Task refreshKnownTech = new Task(GetBlueprints, null);
                //refreshKnownTech.Start();
                GetBlueprints(null);
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
        public static string biomeStringOld;

        public static MemoryWatcher<IntPtr> inventoryDictionaryPtr = new MemoryWatcher<IntPtr>(IntPtr.Zero);
        public static Dictionary<TechType, int> playerInventory;
        public static Dictionary<TechType, int> playerInventoryOld;

        public static MemoryWatcher<IntPtr> knownTechPtr = new MemoryWatcher<IntPtr>(IntPtr.Zero);
        public static List<TechType> knownTech;
        public static List<TechType> knownTechOld;

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
                    gameVersion = GameVersion.CurrentPatch;
                    WriteDebug($"Module length {moduleLen} does not match a version, defaulting to current patch");
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
            DeepPointer blueprintsPtr;
            switch (gameVersion)
            {
                case GameVersion.Sept2018:
                    introPtr = new DeepPointer("mono.dll", 0x262a68, 0x40, 0xd88, 0x218, 0x10, 0x28, 0x18, 0x1e8, 0x28, 0x86);
                    launchPtr = new DeepPointer("mono.dll", 0x27EAD8, 0x40, 0x70, 0x50, 0x90, 0x30, 0x8, 0x80);
                    biomePtr = new DeepPointer("mono.dll", 0x262a68, 0x40, 0xd88, 0x218, 0x10, 0x28, 0x18, 0x1d0);
                    playerCinematicPtr = new DeepPointer("Subnautica.exe", 0x142b908, 0x180, 0x128, 0x80, 0x1d0, 0x8, 0x248, 0x240);
                    inventoryPtr = new DeepPointer("mono.dll", 0x00296bc8, 0x20, 0xa40, 0x0, 0x40, 0x58, 0x28);
                    blueprintsPtr = new DeepPointer("Subnautica.exe", 0x142b5e8, 0x2A8, 0x58, 0x30, 0xF8, 0x8, 0x18, 0x158);
                    break;

                default:
                    introPtr = new DeepPointer("UnityPlayer.dll", 0x16d0400, 0x68, 0x140, 0xa8, 0x18, 0x60, 0x28, 0x86);
                    launchPtr = new DeepPointer("UnityPlayer.dll", 0x1678148, 0x40, 0x5f0, 0x424, 0x8, 0xd8, 0x40, 0x80);
                    biomePtr = new DeepPointer("UnityPlayer.dll", 0x1690cd0, 0x8, 0x10, 0x30, 0x678, 0x58, 0x188, 0x1d8);
                    playerCinematicPtr = new DeepPointer("UnityPlayer.dll", 0x1690cd0, 0x8, 0x10, 0x30, 0x678, 0x58, 0x188, 0x248);
                    inventoryPtr = new DeepPointer("UnityPlayer.dll", 0x1691ce0, 0x8, 0x4f8, 0x160, 0x188, 0x40, 0x58, 0x18);
                    blueprintsPtr = new DeepPointer("mono-2.0-bdwgc.dll", 0x492DC8, 0x38, 0x230, 0x3F0, 0xE0, 0x770, 0x150, 0x1A8);
                    break;
            }
            isIntroActiveWatcher = new MemoryWatcher<bool>(introPtr);
            launchStartedWatcher = new MemoryWatcher<bool>(launchPtr);
            playerBiomePtr = new MemoryWatcher<IntPtr>(biomePtr);
            playerCinematicActive = new MemoryWatcher<bool>(playerCinematicPtr);
            inventoryDictionaryPtr = new MemoryWatcher<IntPtr>(inventoryPtr);
            knownTechPtr = new MemoryWatcher<IntPtr>(blueprintsPtr);
            WriteDebug("Pointers initialized");
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

        public void GetInventory(object o)
        {
            Dictionary<TechType, int> inv = new Dictionary<TechType, int>();
            if (game != null)
            {
                inventoryDictionaryPtr.Update(game);
                IntPtr startAddr = inventoryDictionaryPtr.Current;
                
                int size = game.ReadValue<int>(startAddr + 0x18);
                int startOffset = gameVersion == GameVersion.CurrentPatch ? 0x30 : 0x20;
                int itemOffset = gameVersion == GameVersion.CurrentPatch ? 0x18 : 0x8;
                for (int i = 0; i < size; i++)
                {
                    IntPtr itemGroup = game.ReadPointer(startAddr + startOffset + (itemOffset * i));

                    if (itemGroup != IntPtr.Zero)
                    {
                        TechType itemType = (TechType)game.ReadValue<int>(itemGroup + 0x18);

                        IntPtr list = game.ReadPointer(itemGroup + 0x10);
                        int itemCount = game.ReadValue<int>(list + 0x18);
                        inv.Add(itemType, itemCount);
                    }
                }
            }
            else
            {
                WriteDebug("Game null in GetInventory");
            }
            Thread.Sleep(10);
            //WriteDebug("end inv");
            playerInventoryOld = playerInventory;
            playerInventory = inv;
            //return inv;
        }

        public void GetBlueprints(object o)
        {
            List<TechType> blueprints = new List<TechType>();
            if (game != null)
            {
                //DateTime start = DateTime.Now;
                knownTechPtr.Update(game);
                //WriteDebug("Getting bps from " + knownTechPtr.Current.ToString("X"));
                IntPtr startAddr = knownTechPtr.Current;

                int slotsOffset = gameVersion == GameVersion.Sept2018 ? 0x20 : 0x18;
                IntPtr slots = game.ReadPointer(startAddr + slotsOffset);
                int countOffset = gameVersion == GameVersion.Sept2018 ? 0x40 : 0x30;
                int count = game.ReadValue<int>(startAddr + countOffset);

                int slotBeginningOffset = gameVersion == GameVersion.Sept2018 ? 0x0 : 0x38;
                int slotSize = gameVersion == GameVersion.Sept2018 ? 0x4 : 0x18;
                for (int i = 0; i < count; i++)
                {
                    int tech = game.ReadValue<int>(slots + slotBeginningOffset + slotSize * i);
                    if (tech > 0 && tech < 10005)
                    {
                        TechType type = (TechType)tech;
                        blueprints.Add(type);
                        //WriteDebug($"has {type}");
                    }
                }
                //DateTime end = DateTime.Now;
                //TimeSpan time = end - start;
                //WriteDebug($"took {time.Ticks / 1000000d}ms to read bps");
            }
            //WriteDebug("end BPs");

            knownTechOld = knownTech;
            knownTech = blueprints;
        }

        #endregion

        #endregion

        #region Logic
        public bool ShouldSplit(LiveSplitState state)
        {
            if (game != null)
            {
                if (ToothSplitSetting && !toothSplitTriggered)
                {
                    if (playerInventory == null || playerInventoryOld == null) { WriteDebug("inv null"); }
                    else if (playerInventory.ContainsKey(TechType.StalkerTooth) && 
                        playerInventory[TechType.StalkerTooth] >= 4 && 
                        playerInventoryOld.ContainsKey(TechType.StalkerTooth) && 
                        playerInventoryOld[TechType.StalkerTooth] < 4)
                    {
                        toothSplitTriggered = true;
                        return true;
                    }
                }
                if (RocketSplitSetting)
                {
                    if (knownTech.Contains(TechType.RocketBase) && !knownTechOld.Contains(TechType.RocketBase))
                        return true;
                }
                if (MountainSplitSetting)
                {
                    if (biomeString == "mountains" && biomeStringOld == "kelpForest" && !mountainSplitTriggered)
                    {
                        mountainSplitTriggered = true;
                        return true;
                    }
                }
                if (IonSplitSetting)
                {
                    if (knownTech.Contains(TechType.PrecursorIonBattery) && !knownTechOld.Contains(TechType.PrecursorIonBattery))
                        return true;
                }
                if (SparseSplitSetting)
                {
                    if ((biomeString == "Lifepod" || biomeString == "safeShallows") && biomeStringOld == "seaTreaderPath")
                        return true;
                }
                if (GunSplitSetting)
                {
                    if (playerCinematicActive.Current == true && playerCinematicActive.Old == false && biomeString == "Precursor_Gun_ControlRoom")
                        return true;
                }
                if (EndSplitSetting)
                {
                    if (launchStartedWatcher.Current == true && launchStartedWatcher.Old == false)
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
                if (game != null)
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

        public void OnReset(TimerPhase t)
        {
            toothSplitTriggered = false;
            mountainSplitTriggered = false;
            WriteDebug("OnReset");
        }
        
        public bool IsGameTimePaused(LiveSplitState state) { return false; }
        public TimeSpan? GetGameTime(LiveSplitState state) { return null; }

        #endregion Logic

        private void WriteDebug(string message)
        {
#if DEBUG
            Debug.WriteLine($"[Subnautica Autosplitter] {message}");
#endif
        }
    }
    
    internal enum GameVersion
    {
        CurrentPatch,
        Sept2018
    }
}
