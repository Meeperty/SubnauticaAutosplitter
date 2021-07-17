state("Subnautica")
{
    bool rocketLaunching: "UnityPlayer.dll", 0x01678148, 0x40, 0x5f0, 0x424, 0x8, 0xd8, 0x40, 0x80;
    bool introCinematicActive: "UnityPlayer.dll", 0x1690a98, 0x78, 0x2a8, 0x28, 0x248, 0x1f0, 0x28, 0x86;
}

update
{
    print("introCinematicActive is " + current.introCinematicActive);
}

split
{
    if (!old.rocketLaunching && current.rocketLaunching) { return true; }
}

start
{
    if (old.introCinematicActive && !current.introCinematicActive) { return true; }
}