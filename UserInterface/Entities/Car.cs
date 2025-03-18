namespace UserInterface.Entities;

public class Car(float weight, float enginePower, float brakePower) : IEntity
{
    public float Weight { get; init; } = weight;
    public float EnginePower { get; init; } = enginePower;
    public float BrakePower { get; init; } = brakePower;
    public Velocity Velocity { get; private set; } = new(0,0);
    public Position Position { get; private set; } = new(0,0);
    public int Height { get; init; }
    public int Width { get; init; }
    
    

    public void Update(float deltaTime)
    {
        throw new NotImplementedException();
    }

    public void Draw(Graphics graphics) => 
        graphics.FillRectangle(Brushes.Red, Position.X, Position.Y, Width, Height);

    public void KeepInBounds(int screenWidth, int screenHeight) => 
        Position.KeepInBounds(screenWidth, screenHeight);
}