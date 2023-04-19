using Objects;

namespace Calculator
{
    public interface ILBKCalculator
    {
        public List<LBK> FindAllLBK(CalculationParameters parameters);
        public double NextLunarSignTime(double jd, Coordinates? coordinates = null, bool topocentric = false);
    }
}
