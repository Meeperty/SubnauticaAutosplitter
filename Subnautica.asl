state("Subnautica") 
{
	bool rocketLaunching: "Subnautica.exe", 0x014BBD60, 0x2D8, 0x328, 0x920, 0x54, 0x148, 0x0, 0x80; 
}

update
{
	print("rocketLaunching is" + current.rocketLaunching);
}

split
{
	if(!old.rocketLaunching && current.rocketLaunching) { return true; }
}