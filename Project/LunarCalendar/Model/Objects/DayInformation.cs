namespace Objects
{
    public class DayInformation
    {
        public DateTime Date { get; set; }
        public Coordinates Coordinates { get; set; }
        public List<LunarAspect> LunarAspects { get; set; }
        public List<LBK> LBK { get; set; }

        public DayInformation(DateTime date, Coordinates coordinates, List<LunarAspect> lunarAspects, List<LBK> lBK)
        {
            Date = date;
            Coordinates = coordinates;
            LunarAspects = lunarAspects;
            LBK = lBK;
        }
    }
}
