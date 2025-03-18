using UserInterface.Map;

namespace UserInterface.Settings;

public record TerrainConfig
{
    public const string SectionName = "TerrainSettings";
    
    public TerrainType TerrainType { get; init; }
    public float Acceleration { get; init; }
    public float Friction { get; init; }
};