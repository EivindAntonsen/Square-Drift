using UserInterface.Map;

namespace UserInterface;

public static  class TerrainGenerator
{
    public static List<Terrain> GenerateRandomTerrain(int mapWidth, int mapHeight)
    {
        var random = new Random();
        var grounds = new List<Terrain>();

        // Divide the map into tiles
        const int tileSize = 64; // e.g., each ground area will be 50x50 pixels

        for (var x = 0; x < mapWidth; x += tileSize)
        for (var y = 0; y < mapHeight; y += tileSize)
        {
            // Randomly assign a terrain type
            var terrainType = (TerrainType)random.Next(0, 3); // Assuming 0=Tarmac, 1=Ice, 2=Dirt

            // Create a ground area
            var ground = new Terrain(new Rectangle(x, y, tileSize, tileSize), terrainType);
            grounds.Add(ground);
        }

        return grounds;
    }
}