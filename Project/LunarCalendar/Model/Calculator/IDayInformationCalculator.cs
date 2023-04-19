using Objects;

namespace Calculator
{
    public interface IDayInformationCalculator
    {
        public DayInformation Calculate(CalculationParameters parameters);
    }
}
