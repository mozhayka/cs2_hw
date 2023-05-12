using Objects;

namespace ConsoleUI.ConsoleRunner
{
    internal interface IReader
    {
        public DateTime ReadDate();
        public Coordinates ReadCoordinates();
    }
}
