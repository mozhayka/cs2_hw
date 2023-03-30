using System.Runtime.InteropServices;
using System.Text;

namespace Calculator.SwissEphemeris
{
    [Flags]
    enum SEFLG : int
    {
        SEFLG_JPLEPH = 1,                    // use JPL ephemeris
        SEFLG_SWIEPH = 2,                    // use SWISSEPH ephemeris, default
        SEFLG_MOSEPH = 4,                    // use Moshier ephemeris

        SEFLG_HELCTR = 8,                    // return heliocentric position
        SEFLG_TRUEPOS = 16,                  // return true positions, not apparent
        SEFLG_J2000 = 32,                    // no precession, i.e. give J2000 equinox
        SEFLG_NONUT = 64,                    // no nutation, i.e. mean equinox of date
        SEFLG_SPEED3 = 128,                  // speed from 3 positions (do not use it, SEFLG_SPEED is
                                             // faster and preciser.)
        SEFLG_SPEED = 256,                   // high precision speed (analyt. comp.)
        SEFLG_NOGDEFL = 512,                 // turn off gravitational deflection
        SEFLG_NOABERR = 1024,                // turn off 'annual' aberration of light
        SEFLG_EQUATORIAL = 2048,             // equatorial positions are wanted
        SEFLG_XYZ = 4096,                    // cartesian, not polar, coordinates
        SEFLG_RADIANS = 8192,                // coordinates in radians, not degrees
        SEFLG_BARYCTR = 16384,               // barycentric positions
        SEFLG_TOPOCTR = (32 * 1024),         // topocentric positions
        SEFLG_SIDEREAL = (64 * 1024),        // sidereal positions
        SEFLG_ICRS = (128 * 1024),           // ICRS (DE406 reference frame)
        SEFLG_DPSIDEPS_1980 = (256 * 1024),  /* reproduce JPL Horizons
                                              * 1962 - today to 0.002 arcsec. */
        SEFLG_JPLHOR = SEFLG_DPSIDEPS_1980,
        SEFLG_JPLHOR_APPROX = (512 * 1024)   /* approximate JPL Horizons 1962 - today */
    }

    internal class SwEph
    {
        public const int SE_SUN = 0;
        public const int SE_MOON = 1;
        public const int SE_MERCURY = 2;
        public const int SE_VENUS = 3;
        public const int SE_MARS = 4;
        public const int SE_JUPITER = 5;
        public const int SE_SATURN = 6;
        public const int SE_URANUS = 7;
        public const int SE_NEPTUNE = 8;
        public const int SE_PLUTO = 9;


        [DllImport("swedll32.dll")]
        public static extern void swe_set_ephe_path(string path);

        [DllImport("swedll32.dll")]
        public static extern double swe_julday(int year, int mon, int mday, double hour, int gregflag);

        [DllImport("swedll32.dll")]
        public static extern void swe_revjul(double jd, int gregflag, out int jyear, out int jmon, out int jday, out double jut);

        [DllImport("swedll32.dll")]
        public static extern int swe_calc_ut(double tjd_ut, int ipl, SEFLG iflag, [In, Out] double[] xx, StringBuilder serr);

        [DllImport("swedll32.dll")]
        public static extern void swe_set_topo(double geolon, double geolat, double geoalt);
    }
}
