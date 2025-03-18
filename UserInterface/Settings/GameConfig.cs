namespace UserInterface.Settings;

public record GameConfig
{
    public required List<TerrainConfig> TerrainConfigs { get; init; }
    
}