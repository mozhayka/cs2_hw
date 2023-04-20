using Objects;

namespace Calculator
{
    public interface IAspectCalculator
    {
        public List<LunarAspect> FindLunarAspects(CalculationParameters parameters);
        public List<LunarAspect> FindLunarAspects(CalculationParameters parameters, AstroObject[] planets);
        public List<LunarAspect> FindLunarAspects(double jdFrom, double jdTo, AstroObject[] planets, Coordinates? coordinates);
    }
}
