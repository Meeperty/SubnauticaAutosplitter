state("Subnautica")
{
	bool rocketLaunching: "mono.dll", 0x0027EAD8, 0x40, 0x70, 0x50, 0x90, 0x30, 0x8, 0x80; 
	bool introCinematicActive: "Subnautica.exe", 0x142b908, 0x188, 0x150, 0xd0, 0x18, 0x1e8, 0x28, 0x86;
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