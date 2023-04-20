namespace Objects
{
    public class DayInformation
    {
        public CalculationParameters Input { get; set; }
        public LunarInformation LunarPosition { get; set; }
        public List<LunarAspect> LunarAspects { get; set; }

        public List<LBK> LBKSeptener { get; set; }
        public List<LBK> LBKAll { get; set; }

        public DayInformation(CalculationParameters input, LunarInformation lunarPosition, List<LunarAspect> lunarAspects, List<LBK> lbkSeptener, List<LBK> lbkAll)
        {
            Input = input;
            LunarPosition = lunarPosition;
            LunarAspects = lunarAspects;
            LBKSeptener = lbkSeptener;
            LBKAll = lbkAll;
        }
    }

    public class LunarInformation
    {
        public DateTime? LunarIngression { get; set; }

        public Zodiac StartSign { get; set; }
        public Zodiac EndSign { get; set; }

        public LunarPhase StartPhase { get; set; }
        public LunarPhase EndPhase { get; set; }

        public LunarInformation(DateTime? lunarIngression, Zodiac startSign, Zodiac endSign, LunarPhase startPhase, LunarPhase endPhase)
        {
            LunarIngression = lunarIngression;
            StartSign = startSign;
            EndSign = endSign;
            StartPhase = startPhase;
            EndPhase = endPhase;
        }

        public LunarInformation()
        { }
    }
}
