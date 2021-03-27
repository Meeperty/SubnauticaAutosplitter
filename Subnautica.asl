state("Subnautica")
{
	float infectedAmount: "mono.dll", 0x2655E0, 0x250, 0xA60, 0xF8, 0x8, 0x18, 0x8, 0x140, 0x38;
	bool rocketLaunching: "mono.dll", 0x262110, 0x240, 0x0, 0x20, 0x30, 0x30, 0x8, 0x80;
	string255 biomeString: "mono.dll", 0x2655E0, 0x250, 0xA60, 0xF8, 0x8, 0x18, 0x8, 0x1D0, 0x14;
}

startup
{
	//survival settings parent
	settings.Add("survivalSplits", true, "Survival");
	//survival splits
	settings.Add("sparseEndSplit", true, "Split on Sparse Reef deathwarp", "survivalSplits");
	settings.Add("mountainClipSplit", true, "Split on the mushroom forest clip after mountain setup", "survivalSplits");
	settings.Add("cureSplit", false,"Split on end of the cure anim","survivalSplits");

	//creative settings parent
	settings.Add("creativeSplits", false, "Creative");
	//creative settings

	//general settings
	settings.Add("endSplit", true, "Split on rocket launch");
}

update
{
	//print(String.Format("biome is: {0}", current.biome));

	//print(current.biomeString);

	print(current.infectedAmount.ToString());
}

split
{
	//split on rocket launch
	if(current.rocketLaunching != old.rocketLaunching && settings["endSplit"]) {return true;}

	//split on sparse deathwarp
	if(old.biomeString == "seaTreaderPath" && current.biomeString == "safeShallows" && settings["sparseEndSplit"]) {return true;}

	//split on mushroom clip


	//split on cure
	if(old.infectedAmount > 0f && current.infectedAmount == 0f && settings["cureSplit"]) {return true;}
}