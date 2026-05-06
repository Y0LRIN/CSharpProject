namespace CityDriveManager.Interfaces;

public interface IThermalCar
{
    double FuelLevel { get; set; }
    void Refuel(double amount);
}
