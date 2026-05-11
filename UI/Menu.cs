using CityDriveManager.Models;
using CityDriveManager.Services;

namespace CityDriveManager.UI;

public class Menu
{
    private readonly CityService _service;

    public Menu(CityService service)
    {
        _service = service;
    }

    public void Run()
    {
        while (true)
        {
            PrintHeader();
            string? choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1": AddPointOfInterest(); break;
                case "2": AddVehicle(); break;
                case "3": DisplayVehicles(); break;
                case "4": DisplayPoints(); break;
                case "5": CalculateDistance(); break;
                case "6": SimulateDriving(); break;
                case "7": CreateTrip(); break;
                case "8": DisplayTrips(); break;
                case "9":
                    Console.WriteLine("\nFermeture du programme...");
                    Console.WriteLine("Merci d'avoir utilisé City Drive Manager 🚗");
                    return;
                default:
                    Console.WriteLine("⚠ Choix invalide. Veuillez entrer un chiffre entre 1 et 9.");
                    break;
            }

            Console.WriteLine("\nAppuyez sur Entrée pour continuer...");
            Console.ReadLine();
        }
    }

    // ── Header ─────────────────────────────────────────────────────────────────

    private static void PrintHeader()
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("     CITY DRIVE MANAGER - SMART CITY");
        Console.WriteLine("========================================\n");
        Console.WriteLine("1. Ajouter un point d'intérêt");
        Console.WriteLine("2. Ajouter un véhicule");
        Console.WriteLine("3. Afficher les véhicules");
        Console.WriteLine("4. Afficher les lieux");
        Console.WriteLine("5. Calculer une distance");
        Console.WriteLine("6. Simuler accélération / freinage");
        Console.WriteLine("7. Créer un trajet");
        Console.WriteLine("8. Afficher les trajets");
        Console.WriteLine("9. Quitter\n");
        Console.Write("Choix : ");
    }

    // ── 1. Ajouter point d'intérêt ─────────────────────────────────────────────

    private void AddPointOfInterest()
    {
        Console.WriteLine("\n--- Ajouter un point d'intérêt ---\n");

        int type = ReadInt("Type (1 = Campus, 2 = Monument) : ", 1, 2);
        string name = ReadString("Nom : ");
        double lat = ReadDouble("Latitude : ");
        double lon = ReadDouble("Longitude : ");

        PointOfInterest poi;

        if (type == 1)
        {
            int capacity = ReadInt("Capacité : ", 1, int.MaxValue);
            poi = new Campus(name, lat, lon, capacity);
        }
        else
        {
            int year = ReadInt("Année de construction : ", 1, DateTime.Now.Year);
            poi = new HistoricalMonument(name, lat, lon, year);
        }

        if (_service.AddPoint(poi))
            Console.WriteLine("\n✓ Point ajouté avec succès !");
    }

    // ── 2. Ajouter véhicule ────────────────────────────────────────────────────

    private void AddVehicle()
    {
        Console.WriteLine("\n--- Ajouter un véhicule ---\n");

        int type = ReadInt("Type (1 = Car, 2 = Truck, 3 = HybridCar) : ", 1, 3);
        string brand = ReadString("Marque : ");
        string color = ReadString("Couleur : ");

        Vehicle vehicle;

        switch (type)
        {
            case 1:
                string model = ReadString("Modèle : ");
                vehicle = new Car(brand, color, model);
                break;
            case 2:
                double tonnage = ReadDouble("Tonnage (T) : ");
                vehicle = new Truck(brand, color, tonnage);
                break;
            default:
                double battery = ReadDouble("Niveau batterie (%) : ");
                double fuel = ReadDouble("Niveau carburant (L) : ");
                vehicle = new HybridCar(brand, color, battery, fuel);
                break;
        }

        _service.AddVehicle(vehicle);
        Console.WriteLine("\n✓ Véhicule ajouté !");
    }

    // ── 3. Afficher véhicules ──────────────────────────────────────────────────

    private void DisplayVehicles()
    {
        Console.WriteLine("\n--- Liste des véhicules ---\n");

        if (_service.Vehicles.Count == 0)
        {
            Console.WriteLine("Aucun véhicule enregistré.");
            return;
        }

        for (int i = 0; i < _service.Vehicles.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {_service.Vehicles[i]}");
            Console.WriteLine("----------------------------");
        }
    }

    // ── 4. Afficher lieux ──────────────────────────────────────────────────────

    private void DisplayPoints()
    {
        Console.WriteLine("\n--- Points d'intérêt ---\n");

        if (_service.Points.Count == 0)
        {
            Console.WriteLine("Aucun lieu enregistré.");
            return;
        }

        for (int i = 0; i < _service.Points.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {_service.Points[i]}");
            Console.WriteLine("----------------------------");
        }
    }

    // ── 5. Calculer distance ───────────────────────────────────────────────────

    private void CalculateDistance()
    {
        Console.WriteLine("\n--- Calculer une distance ---\n");

        if (_service.Points.Count < 2)
        {
            Console.WriteLine("⚠ Il faut au moins 2 lieux enregistrés.");
            return;
        }

        DisplayPoints();

        int idx1 = ReadInt("Index du lieu de départ : ", 1, _service.Points.Count);
        int idx2 = ReadInt("Index du lieu d'arrivée : ", 1, _service.Points.Count);

        var p1 = _service.GetPoint(idx1)!;
        var p2 = _service.GetPoint(idx2)!;

        double dist = p1.CalculateDistance(p2);
        Console.WriteLine($"\nDistance entre {p1.Name} et {p2.Name} : {dist} km");
    }

    // ── 6. Simuler accélération/freinage ───────────────────────────────────────

    private void SimulateDriving()
    {
        Console.WriteLine("\n--- Simuler accélération / freinage ---\n");

        if (_service.Vehicles.Count == 0)
        {
            Console.WriteLine("⚠ Aucun véhicule disponible.");
            return;
        }

        DisplayVehicles();

        int vIdx = ReadInt("Choisir véhicule (index) : ", 1, _service.Vehicles.Count);
        var vehicle = _service.GetVehicle(vIdx)!;

        Console.WriteLine("\n1. Accélérer\n2. Freiner");
        int action = ReadInt("Choix : ", 1, 2);

        if (action == 1)
        {
            vehicle.Accelerate();
            Console.WriteLine($"\n✓ Le véhicule accélère...");
            Console.WriteLine($"Vitesse actuelle : {vehicle.CurrentSpeed} km/h");

            if (vehicle is HybridCar hc)
                Console.WriteLine($"Batterie restante : {hc.BatteryLevel}%");
        }
        else
        {
            vehicle.Brake();
            Console.WriteLine($"\n✓ Freinage en cours...");
            Console.WriteLine($"Vitesse actuelle : {vehicle.CurrentSpeed} km/h");
        }
    }

    // ── 7. Créer trajet ────────────────────────────────────────────────────────

    private void CreateTrip()
    {
        Console.WriteLine("\n--- Créer un trajet ---\n");

        if (_service.Vehicles.Count == 0 || _service.Points.Count < 2)
        {
            Console.WriteLine("⚠ Il faut au moins 1 véhicule et 2 lieux.");
            return;
        }

        DisplayVehicles();
        int vIdx = ReadInt("Véhicule (index) : ", 1, _service.Vehicles.Count);

        DisplayPoints();
        int pDep = ReadInt("Point de départ : ", 1, _service.Points.Count);
        int pArr = ReadInt("Point d'arrivée : ", 1, _service.Points.Count);

        DateTime date = ReadDateTime("Date de départ (yyyy-MM-dd HH:mm) : ");

        var trip = new Trip(
            _service.GetVehicle(vIdx)!,
            _service.GetPoint(pDep)!,
            _service.GetPoint(pArr)!,
            date
        );

        _service.AddTrip(trip);
        Console.WriteLine("\n✓ Trajet créé !");
    }

    // ── 8. Afficher trajets ────────────────────────────────────────────────────

    private void DisplayTrips()
    {
        Console.WriteLine("\n--- Liste des trajets ---\n");

        if (_service.Trips.Count == 0)
        {
            Console.WriteLine("Aucun trajet enregistré.");
            return;
        }

        for (int i = 0; i < _service.Trips.Count; i++)
        {
            Console.WriteLine($"Trajet #{i + 1}");
            Console.WriteLine(_service.Trips[i]);
            Console.WriteLine("----------------------------");
        }
    }

    // ── Helpers de saisie ──────────────────────────────────────────────────────

    private static string ReadString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? value = Console.ReadLine()?.Trim().ToUpper();
            if (!string.IsNullOrWhiteSpace(value))
                return value;
            Console.WriteLine("⚠ La saisie ne peut pas être vide.");
        }
    }

    private static int ReadInt(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                return value;
            Console.WriteLine($"⚠ Veuillez entrer un entier entre {min} et {max}.");
        }
    }

    private static double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine()?.Replace(',', '.'),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out double value) && value >= 0)
                return value;
            Console.WriteLine("⚠ Veuillez entrer un nombre positif.");
        }
    }

    private static DateTime ReadDateTime(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine()?.Trim();
            if (DateTime.TryParseExact(input, "yyyy-MM-dd HH:mm",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime dt))
                return dt;
            Console.WriteLine("⚠ Format invalide. Utilisez : yyyy-MM-dd HH:mm");
        }
    }
}
