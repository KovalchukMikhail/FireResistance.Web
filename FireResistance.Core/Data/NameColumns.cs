using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Data
{
    internal static class NameColumns
    {
        public static Dictionary<int, int> TemperatureForTable { get; } = new Dictionary<int, int>
        {
            {20, 0},
            {200, 1},
            {300, 2},
            {400, 3},
            {500, 4},
            {600, 5},
            {700, 6},
            {800, 7},
        };
        public static Dictionary<int, int> LenthFromArmatureToEdgeForH200 { get; } = new Dictionary<int, int>
        {
            {0, 0},
            {10, 1},
            {20, 2},
            {30, 3},
            {40, 4},
            {50, 5},
            {60, 6},
            {70, 7},
            {80, 8},
            {90, 9},
            {100, 10}
        };

        public static Dictionary<int, int> LenthFromArmatureToEdgeForH300 { get; } = new Dictionary<int, int>
        {
            {0, 0},
            {30, 1},
            {60, 2},
            {90, 3},
            {120, 4},
            {150, 5}
        };

        public static Dictionary<int, int> LenthFromArmatureToEdgeForH400 { get; } = new Dictionary<int, int>
        {
            {0, 0},
            {20, 1},
            {40, 2},
            {60, 3},
            {80, 4},
            {100, 5},
            {120, 6},
            {140, 7},
            {160, 8},
            {180, 9},
            {200, 10}
        };


    }
}
