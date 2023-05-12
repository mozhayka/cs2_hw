using Objects;

namespace Calculator
{
    // The Single Responsibility Principle - все классы в проекте Calculator выполняют только свою задачу
    
    public class DayInformationCalculator : IDayInformationCalculator
    {
        // Dependency Inversion Principle - связываемся с AspectsCalculator через интерфейс
        private readonly IAspectCalculator _AspectCalculator;
        private readonly ILBKCalculator _LBKCalculator;
        private readonly ILunarPositionCalculator _LunarCalculator;

        public DayInformationCalculator(IAspectCalculator aspectCalculator, ILBKCalculator lbkCalculator, ILunarPositionCalculator lunarCalculator)
        {
            _AspectCalculator = aspectCalculator;
            _LBKCalculator = lbkCalculator;
            _LunarCalculator = lunarCalculator;
        }

        public DayInformation Calculate(CalculationParameters parameters)
        {
            var listOfAspects = _AspectCalculator.FindLunarAspects(parameters);
            var lunarPosition = _LunarCalculator.LunarInformation(parameters);
            var lbkSeptener = _LBKCalculator.FindAllLBK(parameters, true);
            var lbkAll = _LBKCalculator.FindAllLBK(parameters, false);

            return new DayInformation(parameters, lunarPosition, listOfAspects, lbkSeptener, lbkAll);
        }
    }
}
