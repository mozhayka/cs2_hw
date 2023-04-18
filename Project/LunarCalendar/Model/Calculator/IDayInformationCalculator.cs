using Objects;

namespace Calculator
{
    public interface IDayInformationCalculator
    {
        public DayInformation Calculate(DateTime day, Coordinates coordinates, bool septener = true);
    }
}
