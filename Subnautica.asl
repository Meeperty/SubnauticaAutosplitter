state("Subnautica") 
{
	bool rocketLaunching: "mono.dll", 0x0027EAD8, 0x40, 0x70, 0x50, 0x90, 0x30, 0x8, 0x80; 
}

update
{
	print("rocketLaunching is " + current.rocketLaunching);
}

split
{
	if(!old.rocketLaunching && current.rocketLaunching) { return true; }
}