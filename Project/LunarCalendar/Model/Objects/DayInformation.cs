namespace Objects
{
    public class DayInformation
    {
        public DateTime Date { get; set; }
        public string? Coordinates { get; set; }
        public List<Aspect>? Aspects { get; set; }
        public LBK? LBK { get; set; }

    }
}