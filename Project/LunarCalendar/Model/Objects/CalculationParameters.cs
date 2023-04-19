using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public  class CalculationParameters
    {
        public const double DegMinute = (double)1 / 60;
        public double JdFrom { get; set; }
        public double JdTo { get; set; }
        public Coordinates? Coordinates { get; set; }
        public AstroObject[] Planets { get; set; }
        public bool Topocentric { get; set; }
        public double EpsDeg { get; set; }

        public CalculationParameters(double jdFrom, double jdTo, Coordinates? coordinates = null, bool septener = true, bool topocentric = false, double eps = DegMinute)
        {
            JdFrom = jdFrom;
            JdTo = jdTo;
            Coordinates = coordinates;
            Planets = septener ? InterestingPlanets.Septener : InterestingPlanets.All;
            Topocentric = topocentric;
            EpsDeg = eps;
        }
    }
}
