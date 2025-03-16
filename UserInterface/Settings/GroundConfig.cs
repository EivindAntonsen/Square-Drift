namespace UserInterface.Settings;

public record GroundConfig()
{
    public GroundType GroundType { get; init; }
    public float Acceleration { get; init; }
    public float Friction { get; init; }
};