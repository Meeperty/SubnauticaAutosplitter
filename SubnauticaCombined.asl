state("Subnautica")
{
    bool rocketLaunchingCP: "UnityPlayer.dll", 0x1678148, 0x40, 0x5f0, 0x424, 0x8, 0xd8, 0x40, 0x80;
    bool rocketLaunching: "mono.dll", 0x27EAD8, 0x40, 0x70, 0x50, 0x90, 0x30, 0x8, 0x80;
    bool introCinematicActiveCP: "UnityPlayer.dll", 0x16d0400, 0x68, 0x140, 0xa8, 0x18, 0x60, 0x28, 0x86;
    bool introCinematicActive: "Subnautica.exe", 0x142b908, 0x188, 0x150, 0xd0, 0x18, 0x1e8, 0x28, 0x86;
}

startup
{
    //settings.Add(id (string), default_value (bool), description (string), parent (string))
    settings.Add("april 21", false, "I'm playing on current patch");
    settings.Add("start 21", true, "Split on start", "april 21");
    settings.Add("end 21", true, "Split on rocket launch", "april 21");

    settings.Add("sept 18", true, "I'm playing on September 2018 patch");
    settings.Add("start 18", true, "Split on start", "sept 18");
    settings.Add("end 18", true, "Split on rocket launch", "sept 18");

}

split
{
    if (!old.rocketLaunchingCP && current.rocketLaunchingCP && settings["end 21"]) { return true; }
    if (!old.rocketLaunching && current.rocketLaunching && settings["end 18"]) { return true; }
}

start
{
    if (old.introCinematicActiveCP && !current.introCinematicActiveCP && settings["start 21"]) { return true; }
    if (old.introCinematicActive && !current.introCinematicActive && settings["end 18"]) { return true; }
}