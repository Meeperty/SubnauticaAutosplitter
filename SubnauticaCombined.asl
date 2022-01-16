state("Subnautica", "September 2018")
{
    //player is "Subnautica.exe", 0x142b908, 0x180, 0x128, 0x80, 0x1d0, 0x8, 0x248, ...
    //modules.First() length 23801856
    bool rocketLaunching: "mono.dll", 0x27EAD8, 0x40, 0x70, 0x50, 0x90, 0x30, 0x8, 0x80;
    bool introCinematicActive: "Subnautica.exe", 0x142b908, 0x188, 0x150, 0xd0, 0x18, 0x1e8, 0x28, 0x86;
    bool playerCinematicActive: "Subnautica.exe", 0x142b908, 0x180, 0x128, 0x80, 0x1d0, 0x8, 0x248, 0x240;
    string128 biomeString: "Subnautica.exe", 0x142b908, 0x180, 0x128, 0x80, 0x1d0, 0x8, 0x248, 0x1d0, 0x14;
}

state("Subnautica", "December 2021")
{
    // player is "UnityPlayer.dll", 0x1690cd0, 0x8, 0x10, 0x30, 0x678, 0x58, 0x188, ...
    // inventory is "UnityPlayer.dll", 0x1690cd0, 0x8, 0x10, 0x30, 0x1a8, 0x28
    // modules.First() length 671744
    bool rocketLaunching:       "UnityPlayer.dll", 0x1678148, 0x40, 0x5f0, 0x424, 0x8, 0xd8, 0x40, 0x80;
    bool introCinematicActive:  "UnityPlayer.dll", 0x16d0400, 0x68, 0x140, 0xa8, 0x18, 0x60, 0x28, 0x86;
    bool playerCinematicActive: "UnityPlayer.dll", 0x1690cd0, 0x8, 0x10, 0x30, 0x678, 0x58, 0x188, 0x248;
    string128 biomeString:      "UnityPlayer.dll", 0x1690cd0, 0x8, 0x10, 0x30, 0x678, 0x58, 0x188, 0x1d8, 0x14;

    uint playerExistenceCheck:  "UnityPlayer.dll", 0x1690cd0, 0x8, 0x10, 0x30, 0x678, 0x58, 0x188;
    bool currentSubIsBase:      "UnityPlayer.dll", 0x1690cd0, 0x8, 0x10, 0x30, 0x678, 0x58, 0x188, 0x1e0, 0x244;

    string128 activeToolName:   "UnityPlayer.dll", 0x1690cd0, 0x8, 0x10, 0x30, 0x1a8, 0x28, 0x30, 0x60, 0x14;
}

state("Subnautica", "Experimental")
{
    // modules.First() length 675840
    // for Experimental on 13 December 2021

    // player is "UnityPlayer.dll", 0x017E1C60, 0x8, 0x10, 0x30, 0xD8, 0x28, 0x18
    // inventory is "UnityPlayer.dll", 0x017E1C60, 0x8, 0x10, 0x30, 0x1a8, 0x28
    // uSkyManager.main is "UnityPlayer.dll", 0x017C1DB0, 0x10, 0x50, 0x28, 0x18, 0x20

    // pointer to the player object. This doesn't exist when at the menu screen.
    uint playerExistenceCheck:  "UnityPlayer.dll", 0x017E1C60, 0x8, 0x10, 0x30, 0xD8, 0x28, 0x18;
    // player._currentEscapePod.introCinematic.cinematicModeActive
    bool introCinematicActive:  "UnityPlayer.dll", 0x017E1C60, 0x8, 0x10, 0x30, 0xD8, 0x28, 0x18, 0x1f0, 0x28, 0x87;
    // player._cinematicModeActive
    bool playerCinematicActive: "UnityPlayer.dll", 0x017E1C60, 0x8, 0x10, 0x30, 0xD8, 0x28, 0x18, 0x248;
    // player.biomeString + 0x14
    string128 biomeString:      "UnityPlayer.dll", 0x017E1C60, 0x8, 0x10, 0x30, 0xD8, 0x28, 0x18, 0x1d8, 0x14;

    // player._currentSub.isBase
    bool currentSubIsBase:      "UnityPlayer.dll", 0x017E1C60, 0x8, 0x10, 0x30, 0xD8, 0x28, 0x18, 0x1e0, 0x244;

    // Inventory.main._quickSlots.activeToolName (string)
    //  eg "seaglide"
    string128 activeToolName:   "UnityPlayer.dll", 0x017E1C60, 0x8, 0x10, 0x30, 0x1a8, 0x28, 0x30, 0x60, 0x14;

    // uSkyManager.main.rocketTrajectoryHelper. I couldn't get a stable pointer path for LaunchRocket.isLaunching.
    uint rocketLaunchHelper: "UnityPlayer.dll", 0x017C1DB0, 0x10, 0x50, 0x28, 0x18, 0x20, 0x88;
}

