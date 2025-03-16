namespace UserInterface.Settings;

public static class GameSettings
{
    public static HashSet<KeyValuePair<string, string>> Properties { get; } = [];
    
    private const string GroundPropertiesPath = "GroundProperties.json";
    
    public static void Load()
    {
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, GroundPropertiesPath);
        var json = File.ReadAllText(path);
        
        
    }
}