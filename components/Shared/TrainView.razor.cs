namespace components.Shared;

using Microsoft.AspNetCore.Components;
using RailRoad;

public partial class TrainView : ComponentBase
{

    public List<Train> trains { get; set; } = default!;

    protected override void OnInitialized()
    {
        List<RailRoad.Wagon> wagons = new() {
            new PassengerWagon {
            Name = "Passenger Coach 40",
            Seats = 40,
            WheelSets = 4,
            WagonCategory = RailRoad.Wagon.WagonCategoryType.OpenCoach
            },
            new PassengerWagon {
            Name = "Passenger Coach 40",
            Seats = 40,
            WheelSets = 4,
            WagonCategory = RailRoad.Wagon.WagonCategoryType.OpenCoach
            },
            new PassengerWagon {
            Name = "Passenger Coach 40",
            Seats = 0,
            WheelSets = 4,
            WagonCategory = RailRoad.Wagon.WagonCategoryType.Baggage
            },
        };

        TrainEngine EDRB41 = new TrainEngine
        {
            Name = "DRB Class 41",
            SerialNumber = 41,
            Propulsion = TrainEngine.PropulsionType.Steam,
        };


        TrainEngine EDB10 = new TrainEngine
        {
            Name = "DB Class 10",
            SerialNumber = 10,
            Propulsion = TrainEngine.PropulsionType.Steam
        };

        Train t1 = new Train("Train 1", EDB10);
        t1.Wagons = wagons;
        Train t2 = new Train("Train 2", EDRB41);
        t2.Wagons = wagons;

        trains = new() { t1, t2 };
        StateHasChanged();
    }
}