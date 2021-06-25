state("Subnautica") 
{
	float rocketTimePassed: "Subnautica.exe", 0x014BBD60, 0x3F8, 0x910, 0x10, 0x148, 0x190, 0x38, 0x1B4; 
	float rocketTimePassed2: "Subnautica.exe", 0x014BBD60, 0x3F8, 0x910, 0x10, 0x148, 0xB0, 0x38, 0x1B4;
	float rocketTimePassed3: "Subnautica.exe", 0x014BBD60, 0x3F8, 0x910, 0x54, 0x148, 0x190, 0x38, 0x1B4;
	float rocketTimePassed4: "Subnautica.exe", 0x014BBD60, 0x3F8, 0x910, 0x54, 0x148, 0xB0, 0x38, 0x1B4;
}

update
{
	print(String.Format("#1 is {0}" + 
	" #2 is {1}" + 
	" #3 is {2}" +
	" #4 is {3}", 
	current.rocketTimePassed, current.rocketTimePassed2, current.rocketTimePassed3, current.rocketTimePassed4));
}

split
{
	if(old.rocketTimePassed2 == 0f && current.rocketTimePassed2 > 0f) { return true; }
}