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

        public CalculationParameters(double jdFrom, double jdTo, bool septener = true, Coordinates? coordinates = null, bool topocentric = false, double eps = DegMinute)
        {
            JdFrom = jdFrom;
            JdTo = jdTo;
            Coordinates = coordinates;
            Planets = septener ? InterestingPlanets.Septener : InterestingPlanets.All;
            Topocentric = topocentric;
            EpsDeg = eps;
        }

        public CalculationParameters(double jdFrom, double jdTo, CalculationParameters parameters)
        {
            JdFrom = jdFrom;
            JdTo = jdTo;
            Coordinates = parameters.Coordinates;
            Planets = parameters.Planets;
            Topocentric = parameters.Topocentric;
            EpsDeg = parameters.EpsDeg;
        }
    }
}
