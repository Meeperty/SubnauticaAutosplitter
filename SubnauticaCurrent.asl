state("Subnautica", "61056") {
    float infectedAmount: "mono.dll", 0x2655E0, 0x250, 0xA60, 0xF8, 0x8, 0x18, 0x8, 0x140, 0x38;
    string255 biomeString: "mono.dll", 0x2655E0, 0x250, 0xA60, 0xF8, 0x8, 0x18, 0x8, 0x1D0, 0x14;
    bool rocketLaunching: "mono.dll", 0x262110, 0x240, 0x0, 0x20, 0x30, 0x30, 0x8, 0x80;
    uint introCoroutine: "mono.dll", 0x2655E0, 0xa0, 0x768, 0x40, 0x30, 0x48;

}

startup { 
    //------------------------------------------------------------------------------------------//
    // Survival
    settings.Add("survivalSplits", true, "Survival");
    settings.Add("sparseEnd", true, "Split on Sparse Reef deathwarp", "survivalSplits");
    
    // Creative
    settings.Add("creativeSplits", false, "Creative");

    // Self-sufficient
    settings.Add("end", true, "Split on rocket launch");
    settings.Add("cure", true, "Split after touching the enzyme");
    //------------------------------------------------------------------------------------------//

    vars.splitNames = new Dictionary<string, string>();

    //------------------------------------------------------------------------------------------//
    // Split names
    vars.splitNames.Add("Sparse End", "sparseEnd");
    vars.splitNames.Add("Cured", "cure");
    vars.splitNames.Add("Finish", "end");
    //------------------------------------------------------------------------------------------//
}

init {
    switch(modules.First().ModuleMemorySize) {
        case 0x16B3000:
            version = "61056";
            break;
    }
}

update { 
}

start {
    return old.introCoroutine > 0 && current.introCoroutine == 0;
}

split {
    if(timer.CurrentSplit != null) {
        foreach(KeyValuePair<string, string> splitName in vars.splitNames) {
            if(timer.CurrentSplit.Name == splitName.Key && settings[splitName.Value]) {
                switch(splitName.Value) {
                    case "cure":
                        return current.infectedAmount == 0;
                    case "end":
                        return current.rocketLaunching != old.rocketLaunching;
                    case "sparseEnd":
                        return old.biomeString == "seaTreaderPath" && current.biomeString == "safeShallows";
                }
            }            
        }
    }
}