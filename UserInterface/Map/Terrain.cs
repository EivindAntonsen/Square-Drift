namespace UserInterface.Map;

public record Terrain(Rectangle Area, TerrainType Type)
{
    public Rectangle Area { get; } = Area;
    public TerrainType Type { get; } = Type;
}