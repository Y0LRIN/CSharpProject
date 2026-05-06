namespace CityDriveManager.Interfaces;

public interface IElectricCar
{
    double BatteryLevel { get; set; }
    void Recharge(double amount);
}
