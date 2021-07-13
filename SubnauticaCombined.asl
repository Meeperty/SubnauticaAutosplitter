state("Subnautica")
{
    bool rocketLaunchingCP: "UnityPlayer.dll", 0x1678148, 0x40, 0x5f0, 0x424, 0x8, 0xd8, 0x40, 0x80;
    bool rocketLaunching: "mono.dll", 0x27EAD8, 0x40, 0x70, 0x50, 0x90, 0x30, 0x8, 0x80;
}

startup
{
    //settings.Add(id (string), default_value (bool), description (string), parent (string))
    settings.Add("April '21 Patch", false, "I'm playing on April 2021 patch");
    settings.Add("Sept '18 Patch", true, "I'm playing on September 2018 patch");
}

split
{
    if (!old.rocketLaunchingCP && current.rocketLaunchingCP && settings["April '21 Patch"]) { return true; }
    if (!old.rocketLaunching && current.rocketLaunching && settings["Sept '18 Patch"]) { return true; }
}