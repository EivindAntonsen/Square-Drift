using UserInterface.Entities;
using UserInterface.Map;

namespace UserInterface;

public class Player
{
    public Car Car { get; } =
        new(GameConstants.Car.Weight,
            GameConstants.Car.EnginePower,
            GameConstants.Car.BrakePower);
}