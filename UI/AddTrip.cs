// public class AddTripMenu : Menu
// {
//     private void CreateTrip()
//     {
//         Console.WriteLine("=== Créer un trajet ===");
//         var vehicles = _data.GetVehicles();
//         var points = _data.GetPoints();
//
//         if (vehicles.Count == 0)
//         {
//             Console.WriteLine("  ⚠ Aucun véhicule.");
//             return;
//         }
//         if (points.Count < 2)
//         {
//             Console.WriteLine("  ⚠ Ajoutez au moins 2 lieux.");
//             return;
//         }
//
//         Console.WriteLine("  --- Véhicules ---");
//         for (int i = 0; i < vehicles.Count; i++)
//             Console.WriteLine($"  {i + 1}. {vehicles[i]}");
//         int vIdx = ReadIndex("  Véhicule (n°) : ", vehicles.Count);
//
//         Console.WriteLine("  --- Lieux ---");
//         for (int i = 0; i < points.Count; i++)
//             Console.WriteLine($"  {i + 1}. {points[i].Name}");
//         int dIdx = ReadIndex("  Départ (n°) : ", points.Count);
//         int aIdx = ReadIndex("  Arrivée (n°) : ", points.Count);
//
//         Console.Write("  Date de départ (dd/MM/yyyy HH:mm, vide = maintenant) : ");
//         string? dateInput = Console.ReadLine()?.Trim();
//         DateTime departureDate;
//         if (
//             string.IsNullOrWhiteSpace(dateInput)
//             || !DateTime.TryParseExact(
//                 dateInput,
//                 "dd/MM/yyyy HH:mm",
//                 System.Globalization.CultureInfo.InvariantCulture,
//                 System.Globalization.DateTimeStyles.None,
//                 out departureDate
//             )
//         )
//         {
//             departureDate = DateTime.Now;
//             Console.WriteLine("  → Date de départ définie à maintenant.");
//         }
//
//         Trip trip = new Trip(vehicles[vIdx], points[dIdx], points[aIdx], departureDate);
//
//         Console.WriteLine($"\n  ✓ Trajet créé :\n{trip}");
//     }
// }
//

