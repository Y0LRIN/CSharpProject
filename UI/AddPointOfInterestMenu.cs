using System.Drawing;

public class AddPointOfInterestMenu : Menu
{
    private void AddPointOfInterest()
    {
        Console.WriteLine("=== Ajouter un point d'intérêt ===");
        Console.WriteLine("  1. Campus");
        Console.WriteLine("  2. Monument historique");
        int type = ReadInt("  Type : ");

        string name = ReadString("  Nom : ");
        double lat = ReadDouble("  Latitude  : ");
        double lon = ReadDouble("  Longitude : ");

        PointOfInterest? poi = type switch
        {
            1 => new Campus(name, lat, lon, ReadInt("  Capacité (personnes) : ")),
            2 => new HistoricalMonument(name, lat, lon, ReadInt("  Année de construction : ")),
            3 => null,
        };

        if (poi == null)
        {
            Console.WriteLine("  ⚠ Type invalide.");
            return;
        }

        if (success)
            Console.WriteLine($"  ✓ Point d'intérêt ajouté : {poin}");
        else
            Console.WriteLine("  ⚠ Un point d'intérêt existe déjà à ces coordonnées.");
    }
}

