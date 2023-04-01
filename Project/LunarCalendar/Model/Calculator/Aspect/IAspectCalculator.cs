using Objects;

namespace Calculator
{
    internal interface IAspectCalculator
    {
        public List<Aspect> FindAllAspects(DateTime day, Coordinates coorinates);
    }
}
