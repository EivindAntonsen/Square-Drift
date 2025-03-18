namespace UserInterface.Entities;

public interface IEntity
{
    void Update(float deltaTime);
    void Draw(Graphics graphics);
    Position Position { get; }
    Velocity Velocity { get; }
}
