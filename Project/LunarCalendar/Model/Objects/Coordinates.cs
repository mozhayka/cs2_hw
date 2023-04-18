namespace Objects
{
    public class Coordinates
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Geoalt { get; set; }

        public Coordinates(double longitude, double latitude, double geoalt = 0)
        {
            Longitude = longitude;
            Latitude = latitude;
            Geoalt = geoalt;
        }

        public Coordinates(DMS longitude, DMS latitude, double geoalt = 0)
            : this(longitude.ToDegrees(), latitude.ToDegrees(), geoalt)
        { }

        public Coordinates()
            : this(0, 0)
        { }
    }

    public class DMS
    {
        public int Degrees { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public DMS(int degrees, int minutes, int seconds)
        {
            Degrees = degrees;
            Minutes = minutes;
            Seconds = seconds;
        }

        public double ToDegrees()
        {
            return Degrees + Minutes / 60.0 + Seconds / 3600.0;
        }

        public override string ToString()
        {
            return $"{Degrees}♦ {Minutes}' {Seconds}''";
        }

        public static DMS FromDegrees(double deg)
        {
            var d = (int)deg;
            deg = (deg - d) * 60;
            var m = (int)deg;
            var s = (int)((deg - m) * 60 + 0.5);
            return new DMS(d, m, s);
        }
    }

    public static class InterestingCoordinates
    {
        public static readonly Coordinates SPB = new(
            new DMS(30, 18, 50), // longitude
            new DMS(59, 56, 19), // latitude
            11); // geoalt
        public static readonly Coordinates Moscow = new(
            new DMS(37, 36, 56),
            new DMS(55, 45, 07),
            144);
    }
}
