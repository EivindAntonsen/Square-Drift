using UserInterface.Entities;
using UserInterface.Map;

namespace UserInterface;

public class GameState
{
    public Player Player { get; }
    public IEnumerable<Terrain> Terrain { get; }

    

    public GameState(int mapWidth, int mapHeight)
    {
        Player = new Player();
        
        
        EntityManager.AddEntity(Player.Car);
        Terrain = TerrainGenerator.GenerateRandomTerrain(mapWidth, mapHeight);
    }

  
    public static void Update(float deltaTime)
    {
        EntityManager.UpdateEntities(deltaTime);
    }

    public static void DrawEntities(Graphics graphics) => 
        EntityManager.DrawEntities(graphics);
    
    public IEnumerable<TerrainType> GetTerrainType(float x, float y) =>
        from ground in Terrain
        where ground.Area.Contains(Convert.ToInt32(x), Convert.ToInt32(y))
        select ground.Type;
}