using Objects;

namespace Calculator
{
    public interface IAspectCalculator
    {
        public List<Aspect> FindAllAspects(DateTime date, Coordinates coorinates);
        public List<Aspect> FindAllAspects(double jdFrom, double jdTo, Coordinates coorinates);
    }
}
