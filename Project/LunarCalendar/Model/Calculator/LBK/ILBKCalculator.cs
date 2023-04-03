using Objects;

namespace Calculator
{
    public interface ILBKCalculator
    {
        public List<LBK> FindAllLBK(DateTime day, Coordinates coordinates);
    }
}
