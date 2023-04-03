using System.Text;
using Calculator.Helper;
using Calculator.SwissEphemeris;
using Objects;

namespace Calculator
{
    internal class PlanetPositionCalculator : IPlanetPositionCalculator
    {
        public Coordinates? CurrentCoordinates { get; set; }
        public PlanetPositionCalculator()
        {
            // Инициализация SwEph
            SwEph.swe_set_ephe_path(null);
        }

        public double CalculatePosition(AstroObject planet, double jd, Coordinates coordinates)
        {
            if (CurrentCoordinates == null || CurrentCoordinates != coordinates)
            {
                CurrentCoordinates = coordinates;
                SwEph.swe_set_topo(coordinates.Longitude, coordinates.Latitude, coordinates.Geoalt);
            }

            return planet switch
            {
                AstroObject.Moon => CalcMoon(jd),
                AstroObject.Sun => CalcSun(jd),
                AstroObject.Mercury => CalcMerc(jd),
                AstroObject.Venus => CalcVenus(jd),
                AstroObject.Mars => CalcMars(jd),
                AstroObject.Jupiter => CalcJupiter(jd),
                AstroObject.Saturn => CalcSaturn(jd),
                AstroObject.Uranus => CalcUran(jd),
                AstroObject.Neptune => CalcNeptun(jd),
                AstroObject.Pluto => CalcPluto(jd),
                _ => throw new Exception("Unknow astro object"),
            };
        }

        private double CalcMoon(double jd)
        {
            var moon_xx = new double[6];
            var moon_serr = new StringBuilder(1000);
            SwEph.swe_calc_ut(jd, SwEph.SE_MOON, SEFLG.SEFLG_TOPOCTR, moon_xx, moon_serr);

            return moon_xx[0];
        }

        private double CalcSun(double jd)
        {
            var sun_xx = new double[6];
            var sun_serr = new StringBuilder(1000);
            SwEph.swe_calc_ut(jd, SwEph.SE_SUN, 0, sun_xx, sun_serr);

            return sun_xx[0];
        }

        private double CalcMerc(double jd)
        {
            var merc_xx = new double[6];
            var merc_serr = new StringBuilder(1000);
            SwEph.swe_calc_ut(jd, SwEph.SE_MERCURY, 0, merc_xx, merc_serr);

            return merc_xx[0];
        }

        private double CalcVenus(double jd)
        {
            var venus_xx = new double[6];
            var venus_serr = new StringBuilder(1000);
            SwEph.swe_calc_ut(jd, SwEph.SE_VENUS, 0, venus_xx, venus_serr);

            return venus_xx[0];
        }

        private double CalcMars(double jd)
        {
            var mars_xx = new double[6];
            var mars_serr = new StringBuilder(1000);
            SwEph.swe_calc_ut(jd, SwEph.SE_MARS, 0, mars_xx, mars_serr);

            return mars_xx[0];
        }

        private double CalcJupiter(double jd)
        {
            var jup_xx = new double[6];
            var jup_serr = new StringBuilder(1000);
            SwEph.swe_calc_ut(jd, SwEph.SE_JUPITER, 0, jup_xx, jup_serr);

            return jup_xx[0];
        }

        private double CalcSaturn(double jd)
        {
            var saturn_xx = new double[6];
            var saturn_serr = new StringBuilder(1000);
            SwEph.swe_calc_ut(jd, SwEph.SE_SATURN, 0, saturn_xx, saturn_serr);

            return saturn_xx[0];
        }

        private double CalcUran(double jd)
        {
            var uran_xx = new double[6];
            var uran_serr = new StringBuilder(1000);
            SwEph.swe_calc_ut(jd, SwEph.SE_URANUS, 0, uran_xx, uran_serr);

            return uran_xx[0];
        }

        private double CalcNeptun(double jd)
        {
            var nept_xx = new double[6];
            var nept_serr = new StringBuilder(1000);
            SwEph.swe_calc_ut(jd, SwEph.SE_NEPTUNE, 0, nept_xx, nept_serr);

            return nept_xx[0];
        }

        private double CalcPluto(double jd)
        {
            var pluto_xx = new double[6];
            var pluto_serr = new StringBuilder(1000);
            SwEph.swe_calc_ut(jd, SwEph.SE_PLUTO, 0, pluto_xx, pluto_serr);

            return pluto_xx[0];
        }
    }
}
