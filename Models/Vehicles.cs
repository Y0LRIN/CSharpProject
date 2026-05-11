using CityDriveManager.Interfaces;

namespace CityDriveManager.Models;

public class Car : Vehicle
{
    public string Model { get; set; }

    public Car(string brand, string color, string model)
        : base(brand, color)
    {
        Model = model;
    }

    public override string ToString()
    {
        return $"[CAR]\n{base.ToString()}\nModèle : {Model}";
    }
}

public class Truck : Vehicle
{
    public int Tonnage { get; set; }

    public Truck(string brand, string color, int tonnage)
        : base(brand, color)
    {
        Tonnage = tonnage;
    }

    public override string ToString()
    {
        return $"[TRUCK]\n{base.ToString()}\nTonnage : {Tonnage} T";
    }
}

public class HybridCar : Vehicle, IThermalCar, IElectricCar
{
    public double BatteryLevel { get; set; }
    public double FuelLevel { get; set; }

    public HybridCar(string brand, string color, double batteryLevel, double fuelLevel)
        : base(brand, color)
    {
        BatteryLevel = batteryLevel;
        FuelLevel = fuelLevel;
    }

    public void Recharge(double amount)
    {
        BatteryLevel = Math.min(100, BatteryLevel + amount);
        Console.WriteLine($"Recharge effectuée. Batterie : {BatteryLevel}%");
    }

    public void Refuel(double amount)
    {
        FuelLevel += amount;
        Console.WriteLine($"Carburant ajouté. Niveau : {FuelLevel}L");
    }

    public override void Accelerate()
    {
        CurrentSpeed += 10;

        if (BatteryLevel > 0)
        {
            BatteryLevel = Math.Max(0, BatteryLevel - 2);
        }
        else
        {
            FuelLevel = Math.Max(0, FuelLevel - 1);
        }
    }

    public override string ToString()
    {
        return $"[HYBRID CAR]\n{base.ToString()}\nBatterie : {BatteryLevel}%\nCarburant : {FuelLevel}L";
    }
}
