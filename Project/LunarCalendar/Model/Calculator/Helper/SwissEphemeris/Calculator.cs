using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.SwissEphemeris;
using Objects;

namespace Calculator.SwissEphemeris
{
    internal class Calculator
    {

        public double GetJulianDate(DateTime utcDate)
        {
            return TimeCalculator.GetJulDay(utcDate);
        }

        public double CalcMoon(double jd, double latitude, double longitude)
        {
            // Положение Луны в карте рождения
            var moon_xx = new double[6];
            var moon_serr = new StringBuilder(1000);

            SwEph.swe_set_topo(longitude, latitude, 0);
            SwEph.swe_calc_ut(jd, SwEph.SE_MOON, SEFLG.SEFLG_TOPOCTR, moon_xx, moon_serr);

            return moon_xx[0];
        }

        public double CalcSun(double jd, double latitude, double longitude)
        {
            //Положение Солнца в карте рождения
            var sun_xx = new double[6];
            var sun_serr = new StringBuilder(1000);
            SwEph.swe_calc_ut(jd, SwEph.SE_SUN, 0, sun_xx, sun_serr);

            return sun_xx[0];
        }

        public double CalcMerc(double jd, double latitude, double longitude)
        {
            var merc_xx = new double[6];
            var merc_serr = new StringBuilder(1000);
            SwEph.swe_calc_ut(jd, SwEph.SE_MERCURY, 0, merc_xx, merc_serr);

            return merc_xx[0];
        }

        public double CalcVenus(double jd, double latitude, double longitude)
        {
            var venus_xx = new double[6];
            var venus_serr = new StringBuilder(1000);
            SwEph.swe_calc_ut(jd, SwEph.SE_VENUS, 0, venus_xx, venus_serr);

            return venus_xx[0];
        }

        public double CalcMars(double jd, double latitude, double longitude)
        {
            var mars_xx = new double[6];
            var mars_serr = new StringBuilder(1000);
            SwEph.swe_calc_ut(jd, SwEph.SE_MARS, 0, mars_xx, mars_serr);

            return mars_xx[0];
        }

        public double CalcJupiter(double jd, double latitude, double longitude)
        {
            var jup_xx = new double[6];
            var jup_serr = new StringBuilder(1000);
            SwEph.swe_calc_ut(jd, SwEph.SE_JUPITER, 0, jup_xx, jup_serr);

            return jup_xx[0];
        }

        public double CalcSaturn(double jd, double latitude, double longitude)
        {
            var saturn_xx = new double[6];
            var saturn_serr = new StringBuilder(1000);
            SwEph.swe_calc_ut(jd, SwEph.SE_SATURN, 0, saturn_xx, saturn_serr);

            return saturn_xx[0];
        }

        public double CalcUran(double jd, double latitude, double longitude)
        {
            var uran_xx = new double[6];
            var uran_serr = new StringBuilder(1000);
            SwEph.swe_calc_ut(jd, SwEph.SE_URANUS, 0, uran_xx, uran_serr);

            return uran_xx[0];
        }

        public double CalcNeptun(double jd, double latitude, double longitude)
        {
            var nept_xx = new double[6];
            var nept_serr = new StringBuilder(1000);
            SwEph.swe_calc_ut(jd, SwEph.SE_NEPTUNE, 0, nept_xx, nept_serr);

            return nept_xx[0];
        }

        public double CalcPluto(double jd, double latitude, double longitude)
        {
            var pluto_xx = new double[6];
            var pluto_serr = new StringBuilder(1000);
            SwEph.swe_calc_ut(jd, SwEph.SE_PLUTO, 0, pluto_xx, pluto_serr);

            return pluto_xx[0];
        }

        public double CalcNode(double jd, double latitude, double longitude)
        {
            var node_xx = new double[6];
            var node_serr = new StringBuilder(1000);
            SwEph.swe_calc_ut(jd, SwEph.SE_TRUE_NODE, 0, node_xx, node_serr);

            return node_xx[0];
        }

        public double CalcLilit(double jd, double latitude, double longitude)
        {
            var lilit_xx = new double[6];
            var lilit_serr = new StringBuilder(1000);
            SwEph.swe_calc_ut(jd, SwEph.SE_LILIT, 0, lilit_xx, lilit_serr);

            return lilit_xx[0];
        }

        public double CalcPlanet(AstroObject planet, double jd, double latitude, double longitude)
        {
            return planet switch
            {
                AstroObject.Sun => CalcSun(jd, latitude, longitude),
                AstroObject.Mercury => CalcMerc(jd, latitude, longitude),
                AstroObject.Venus => CalcVenus(jd, latitude, longitude),
                AstroObject.Mars => CalcMars(jd, latitude, longitude),
                AstroObject.Jupiter => CalcJupiter(jd, latitude, longitude),
                AstroObject.Saturn => CalcSaturn(jd, latitude, longitude),
                AstroObject.Uranus => CalcUran(jd, latitude, longitude),
                AstroObject.Neptune => CalcNeptun(jd, latitude, longitude),
                AstroObject.Pluto => CalcPluto(jd, latitude, longitude),
                AstroObject.Moon => CalcMoon(jd, latitude, longitude),
                _ => throw new Exception("Unknow astro object"),
            };
        }

        public double CalcNextSolarEclipse(double jd)
        {
            var ifl = 4;
            var ifltype = 0;
            var tret = new double[10];
            var backwards = 0;
            var serr = new StringBuilder(1000);

            SwEph.swe_sol_eclipse_when_glob(jd, ifl, ifltype, tret, backwards, serr);
            double next_solar_eclipse = tret[0];
            return next_solar_eclipse;
        }

        public double CalcNextLunarEclipse(double jd)
        {
            var ifl = 4;
            var ifltype = 0;
            var tret = new double[10];
            var backwards = 0;
            var serr = new StringBuilder(1000);

            SwEph.swe_lun_eclipse_when(jd, ifl, ifltype, tret, backwards, serr);
            double next_lunar_eclipse = tret[0];
            return next_lunar_eclipse;
        }
    }
}
