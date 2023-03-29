using Objects;

namespace Calculator
{
    public interface IAspectCalculator
    {
        public List<Aspect> FindAllAspects(DateTime day, Coordinates coorinates);
    }
}
