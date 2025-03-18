using UserInterface.Entities;
using UserInterface.Map;

namespace UserInterface;

public static class PhysicsManager
{
    private static float _velocityX;
    private static float _velocityY;

    public static Velocity CalculatePhysics(
        Car car, 
        IEnumerable<TerrainType> terrainTypes, 
        bool forward,
        bool backward, 
        bool left, 
        bool right,
        float deltaTime)
    {
        var acceleration = car.EnginePower * deltaTime;
        
        var friction = terrainTypes.DefaultIfEmpty(TerrainType.Tarmac)
            .Average(type => type switch
            {
                TerrainType.Tarmac => GameConstants.Friction.Tarmac,
                TerrainType.Dirt => GameConstants.Friction.Dirt,
                TerrainType.Ice => GameConstants.Friction.Ice,
                _ => GameConstants.Friction.Default
            });
        
        if (forward) _velocityY -= acceleration;
        if (backward) _velocityY += acceleration;
        if (left) _velocityX -= acceleration;
        if (right) _velocityX += acceleration;

        _velocityX *= friction;
        _velocityY *= friction;

        return new Velocity(_velocityX, _velocityY);
    }
}