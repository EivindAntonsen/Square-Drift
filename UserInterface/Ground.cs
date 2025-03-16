namespace UserInterface;

public record Ground(Rectangle Area, GroundType Type)
{
    public Rectangle Area { get; } = Area;
    public GroundType Type { get; } = Type;
}