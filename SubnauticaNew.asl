state("Subnautica") 
{
	float rocketTimePassed: "Subnautica.exe", 0x014BBD60, 0x3F8, 0x910, 0x10, 0x148, 0xB0, 0x38, 0x1B4; 
}

update
{
	print(current.rocketTimePassed.ToString());
}

split
{
	if(old.rocketTimePassed == 0f && current.rocketTimePassed > 0f) { return true; }
}