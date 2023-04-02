using Objects;

namespace Calculator
{
    internal interface ILBKCalculator
    {
        public List<LBK> FindAllLBK(DateTime day, Coordinates coordinates);
    }
}
