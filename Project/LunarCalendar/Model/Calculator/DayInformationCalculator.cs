using Objects;

namespace Calculator
{
    // The Single Responsibility Principle - все классы в проекте Calculator выполняют только свою задачу
    
    public class DayInformationCalculator : IDayInformationCalculator
    {
        // Dependency Inversion Principle - связываемся с AspectsCalculator через интерфейс
        private readonly IAspectCalculator _AspectCalculator;
        private readonly ILBKCalculator _LBKCalculator;

        public DayInformationCalculator()
            : this(new AspectsCalculator(), new LBKCalculator())
        { }

        internal DayInformationCalculator(IAspectCalculator aspectCalculator, ILBKCalculator lbkCalculator)
        {
            _AspectCalculator = aspectCalculator;
            _LBKCalculator = lbkCalculator;
        }

        public DayInformation Calculate(DateTime day, Coordinates coordinates)
        {
            var listOfAspects = _AspectCalculator.FindAllAspects(day, coordinates);
            var lbk = _LBKCalculator.FindAllLBK(day, coordinates);
            return new DayInformation(day, coordinates, listOfAspects, lbk);
        }
    }
}
