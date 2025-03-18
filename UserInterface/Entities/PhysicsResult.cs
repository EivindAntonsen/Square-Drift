namespace UserInterface.Entities;

public record PhysicsResult(
    IEntity Entity,
    float DeltaTime,
    float VelocityX,
    float VelocityY,
    float AccelerationX,
    float AccelerationY
    );