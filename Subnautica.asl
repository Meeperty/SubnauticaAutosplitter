state("Subnautica")
{
	bool rocketLaunching: "mono.dll", 0x262110, 0x240, 0x0, 0x20, 0x30, 0x30, 0x8, 0x80;
}

update
{
	print(String.Format("Rocket launching is: {0}", 
	current.rocketLaunching));
}

split
{
	return current.rocketLaunching != old.rocketLaunching;
}