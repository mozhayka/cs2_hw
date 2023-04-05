using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public enum Sector
    {
        _0_30,
        _30_60,
        _60_90,

        _90_120,
        _120_150,
        _150_180,

        _180_210,
        _210_240,
        _240_270,

        _270_300,
        _300_330,
        _330_0,
    }

    public enum AspectSector
    {
        _0_60,
        _60_90,
        _90_120,
        _120_180,

        _180_240,
        _240_270,
        _270_300,
        _300_0,
    }

    public static class SectorCalc
    {
        public static Sector SectorFromAngle(double angle)
        {
            if (0 <= angle && angle < 30)
                return Sector._0_30;
            if (30 <= angle && angle < 60)
                return Sector._30_60;
            if (60 <= angle && angle < 90)
                return Sector._60_90;

            if (90 <= angle && angle < 120)
                return Sector._90_120;
            if (120 <= angle && angle < 150)
                return Sector._120_150;
            if (150 <= angle && angle < 180)
                return Sector._150_180;

            if (180 <= angle && angle < 210)
                return Sector._180_210;
            if (210 <= angle && angle < 240)
                return Sector._210_240;
            if (240 <= angle && angle < 270)
                return Sector._240_270;

            if (270 <= angle && angle < 300)
                return Sector._270_300;
            if (300 <= angle && angle < 330)
                return Sector._300_330;
            if (330 <= angle && angle < 360)
                return Sector._330_0;

            throw new Exception("Bad angle, should be in [0, 360)");
        }

        public static bool IsSameSectors(double angle1, double angle2)
        {
            var sector1 = SectorFromAngle(angle1);
            var sector2 = SectorFromAngle(angle2);

            return sector1 == sector2;
        }

        public static AspectSector AspectSectorFromAngle(double angle)
        {
            if (0 <= angle && angle < 60)
                return AspectSector._0_60;
            if (60 <= angle && angle < 90)
                return AspectSector._60_90;

            if (90 <= angle && angle < 120)
                return AspectSector._90_120;
            if (120 <= angle && angle < 180)
                return AspectSector._120_180;

            if (180 <= angle && angle < 240)
                return AspectSector._180_240;
            if (240 <= angle && angle < 270)
                return AspectSector._240_270;

            if (270 <= angle && angle < 300)
                return AspectSector._270_300;
            if (300 <= angle && angle < 360)
                return AspectSector._300_0;

            throw new Exception("Bad angle, should be in [0, 360)");
        }

        public static bool IsSameAspectSectors(double angle1, double angle2)
        {
            var sector1 = AspectSectorFromAngle(angle1);
            var sector2 = AspectSectorFromAngle(angle2);

            return sector1 == sector2;
        }
    }
}
