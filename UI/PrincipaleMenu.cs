using (AddTrip addTrip = new AddTrip())
{
    
}

using (AddPointOfInterest addPointOfInterest = new AddPointOfInterest())
{
    
}
using (AddCars addCars = new AddCars())
{
    
}
using (CalculateDistance calculateDistance = new CalculateDistance())
{    
}
using (DisplayPoints displayPoints = new DisplayPoints())
{    
}
using (DisplayTrips displayTrips = new DisplayTrips())
{    
}
using (DisplayVehicles displayVehicles = new DisplayVehicles())
{    
}
using (SimulateDriving simulateDriving = new SimulateDriving())
{    
} 


 public class PrincipaleMenu
{
    private void PrintSeparator() => Console.WriteLine(new string('─', 50));

    public void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        bool running = true;
        while (running)
        {
            Console.Clear();
            PrintSeparator();
            Console.WriteLine(" ------------ SMART CITY MANAGER ------------ ");
            PrintSeparator();
            Console.WriteLine("  1. Ajouter un point d'intérêt");
            Console.WriteLine("  2. Ajouter un véhicule");
            Console.WriteLine("  3. Afficher les véhicules");
            Console.WriteLine("  4. Afficher les lieux");
            Console.WriteLine("  5. Calculer une distance");
            Console.WriteLine("  6. Simuler accélération / freinage");
            Console.WriteLine("  7. Créer un trajet");
            Console.WriteLine("  8. Afficher les trajets");
            Console.WriteLine("  9. Quitter");
            PrintSeparator();

            int choice = ReadInt("  Votre choix : ");
            Console.WriteLine();
            switch (choice)
            {
                case 1: AddPointOfInterest(); break;
                case 2: AddVehicle(); break;
                case 3: DisplayVehicles(); break;
                case 4: DisplayPoints(); break;
                case 5: CalculateDistance(); break;
                case 6: SimulateDriving(); break;
                case 7: CreateTrip(); break;
                case 8: DisplayTrips(); break;
                case 9: running = false; Console.WriteLine("  Au revoir ! 👋"); break;
                default: Console.WriteLine("  !!!  Option invalide !!!  "); break;
            }

            if (running)
            {
                Console.WriteLine();
                Console.Write("  Appuyez sur Entrée pour continuer...");
                Console.ReadLine();
            }
        }
    }
}