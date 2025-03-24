using UserInterface.Entities;

namespace UserInterface.Managers;

public static class EntityManager
{
    private static readonly List<IEntity> Entities = [];
    
    public static void AddEntity(IEntity entity) => 
        Entities.Add(entity);
    
    public static void RemoveEntity(IEntity entity) => 
        Entities.Remove(entity);

    public static void UpdateEntities(float deltaTime)
    {
        foreach (var entity in Entities) 
            entity.Update(deltaTime);
    }

    public static void DrawEntities(Graphics graphics)
    {
        foreach (var entity in Entities) 
            entity.Draw(graphics);
    }
}