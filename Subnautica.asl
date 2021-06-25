state("Subnautica") 
{
	bool rocketLaunching: "Subnautica.exe", 0x014BBD60, 0x3F8, 0x910, 0x10, 0x148, 0x190, 0x38, 0x1B4; 
}

split
{
	if(!old.rocketLaunching && current.rocketLaunching) { return true; }
}