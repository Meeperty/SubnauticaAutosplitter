state("Subnautica")
{
	bool rocketLaunching: "mono.dll", 0x0027EAD8, 0x40, 0x70, 0x50, 0x90, 0x30, 0x8, 0x80; 
	bool escapePodIntroCinematicModeActive: "mono.dll", 0x262110, 0x210, 0xc0, 0x28, 0xf0, 0x28, 0x86;
}

update
{
	print("cutscene bool is " + current.escapePodIntroCinematicModeActive);
}

start
{
	if(old.escapePodIntroCinematicModeActive && !current.escapePodIntroCinematicModeActive) { return true; }
} 

split
{
	if (!old.rocketLaunching && current.rocketLaunching) { return true; }
}