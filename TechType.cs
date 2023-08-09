﻿namespace SubnauticaAutosplitter
{
    public enum TechType
    {
        None = 0,
        Quartz = 1,
        ScrapMetal = 2,
        FiberMesh = 3,
        LimestoneChunk = 4,
        CalciteOld = 5,
        DolomiteOld = 6,
        Copper = 7,
        Lead = 8,
        Salt = 9,
        FlintOld = 10, // 0x0000000A
        EmeryOld = 11, // 0x0000000B
        MercuryOre = 12, // 0x0000000C
        CalciumChunk = 13, // 0x0000000D
        Placeholder = 14, // 0x0000000E
        Glass = 15, // 0x0000000F
        Titanium = 16, // 0x00000010
        Silicone = 17, // 0x00000011
        CarbonOld = 18, // 0x00000012
        EthanolOld = 19, // 0x00000013
        EthyleneOld = 20, // 0x00000014
        Gold = 21, // 0x00000015
        Magnesium = 22, // 0x00000016
        Sulphur = 23, // 0x00000017
        HydrogenOld = 24, // 0x00000018
        Lodestone = 25, // 0x00000019
        SandLoot = 26, // 0x0000001A
        Bleach = 27, // 0x0000001B
        Silver = 28, // 0x0000001C
        BatteryAcidOld = 29, // 0x0000001D
        TitaniumIngot = 30, // 0x0000001E
        SandstoneChunk = 31, // 0x0000001F
        CopperWire = 32, // 0x00000020
        WiringKit = 33, // 0x00000021
        AdvancedWiringKit = 34, // 0x00000022
        CrashPowder = 35, // 0x00000023
        Diamond = 36, // 0x00000024
        BasaltChunk = 37, // 0x00000025
        ShaleChunk = 38, // 0x00000026
        ObsidianChunk = 39, // 0x00000027
        Lithium = 40, // 0x00000028
        PlasteelIngot = 41, // 0x00000029
        EnameledGlass = 42, // 0x0000002A
        PowerCell = 43, // 0x0000002B
        ComputerChip = 44, // 0x0000002C
        Fiber = 45, // 0x0000002D
        Enamel = 46, // 0x0000002E
        AcidOld = 47, // 0x0000002F
        VesselOld = 48, // 0x00000030
        CombustibleOld = 49, // 0x00000031
        OpalGem = 50, // 0x00000032
        Uranium = 51, // 0x00000033
        AluminumOxide = 52, // 0x00000034
        HydrochloricAcid = 53, // 0x00000035
        Magnetite = 54, // 0x00000036
        AminoAcids = 55, // 0x00000037
        Polyaniline = 56, // 0x00000038
        AramidFibers = 57, // 0x00000039
        Graphene = 58, // 0x0000003A
        Aerogel = 59, // 0x0000003B
        Nanowires = 60, // 0x0000003C
        Benzene = 61, // 0x0000003D
        Lubricant = 62, // 0x0000003E
        UraniniteCrystal = 63, // 0x0000003F
        ReactorRod = 64, // 0x00000040
        DepletedReactorRod = 65, // 0x00000041
        PrecursorIonCrystal = 66, // 0x00000042
        PrecursorIonCrystalMatrix = 67, // 0x00000043
        Kyanite = 68, // 0x00000044
        Nickel = 69, // 0x00000045
        DrillableSalt = 70, // 0x00000046
        DrillableQuartz = 71, // 0x00000047
        DrillableCopper = 72, // 0x00000048
        DrillableTitanium = 73, // 0x00000049
        DrillableLead = 74, // 0x0000004A
        DrillableSilver = 75, // 0x0000004B
        DrillableDiamond = 76, // 0x0000004C
        DrillableGold = 77, // 0x0000004D
        DrillableMagnetite = 78, // 0x0000004E
        DrillableLithium = 79, // 0x0000004F
        DrillableMercury = 80, // 0x00000050
        DrillableUranium = 81, // 0x00000051
        DrillableAluminiumOxide = 82, // 0x00000052
        DrillableNickel = 83, // 0x00000053
        DrillableSulphur = 84, // 0x00000054
        DrillableKyanite = 85, // 0x00000055
        DiveSuit = 500, // 0x000001F4
        ShipComputerOld = 501, // 0x000001F5
        Fins = 502, // 0x000001F6
        Tank = 503, // 0x000001F7
        Battery = 504, // 0x000001F8
        Knife = 505, // 0x000001F9
        Drill = 506, // 0x000001FA
        Flashlight = 507, // 0x000001FB
        Beacon = 508, // 0x000001FC
        Builder = 509, // 0x000001FD
        PDA = 510, // 0x000001FE
        EscapePod = 511, // 0x000001FF
        Compass = 512, // 0x00000200
        AirBladder = 513, // 0x00000201
        Terraformer = 514, // 0x00000202
        Pipe = 515, // 0x00000203
        Thermometer = 516, // 0x00000204
        DiveReel = 517, // 0x00000205
        Rebreather = 518, // 0x00000206
        RadiationSuit = 519, // 0x00000207
        RadiationHelmet = 520, // 0x00000208
        RadiationGloves = 521, // 0x00000209
        ReinforcedDiveSuit = 522, // 0x0000020A
        Scanner = 523, // 0x0000020B
        FireExtinguisher = 524, // 0x0000020C
        MapRoomHUDChip = 525, // 0x0000020D
        PipeSurfaceFloater = 526, // 0x0000020E
        CyclopsDecoy = 527, // 0x0000020F
        DoubleTank = 528, // 0x00000210
        ReinforcedGloves = 529, // 0x00000211
        Welder = 750, // 0x000002EE
        Seaglide = 751, // 0x000002EF
        Constructor = 752, // 0x000002F0
        Transfuser = 753, // 0x000002F1
        Flare = 754, // 0x000002F2
        StasisRifle = 755, // 0x000002F3
        BuildBot = 756, // 0x000002F4
        PropulsionCannon = 757, // 0x000002F5
        Gravsphere = 758, // 0x000002F6
        SmallStorage = 759, // 0x000002F7
        StasisSphere = 760, // 0x000002F8
        LaserCutter = 761, // 0x000002F9
        LEDLight = 762, // 0x000002FA
        DiamondBlade = 800, // 0x00000320
        HeatBlade = 801, // 0x00000321
        LithiumIonBattery = 802, // 0x00000322
        PlasteelTank = 803, // 0x00000323
        HighCapacityTank = 804, // 0x00000324
        UltraGlideFins = 805, // 0x00000325
        SwimChargeFins = 806, // 0x00000326
        RepulsionCannon = 807, // 0x00000327
        WaterFiltrationSuit = 808, // 0x00000328
        PowerGlide = 809, // 0x00000329
        CompostCreepvine = 900, // 0x00000384
        ProcessUranium = 901, // 0x00000385
        PrecursorIonEnergyBlueprint = 950, // 0x000003B6
        FabricatorBlueprintOld = 1000, // 0x000003E8
        ConstructorBlueprint = 1001, // 0x000003E9
        CyclopsBlueprint = 1002, // 0x000003EA
        FragmentAnalyzerBlueprintOld = 1003, // 0x000003EB
        LockerBlueprint = 1004, // 0x000003EC
        SpecialHullPlateBlueprintOld = 1005, // 0x000003ED
        BikemanHullPlateBlueprintOld = 1006, // 0x000003EE
        EatMyDictionHullPlateBlueprintOld = 1007, // 0x000003EF
        DevTestItemBlueprintOld = 1008, // 0x000003F0
        SeamothBlueprint = 1009, // 0x000003F1
        StasisRifleBlueprint = 1010, // 0x000003F2
        ExosuitBlueprint = 1011, // 0x000003F3
        TransfuserBlueprint = 1012, // 0x000003F4
        TerraformerBlueprint = 1013, // 0x000003F5
        ReinforceHullBlueprint = 1014, // 0x000003F6
        WorkbenchBlueprint = 1015, // 0x000003F7
        PropulsionCannonBlueprint = 1016, // 0x000003F8
        SpecimenAnalyzerBlueprint = 1017, // 0x000003F9
        BioreactorBlueprint = 1018, // 0x000003FA
        ThermalPlantBlueprint = 1019, // 0x000003FB
        NuclearReactorBlueprint = 1020, // 0x000003FC
        MoonpoolBlueprint = 1021, // 0x000003FD
        FiltrationMachineBlueprint = 1022, // 0x000003FE
        TechlightBlueprint = 1023, // 0x000003FF
        LEDLightBlueprint = 1024, // 0x00000400
        CyclopsHullBlueprint = 1025, // 0x00000401
        CyclopsBridgeBlueprint = 1026, // 0x00000402
        CyclopsEngineBlueprint = 1027, // 0x00000403
        CyclopsDockingBayBlueprint = 1028, // 0x00000404
        SpotlightBlueprint = 1029, // 0x00000405
        RadioBlueprint = 1030, // 0x00000406
        StarshipCargoCrateBlueprint = 1031, // 0x00000407
        StarshipCircuitBoxBlueprint = 1032, // 0x00000408
        StarshipDeskBlueprint = 1033, // 0x00000409
        StarshipChairBlueprint = 1034, // 0x0000040A
        StarshipMonitorBlueprint = 1035, // 0x0000040B
        SolarPanelBlueprint = 1036, // 0x0000040C
        PowerTransmitterBlueprint = 1037, // 0x0000040D
        BaseUpgradeConsoleBlueprint = 1038, // 0x0000040E
        BaseObservatoryBlueprint = 1039, // 0x0000040F
        BaseWaterParkBlueprint = 1040, // 0x00000410
        PictureFrameBlueprint = 1041, // 0x00000411
        BaseRoomBlueprint = 1042, // 0x00000412
        BaseBulkheadBlueprint = 1043, // 0x00000413
        SeaglideBlueprint = 1044, // 0x00000414
        BatteryChargerBlueprint = 1045, // 0x00000415
        PowerCellChargerBlueprint = 1046, // 0x00000416
        FarmingTrayBlueprint = 1047, // 0x00000417
        SignBlueprint = 1048, // 0x00000418
        BenchBlueprint = 1049, // 0x00000419
        PlanterPotBlueprint = 1050, // 0x0000041A
        PlanterBoxBlueprint = 1051, // 0x0000041B
        PlanterShelfBlueprint = 1052, // 0x0000041C
        AquariumBlueprint = 1053, // 0x0000041D
        ReinforcedDiveSuitBlueprint = 1054, // 0x0000041E
        RadiationSuitBlueprint = 1055, // 0x0000041F
        WaterFiltrationSuitBlueprint = 1056, // 0x00000420
        ScannerRoomBlueprint = 1057, // 0x00000421
        BasePlanterBlueprint = 1058, // 0x00000422
        PlanterPot2Blueprint = 1059, // 0x00000423
        PlanterPot3Blueprint = 1060, // 0x00000424
        MedicalCabinetBlueprint = 1061, // 0x00000425
        BaseMapRoomBlueprint = 1062, // 0x00000426
        SeamothFragment = 1100, // 0x0000044C
        StasisRifleFragment = 1101, // 0x0000044D
        ExosuitFragment = 1102, // 0x0000044E
        TransfuserFragment = 1103, // 0x0000044F
        TerraformerFragment = 1104, // 0x00000450
        ReinforceHullFragment = 1105, // 0x00000451
        WorkbenchFragment = 1106, // 0x00000452
        PropulsionCannonFragment = 1107, // 0x00000453
        BioreactorFragment = 1108, // 0x00000454
        ThermalPlantFragment = 1109, // 0x00000455
        NuclearReactorFragment = 1110, // 0x00000456
        MoonpoolFragment = 1111, // 0x00000457
        BaseFiltrationMachineFragment = 1112, // 0x00000458
        CyclopsHullFragment = 1113, // 0x00000459
        CyclopsBridgeFragment = 1114, // 0x0000045A
        CyclopsEngineFragment = 1115, // 0x0000045B
        CyclopsDockingBayFragment = 1116, // 0x0000045C
        SeaglideFragment = 1117, // 0x0000045D
        ConstructorFragment = 1118, // 0x0000045E
        SolarPanelFragment = 1119, // 0x0000045F
        PowerTransmitterFragment = 1120, // 0x00000460
        BaseUpgradeConsoleFragment = 1121, // 0x00000461
        BaseObservatoryFragment = 1122, // 0x00000462
        BaseWaterParkFragment = 1123, // 0x00000463
        RadioFragment = 1124, // 0x00000464
        BaseRoomFragment = 1125, // 0x00000465
        BaseBulkheadFragment = 1126, // 0x00000466
        BatteryChargerFragment = 1127, // 0x00000467
        PowerCellChargerFragment = 1128, // 0x00000468
        ScannerRoomFragment = 1129, // 0x00000469
        SpecimenAnalyzerFragment = 1130, // 0x0000046A
        FarmingTrayFragment = 1131, // 0x0000046B
        SignFragment = 1132, // 0x0000046C
        PictureFrameFragment = 1133, // 0x0000046D
        BenchFragment = 1134, // 0x0000046E
        PlanterPotFragment = 1135, // 0x0000046F
        PlanterBoxFragment = 1136, // 0x00000470
        PlanterShelfFragment = 1137, // 0x00000471
        AquariumFragment = 1138, // 0x00000472
        ReinforcedDiveSuitFragment = 1139, // 0x00000473
        RadiationSuitFragment = 1140, // 0x00000474
        WaterFiltrationSuitFragment = 1141, // 0x00000475
        BuilderFragment = 1142, // 0x00000476
        LEDLightFragment = 1143, // 0x00000477
        TechlightFragment = 1144, // 0x00000478
        SpotlightFragment = 1145, // 0x00000479
        BaseMapRoomFragment = 1146, // 0x0000047A
        BaseBioReactorFragment = 1147, // 0x0000047B
        BaseNuclearReactorFragment = 1148, // 0x0000047C
        LaserCutterFragment = 1149, // 0x0000047D
        BeaconFragment = 1150, // 0x0000047E
        GravSphereFragment = 1151, // 0x0000047F
        BaseLargeRoomFragment = 1162, // 0x0000048A
        BaseLargeGlassDomeFragment = 1163, // 0x0000048B
        BaseGlassDomeFragment = 1164, // 0x0000048C
        SafeShallowsEgg = 1250, // 0x000004E2
        KelpForestEgg = 1251, // 0x000004E3
        GrassyPlateausEgg = 1252, // 0x000004E4
        GrandReefsEgg = 1253, // 0x000004E5
        MushroomForestEgg = 1254, // 0x000004E6
        KooshZoneEgg = 1255, // 0x000004E7
        TwistyBridgesEgg = 1256, // 0x000004E8
        LavaZoneEgg = 1257, // 0x000004E9
        StalkerEgg = 1258, // 0x000004EA
        ReefbackEgg = 1259, // 0x000004EB
        SpadefishEgg = 1260, // 0x000004EC
        RabbitrayEgg = 1261, // 0x000004ED
        MesmerEgg = 1262, // 0x000004EE
        JumperEgg = 1263, // 0x000004EF
        SandsharkEgg = 1264, // 0x000004F0
        JellyrayEgg = 1265, // 0x000004F1
        BonesharkEgg = 1266, // 0x000004F2
        CrabsnakeEgg = 1267, // 0x000004F3
        ShockerEgg = 1268, // 0x000004F4
        GasopodEgg = 1269, // 0x000004F5
        RabbitrayEggUndiscovered = 1270, // 0x000004F6
        JellyrayEggUndiscovered = 1271, // 0x000004F7
        StalkerEggUndiscovered = 1272, // 0x000004F8
        ReefbackEggUndiscovered = 1273, // 0x000004F9
        JumperEggUndiscovered = 1274, // 0x000004FA
        BonesharkEggUndiscovered = 1275, // 0x000004FB
        GasopodEggUndiscovered = 1276, // 0x000004FC
        MesmerEggUndiscovered = 1277, // 0x000004FD
        SandsharkEggUndiscovered = 1278, // 0x000004FE
        ShockerEggUndiscovered = 1279, // 0x000004FF
        GenericEgg = 1280, // 0x00000500
        CrashEgg = 1281, // 0x00000501
        CrashEggUndiscovered = 1282, // 0x00000502
        CrabsquidEgg = 1283, // 0x00000503
        CrabsquidEggUndiscovered = 1284, // 0x00000504
        CutefishEgg = 1285, // 0x00000505
        CutefishEggUndiscovered = 1286, // 0x00000506
        LavaLizardEgg = 1287, // 0x00000507
        LavaLizardEggUndiscovered = 1288, // 0x00000508
        CrabsnakeEggUndiscovered = 1289, // 0x00000509
        SpadefishEggUndiscovered = 1290, // 0x0000050A
        ReefbackShell = 1300, // 0x00000514
        ReefbackTissue = 1301, // 0x00000515
        ReefbackAdvancedStructure = 1302, // 0x00000516
        ReefbackDNA = 1400, // 0x00000578
        Workbench = 1500, // 0x000005DC
        HullReinforcementModule = 1501, // 0x000005DD
        Fabricator = 1502, // 0x000005DE
        Aquarium = 1503, // 0x000005DF
        Locker = 1504, // 0x000005E0
        Spotlight = 1505, // 0x000005E1
        DiveHatch = 1506, // 0x000005E2
        CurrentGenerator = 1507, // 0x000005E3
        FragmentAnalyzer = 1508, // 0x000005E4
        SpecialHullPlate = 1509, // 0x000005E5
        BikemanHullPlate = 1510, // 0x000005E6
        EatMyDictionHullPlate = 1511, // 0x000005E7
        DevTestItem = 1512, // 0x000005E8
        SpecimenAnalyzer = 1513, // 0x000005E9
        HullReinforcementModule2 = 1514, // 0x000005EA
        HullReinforcementModule3 = 1515, // 0x000005EB
        PowerUpgradeModule = 1516, // 0x000005EC
        SolarPanel = 1517, // 0x000005ED
        Sign = 1518, // 0x000005EE
        PowerTransmitter = 1519, // 0x000005EF
        Accumulator = 1520, // 0x000005F0
        Bioreactor = 1521, // 0x000005F1
        ThermalPlant = 1522, // 0x000005F2
        NuclearReactor = 1523, // 0x000005F3
        SmallLocker = 1524, // 0x000005F4
        Bench = 1525, // 0x000005F5
        PictureFrame = 1526, // 0x000005F6
        PlanterPot = 1527, // 0x000005F7
        PlanterBox = 1528, // 0x000005F8
        PlanterShelf = 1529, // 0x000005F9
        FarmingTray = 1530, // 0x000005FA
        FiltrationMachine = 1531, // 0x000005FB
        Techlight = 1532, // 0x000005FC
        Radio = 1533, // 0x000005FD
        PlanterPot2 = 1534, // 0x000005FE
        PlanterPot3 = 1535, // 0x000005FF
        MedicalCabinet = 1536, // 0x00000600
        CyclopsHullModule1 = 1537, // 0x00000601
        CyclopsHullModule2 = 1538, // 0x00000602
        SingleWallShelf = 1539, // 0x00000603
        WallShelves = 1540, // 0x00000604
        Bed1 = 1541, // 0x00000605
        Bed2 = 1542, // 0x00000606
        NarrowBed = 1543, // 0x00000607
        BatteryCharger = 1544, // 0x00000608
        PowerCellCharger = 1545, // 0x00000609
        Incubator = 1546, // 0x0000060A
        HatchingEnzymes = 1547, // 0x0000060B
        EnyzmeCloud = 1548, // 0x0000060C
        EnzymeCureBall = 1549, // 0x0000060D
        Centrifuge = 1550, // 0x0000060E
        CyclopsShieldModule = 1551, // 0x0000060F
        CyclopsSonarModule = 1552, // 0x00000610
        CyclopsSeamothRepairModule = 1553, // 0x00000611
        CyclopsDecoyModule = 1554, // 0x00000612
        CyclopsFireSuppressionModule = 1555, // 0x00000613
        CyclopsFabricator = 1556, // 0x00000614
        CyclopsThermalReactorModule = 1557, // 0x00000615
        CyclopsHullModule3 = 1558, // 0x00000616
        StarshipCargoCrate = 1800, // 0x00000708
        StarshipCircuitBox = 1801, // 0x00000709
        StarshipDesk = 1802, // 0x0000070A
        StarshipChair = 1803, // 0x0000070B
        StarshipMonitor = 1804, // 0x0000070C
        StarshipChair2 = 1805, // 0x0000070D
        StarshipChair3 = 1806, // 0x0000070E
        LuggageBag = 1807, // 0x0000070F
        ArcadeGorgetoy = 1808, // 0x00000710
        LabEquipment1 = 1809, // 0x00000711
        LabEquipment2 = 1810, // 0x00000712
        LabEquipment3 = 1811, // 0x00000713
        CoffeeVendingMachine = 1812, // 0x00000714
        BarTable = 1813, // 0x00000715
        Cap1 = 1814, // 0x00000716
        Cap2 = 1815, // 0x00000717
        LabContainer = 1816, // 0x00000718
        LabContainer2 = 1817, // 0x00000719
        LabContainer3 = 1818, // 0x0000071A
        Trashcans = 1819, // 0x0000071B
        LabTrashcan = 1820, // 0x0000071C
        VendingMachine = 1821, // 0x0000071D
        LabCounter = 1822, // 0x0000071E
        StarshipSouvenir = 1823, // 0x0000071F
        PosterAurora = 1824, // 0x00000720
        PosterExoSuit1 = 1825, // 0x00000721
        PosterExoSuit2 = 1826, // 0x00000722
        PosterKitty = 1827, // 0x00000723
        ToyCar = 1828, // 0x00000724
        Seamoth = 2000, // 0x000007D0
        Exosuit = 2001, // 0x000007D1
        CrashedShip = 2002, // 0x000007D2
        Cyclops = 2003, // 0x000007D3
        Audiolog = 2004, // 0x000007D4
        Signal = 2005, // 0x000007D5
        SeamothReinforcementModule = 2100, // 0x00000834
        VehiclePowerUpgradeModule = 2101, // 0x00000835
        SeamothSolarCharge = 2102, // 0x00000836
        VehicleStorageModule = 2103, // 0x00000837
        SeamothElectricalDefense = 2104, // 0x00000838
        VehicleArmorPlating = 2105, // 0x00000839
        LootSensorMetal = 2106, // 0x0000083A
        LootSensorLithium = 2107, // 0x0000083B
        LootSensorFragment = 2108, // 0x0000083C
        SeamothTorpedoModule = 2109, // 0x0000083D
        SeamothSonarModule = 2110, // 0x0000083E
        WhirlpoolTorpedo = 2111, // 0x0000083F
        VehicleHullModule1 = 2112, // 0x00000840
        VehicleHullModule2 = 2113, // 0x00000841
        VehicleHullModule3 = 2114, // 0x00000842
        ExosuitJetUpgradeModule = 2115, // 0x00000843
        ExosuitDrillArmModule = 2116, // 0x00000844
        ExosuitThermalReactorModule = 2117, // 0x00000845
        ExosuitClawArmModule = 2118, // 0x00000846
        GasTorpedo = 2119, // 0x00000847
        ExosuitPropulsionArmModule = 2120, // 0x00000848
        ExosuitGrapplingArmModule = 2121, // 0x00000849
        ExosuitTorpedoArmModule = 2122, // 0x0000084A
        ExosuitDrillArmFragment = 2123, // 0x0000084B
        ExosuitPropulsionArmFragment = 2124, // 0x0000084C
        ExosuitGrapplingArmFragment = 2125, // 0x0000084D
        ExosuitTorpedoArmFragment = 2126, // 0x0000084E
        ExosuitClawArmFragment = 2127, // 0x0000084F
        ExoHullModule1 = 2128, // 0x00000850
        ExoHullModule2 = 2129, // 0x00000851
        MapRoomUpgradeScanRange = 2250, // 0x000008CA
        MapRoomUpgradeScanSpeed = 2251, // 0x000008CB
        Creepvine = 2500, // 0x000009C4
        HoleFish = 2501, // 0x000009C5
        Jumper = 2502, // 0x000009C6
        CreepvineSeedCluster = 2503, // 0x000009C7
        Peeper = 2504, // 0x000009C8
        Oculus = 2505, // 0x000009C9
        RabbitRay = 2506, // 0x000009CA
        GarryFish = 2507, // 0x000009CB
        Slime = 2508, // 0x000009CC
        Crash = 2509, // 0x000009CD
        Boomerang = 2510, // 0x000009CE
        LavaLarva = 2511, // 0x000009CF
        Stalker = 2512, // 0x000009D0
        Eyeye = 2513, // 0x000009D1
        Bloom = 2514, // 0x000009D2
        Bladderfish = 2515, // 0x000009D3
        Hoverfish = 2516, // 0x000009D4
        Jellyray = 2517, // 0x000009D5
        Reefback = 2518, // 0x000009D6
        Reginald = 2519, // 0x000009D7
        Spadefish = 2520, // 0x000009D8
        Grabcrab = 2521, // 0x000009D9
        Floater = 2522, // 0x000009DA
        Gasopod = 2523, // 0x000009DB
        Sandshark = 2524, // 0x000009DC
        Player = 2525, // 0x000009DD
        Bleeder = 2526, // 0x000009DE
        Rockgrub = 2527, // 0x000009DF
        CrashHome = 2528, // 0x000009E0
        CreepvinePiece = 2529, // 0x000009E1
        GasPod = 2530, // 0x000009E2
        Hoopfish = 2531, // 0x000009E3
        HoopfishSchool = 2532, // 0x000009E4
        RockPuncher = 2533, // 0x000009E5
        BoneShark = 2534, // 0x000009E6
        Mesmer = 2535, // 0x000009E7
        SeaTreader = 2536, // 0x000009E8
        SeaEmperor = 2537, // 0x000009E9
        Cutefish = 2538, // 0x000009EA
        Crabsnake = 2539, // 0x000009EB
        ReaperLeviathan = 2540, // 0x000009EC
        CaveCrawler = 2541, // 0x000009ED
        Skyray = 2542, // 0x000009EE
        Biter = 2543, // 0x000009EF
        SkyrayNonRoosting = 2544, // 0x000009F0
        Shocker = 2545, // 0x000009F1
        Spinefish = 2546, // 0x000009F2
        Shuttlebug = 2547, // 0x000009F3
        Blighter = 2548, // 0x000009F4
        Warper = 2549, // 0x000009F5
        CrabSquid = 2550, // 0x000009F6
        LavaLizard = 2551, // 0x000009F7
        SpineEel = 2552, // 0x000009F8
        SeaDragon = 2553, // 0x000009F9
        LavaBoomerang = 2554, // 0x000009FA
        LavaEyeye = 2555, // 0x000009FB
        SeaEmperorBaby = 2556, // 0x000009FC
        WarperSpawner = 2557, // 0x000009FD
        GhostRayBlue = 2558, // 0x000009FE
        GhostRayRed = 2559, // 0x000009FF
        ReefbackBaby = 2560, // 0x00000A00
        PrecursorDroid = 2561, // 0x00000A01
        GhostLeviathan = 2562, // 0x00000A02
        SeaEmperorLeviathan = 2563, // 0x00000A03
        SeaEmperorJuvenile = 2564, // 0x00000A04
        GhostLeviathanJuvenile = 2565, // 0x00000A05
        HoleFishAnalysis = 2700, // 0x00000A8C
        PeeperAnalysis = 2701, // 0x00000A8D
        BladderfishAnalysis = 2702, // 0x00000A8E
        GarryFishAnalysis = 2703, // 0x00000A8F
        HoverfishAnalysis = 2704, // 0x00000A90
        ReginaldAnalysis = 2705, // 0x00000A91
        SpadefishAnalysis = 2706, // 0x00000A92
        BoomerangAnalysis = 2707, // 0x00000A93
        EyeyeAnalysis = 2708, // 0x00000A94
        OculusAnalysis = 2709, // 0x00000A95
        HoopfishAnalysis = 2710, // 0x00000A96
        AnalysisTreeOld = 2711, // 0x00000A97
        SpinefishAnalysis = 2712, // 0x00000A98
        PlantPlaceholder = 3000, // 0x00000BB8
        BallClusters = 3001, // 0x00000BB9
        BarnacleSuckers = 3002, // 0x00000BBA
        BlueBarnacle = 3003, // 0x00000BBB
        BlueBarnacleCluster = 3004, // 0x00000BBC
        BlueCoralTubes = 3005, // 0x00000BBD
        RedGrass = 3006, // 0x00000BBE
        GreenGrass = 3007, // 0x00000BBF
        Mohawk = 3008, // 0x00000BC0
        GreenReeds = 3009, // 0x00000BC1
        JellyPlant = 3010, // 0x00000BC2
        BlueJeweledDisk = 3011, // 0x00000BC3
        GreenJeweledDisk = 3012, // 0x00000BC4
        PurpleJeweledDisk = 3013, // 0x00000BC5
        RedJeweledDisk = 3014, // 0x00000BC6
        SmallKoosh = 3015, // 0x00000BC7
        MediumKoosh = 3016, // 0x00000BC8
        LargeKoosh = 3017, // 0x00000BC9
        HugeKoosh = 3018, // 0x00000BCA
        MembrainTree = 3019, // 0x00000BCB
        PurpleFan = 3020, // 0x00000BCC
        AcidMushroom = 3021, // 0x00000BCD
        PurpleTentacle = 3022, // 0x00000BCE
        RedSeaweed = 3023, // 0x00000BCF
        CoralOldPlaceholder = 3024, // 0x00000BD0
        CoralShellPlate = 3025, // 0x00000BD1
        SmallFan = 3026, // 0x00000BD2
        SmallFanCluster = 3027, // 0x00000BD3
        BigCoralTubes = 3028, // 0x00000BD4
        TreeMushroom = 3029, // 0x00000BD5
        BlueCluster = 3030, // 0x00000BD6
        BrownTubes = 3031, // 0x00000BD7
        BloodGrass = 3032, // 0x00000BD8
        HeatArea = 3033, // 0x00000BD9
        BloodOil = 3034, // 0x00000BDA
        WhiteMushroom = 3035, // 0x00000BDB
        BloodRoot = 3036, // 0x00000BDC
        BloodVine = 3037, // 0x00000BDD
        PinkFlower = 3038, // 0x00000BDE
        PinkMushroom = 3039, // 0x00000BDF
        PurpleRattle = 3040, // 0x00000BE0
        BulboTree = 3041, // 0x00000BE1
        PurpleVasePlant = 3042, // 0x00000BE2
        OrangeMushroom = 3043, // 0x00000BE3
        FernPalm = 3044, // 0x00000BE4
        HangingFruitTree = 3045, // 0x00000BE5
        PurpleVegetablePlant = 3046, // 0x00000BE6
        MelonPlant = 3047, // 0x00000BE7
        BluePalm = 3048, // 0x00000BE8
        GabeSFeather = 3049, // 0x00000BE9
        SeaCrown = 3050, // 0x00000BEA
        OrangePetalsPlant = 3051, // 0x00000BEB
        EyesPlant = 3052, // 0x00000BEC
        RedGreenTentacle = 3053, // 0x00000BED
        PurpleStalk = 3054, // 0x00000BEE
        RedBasketPlant = 3055, // 0x00000BEF
        RedBush = 3056, // 0x00000BF0
        RedConePlant = 3057, // 0x00000BF1
        ShellGrass = 3058, // 0x00000BF2
        SpottedLeavesPlant = 3059, // 0x00000BF3
        RedRollPlant = 3060, // 0x00000BF4
        PurpleBranches = 3061, // 0x00000BF5
        SnakeMushroom = 3062, // 0x00000BF6
        SeaTreaderPoop = 3063, // 0x00000BF7
        GenericJeweledDisk = 3064, // 0x00000BF8
        FloatingStone = 3065, // 0x00000BF9
        BlueAmoeba = 3066, // 0x00000BFA
        RedTipRockThings = 3067, // 0x00000BFB
        BlueTipLostRiverPlant = 3068, // 0x00000BFC
        BlueLostRiverLilly = 3069, // 0x00000BFD
        LargeFloater = 3070, // 0x00000BFE
        PiecePlaceholder = 3500, // 0x00000DAC
        JeweledDiskPiece = 3501, // 0x00000DAD
        CoralChunk = 3502, // 0x00000DAE
        KooshChunk = 3503, // 0x00000DAF
        StalkerTooth = 3504, // 0x00000DB0
        TreeMushroomPiece = 3505, // 0x00000DB1
        BulboTreePiece = 3506, // 0x00000DB2
        OrangeMushroomSpore = 3507, // 0x00000DB3
        PurpleVasePlantSeed = 3508, // 0x00000DB4
        AcidMushroomSpore = 3509, // 0x00000DB5
        WhiteMushroomSpore = 3510, // 0x00000DB6
        PinkMushroomSpore = 3511, // 0x00000DB7
        PurpleRattleSpore = 3512, // 0x00000DB8
        HangingFruit = 3513, // 0x00000DB9
        PurpleVegetable = 3514, // 0x00000DBA
        SmallMelon = 3515, // 0x00000DBB
        Melon = 3516, // 0x00000DBC
        MelonSeed = 3517, // 0x00000DBD
        PurpleBrainCoralPiece = 3518, // 0x00000DBE
        SpikePlantSeed = 3519, // 0x00000DBF
        BluePalmSeed = 3520, // 0x00000DC0
        PurpleFanSeed = 3521, // 0x00000DC1
        SmallFanSeed = 3522, // 0x00000DC2
        PurpleTentacleSeed = 3523, // 0x00000DC3
        JellyPlantSeed = 3524, // 0x00000DC4
        GabeSFeatherSeed = 3525, // 0x00000DC5
        SeaCrownSeed = 3526, // 0x00000DC6
        MembrainTreeSeed = 3527, // 0x00000DC7
        PinkFlowerSeed = 3528, // 0x00000DC8
        FernPalmSeed = 3529, // 0x00000DC9
        OrangePetalsPlantSeed = 3530, // 0x00000DCA
        EyesPlantSeed = 3531, // 0x00000DCB
        RedGreenTentacleSeed = 3532, // 0x00000DCC
        PurpleStalkSeed = 3533, // 0x00000DCD
        RedBasketPlantSeed = 3534, // 0x00000DCE
        RedBushSeed = 3535, // 0x00000DCF
        RedConePlantSeed = 3536, // 0x00000DD0
        ShellGrassSeed = 3537, // 0x00000DD1
        SpottedLeavesPlantSeed = 3538, // 0x00000DD2
        RedRollPlantSeed = 3539, // 0x00000DD3
        PurpleBranchesSeed = 3540, // 0x00000DD4
        SnakeMushroomSpore = 3541, // 0x00000DD5
        EnvironmentPlaceholder = 4000, // 0x00000FA0
        Boulder = 4001, // 0x00000FA1
        PurpleBrainCoral = 4002, // 0x00000FA2
        HangingStinger = 4003, // 0x00000FA3
        SpikePlant = 4004, // 0x00000FA4
        BrainCoral = 4005, // 0x00000FA5
        CoveTree = 4006, // 0x00000FA6
        MonsterSkeleton = 4007, // 0x00000FA7
        SeaDragonSkeleton = 4008, // 0x00000FA8
        ReaperSkeleton = 4009, // 0x00000FA9
        CaveSkeleton = 4010, // 0x00000FAA
        HugeSkeleton = 4011, // 0x00000FAB
        PrecursorKey_Red = 4200, // 0x00001068
        PrecursorKey_Blue = 4201, // 0x00001069
        PrecursorKey_Orange = 4202, // 0x0000106A
        PrecursorKey_White = 4203, // 0x0000106B
        PrecursorKey_Purple = 4204, // 0x0000106C
        PrecursorKey_PurpleFragment = 4205, // 0x0000106D
        PrecursorKeyTerminal = 4206, // 0x0000106E
        PrecursorTeleporter = 4207, // 0x0000106F
        PrecursorEnergyCore = 4208, // 0x00001070
        PrecursorIonPowerCell = 4209, // 0x00001071
        PrecursorIonBattery = 4210, // 0x00001072
        PrecursorThermalPlant = 4211, // 0x00001073
        PrecursorWarper = 4212, // 0x00001074
        PrecursorFishSkeleton = 4213, // 0x00001075
        PrecursorScanner = 4214, // 0x00001076
        PrecursorLabCacheContainer1 = 4215, // 0x00001077
        PrecursorLabCacheContainer2 = 4216, // 0x00001078
        PrecursorLabTable = 4217, // 0x00001079
        PrecursorSeaDragonSkeleton = 4218, // 0x0000107A
        PrecursorSensor = 4219, // 0x0000107B
        PrecursorPrisonArtifact1 = 4220, // 0x0000107C
        PrecursorPrisonArtifact2 = 4221, // 0x0000107D
        PrecursorPrisonArtifact3 = 4222, // 0x0000107E
        PrecursorPrisonArtifact4 = 4223, // 0x0000107F
        PrecursorPrisonArtifact5 = 4224, // 0x00001080
        PrecursorPrisonArtifact6 = 4225, // 0x00001081
        PrecursorPrisonArtifact7 = 4226, // 0x00001082
        PrecursorPrisonArtifact8 = 4227, // 0x00001083
        PrecursorPrisonArtifact9 = 4228, // 0x00001084
        PrecursorPrisonArtifact10 = 4229, // 0x00001085
        PrecursorPrisonArtifact11 = 4230, // 0x00001086
        PrecursorPrisonArtifact12 = 4231, // 0x00001087
        PrecursorPipeRoomIncomingPipe = 4232, // 0x00001088
        PrecursorPipeRoomOutgoingPipe = 4233, // 0x00001089
        PrecursorPrisonLabEmperorFetus = 4234, // 0x0000108A
        PrecursorPrisonLabEmperorEgg = 4235, // 0x0000108B
        PrecursorPrisonAquariumPipe = 4236, // 0x0000108C
        PrecursorPrisonAquariumFinalTeleporter = 4237, // 0x0000108D
        PrecursorPrisonAquariumIncubatorEggs = 4238, // 0x0000108E
        PrecursorPrisonAquariumIncubator = 4239, // 0x0000108F
        PrecursorSurfacePipe = 4240, // 0x00001090
        PrecursorPrisonArtifact13 = 4241, // 0x00001091
        PrecursorPrisonIonGenerator = 4242, // 0x00001092
        PrecursorPrisonOutposts = 4243, // 0x00001093
        ObservatoryOld = 4250, // 0x0000109A
        PrecursorLostRiverBrokenAnchor = 4300, // 0x000010CC
        PrecursorLostRiverLabRays = 4301, // 0x000010CD
        PrecursorLostRiverLabBones = 4302, // 0x000010CE
        PrecursorLostRiverLabEgg = 4303, // 0x000010CF
        PrecursorLostRiverProductionLine = 4304, // 0x000010D0
        PrecursorLostRiverWarperParts = 4305, // 0x000010D1
        FilteredWater = 4500, // 0x00001194
        DisinfectedWater = 4501, // 0x00001195
        CookedPeeper = 4502, // 0x00001196
        CookedHoleFish = 4503, // 0x00001197
        CookedGarryFish = 4504, // 0x00001198
        CookedReginald = 4505, // 0x00001199
        CookedBladderfish = 4506, // 0x0000119A
        CookedHoverfish = 4507, // 0x0000119B
        CookedSpadefish = 4508, // 0x0000119C
        CookedBoomerang = 4509, // 0x0000119D
        CookedEyeye = 4510, // 0x0000119E
        CookedOculus = 4511, // 0x0000119F
        CookedHoopfish = 4512, // 0x000011A0
        NutrientBlock = 4513, // 0x000011A1
        FirstAidKit = 4514, // 0x000011A2
        WaterFiltrationSuitWater = 4515, // 0x000011A3
        BigFilteredWater = 4516, // 0x000011A4
        CookedSpinefish = 4517, // 0x000011A5
        CookedLavaEyeye = 4518, // 0x000011A6
        CookedLavaBoomerang = 4519, // 0x000011A7
        Snack1 = 4520, // 0x000011A8
        Snack2 = 4521, // 0x000011A9
        Snack3 = 4522, // 0x000011AA
        Coffee = 4523, // 0x000011AB
        CuredPeeper = 4600, // 0x000011F8
        CuredHoleFish = 4601, // 0x000011F9
        CuredGarryFish = 4602, // 0x000011FA
        CuredReginald = 4603, // 0x000011FB
        CuredBladderfish = 4604, // 0x000011FC
        CuredHoverfish = 4605, // 0x000011FD
        CuredSpadefish = 4606, // 0x000011FE
        CuredBoomerang = 4607, // 0x000011FF
        CuredEyeye = 4608, // 0x00001200
        CuredOculus = 4609, // 0x00001201
        CuredHoopfish = 4610, // 0x00001202
        CuredSpinefish = 4611, // 0x00001203
        CuredLavaEyeye = 4612, // 0x00001204
        CuredLavaBoomerang = 4613, // 0x00001205
        MembraneOld = 5000, // 0x00001388
        Unobtanium = 5001, // 0x00001389
        BaseRoom = 5500, // 0x0000157C
        BaseHatch = 5501, // 0x0000157D
        BaseWall = 5502, // 0x0000157E
        BaseDoor = 5503, // 0x0000157F
        BaseLadder = 5504, // 0x00001580
        BaseWindow = 5505, // 0x00001581
        PowerGeneratorOld = 5506, // 0x00001582
        UnusedOld = 5507, // 0x00001583
        BaseCorridor = 5508, // 0x00001584
        BaseFoundation = 5509, // 0x00001585
        BaseCorridorI = 5510, // 0x00001586
        BaseCorridorL = 5511, // 0x00001587
        BaseCorridorT = 5512, // 0x00001588
        BaseCorridorX = 5513, // 0x00001589
        BaseReinforcement = 5514, // 0x0000158A
        BaseBulkhead = 5515, // 0x0000158B
        BaseCorridorGlassI = 5516, // 0x0000158C
        BaseCorridorGlassL = 5517, // 0x0000158D
        BaseObservatory = 5518, // 0x0000158E
        BaseConnector = 5519, // 0x0000158F
        BaseMoonpool = 5520, // 0x00001590
        BaseCorridorGlass = 5521, // 0x00001591
        BaseUpgradeConsole = 5522, // 0x00001592
        BasePlanter = 5523, // 0x00001593
        BaseFiltrationMachine = 5524, // 0x00001594
        BaseWaterPark = 5525, // 0x00001595
        BaseMapRoom = 5526, // 0x00001596
        MapRoomCamera = 5527, // 0x00001597
        BaseBioReactor = 5528, // 0x00001598
        BaseNuclearReactor = 5529, // 0x00001599
        BasePipeConnector = 5530, // 0x0000159A
        BaseRechargePlatform = 5531, // 0x0000159B
        BaseControlRoom = 5532, // 0x0000159C
        BaseWallFoundation = 5533, // 0x0000159D
        BaseLargeRoom = 5534, // 0x0000159E
        OldBasePartitionI = 5535, // 0x0000159F
        OldBasePartitionL = 5536, // 0x000015A0
        OldBasePartitionT = 5537, // 0x000015A1
        OldBasePartitionX = 5538, // 0x000015A2
        BasePartitionDoor = 5539, // 0x000015A3
        BaseGlassDome = 5540, // 0x000015A4
        BasePartition = 5541, // 0x000015A5
        BaseLargeGlassDome = 5542, // 0x000015A6
        RocketBase = 5900, // 0x0000170C
        RocketBaseLadder = 5901, // 0x0000170D
        RocketStage1 = 5902, // 0x0000170E
        RocketStage2 = 5903, // 0x0000170F
        RocketStage3 = 5904, // 0x00001710
        TimeCapsule = 5905, // 0x00001711
        DioramaHullPlate = 6000, // 0x00001770
        MarkiplierHullPlate = 6001, // 0x00001771
        MuyskermHullPlate = 6002, // 0x00001772
        LordMinionHullPlate = 6003, // 0x00001773
        JackSepticEyeHullPlate = 6004, // 0x00001774
        Poster = 6005, // 0x00001775
        IGPHullPlate = 6006, // 0x00001776
        GilathissHullPlate = 6007, // 0x00001777
        Marki1 = 6008, // 0x00001778
        Marki2 = 6009, // 0x00001779
        JackSepticEye = 6010, // 0x0000177A
        EatMyDiction = 6011, // 0x0000177B
        RadiationLeakPoint = 7000, // 0x00001B58
        SomethingPlaceholder = 10000, // 0x00002710
        Fragment = 10001, // 0x00002711
        Wreck = 10002, // 0x00002712
        CountOld = 10003, // 0x00002713
        Databox = 10004, // 0x00002714
    }
}
