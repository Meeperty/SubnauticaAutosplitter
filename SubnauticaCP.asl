state("Subnautica")
{
    bool rocketLaunching: "UnityPlayer.dll", 0x01678148, 0x40, 0x5f0, 0x424, 0x8, 0xd8, 0x40, 0x80;
}

split
{
    if (!old.rocketLaunching && current.rocketLaunching) { return true; }
}