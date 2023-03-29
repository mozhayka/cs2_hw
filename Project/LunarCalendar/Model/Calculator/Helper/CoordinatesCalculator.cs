using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class CoordinatesCalculator
    {
        public static double dms2deg(int deg, int minute, int second)
        {
            return deg + minute / 60.0 + second / 3600.0;
        }

        public static void deg2dms(double deg, out int d, out int m, out int s)
        {
            int sign = 1;
            if (deg < 0)
            {
                sign = -1;
                deg = -deg;
            }

            d = (int)deg * sign;
            deg = (deg - d) * 60;
            m = (int)deg;
            s = (int)((deg - m) * 60 + 0.5);
        }
    }
}
