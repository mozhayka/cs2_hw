using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Enums
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
            if (315 <= moonSunAngle || moonSunAngle < 45)
                return LunarPhase.New_Moon;
            if (45 <= moonSunAngle && moonSunAngle < 135)
                return LunarPhase.First_Quarter;
            if (135 <= moonSunAngle && moonSunAngle < 225)
                return LunarPhase.Full_Moon;
            if (225 <= moonSunAngle && moonSunAngle < 315)
                return LunarPhase.Last_Quarter;
            throw new Exception($"Bad moon sun angle {moonSunAngle}");
        }
    }
}
