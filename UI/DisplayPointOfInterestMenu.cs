public class DisplayPointOfInterestMenu : Menu
{
    private void DisplayPoints()
    {
        Console.WriteLine("=== Points d'intérêt enregistrés ===");

        if (points.Count == 0)
        {
            Console.WriteLine("  Aucun lieu.");
            return;
        }
        for (int i = 0; i < points.Count; i++)
            Console.WriteLine($"  {i + 1}. {points[i]}");
    }
}

