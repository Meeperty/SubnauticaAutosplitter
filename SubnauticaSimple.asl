state("Subnautica")
{
	bool rocketLaunching: "mono.dll", 0x262110, 0x240, 0x0, 0x20, 0x30, 0x30, 0x8, 0x80;
}

startup
{
	//general settings
	settings.Add("endSplit", true, "Split on rocket launch");
}

split
{
	//split on rocket launch
	if(current.rocketLaunching != old.rocketLaunching && settings["endSplit"] && !vars.hasEnded) {vars.hasEnded = true; return true;}
}