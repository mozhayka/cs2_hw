using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects;

namespace Calculator
{
    public interface ILunarPositionCalculator
    {
        public DayInformation.LunarInformation LunarInformation(CalculationParameters parameters);
        public double NextLunarSignTime(double jd, Coordinates? coordinates = null);
    }
}
