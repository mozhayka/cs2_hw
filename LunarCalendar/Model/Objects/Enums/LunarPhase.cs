using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public enum LunarPhase
    {
        New_Moon,
        First_Quarter, 
        Full_Moon, 
        Last_Quarter, 
    }

    public static class LunarPhaseCalc
    {
        public static LunarPhase FromAngle(double moonSunAngle)
        {
            if (0 <= moonSunAngle && moonSunAngle < 90)
                return LunarPhase.New_Moon;
            if (90 <= moonSunAngle && moonSunAngle < 180)
                return LunarPhase.First_Quarter;
            if (180 <= moonSunAngle && moonSunAngle < 270)
                return LunarPhase.Full_Moon;
            if (270 <= moonSunAngle && moonSunAngle < 360)
                return LunarPhase.Last_Quarter;
            throw new Exception($"Bad moon sun angle {moonSunAngle}");
        }
    }
}
