using CityDriveManager.Models;

namespace CityDriveManager.Services;

public class CityServices
{
    public List<Vehicle> Vehicles { get; } = new();
    public List<PointOfInterest> Points { get; } = new();
    public List<Trip> Trips { get; } = new();

    private readonly Dictionary<string, int> _vehicleIndex = new();
    private readonly Hashset<string> _pointNames = new();

    public bool AddVehicle(Vehicle vehicle)
    {
        Vehicles.Add(vehicle);
        _vehicleIndex[vehicle.Brand] = Vehicles.Count - 1;
        return true;
    }

    public Vehicle? GetVehicle(int index)
    {
        if (index < 1 || index > Vehicles.Count)
            return null;
        return Vehicles[index - 1];
    }

    public bool AddPoint(PointOfInterest point)
    {
        if (!_pointNames.Add(point.Name))
        {
            Console.WriteLine($"Le lieu \"{point.Name}\" existe déjà (doublon ignoré)");
            return false;
        }
        Points.Add(point);
        return true;
    }

    public PointOfInterest? GetPoint(int index)
    {
        if (index < 1 || index > Points.Count)
            return null;
        return Points[index - 1];
    }

    public void AddTrip(Trip trip)
    {
        Trips.Add(trip);
    }
}
