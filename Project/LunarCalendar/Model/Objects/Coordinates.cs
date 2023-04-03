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
        public double Degrees { get; set; }
        public double Minutes { get; set; }
        public double Seconds { get; set; }

        public DMS(double degrees, double minutes, double seconds)
        {
            Degrees = degrees;
            Minutes = minutes;
            Seconds = seconds;
        }

        public double ToDegrees()
        {
            return Degrees + Minutes / 60.0 + Seconds / 3600.0;
        }
    }
}
