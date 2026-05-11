public class DisplayAndErrorGestionMenu : Menu
{
    private void DisplayErrors()
    {
        Console.WriteLine("=== Gestion des Erreurs ===");
        var errors = _data.GetErrors();
        if (errors.Count == 0) { Console.WriteLine("  ⚠ Aucune erreur enregistrée."); return; }

        foreach (var error in errors)
            Console.WriteLine($"  - {error}");
    }

    private void ClearErrors()
    {
        Console.WriteLine("=== Effacer les Erreurs ===");
        var errors = _data.GetErrors();
        if (errors.Count == 0) { Console.WriteLine("  ⚠ Aucune erreur à effacer."); return; }

        Console.Write("  Êtes-vous sûr de vouloir effacer toutes les erreurs ? (o/n) : ");
        string? input = Console.ReadLine()?.Trim().ToLower();
        if (input == "o" || input == "oui")
        {
            _data.ClearErrors();
            Console.WriteLine("  ✓ Toutes les erreurs ont été effacées.");
        }
        else
        {
            Console.WriteLine("  ✗ Opération annulée.");
        }
    }

    private static string ReadString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? val = Console.ReadLine()?.Trim().ToUpper();
            if (!string.IsNullOrWhiteSpace(val)) return val;
            Console.WriteLine("  ⚠ Saisie invalide, veuillez réessayer.");
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
                    out double val))
                return val;
            Console.WriteLine("  ⚠ Nombre invalide, veuillez réessayer.");
        }
    }

    private static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int val)) return val;
            Console.WriteLine("  ⚠ Entier invalide, veuillez réessayer.");
        }
    }

    private static int ReadIndex(string prompt, int max)
    {
        while (true)
        {
            int idx = ReadInt(prompt) - 1;
            if (idx >= 0 && idx < max) return idx;
            Console.WriteLine($"  ⚠ Index invalide (1–{max}).");
        }
    }
}
