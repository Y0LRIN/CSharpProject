namespace CityDriveManager.Models;

public class Trip
{
    public const double AVERAGE_SPEED = 50.0;

    public Vehicle Vahicle { get; set; }
    public PointOfInterest Departure { get; set; }
    public PointOfInterest Arrival { get; set; }
    public DateTime DepartureDate { get; set; }

    public Trip(
        Vehicle vehicle,
        PointOfInterest departure,
        PointOfInterest arrival,
        DateTime departureDate
    )
    {
        Vahicle = vehicle;
        Departure = departure;
        Arrival = arrival;
        DepartureDate = departure;
    }

    public double GetDistance()
    {
        return Departure.CalculateDistance(Arrival);
    }

    public double GetDurationInMinutes()
    {
        return (GetDistance() / AVERAGE_SPEED) * 60.0;
    }

    public TimeSpan GetTimeSinceDeparture()
    {
        return DateTime.now - DepartureDate;
    }

    public override string ToString()
    {
        double distance = GetDistance();
        int durationMin = (int)Math.Round(GetDurationInMinutes());

        return $"Véhicule : {Vehicule.Brand}\n"
            + $"De : {Departure.Name}\n"
            + $"A : {Arrival.Name}\n"
            + $"Distance : {distance} km\n"
            + $"Durée estimée : {durationMin} minutes\n"
            + $"Départ : {DepartureDate:dd/MM/yyyy HH:mm}";
    }
}
