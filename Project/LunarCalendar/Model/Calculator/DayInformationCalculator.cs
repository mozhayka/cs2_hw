using Objects;

namespace Calculator
{
    // The Single Responsibility Principle - все классы в проекте Calculator выполняют только свою задачу
    
    public class DayInformationCalculator : IDayInformationCalculator
    {
        // Dependency Inversion Principle - связываемся с AspectsCalculator через интерфейс
        private readonly IAspectCalculator _AspectCalculator;
        private readonly ILBKCalculator _LBKCalculator;

/*        public DayInformationCalculator()
            : this(new AspectsCalculator(), new LBKCalculator())
        { }*/

        public DayInformationCalculator(IAspectCalculator aspectCalculator, ILBKCalculator lbkCalculator)
        {
            _AspectCalculator = aspectCalculator;
            _LBKCalculator = lbkCalculator;
        }

        public DayInformation Calculate(CalculationParameters parameters)
        {
            var listOfAspects = _AspectCalculator.FindLunarAspects(parameters);
            var lbk = _LBKCalculator.FindAllLBK(parameters);
            return new DayInformation(TimeCalculator.FromJulDay(parameters.JdFrom), parameters.Coordinates, listOfAspects, lbk);
        }
    }
}
