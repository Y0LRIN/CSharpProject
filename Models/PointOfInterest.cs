namespace CityDriveManager.Models;

public abstract class PointOfInterest
{
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    protected PointOfInterest(string name, double latitude, double longitude)
    {
        Name = name;
        Latitude = latitude;
        Longitude = longitude;
    }

    public string GetGoogleMapsUrl()
    {
        return $"https://www.google.com/maps?q={Latitude},{Longitude}";
    }

    public double CalculateDistance(PointOfInterest other)
    {
        double deltalat = other.Latitude - Latitude;
        double deltaLon = other.Longitude - Longitude;
        double degrees = Math.Sqrt(deltalat * deltalat + deltaLon * deltaLon);
        return Math.Round(degrees * 111.0, 2);
    }

    public override string ToString()
    {
        return $"Nom : {Name}\n"
            + $"Coordonnées : ({Latitude}, {Longitude})\n"
            + $"Google Maps : {GetGoogleMapsUrl()}";
    }
}
