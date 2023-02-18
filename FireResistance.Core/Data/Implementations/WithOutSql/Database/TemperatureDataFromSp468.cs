﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FireResistance.Core.Data.Implementations.WithOutSql.Database
{
    internal static class TemperatureDataFromSp468
    {
        public static List<int> LenthFromArmatureToEdgeTable200 => new List<int>(lenthFromArmatureToEdgeTable200);
        public static List<int> LenthFromArmatureToEdgeTable300 => new List<int>(lenthFromArmatureToEdgeTable300);
        public static List<int> LenthFromArmatureToEdgeTable400 => new List<int>(lenthFromArmatureToEdgeTable400);
        public static List<int> TemperatureForCriticalTemperature => new List<int>(temperatureForCriticalTemperature);
        public static List<string> FireResistanceForCriticalTemperature => new List<string>(fireResistanceForCriticalTemperature);
        public static double[,] TemperatureH200R30 => Utilities.GetCopyArray(temperatureH200R30);
        public static double[,] TemperatureH200R45 => Utilities.GetCopyArray(temperatureH200R45);
        public static double[,] TemperatureH200R60 => Utilities.GetCopyArray(temperatureH200R60);
        public static double[,] TemperatureH200R90 => Utilities.GetCopyArray(temperatureH200R90);
        public static double[,] TemperatureH200R120 => Utilities.GetCopyArray(temperatureH200R120);
        public static double[,] TemperatureH200R150 => Utilities.GetCopyArray(temperatureH200R150);
        public static double[,] TemperatureH300R30 => Utilities.GetCopyArray(temperatureH300R30);
        public static double[,] TemperatureH300R45 => Utilities.GetCopyArray(temperatureH300R45);
        public static double[,] TemperatureH300R60 => Utilities.GetCopyArray(temperatureH300R60);
        public static double[,] TemperatureH300R90 => Utilities.GetCopyArray(temperatureH300R90);
        public static double[,] TemperatureH300R120 => Utilities.GetCopyArray(temperatureH300R120);
        public static double[,] TemperatureH300R150 => Utilities.GetCopyArray(temperatureH300R150);
        public static double[,] TemperatureH400R30 => Utilities.GetCopyArray(temperatureH400R30);
        public static double[,] TemperatureH400R45 => Utilities.GetCopyArray(temperatureH400R45);
        public static double[,] TemperatureH400R60 => Utilities.GetCopyArray(temperatureH400R60);
        public static double[,] TemperatureH400R90 => Utilities.GetCopyArray(temperatureH400R90);
        public static double[,] TemperatureH400R120 => Utilities.GetCopyArray(temperatureH400R120);
        public static double[,] TemperatureH400R150 => Utilities.GetCopyArray(temperatureH400R150);
        public static double[,] DeepCriticalTemperatureConcreteSilicate => Utilities.GetCopyArray(deepCriticalTemperatureConcreteSilicate);
        public static double[,] DeepCriticalTemperatureConcreteCarbonate => Utilities.GetCopyArray(deepCriticalTemperatureConcreteCarbonate);


        private static List<int> lenthFromArmatureToEdgeTable200 = new List<int>()
        {
            0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100
        };
        private static List<int> lenthFromArmatureToEdgeTable300 = new List<int>()
        {
            0, 30, 60, 90, 120, 150
        };
        private static List<int> lenthFromArmatureToEdgeTable400 = new List<int>()
        {
            0, 20, 40, 60, 80, 100, 120, 140, 160, 180, 200
        };
        private static List<int> temperatureForCriticalTemperature = new List<int>
        {
            200, 300, 400, 500, 600, 700, 800, 900, 1000
        };
        private static List<string> fireResistanceForCriticalTemperature = new List<string>
        {
            "R30", "R45", "R60", "R90", "R120", "R150"
        };

        private static double[,] temperatureH200R30 =
       {
            {824, 767, 735, 710, 692, 679, 671, 666, 663, 662, 661},
            {767, 670, 600, 550, 515, 492, 476, 467, 462, 460, 459},
            {735, 600, 504, 435, 388, 355, 335, 322, 315, 312, 311},
            {710, 550, 435, 353, 296, 256, 230, 215, 207, 203, 202},
            {692, 515, 388, 296, 229, 183, 154, 139, 132, 129, 128},
            {679, 492, 355, 256, 183, 134, 111, 99, 93, 90, 89},
            {671, 476, 335, 230, 154, 111, 91, 81, 74, 71, 70},
            {666, 467, 322, 215, 139, 99, 81, 69, 63, 59, 58},
            {663, 462, 315, 207, 132, 93, 74, 63, 55, 51, 50},
            {662, 460, 312, 203, 129, 90, 71, 59, 51, 47, 46},
            {661, 459, 311, 202, 128, 89, 70, 58, 50, 46, 45}
        };

        private static double[,] temperatureH200R45 =
{
            {878, 841, 818, 798, 784, 774, 766, 762, 758, 756, 756},
            {841, 764, 706, 662, 630, 608, 591, 580, 574, 570, 568},
            {818, 706, 623, 560, 515, 482, 459, 443, 433, 428, 426},
            {798, 662, 560, 484, 428, 386, 357, 338, 325, 318, 316},
            {790, 630, 515, 428, 362, 314, 280, 258, 244, 237, 234},
            {774, 608, 482, 386, 314, 260, 227, 204, 190, 182, 178},
            {766, 591, 459, 357, 280, 227, 192, 169, 152, 143, 140},
            {762, 580, 443, 338, 258, 204, 169, 142, 124, 114, 110},
            {758, 574, 433, 325, 244, 190, 152, 124, 104, 93, 90},
            {756, 570, 428, 318, 237, 182, 143, 114, 93, 83, 80},
            {756, 568, 426, 316, 234, 178, 140, 110, 90, 80, 77}
        };

        private static double[,] temperatureH200R60 =
        {
            {932, 915, 900, 887, 877, 868, 862, 857, 853, 851, 851},
            {915, 858, 812, 775, 746, 724, 706, 694, 685, 680, 678},
            {900, 812, 742, 686, 642, 608, 583, 564, 551, 543, 541},
            {887, 775, 686, 615, 560, 517, 484, 460, 443, 433, 430},
            {887, 746, 642, 560, 495, 444, 405, 376, 356, 345, 341},
            {868, 724, 608, 517, 444, 387, 343, 310, 287, 273, 268},
            {862, 706, 583, 484, 405, 343, 294, 257, 231, 215, 209},
            {857, 694, 564, 460, 376, 310, 257, 216, 186, 168, 162},
            {853, 685, 551, 443, 356, 287, 231, 186, 154, 135, 130},
            {851, 680, 543, 433, 345, 273, 215, 168, 135, 119, 114},
            {851, 678, 541, 430, 341, 268, 209, 162, 130, 114, 109}
        };

        private static double[,] temperatureH200R90 =
        {
            {1000, 988, 979, 971, 964, 958, 953, 950, 947, 946, 945},
            {988, 949, 915, 887, 864, 845, 830, 819, 811, 806, 805},
            {979, 915, 861, 816, 780, 750, 727, 710, 698, 691, 688},
            {971, 887, 816, 758, 711, 673, 643, 620, 605, 596, 593},
            {964, 864, 780, 711, 654, 609, 574, 548, 529, 518, 514},
            {958, 845, 750, 673, 609, 559, 519, 489, 468, 455, 451},
            {953, 830, 727, 643, 574, 519, 475, 443, 420, 406, 402},
            {950, 819, 710, 620, 548, 489, 443, 408, 383, 369, 364},
            {947, 811, 698, 605, 529, 468, 420, 383, 358, 343, 338},
            {946, 806, 691, 596, 518, 455, 406, 369, 343, 327, 322},
            {945, 805, 688, 593, 514, 451, 402, 364, 338, 322, 317}
        };

        private static double[,] temperatureH200R120 =
        {
            {1045, 1037, 1031, 1025, 1020, 1016, 1013, 1010, 1008, 1007, 1007},
            {1037, 1008, 982, 961, 943, 928, 916, 907, 901, 897, 895},
            {1031, 982, 941, 905, 875, 850, 830, 816, 806, 800, 798},
            {1025, 961, 905, 857, 817, 785, 759, 740, 727, 719, 716},
            {1020, 943, 875, 817, 769, 731, 701, 678, 662, 653, 650},
            {1016, 928, 850, 785, 731, 688, 653, 628, 610, 599, 596},
            {1013, 916, 830, 759, 701, 653, 616, 588, 569, 557, 553},
            {1010, 907, 816, 740, 678, 628, 588, 558, 538, 525, 521},
            {1008, 901, 806, 727, 662, 610, 569, 538, 516, 503, 499},
            {1007, 897, 800, 719, 653, 599, 557, 525, 503, 490, 486},
            {1007, 895, 798, 716, 650, 596, 553, 521, 499, 486, 481}
        };

        private static double[,] temperatureH200R150 =
        {
            {1077, 1074, 1070, 1068, 1064, 1060, 1055, 1053, 1050, 1048, 1046},
            {1074, 1055, 1035, 1066, 997, 985, 970, 959, 948, 942, 933},
            {1070, 1035, 1000, 1065, 930, 910, 885, 865, 845, 835, 820},
            {1068, 1066, 965, 975, 885, 855, 823, 798, 773, 758, 740},
            {1064, 997, 930, 885, 840, 800, 760, 730, 700, 680, 660},
            {1060, 985, 910, 854, 800, 765, 730, 695, 660, 640, 615},
            {1055, 970, 885, 823, 760, 730, 700, 660, 620, 595, 570},
            {1053, 959, 865, 798, 730, 695, 660, 635, 610, 580, 550},
            {1050, 948, 845, 773, 700, 660, 620, 610, 600, 565, 530},
            {1048, 942, 835, 758, 680, 635, 595, 580, 565, 540, 515},
            {1046, 933, 820, 740, 660, 615, 570, 550, 530, 515, 500}
        };

        private static double[,] temperatureH300R30 =
        {
            {827, 700, 650, 640, 630, 620},
            {700, 380, 250, 200, 200, 200},
            {650, 250, 100, 90, 90, 90},
            {640, 200, 90, 70, 70, 70},
            {630, 200, 90, 70, 55, 55},
            {620, 200, 90, 70, 55, 45}
        };

        private static double[,] temperatureH300R45 =
{
            {880, 775, 735, 715, 705, 700},
            {775, 505, 375, 310, 300, 300},
            {735, 375, 200, 145, 140, 140},
            {715, 310, 145, 85, 80, 80},
            {705, 300, 140, 80, 68, 62},
            {700, 300, 140, 80, 68, 58}
        };

        private static double[,] temperatureH300R60 =
        {
            {933, 850, 820, 790, 780, 780},
            {850, 630, 500, 420, 400, 400},
            {820, 500, 300, 200, 190, 190},
            {790, 420, 200, 100, 90, 90},
            {780, 400, 190, 90, 80, 70},
            {780, 400, 190, 90, 80, 70}
        };

        private static double[,] temperatureH300R90 =
        {
            {1002, 950, 910, 910, 910, 910},
            {950, 750, 610, 550, 500, 500},
            {910, 610, 450, 350, 290, 290},
            {910, 550, 350, 200, 170, 170},
            {910, 500, 290, 170, 100, 90},
            {910, 500, 290, 170, 100, 90}
        };

        private static double[,] temperatureH300R120 =
        {
            {1046, 1010, 990, 950, 930, 920},
            {1010, 870, 750, 690, 630, 600},
            {990, 750, 590, 480, 400, 400},
            {950, 690, 480, 350, 250, 250},
            {930, 630, 400, 250, 180, 180},
            {920, 600, 400, 250, 180, 150}
        };

        private static double[,] temperatureH300R150 =
        {
            {1077, 1045, 1020, 985, 975, 970},
            {1045, 925, 825, 750, 710, 695},
            {1020, 825, 670, 565, 495, 495},
            {985, 750, 565, 425, 350, 325},
            {975, 710, 495, 350, 280, 275},
            {970, 695, 495, 325, 275, 255}
        };

        private static double[,] temperatureH400R30 =
        {
            {827, 723, 690, 670, 662, 660, 659, 659, 659, 659, 659},
            {723, 491, 378, 329, 311, 306, 304, 304, 304, 304, 304},
            {690, 378, 222, 154, 135, 131, 130, 130, 130, 130, 130},
            {670, 329, 154, 88, 71, 65, 63, 63, 62, 62, 62},
            {662, 311, 135, 71, 51, 43, 40, 39, 38, 38, 38},
            {660, 306, 131, 65, 43, 33, 29, 28, 27, 27, 27},
            {659, 340, 130, 63, 40, 29, 25, 24, 23, 23, 23},
            {659, 304, 130, 63, 39, 28, 24, 22, 21, 21, 21},
            {659, 304, 130, 62, 38, 27, 23, 21, 21, 20, 20},
            {659, 304, 130, 62, 38, 27, 23, 21, 20, 20, 20},
            {659, 304, 130, 62, 38, 27, 23, 21, 20, 20, 20}
        };

        private static double[,] temperatureH400R45 =
{
            {880, 808, 784, 766, 758, 754, 752, 752, 752, 752, 752},
            {808, 612, 506, 452, 426, 414, 408, 406, 406, 406, 406},
            {784, 456, 354, 274, 238, 222, 216, 213, 212, 212, 212},
            {766, 452, 274, 186, 143, 122, 113, 110, 108, 108, 108},
            {758, 426, 238, 143, 95, 74, 67, 64, 62, 61, 61},
            {754, 414, 222, 122, 74, 56, 48, 44, 42, 42, 42},
            {752, 426, 216, 113, 67, 48, 39, 35, 32, 32, 32},
            {752, 406, 213, 110, 64, 44, 35, 30, 28, 26, 26},
            {752, 406, 212, 108, 62, 42, 32, 28, 26, 24, 24},
            {752, 406, 212, 108, 61, 42, 32, 26, 24, 22, 22},
            {752, 406, 212, 108, 61, 42, 32, 26, 24, 22, 22}
        };

        private static double[,] temperatureH400R60 =
        {
            {933, 894, 877, 861, 853, 848, 846, 845, 844, 844, 844},
            {894, 734, 634, 574, 540, 522, 513, 509, 508, 508, 507},
            {877, 534, 485, 394, 342, 314, 301, 296, 294, 293, 293},
            {861, 574, 394, 283, 215, 178, 163, 157, 154, 154, 153},
            {853, 540, 342, 215, 139, 106, 94, 88, 85, 84, 84},
            {848, 522, 314, 178, 106, 79, 67, 61, 58, 56, 56},
            {846, 513, 301, 163, 94, 67, 53, 46, 42, 41, 40},
            {845, 509, 296, 157, 88, 61, 46, 38, 34, 32, 31},
            {844, 508, 294, 154, 85, 58, 42, 34, 30, 28, 27},
            {844, 508, 293, 154, 84, 56, 41, 32, 28, 25, 25},
            {844, 507, 293, 153, 84, 56, 40, 31, 27, 25, 24}
        };

        private static double[,] temperatureH400R90 =
        {
            {1002, 974, 964, 952, 944, 939, 936, 935, 934, 933, 933},
            {974, 855, 769, 712, 674, 651, 637, 629, 625, 623, 623},
            {964, 769, 637, 549, 490, 453, 431, 418, 412, 409, 408},
            {952, 712, 549, 438, 363, 315, 286, 270, 262, 258, 257},
            {944, 674, 490, 363, 277, 219, 183, 164, 156, 152, 151},
            {939, 651, 453, 315, 219, 153, 119, 105, 98, 94, 93},
            {936, 637, 431, 286, 183, 119, 91, 79, 72, 69, 68},
            {935, 629, 418, 270, 164, 105, 79, 66, 58, 54, 53},
            {934, 625, 412, 262, 156, 98, 72, 58, 49, 45, 44},
            {933, 623, 409, 258, 152, 94, 69, 54, 45, 41, 39},
            {933, 623, 408, 257, 151, 93, 68, 53, 44, 39, 38}
        };

        private static double[,] temperatureH400R120 =
        {
            {1046, 1026, 1018, 1008, 1002, 998, 995, 993, 992, 992, 992},
            {1026, 932, 859, 805, 768, 741, 724, 714, 707, 704, 703},
            {1018, 859, 740, 656, 597, 556, 529, 512, 502, 496, 495},
            {1008, 805, 656, 550, 474, 422, 386, 364, 350, 343, 341},
            {1002, 768, 597, 474, 386, 324, 281, 254, 238, 230, 227},
            {998, 742, 556, 422, 324, 254, 204, 172, 155, 147, 144},
            {995, 724, 529, 386, 281, 204, 150, 120, 107, 101, 99},
            {993, 714, 512, 364, 254, 172, 120, 96, 85, 81, 79},
            {992, 707, 502, 350, 238, 155, 107, 85, 75, 69, 67},
            {992, 704, 496, 343, 230, 147, 101, 81, 69, 63, 62},
            {992, 703, 495, 341, 227, 144, 99, 79, 67, 61, 59}
        };

        private static double[,] temperatureH400R150 =
        {
            {1077, 1060, 1054, 1045, 1040, 1036, 1033, 1031, 1030, 1030, 1030},
            {1060, 980, 916, 867, 832, 806, 788, 776, 768, 764, 763},
            {1054, 916, 808, 729, 671, 630, 602, 582, 570, 563, 561},
            {1045, 867, 729, 628, 554, 501, 463, 438, 421, 412, 410},
            {1040, 832, 671, 554, 467, 404, 359, 328, 309, 298, 295},
            {1036, 806, 630, 501, 404, 333, 281, 245, 223, 212, 208},
            {1033, 788, 602, 463, 359, 281, 224, 187, 165, 153, 149},
            {1031, 776, 582, 438, 328, 245, 187, 151, 128, 116, 112},
            {1030, 768, 570, 421, 309, 223, 165, 128, 105, 94, 90},
            {1030, 764, 563, 412, 298, 212, 153, 116, 94, 84, 82},
            {1030, 763, 561, 410, 295, 208, 149, 112, 90, 81, 79}
        };

        private static double[,] deepCriticalTemperatureConcreteSilicate =
        {
            {15, 11, 8, 6, 6, 6, 6, 6, 6},
            {22, 18, 15, 13, 13, 13, 13, 13, 13},
            {29, 25, 22, 20, 20, 20, 20, 20, 20},
            {48, 40, 35, 32, 29, 28, 28, 28, 28},
            {62, 54, 46, 42, 39, 38, 38, 38, 38},
            {70, 62, 55, 52, 48, 47, 46, 45, 44}
        };

        private static double[,] deepCriticalTemperatureConcreteCarbonate =
        {
            {8, 5, 3, 3, 3, 3, 3, 3, 3},
            {15, 12, 8, 7, 7, 7, 7, 7, 7},
            {22, 18, 13, 11, 11, 11, 11, 11, 11},
            {36, 30, 26, 23, 20, 20, 18, 18, 18},
            {53, 45, 35, 32, 28, 27, 26, 26, 25},
            {66, 53, 45, 40, 37, 35, 33, 32, 31}
        };
    }
}
