using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public enum Zodiac
    {
        Aries,
        Taurus,
        Gemini,

        Cancer,
        Leo,
        Virgo,

        Libra,
        Scorpio,
        Sagittarius,

        Capricornus,
        Aquarius,
        Pisces,
    }

    public static class ZodiacCalc
    {
        public static Zodiac FromAngle(double angle)
        {
            return FromSector(SectorCalc.SectorFromAngle(angle));
        }

        public static Zodiac FromSector(Sector sector)
        {
            return sector switch
            {
                Sector._0_30 => Zodiac.Aries,
                Sector._30_60 => Zodiac.Taurus,
                Sector._60_90 => Zodiac.Gemini,

                Sector._90_120 => Zodiac.Cancer,
                Sector._120_150 => Zodiac.Leo,
                Sector._150_180 => Zodiac.Virgo,

                Sector._180_210 => Zodiac.Libra,
                Sector._210_240 => Zodiac.Scorpio,
                Sector._240_270 => Zodiac.Sagittarius,

                Sector._270_300 => Zodiac.Capricornus,
                Sector._300_330 => Zodiac.Aquarius,
                Sector._330_0 => Zodiac.Pisces,

                _ => throw new Exception("Unknown sector"),
            };
        }
    }
}
