state("Subnautica")
{
    bool rocketLaunching: "UnityPlayer.dll", 01678148, 40, 5f0, 424, 8, d8, 40, 80;
}

split
{
    if (!old.rocketLaunching && current.rocketLaunching) { return true; }
}