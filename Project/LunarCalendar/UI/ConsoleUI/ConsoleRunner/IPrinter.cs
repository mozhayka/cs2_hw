using Objects;

namespace ConsoleUI.ConsoleRunner
{
    internal interface IPrinter
    {
        public void Greetings();
        public void Print(DayInformation info);
    }
}
