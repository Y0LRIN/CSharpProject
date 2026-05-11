public class AddCarsMenu : Menu
{
private void AddVehicle()
    {
        Console.WriteLine("=== Ajouter un véhicule ===");
        Console.WriteLine("  1. Voiture (Car)");
        Console.WriteLine("  2. Camion (Truck)");
        Console.WriteLine("  3. Voiture hybride (HybridCar)");
        int type = ReadInt("  Type : ");

        string brand = ReadString("  Marque : ");
        string color = ReadString("  Couleur : ");

        Vehicle? vehicle = null;
        switch (type)
        {
            case 1:
                string carModel = ReadString("  Modèle : ");
                vehicle = new Car(brand, color, carModel);
                break;
            case 2:
                double tonnage = ReadDouble("  Tonnage (t) : ");
                vehicle = new Truck(brand, color, tonnage);
                break;
            case 3:
                string hybridModel = ReadString("  Modèle : ");
                double battery = ReadDouble("  Niveau batterie initial (%) : ");
                double fuel    = ReadDouble("  Niveau carburant initial (L) : ");
                vehicle = new HybridCar(brand, color, hybridModel, battery, fuel);
                break;
            default:
                Console.WriteLine("  ⚠ Type invalide.");
                return;
        }

        
        Console.WriteLine($"  ✓ Véhicule ajouté : {vehicle}");
    }
}