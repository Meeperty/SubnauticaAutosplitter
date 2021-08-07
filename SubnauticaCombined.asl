state("Subnautica", "September 2018")
{
    //player is "Subnautica.exe", 0x142b908, 0x180, 0x128, 0x80, 0x1d0, 0x8, 0x248, ...
    //modules.First() length 23801856
    bool rocketLaunching: "mono.dll", 0x27EAD8, 0x40, 0x70, 0x50, 0x90, 0x30, 0x8, 0x80;
    bool introCinematicActive: "Subnautica.exe", 0x142b908, 0x188, 0x150, 0xd0, 0x18, 0x1e8, 0x28, 0x86;
    bool playerCinematicActive: "Subnautica.exe", 0x142b908, 0x180, 0x128, 0x80, 0x1d0, 0x8, 0x248, 0x240;
}

state("Subnautica", "April 2021")
{
    //modules.First() length 671744
    bool rocketLaunching: "UnityPlayer.dll", 0x1678148, 0x40, 0x5f0, 0x424, 0x8, 0xd8, 0x40, 0x80;
    bool introCinematicActive: "UnityPlayer.dll", 0x16d0400, 0x68, 0x140, 0xa8, 0x18, 0x60, 0x28, 0x86;
}

init
{
    int firstModuleSize = modules.First().ModuleMemorySize;
    print(firstModuleSize.ToString());
    switch (firstModuleSize)
    {
        case 23801856:
            version = "September 2018";
            break;
        case 671744:
            version = "April 2021";
            break;
    }
}

startup
{
    //settings.Add(id (string), default_value (bool), description (string), parent (string))
    settings.Add("start", true, "Split on start");
    settings.Add("end", true, "Split on rocket launch");

}

split
{
    if (!old.rocketLaunching && current.rocketLaunching && settings["end"]) { return true; }
}

start
{
    
    if (old.introCinematicActive && !current.introCinematicActive && settings["start"]) { return true; }
}

update
{
    //print(modules.First().ModuleMemorySize.ToString());
    //print(modules.First().ToString());
}