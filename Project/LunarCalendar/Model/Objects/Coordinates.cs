namespace Objects
{
    public class Coordinates
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Geoalt { get; set; }

        public Coordinates(double longitude, double latitude, double geoalt)
        {
            Longitude = longitude;
            Latitude = latitude;
            Geoalt = geoalt;
        }

        public Coordinates(int lon_deg, int lon_min, int lon_sec, int lat_deg, int lat_min, int lat_sec, double geoalt = 0)
            : this(DMS2DEG(lon_deg, lon_min, lon_sec), DMS2DEG(lat_deg, lat_min, lat_sec), geoalt)
        {

        }

        private static double DMS2DEG(int deg, int minute, int second)
        {
            return deg + minute / 60.0 + second / 3600.0;
        }
    }
}
