using System;

namespace RailRoad;

public class TrainEngine
{

    public enum CategoryType
    {
        ExpressTrain,
        PassengerTrain,
        GoodsTrain,
        PassengerTrainTank,
        GoodsTrainTank,
        RackRailway,
        BranchLine,
        NarrowGauge
    }

    public enum PropulsionType
    {
        Steam,
        Electric,
        Diesel
    }

    public string? Name { get; set; }

    public PropulsionType Propulsion { get; set; }

    public int SerialNumber { get; set; }

    // Declare a private field to store the locomotive type
    public CategoryType Category { get => GetCategory(SerialNumber); }

    // Declare a constructor that takes a number and assigns the corresponding locomotive type
    private CategoryType GetCategory(int serialNumber)
    {
        return serialNumber switch
        {
            >= 1 and <= 19 => CategoryType.ExpressTrain,
            >= 20 and <= 39 => CategoryType.PassengerTrain,
            >= 40 and <= 59 => CategoryType.GoodsTrain,
            >= 60 and <= 79 => CategoryType.PassengerTrainTank,
            >= 80 and <= 96 => CategoryType.GoodsTrainTank,
            97 => CategoryType.RackRailway,
            98 => CategoryType.BranchLine,
            99 => CategoryType.NarrowGauge,
            _ => throw new ArgumentException("Invalid locomotive number")
        };
    }
}
