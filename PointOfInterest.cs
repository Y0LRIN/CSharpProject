using System;
using System.Globalization;

namespace CSharpDiscovery.Quest03
{
    public class PointOfInterest
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public static string GoogleMapsUrlTemplate { get; } =
            "https://www.google.com/maps/place/{0}/@{1},{2},15z/";

        public PointOfInterest()
        {
            Name = "Bordeaux Ynov Campus";
            Latitude = 44.854186;
            Longitude = -0.5663056;
        }

        public PointOfInterest(string name, double latitude, double longitude)
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }

        public string GetGoogleMapsUrl()
        {
            string formattedName = Name.Replace(" ", "+");
            string lat = Latitude.ToString(CultureInfo.InvariantCulture);
            string lon = Longitude.ToString(CultureInfo.InvariantCulture);
            return string.Format(GoogleMapsUrlTemplate, formattedName, lat, lon);
        }

        public override string ToString()
        {
            string lat = Latitude.ToString(CultureInfo.InvariantCulture);
            string lon = Longitude.ToString(CultureInfo.InvariantCulture);
            return $"{Name} (Lat={lat}, Long={lon})";
        }

        public int GetDistance(PointOfInterest other)
        {
            return GetDistance(this, other);
        }

        public static int GetDistance(PointOfInterest p1, PointOfInterest p2)
        {
            const double EarthRadiusKm = 6371.0;

            double lat1 = p1.Latitude * Math.PI / 180.0;
            double lat2 = p2.Latitude * Math.PI / 180.0;
            double deltaLat = (p2.Latitude - p1.Latitude) * Math.PI / 180.0;
            double deltaLon = (p2.Longitude - p1.Longitude) * Math.PI / 180.0;

            double a =
                Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2)
                + Math.Cos(lat1) * Math.Cos(lat2) * Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return (int)Math.Round(EarthRadiusKm * c);
        }
    }
}
