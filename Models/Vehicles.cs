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
