namespace Objects
{
    public class LBK
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public LBK(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }
    }
}
