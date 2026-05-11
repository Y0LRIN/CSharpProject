public class CalculateDistanceMenu : Menu
{
    private void CalculateDistances()
    {
        Console.WriteLine("=== Calcul des Distances ===");
        var trips = _data.GetTrips();
        if (trips.Count == 0) { Console.WriteLine("  ⚠ Aucun trajet pour calculer."); return; }

        foreach (var trip in trips)
        {
            double distance = trip.CalculateDistance();
            Console.WriteLine($"  - {trip}: Distance = {distance:F2} km");
        }
    }
}