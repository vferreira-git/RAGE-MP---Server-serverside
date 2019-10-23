using GTANetworkAPI;
using System;
using System.Collections.Generic;

namespace Interiors
{
    public static class InteriorsMain
    {
        private static readonly Interior[] Interiors =
        {
            //Online Apartments
            new Interior(){ Name="Modern 1 Apartment",Position = new Vector3(-786.8663, 315.7642, 217.6385),NeedIPL=true,IPL="apa_v_mp_h_01_a"},
            new Interior(){ Name="Modern 2 Apartment",Position = new Vector3(-786.9563, 315.6229, 187.9136),NeedIPL=true,IPL="apa_v_mp_h_01_c"},
            new Interior(){ Name="Modern 3 Apartment",Position = new Vector3(-774.0126, 342.0428, 196.6864),NeedIPL=true,IPL="apa_v_mp_h_01_b"},
            new Interior(){ Name="Mody 1 Apartment",Position = new Vector3(-787.0749, 315.8198, 217.6386),NeedIPL=true,IPL="apa_v_mp_h_02_a"},
            new Interior(){ Name="Mody 2 Apartment",Position = new Vector3(-786.8195, 315.5634, 187.9137),NeedIPL=true,IPL="apa_v_mp_h_02_c"},
            new Interior(){ Name="Mody 3 Apartment",Position = new Vector3(-774.1382, 342.0316, 196.6864),NeedIPL=true,IPL="apa_v_mp_h_02_b"},
            new Interior(){ Name="Vibrant 1 Apartment",Position = new Vector3(-786.6245, 315.6175, 217.6385),NeedIPL=true,IPL="apa_v_mp_h_03_a"},
            new Interior(){ Name="Vibrant 2 Apartment",Position = new Vector3(-786.9584, 315.7974, 187.9135),NeedIPL=true,IPL="apa_v_mp_h_03_c"},
            new Interior(){ Name="Vibrant 3 Apartment",Position = new Vector3(-774.0223, 342.1718, 196.6863),NeedIPL=true,IPL="apa_v_mp_h_03_b"},
            new Interior(){ Name="Sharp 1 Apartment",Position = new Vector3(-787.0902, 315.7039, 217.6384),NeedIPL=true,IPL="apa_v_mp_h_04_a"},
            new Interior(){ Name="Sharp 2 Apartment",Position = new Vector3(-787.0155, 315.7071, 187.9135),NeedIPL=true,IPL="apa_v_mp_h_04_c"},
            new Interior(){ Name="Sharp 3 Apartment",Position = new Vector3(-773.8976, 342.1525, 196.6863),NeedIPL=true,IPL="apa_v_mp_h_04_b"},
            new Interior(){ Name="Monochrome 1 Apartment",Position = new Vector3(-786.9887, 315.7393, 217.6386),NeedIPL=true,IPL="apa_v_mp_h_05_a"},
            new Interior(){ Name="Monochrome 2 Apartment",Position = new Vector3(-786.8809, 315.6634, 187.9136),NeedIPL=true,IPL="apa_v_mp_h_05_c"},
            new Interior(){ Name="Monochrome 3 Apartment",Position = new Vector3(-774.0675, 342.0773, 196.6864),NeedIPL=true,IPL="apa_v_mp_h_05_b"},
            new Interior(){ Name="Seductive 1 Apartment",Position = new Vector3(-787.1423, 315.6943, 217.6384),NeedIPL=true,IPL="apa_v_mp_h_06_a"},
            new Interior(){ Name="Seductive 2 Apartment",Position = new Vector3(-787.0961, 315.815, 187.9135),NeedIPL=true,IPL="apa_v_mp_h_06_c"},
            new Interior(){ Name="Seductive 3 Apartment",Position = new Vector3(-773.9552, 341.9892, 196.6862),NeedIPL=true,IPL="apa_v_mp_h_06_b"},
            new Interior(){ Name="Regal 1 Apartment",Position = new Vector3(-787.029, 315.7113, 217.6385),NeedIPL=true,IPL="apa_v_mp_h_07_a"},
            new Interior(){ Name="Regal 2 Apartment",Position = new Vector3(-787.0574, 315.6567, 187.9135),NeedIPL=true,IPL="apa_v_mp_h_07_c"},
            new Interior(){ Name="Regal 3 Apartment	",Position = new Vector3(-774.0109, 342.0965, 196.6863),NeedIPL=true,IPL="apa_v_mp_h_07_b"},
            new Interior(){ Name="Aqua 1 Apartment",Position = new Vector3(-786.9469, 315.5655, 217.6383),NeedIPL=true,IPL="apa_v_mp_h_08_a"},
            new Interior(){ Name="Aqua 2 Apartment",Position = new Vector3(-786.9756, 315.723, 187.9134),NeedIPL=true,IPL="apa_v_mp_h_08_c"},
            new Interior(){ Name="Aqua 3 Apartment",Position = new Vector3(-774.0349, 342.0296, 196.6862),NeedIPL=true,IPL="apa_v_mp_h_08_b"},

            //Arcadius Business Centre
            new Interior(){ Name="Executive Rich",Position = new Vector3(-141.1987, -620.913, 168.8205),NeedIPL=true,IPL="ex_dt1_02_office_02b"},
            new Interior(){ Name="Executive Cool",Position = new Vector3(-141.5429, -620.9524, 168.8204),NeedIPL=true,IPL="ex_dt1_02_office_02c"},
            new Interior(){ Name="Executive Contrast",Position = new Vector3(-141.2896, -620.9618, 168.8204),NeedIPL=true,IPL="ex_dt1_02_office_02a"},
            new Interior(){ Name="Old Spice Warm",Position = new Vector3(-141.4966, -620.8292, 168.8204),NeedIPL=true,IPL="ex_dt1_02_office_01a"},
            new Interior(){ Name="Old Spice Classical",Position = new Vector3(-141.3997, -620.9006, 168.8204),NeedIPL=true,IPL="ex_dt1_02_office_01b"},
            new Interior(){ Name="Old Spice Vintage",Position = new Vector3(-141.5361, -620.9186, 168.8204),NeedIPL=true,IPL="ex_dt1_02_office_01c"},
            new Interior(){ Name="Power Broker Ice",Position = new Vector3(-141.392, -621.0451, 168.8204),NeedIPL=true,IPL="ex_dt1_02_office_03a"},
            new Interior(){ Name="Power Broker Conservative",Position = new Vector3(-141.1945, -620.8729, 168.8204),NeedIPL=true,IPL="ex_dt1_02_office_03b"},
            new Interior(){ Name="Power Broker Polished",Position = new Vector3(-141.4924, -621.0035, 168.8205),NeedIPL=true,IPL="ex_dt1_02_office_03c"},
            new Interior(){ Name="Garage 1",Position = new Vector3(-191.0133, -579.1428, 135.0000),NeedIPL=true,IPL="imp_dt1_02_cargarage_a"},
            new Interior(){ Name="Garage 2",Position = new Vector3(-117.4989, -568.1132, 135.0000),NeedIPL=true,IPL="imp_dt1_02_cargarage_b"},
            new Interior(){ Name="Garage 3",Position = new Vector3(-136.0780, -630.1852, 135.0000),NeedIPL=true,IPL="imp_dt1_02_cargarage_c"},
            new Interior(){ Name="Mod Shop",Position = new Vector3(-146.6166, -596.6301, 166.0000),NeedIPL=true,IPL="imp_dt1_02_modgarage"},

            //Maze Bank Building
            new Interior(){ Name="Executive Rich",Position = new Vector3(-75.8466, -826.9893, 243.3859),NeedIPL=true,IPL="ex_dt1_11_office_02b"},
            new Interior(){ Name="Executive Cool",Position = new Vector3(-75.49945, -827.05, 243.386),NeedIPL=true,IPL="ex_dt1_11_office_02c"},
            new Interior(){ Name="Executive Contrast",Position = new Vector3(-75.49827, -827.1889, 243.386),NeedIPL=true,IPL="ex_dt1_11_office_02a"},
            new Interior(){ Name="Old Spice Warm",Position = new Vector3(-75.44054, -827.1487, 243.3859),NeedIPL=true,IPL="ex_dt1_11_office_01a"},
            new Interior(){ Name="Old Spice Classica",Position = new Vector3(-75.63942, -827.1022, 243.3859),NeedIPL=true,IPL="ex_dt1_11_office_01b"},
            new Interior(){ Name="Old Spice Vintage",Position = new Vector3(-75.47446, -827.2621, 243.386),NeedIPL=true,IPL="ex_dt1_11_office_01c"},
            new Interior(){ Name="Power Broker Ice",Position = new Vector3(-75.56978, -827.1152, 243.3859),NeedIPL=true,IPL="ex_dt1_11_office_03a"},
            new Interior(){ Name="Power Broker Conservative",Position = new Vector3(-75.51953, -827.0786, 243.3859),NeedIPL=true,IPL="ex_dt1_11_office_03b"},
            new Interior(){ Name="Power Broker Polished",Position = new Vector3(-75.41915, -827.1118, 243.3858),NeedIPL=true,IPL="ex_dt1_11_office_03c"},
            new Interior(){ Name="Garage 1",Position = new Vector3(-84.2193, -823.0851, 221.0000),NeedIPL=true,IPL="imp_dt1_11_cargarage_a"},
            new Interior(){ Name="Garage 2",Position = new Vector3(-69.8627, -824.7498, 221.0000),NeedIPL=true,IPL="imp_dt1_11_cargarage_b"},
            new Interior(){ Name="Garage 3",Position = new Vector3(-80.4318, -813.2536, 221.0000),NeedIPL=true,IPL="imp_dt1_11_cargarage_c"},
            new Interior(){ Name="Mod Shop",Position = new Vector3(-73.9039, -821.6204, 284.0000),NeedIPL=true,IPL="imp_dt1_11_modgarage"},

            //Lom Bank
            new Interior(){ Name="Executive Rich",Position = new Vector3(-1579.756, -565.0661, 108.523),NeedIPL=true,IPL="ex_sm_13_office_02b"},
            new Interior(){ Name="Executive Cool",Position = new Vector3(-1579.678, -565.0034, 108.5229),NeedIPL=true,IPL="ex_sm_13_office_02c"},
            new Interior(){ Name="Executive Contrast",Position = new Vector3(-1579.583, -565.0399, 108.5229),NeedIPL=true,IPL="ex_sm_13_office_02a"},
            new Interior(){ Name="Old Spice Warm",Position = new Vector3(-1579.702, -565.0366, 108.5229),NeedIPL=true,IPL="ex_sm_13_office_01a"},
            new Interior(){ Name="Old Spice Classical",Position = new Vector3(-1579.643, -564.9685, 108.5229),NeedIPL=true,IPL="ex_sm_13_office_01b"},
            new Interior(){ Name="Old Spice Vintage",Position = new Vector3(-1579.681, -565.0003, 108.523),NeedIPL=true,IPL="ex_sm_13_office_01c"},
            new Interior(){ Name="Power Broker Ice	",Position = new Vector3(-1579.677, -565.0689, 108.5229),NeedIPL=true,IPL="ex_sm_13_office_03a"},
            new Interior(){ Name="Power Broker Conservative	",Position = new Vector3(-1579.708, -564.9634, 108.5229),NeedIPL=true,IPL="ex_sm_13_office_03b"},
            new Interior(){ Name="Power Broker Polished",Position = new Vector3(-1579.693, -564.8981, 108.5229),NeedIPL=true,IPL="ex_sm_13_office_03c"},
            new Interior(){ Name="Garage 1",Position = new Vector3(-1581.1120, -567.2450, 85.5000),NeedIPL=true,IPL="imp_sm_13_cargarage_a"},
            new Interior(){ Name="Garage 2",Position = new Vector3(-1568.7390, -562.0455, 85.5000),NeedIPL=true,IPL="imp_sm_13_cargarage_b"},
            new Interior(){ Name="Garage 3",Position = new Vector3(-1563.5570, -574.4314, 85.5000),NeedIPL=true,IPL="imp_sm_13_cargarage_c"},
            new Interior(){ Name="Mod Shop",Position = new Vector3(-1578.0230, -576.4251, 104.2000),NeedIPL=true,IPL="imp_sm_13_modgarage"},

            //Maze Bank West
            new Interior(){ Name="Executive Rich",Position = new Vector3(-1392.667, -480.4736, 72.04217),NeedIPL=true,IPL="ex_sm_15_office_02b"},
            new Interior(){ Name="Executive Cool",Position = new Vector3(-1392.542, -480.4011, 72.04211),NeedIPL=true,IPL="ex_sm_15_office_02c"},
            new Interior(){ Name="Executive Contrast",Position = new Vector3(-1392.626, -480.4856, 72.04212),NeedIPL=true,IPL="ex_sm_15_office_02a"},
            new Interior(){ Name="Old Spice Warm",Position = new Vector3(-1392.617, -480.6363, 72.04208),NeedIPL=true,IPL="ex_sm_15_office_01a"},
            new Interior(){ Name="Old Spice Classical",Position = new Vector3(-1392.532, -480.7649, 72.04207),NeedIPL=true,IPL="ex_sm_15_office_01b"},
            new Interior(){ Name="Old Spice Vintage",Position = new Vector3(-1392.611, -480.5562, 72.04214),NeedIPL=true,IPL="ex_sm_15_office_01c"},
            new Interior(){ Name="Power Broker Ice",Position = new Vector3(-1392.563, -480.549, 72.0421),NeedIPL=true,IPL="ex_sm_15_office_03a"},
            new Interior(){ Name="Power Broker Convservative",Position = new Vector3(-1392.528, -480.475, 72.04206),NeedIPL=true,IPL="ex_sm_15_office_03b"},
            new Interior(){ Name="Power Broker Polished",Position = new Vector3(-1392.416, -480.7485, 72.04207),NeedIPL=true,IPL="ex_sm_15_office_03c"},
            new Interior(){ Name="Garage 1",Position = new Vector3(-1388.8400, -478.7402, 56.1000),NeedIPL=true,IPL="imp_sm_15_cargarage_a"},
            new Interior(){ Name="Garage 2",Position = new Vector3(-1388.8600, -478.7574, 48.1000),NeedIPL=true,IPL="imp_sm_15_cargarage_b"},
            new Interior(){ Name="Garage 3",Position = new Vector3(-1374.6820, -474.3586, 56.1000),NeedIPL=true,IPL="imp_sm_15_cargarage_c"},
            new Interior(){ Name="Mod Shop",Position = new Vector3(-1391.2450, -473.9638, 77.2000),NeedIPL=true,IPL="imp_sm_15_modgarage"},

            //Clubhouse & Warehouses
            new Interior(){ Name="Clubhouse 1",Position = new Vector3(1107.04, -3157.399, -37.51859),NeedIPL=true,IPL="bkr_biker_interior_placement_interior_0_biker_dlc_int_01_milo"},
            new Interior(){ Name="Clubhouse 2",Position = new Vector3(998.4809, -3164.711, -38.90733),NeedIPL=true,IPL="bkr_biker_interior_placement_interior_1_biker_dlc_int_02_milo"},
            new Interior(){ Name="Meth Lab",Position = new Vector3(1009.5, -3196.6, -38.99682),NeedIPL=true,IPL="bkr_biker_interior_placement_interior_2_biker_dlc_int_ware01_milo"},
            new Interior(){ Name="Weed Farm",Position = new Vector3(1051.491, -3196.536, -39.14842),NeedIPL=true,IPL="bkr_biker_interior_placement_interior_3_biker_dlc_int_ware02_milo"},
            new Interior(){ Name="Cocaine Lockup",Position = new Vector3(1093.6, -3196.6, -38.99841),NeedIPL=true,IPL="bkr_biker_interior_placement_interior_4_biker_dlc_int_ware03_milo"},
            new Interior(){ Name="Counterfeit Cash Factory",Position = new Vector3(1121.897, -3195.338, -40.4025),NeedIPL=true,IPL="bkr_biker_interior_placement_interior_5_biker_dlc_int_ware04_milo"},
            new Interior(){ Name="Document Forgery Office",Position = new Vector3(1165, -3196.6, -39.01306),NeedIPL=true,IPL="bkr_biker_interior_placement_interior_6_biker_dlc_int_ware05_milo"},
            new Interior(){ Name="Warehouse Small",Position = new Vector3(1094.988, -3101.776, -39.00363),NeedIPL=true,IPL="ex_exec_warehouse_placement_interior_1_int_warehouse_s_dlc_milo"},
            new Interior(){ Name="Warehouse Medium",Position = new Vector3(1056.486, -3105.724, -39.00439),NeedIPL=true,IPL="ex_exec_warehouse_placement_interior_0_int_warehouse_m_dlc_milo"},
            new Interior(){ Name="Warehouse Large",Position = new Vector3(1006.967, -3102.079, -39.0035),NeedIPL=true,IPL="ex_exec_warehouse_placement_interior_2_int_warehouse_l_dlc_milo"},
            new Interior(){ Name="Vehicle Warehouse",Position = new Vector3(994.5925, -3002.594, -39.64699),NeedIPL=true,IPL="imp_impexp_interior_placement_interior_1_impexp_intwaremed_milo_"},
            new Interior(){ Name="Lost MC Clubhouse",Position = new Vector3(982.0083, -100.8747, 74.84512),NeedIPL=true,IPL="bkr_bi_hw1_13_int"},

            //Special Locations
            new Interior(){ Name="Normal Cargo Ship",Position = new Vector3(-163.3628, -2385.161, 5.999994),NeedIPL=true,IPL="cargoship"},
            new Interior(){ Name="Sunken Cargo Ship",Position = new Vector3(-163.3628, -2385.161, 5.999994),NeedIPL=true,IPL="sunkcargoship"},
            new Interior(){ Name="Burning Cargo Ship",Position = new Vector3(-163.3628, -2385.161, 5.999994),NeedIPL=true,IPL="SUNK_SHIP_FIRE"},
            new Interior(){ Name="Red Carpet",Position = new Vector3(300.5927, 300.5927, 104.3776),NeedIPL=true,IPL="redCarpet"},
            new Interior(){ Name="Rekt Stilthouse Destroyed",Position = new Vector3(-1020.518, 663.27, 153.5167),NeedIPL=true,IPL="DES_StiltHouse_imapend"},
            new Interior(){ Name="Rekt Stilthouse Rebuild",Position = new Vector3(-1020.518, 663.27, 153.5167),NeedIPL=true,IPL="DES_stilthouse_rebuild"},
            new Interior(){ Name="Union Depository",Position = new Vector3(2.6968, -667.0166, 16.13061),NeedIPL=true,IPL="FINBANK"},
            new Interior(){ Name="Trevors Trailer Dirty	",Position = new Vector3(1975.552, 3820.538, 33.44833),NeedIPL=true,IPL="TrevorsMP"},
            new Interior(){ Name="Trevors Trailer Clean",Position = new Vector3(1975.552, 3820.538, 33.44833),NeedIPL=true,IPL="TrevorsTrailerTidy"},
            new Interior(){ Name="Stadium",Position = new Vector3(-248.6731, -2010.603, 30.14562),NeedIPL=true,IPL="SP1_10_real_interior"},
            new Interior(){ Name="Max Renda Shop",Position = new Vector3(-585.8247, -282.72, 35.45475),NeedIPL=true,IPL="refit_unload"},
            new Interior(){ Name="Jewel Store",Position = new Vector3(-630.07, -236.332, 38.05704),NeedIPL=true,IPL="post_hiest_unload"},
            new Interior(){ Name="FIB Lobby",Position = new Vector3(110.4, -744.2, 45.7496),NeedIPL=true,IPL="FIBlobby"},

            //Car Garages NO IPL
            new Interior(){ Name="2 Car",Position = new Vector3(173.2903, -1003.6, -99.65707),NeedIPL=false},
            new Interior(){ Name="6 Car",Position = new Vector3(197.8153, -1002.293, -99.65749),NeedIPL=false},
            new Interior(){ Name="10 Car",Position = new Vector3(229.9559, -981.7928, -99.66071),NeedIPL=false},

            //Apartments NO IPL
            new Interior(){ Name="Low End Apartment",Position = new Vector3(261.4586, -998.8196, -99.00863),NeedIPL=false },
            new Interior(){ Name="Medium End Apartment",Position = new Vector3(347.2686, -999.2955, -99.19622),NeedIPL=false },
            new Interior(){ Name="4 Integrity Way, Apt 28",Position = new Vector3(-18.07856, -583.6725, 79.46569),NeedIPL=false },
            new Interior(){ Name="4 Integrity Way, Apt 30",Position = new Vector3(-35.31277, -580.4199, 88.71221),NeedIPL=false },
            new Interior(){ Name="Dell Perro Heights, Apt 4",Position = new Vector3(-1468.14, -541.815, 73.4442),NeedIPL=false },
            new Interior(){ Name="Dell Perro Heights, Apt 7",Position = new Vector3(-1477.14, -538.7499, 55.5264),NeedIPL=false },
            new Interior(){ Name="Richard Majestic, Apt 2",Position = new Vector3(-915.811, -379.432, 113.6748),NeedIPL=false },
            new Interior(){ Name="Tinsel Towers, Apt 42",Position = new Vector3(-614.86, 40.6783, 97.60007),NeedIPL=false },
            new Interior(){ Name="Eclipse Towers, Apt 3",Position = new Vector3(-773.407, 341.766, 211.397),NeedIPL=false },
            new Interior(){ Name="3655 Wild Oats Drive",Position = new Vector3(-169.286, 486.4938, 137.4436),NeedIPL=false },
            new Interior(){ Name="2044 North Conker Avenue",Position = new Vector3(340.9412, 437.1798, 149.3925),NeedIPL=false },
            new Interior(){ Name="2045 North Conker Avenue",Position = new Vector3(373.023, 416.105, 145.7006),NeedIPL=false },
            new Interior(){ Name="2862 Hillcrest Avenue",Position = new Vector3(-676.127, 588.612, 145.1698),NeedIPL=false },
            new Interior(){ Name="2868 Hillcrest Avenue",Position = new Vector3(-763.107, 615.906, 144.1401),NeedIPL=false },
            new Interior(){ Name="2874 Hillcrest Avenue",Position = new Vector3(-857.798, 682.563, 152.6529),NeedIPL=false },
            new Interior(){ Name="2677 Whispymound Drive",Position = new Vector3(120.5, 549.952, 184.097),NeedIPL=false },
            new Interior(){ Name="2133 Mad Wayne Thunder",Position = new Vector3(-1288, 440.748, 97.69459),NeedIPL=false },

            //Misc NO IPL
            new Interior(){ Name="Bunker Interior",Position = new Vector3(899.5518,-3246.038, -98.04907),NeedIPL=false },
            new Interior(){ Name="CharCreator",Position = new Vector3(402.5164, -1002.847, -99.2587),NeedIPL=false },
            new Interior(){ Name="Mission Carpark",Position = new Vector3(405.9228, -954.1149, -99.6627),NeedIPL=false },
            new Interior(){ Name="Torture Room",Position = new Vector3(136.5146, -2203.149, 7.30914),NeedIPL=false },
            new Interior(){ Name="Solomon's Office",Position = new Vector3(-1005.84, -478.92, 50.02733),NeedIPL=false },
            new Interior(){ Name="Psychiatrist's Office",Position = new Vector3(-1908.024, -573.4244, 19.09722),NeedIPL=false },
            new Interior(){ Name="Omega's Garage",Position = new Vector3(2331.344, 2574.073, 46.68137),NeedIPL=false },
            new Interior(){ Name="Movie Theatre",Position = new Vector3(-1427.299, -245.1012, 16.8039),NeedIPL=false },
            new Interior(){ Name="Motel",Position = new Vector3(152.2605, -1004.471, -98.99999),NeedIPL=false },
            new Interior(){ Name="Madrazos Ranch",Position = new Vector3(1399, 1150, 115),NeedIPL=false },
            new Interior(){ Name="Life Invader Office",Position = new Vector3(-1044.193, -236.9535, 37.96496),NeedIPL=false },
            new Interior(){ Name="Lester's House",Position = new Vector3(1273.9, -1719.305, 54.77141),NeedIPL=false },
            new Interior(){ Name="FBI Top Floor",Position = new Vector3(134.5835, -749.339, 258.152),NeedIPL=false },
            new Interior(){ Name="FBI Floor 47",Position = new Vector3(134.5835, -766.486, 234.152),NeedIPL=false },
            new Interior(){ Name="FBI Floor 49",Position = new Vector3(134.635, -765.831, 242.152),NeedIPL=false },
            new Interior(){ Name="IAA Office",Position = new Vector3(117.22, -620.938, 206.1398),NeedIPL=false },
            new Interior(){ Name="Smuggler's Run Hangar",Position = new Vector3(-1266.802, -3014.837, -49.000),NeedIPL=false },
            new Interior(){ Name="Avenger Interior",Position = new Vector3(520.0, 4750.0, -70.0),NeedIPL=false },
            new Interior(){ Name="Facility",Position = new Vector3(345.0041, 4842.001, -59.9997),NeedIPL=false },
            new Interior(){ Name="Server Farm",Position = new Vector3(2168.0, 2920.0, -84.0),NeedIPL=false },
            new Interior(){ Name="Submarine",Position = new Vector3(514.33, 4886.18, -62.59),NeedIPL=false },
            new Interior(){ Name="IAA Facility",Position = new Vector3(2147.91, 2921.0, -61.9),NeedIPL=false },
            new Interior(){ Name="Nightclub",Position = new Vector3(-1604.664, -3012.583, -78.000),NeedIPL=false },
            new Interior(){ Name="Nightclub Warehouse",Position = new Vector3(-1505.783, -3012.587, -80.000),NeedIPL=false },
            new Interior(){ Name="Terrorbyte Interior",Position = new Vector3(-1421.015, -3012.587, -80.000),NeedIPL=false },

            //Apartments NO IPL
            new Interior(){ Name="Low End Apartment",Position = new Vector3(261.4586, -998.8196, -99.00863),NeedIPL=false },
            new Interior(){ Name="Medium End Apartment",Position = new Vector3(347.2686, -999.2955, -99.19622),NeedIPL=false },
            new Interior(){ Name="4 Integrity Way, Apt 28",Position = new Vector3(-18.07856, -583.6725, 79.46569),NeedIPL=false },
            new Interior(){ Name="4 Integrity Way, Apt 30",Position = new Vector3(-35.31277, -580.4199, 88.71221),NeedIPL=false },
            new Interior(){ Name="Dell Perro Heights, Apt 4",Position = new Vector3(-1468.14, -541.815, 73.4442),NeedIPL=false },
            new Interior(){ Name="Dell Perro Heights, Apt 7",Position = new Vector3(-1477.14, -538.7499, 55.5264),NeedIPL=false },
            new Interior(){ Name="Richard Majestic, Apt 2",Position = new Vector3(-915.811, -379.432, 113.6748),NeedIPL=false },
            new Interior(){ Name="Tinsel Towers, Apt 42",Position = new Vector3(-614.86, 40.6783, 97.60007),NeedIPL=false },
            new Interior(){ Name="Eclipse Towers, Apt 3",Position = new Vector3(-773.407, 341.766, 211.397),NeedIPL=false },
            new Interior(){ Name="3655 Wild Oats Drive",Position = new Vector3(-169.286, 486.4938, 137.4436),NeedIPL=false },
            new Interior(){ Name="2044 North Conker Avenue",Position = new Vector3(340.9412, 437.1798, 149.3925),NeedIPL=false },
            new Interior(){ Name="2045 North Conker Avenue",Position = new Vector3(373.023, 416.105, 145.7006),NeedIPL=false },
            new Interior(){ Name="2862 Hillcrest Avenue",Position = new Vector3(-676.127, 588.612, 145.1698),NeedIPL=false },
            new Interior(){ Name="2868 Hillcrest Avenue",Position = new Vector3(-763.107, 615.906, 144.1401),NeedIPL=false },
            new Interior(){ Name="2874 Hillcrest Avenue",Position = new Vector3(-857.798, 682.563, 152.6529),NeedIPL=false },
            new Interior(){ Name="2677 Whispymound Drive",Position = new Vector3(120.5, 549.952, 184.097),NeedIPL=false },
            new Interior(){ Name="2133 Mad Wayne Thunder",Position = new Vector3(-1288, 440.748, 97.69459),NeedIPL=false },

            //Diamond Casino & Resort
            new Interior(){ Name="Casino",Position = new Vector3(1100.000, 220.000, -50.000),NeedIPL=true,IPL="vw_casino_main﻿" },
            new Interior(){ Name="Garage",Position = new Vector3(1295.000, 230.000, -50.000),NeedIPL=true,IPL="vw_casino_garage" },
            new Interior(){ Name="Car Park",Position = new Vector3(1380.000, 200.000, -50.000),NeedIPL=true,IPL="vw_casino_carpark" },
            new Interior(){ Name="Penthouse",Position = new Vector3(976.636, 70.295, 115.164),NeedIPL=true,IPL="vw_casino_penthouse" }

        };

        public static void TeleportInterior(Client client, uint i)
        {
            if (Interiors[i].NeedIPL)
                client.TriggerEvent("loadInterior", Interiors[i].IPL);
            client.Position = Interiors[i].Position;
            client.SetData("CurrentInterior", i);
        }

        public static Vector3 GetInteriorPos(uint interior)
        {
            return Interiors[interior].Position;
        }
        public static void LoadInterior(Client client, uint i)
        {
            if (Interiors[i].NeedIPL)
                client.TriggerEvent("loadInterior", Interiors[i].IPL);
        }
    }
}
