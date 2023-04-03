using Objects;

namespace ConsoleUI.ConsoleRunner
{
    internal interface IWriter
    {
        public void Greetings();
        public void Print(DayInformation info);
    }
}
