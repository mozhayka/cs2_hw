namespace Objects
{
    public class DayInformation
    {
        public DateTime Date { get; set; }
        public Coordinates Coordinates { get; set; }
        public List<Aspect> Aspects { get; set; }
        public List<LBK> LBK { get; set; }

        public DayInformation(DateTime date, Coordinates coordinates, List<Aspect> aspects, List<LBK> lBK)
        {
            Date = date;
            Coordinates = coordinates;
            Aspects = aspects;
            LBK = lBK;
        }
    }
}
