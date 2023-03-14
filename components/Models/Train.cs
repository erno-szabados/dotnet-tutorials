namespace RailRoad;

public abstract class Wagon
{
    public enum WagonCategoryType
    {
        OpenFreight,
        CoveredFreight,
        RefrigeratedFreight,
        FlatFreight,
        SpecialFreigh,
        OpenCoach,
        CompartmentCoach,
        CompositeCoach,
        DiningCoach,
        ObservationCoach,
        SleeperCoach,
        Baggage,
    }
    public string? Name { get; set; }
    public int WheelSets { get; set; }

    public WagonCategoryType WagonCategory { get; set; }
}

public class FreightWagon : Wagon
{
    public int Capacity { get; set; }
}

public class PassengerWagon : Wagon
{
    public int Seats { get; set; }
}

public class Train
{
    public string? Name { get; set; }
    public List<TrainEngine> Engines { get; set; }
    public List<Wagon> Wagons { get; set; } = default!;

    public Train(string name)
    {
        Engines = new();
        Wagons = new();
    }

    public Train(string name, TrainEngine engine)
    {
        Engines = new() { engine };
        Wagons = new();
    }
}