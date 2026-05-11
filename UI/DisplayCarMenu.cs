public class DisplayCarMenu : Menu
{
    private void DisplayVehicles()
    {
        Console.WriteLine("=== Véhicules enregistrés ===");
        var vehicles = Vehicles();
        if (vehicles.Count == 0)
        {
            Console.WriteLine("  Aucun véhicule.");
            return;
        }
        for (int i = 0; i < vehicles.Count; i++)
            Console.WriteLine($"  {i + 1}. {vehicles[i]}");
    }
}