init
{
    int firstModuleSize = modules.First().ModuleMemorySize;
    switch (firstModuleSize)
    {
        case 23801856:
            version = "September 2018";
            break;
        case 671744:
            version = "December 2021";
            break;
        case 675840:
            version = "Experimental";
            break;
    }
    print("Configured for " + version + " version (module size " + firstModuleSize.ToString() + ")");

    // return true if this is the first time we've seen the split with the given name,
    // and if it's enabled in settings.
    // (Defined in init so we get the right binding for 'settings')
    vars.SplitOnce = (Func<string, string, bool>)((name, debugText) => {
        if (!vars.seenSplits.Contains(name))
        {
            bool enabled = settings[name];
            print("SPLIT: " + debugText + (enabled ? " (enabled)" : " (disabled)"));
            vars.seenSplits.Add(name);
            if (enabled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    });
}

startup
{
    //settings.Add(id (string), default_value (bool), description (string), parent (string))
    settings.Add("start", true, "Start the timer when the intro cutscene ends");
    settings.Add("firstBase", false, "Split on the first time entering a base");
    settings.Add("seaglide", false, "Split on first use of the Seaglide");
    settings.Add("mountainsBase", false, "Split on entering a base in the biome around the enforcement platform");
    settings.Add("lostRiver", false, "Split on entering the lost river");
    settings.Add("thermalRoom", false, "Split on entering the thermal power room");
    settings.Add("precursorCache", false, "Split on unlocking the precursor cache in the sparse reef");
    settings.Add("gunDeactivate", false, "Split when the gun is deactivated");
    settings.Add("end", true, "Split when the rocket launches");

    vars.seenSplits = new HashSet<string>();

    vars.ResetStateOnStart = (EventHandler)((s, e) => {
        print("Starting new run");
        vars.seenSplits = new HashSet<string>();
    });
    timer.OnStart += vars.ResetStateOnStart;
}

shutdown
{
    timer.OnStart -= vars.ResetStateOnStart;
}

split
{
    // splits based on when the player cinematics are shown
    if (!old.playerCinematicActive && current.playerCinematicActive)
    {
        print("Player cinematic started in " + current.biomeString);

        if (current.biomeString == "Precursor_Gun_ControlRoom")
        {
            print("SPLIT: gun split");
            if (settings["gunDeactivate"])
            {
                return true;
            }
        }
        else if (current.biomeString == "PrecursorCache")
        {
            if (vars.SplitOnce("precursorCache", "unlocked precursor cache"))
            {
                return true;
            }
        }
    }
    else if (old.playerCinematicActive && !current.playerCinematicActive)
    {
        print("Player cinematic ended in " + current.biomeString);
    }

    // splits based on entering a particular biome
    // if the old.biomeString is null, that means we're loading a game not moving around the map
    if (current.biomeString != old.biomeString && current.biomeString != null && old.biomeString != null)
    {
        print("Entered biome " + current.biomeString);
        // the different entry points to the lost river have different biome names,
        // but they all start with the string LostRiver.
        if (current.biomeString.StartsWith("LostRiver"))
        {
            if (vars.SplitOnce("lostRiver", "entered lost river at " + current.biomeString))
            {
                return true;
            }
        }
        else if (current.biomeString == "PrecursorThermalRoom")
        {
            // proxy for getting the ion power blueprints
            // better would be to trigger on actually getting those
            if (vars.SplitOnce("thermalRoom", "reached thermal power room"))
            {
                return true;
            }
        }
    }

    // splits based on entering a base
    if (current.currentSubIsBase && !old.currentSubIsBase)
    {
        if (vars.SplitOnce("firstBase", "entered first base"))
        {
            return true;
        }
        else if (current.biomeString == "mountains")
        {
            if (vars.SplitOnce("mountainsBase", "base in mountains (enforcement platform?)"))
            {
                return true;
            }
        }
    }

    // splits based on using a particular tool
    if (current.activeToolName != old.activeToolName)
    {
        print("Active tool changed: " + current.activeToolName);

        if (current.activeToolName == "seaglide")
        {
            if (vars.SplitOnce("seaglide", "activated seaglide"))
            {
                return true;
            }
        }
    }

    // split for the rocket launch starting
    if (version == "Experimental")
    {
        if (old.rocketLaunchHelper == 0 && current.rocketLaunchHelper != 0)
        {
            print("SPLIT: rocket launching");
            if (settings["end"])
            {
                return true;
            }
        }
    }
    else
    {
        if (!old.rocketLaunching && current.rocketLaunching)
        {
            print("SPLIT: rocket launching");
            if (settings["end"])
            {
                return true;
            }
        }
    }
}

start
{
    if (old.introCinematicActive && !current.introCinematicActive)
    {
        print("START: intro cinematic completed");
        if (current.playerExistenceCheck == 0)
        {
            // don't even start the timer in this case -- some of the later
            // splits won't work. Need to sort out the pointer path??
            print("ERROR: player existence check failed at start. Bad pointer path?");
        }
        else
        {
            if (settings["start"])
            {
                return true;
            }
        }
    }
}