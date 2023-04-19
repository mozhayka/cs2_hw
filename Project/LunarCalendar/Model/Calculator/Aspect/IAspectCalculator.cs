using Objects;

namespace Calculator
{
    public interface IAspectCalculator
    {
        public List<LunarAspect> FindLunarAspects(CalculationParameters parameters);
    }
}
