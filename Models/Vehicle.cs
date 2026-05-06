namespace CityDriveManager.Models;

public abstract class Vehicle
{
    public string Brand { get; set; }
    public string Color { get; set; }
    public double CurrentSpeed { get; protected set; }

    protected Vehicle(string brand, string color)
    {
        Brand = brand;
        Color = color;
        CurrentSpeed = 0;
    }

    public virtual void Accelerate()
    {
        CurrentSpeed += 10;
    }

    public void Brake()
    {
        CurrentSpeed = Math.Max(0, CurrentSpeed - 10);
    }

    public override string ToString()
    {
        return $"Marque : {Brand}\nCouleur : {Color}\nVitesse Actuelle {CurrentSpeed} km/h";
    }
}
