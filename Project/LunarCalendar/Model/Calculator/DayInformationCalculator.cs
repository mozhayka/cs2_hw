using Objects;

namespace Calculator
{
    // The Single Responsibility Principle - все классы в проекте Calculator выполняют только свою задачу
    
    internal class DayInformationCalculator
    {
        public DayInformationCalculator()
        {

        }

        public DayInformation Calculate(DateTime day, Coordinates coordinates)
        {
            CalculateAspects(day, coordinates);
            throw new NotImplementedException();
        }

        // Dependency Inversion Principle - связываемся с AspectsCalculator через интерфейс
        private List<Aspect> CalculateAspects(DateTime day, Coordinates coordinates)
        {
            IAspectCalculator aspectsCalculator = new AspectsCalculator();
            return aspectsCalculator.FindAllAspects(day, coordinates);
        }
    }
}
