using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects;

namespace Calculator.Helper
{
    internal interface IPlanetPositionCalculator
    {
        public double CalculatePosition(AstroObject planet, double jd);
    }
}
