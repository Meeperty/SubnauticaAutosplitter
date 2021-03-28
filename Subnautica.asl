state("Subnautica")
{
	float infectedAmount: "mono.dll", 0x2655E0, 0x250, 0xA60, 0xF8, 0x8, 0x18, 0x8, 0x140, 0x38;
	bool rocketLaunching: "mono.dll", 0x262110, 0x240, 0x0, 0x20, 0x30, 0x30, 0x8, 0x80;
	string255 biomeString: "mono.dll", 0x2655E0, 0x250, 0xA60, 0xF8, 0x8, 0x18, 0x8, 0x1D0, 0x14;
	float depth: "mono.dll", 0x297548, 0x20, 0xa60, 0x8, 0x218, 0x18, 0x22c;
}

startup
{
	//survival settings parent
	settings.Add("survivalSplits", true, "Survival");
	//survival splits
	settings.Add("sparseEndSplit", true, "Split on Sparse Reef deathwarp", "survivalSplits");
	settings.Add("mountainClipSplit", true, "Split on the mushroom forest clip after mountain setup", "survivalSplits");
	settings.Add("auroraSplit", false, "Split on dying in the aurora to get back", "survivalSplits");

	//creative settings parent
	settings.Add("creativeSplits", false, "Creative");
	//creative settings
	settings.Add("fallSplit", false, "Split on beginning the fall", "creativeSplits");

	//general settings
	settings.Add("endSplit", true, "Split on rocket launch");
	settings.Add("cureSplit", true, "Split on end of the cure anim");

	vars.hasMountainClipped = false;
	vars.hasCured = false;
	vars.hasSparseDeathwarped = false;
	vars.hasEnded = false;
	vars.hasAuroraDeathwarped = false;
	vars.hasFallen = false;
}

update
{
	//print(String.Format("biome is: {0}", current.biome));

	//print(current.biomeString);

	//print(current.infectedAmount.ToString());

	//print(current.depth.ToString());
}

split
{
	//split on rocket launch
	if(current.rocketLaunching != old.rocketLaunching && settings["endSplit"] && !vars.hasEnded) {vars.hasEnded = true; return true;}

	//split on sparse deathwarp
	if(old.biomeString == "seaTreaderPath" && current.biomeString == "safeShallows" && settings["sparseEndSplit"] && !vars.hasSparseDeathwarped) {vars.hasSparseDeathwarped = true; return true;}

	//split on mushroom clip
	if (current.depth < -210f && current.biomeString == "mushroomForest" && settings["mountainClipSplit"] && !vars.hasMountainClipped) {vars.hasMountainClipped = true; return true;}

	//split on cure
	if(old.infectedAmount > 0f && current.infectedAmount == 0f && settings["cureSplit"] && !vars.hasCured) {vars.hasCured = true; return true;}

	//split on leaving aurora
	if (old.biomeString == "crashedShip" && current.biomeString == "safeShallows" && settings["auroraSplit"] && !vars.hasAuroraDeathwarped) {vars.hasAuroraDeathwarped = true; return true;}

	//split on beginning the fall (creative)
	if (current.biomeString == "safeShallows" && current.depth < -60f && settings["fallSplit"] &&vars.hasFallen == false) {vars.hasFallen = true; return true;}


}