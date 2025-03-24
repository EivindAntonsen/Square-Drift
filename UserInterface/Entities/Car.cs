namespace UserInterface.Entities;

public class Car(float weight, float enginePower, float brakePower) : IEntity
{
    public float Weight { get; init; } = weight;
    public float EnginePower { get; init; } = enginePower;
    public float BrakePower { get; init; } = brakePower;
    public Velocity Velocity { get; private set; } = new(0,0);
    public Position Position { get; private set; } = new(0,0);
    public int Height { get; init; } = 32;
    public int Width { get; init; } = 16;
    
    
    public float GetSpeed()
    {
        return MathF.Sqrt((Velocity.X * Velocity.X) + (Velocity.Y * Velocity.Y)); // Hypotenuse
    }
    

    public void Update(float deltaTime)
    {
        Position.Update(Position.X + Velocity.X * deltaTime, Position.Y + Velocity.Y * deltaTime);

        KeepInBounds(GameRuntimeContext.GetApplicationBounds());
    }

    
    public void Draw(Graphics graphics)
    {
        graphics.FillRectangle(Brushes.Gold, Position.X, Position.Y, Width, Height);
        
        // Prepare speedometer display
        var speedText = $"Speed: {GetSpeed():0.0} px/s"; // Format to 1 decimal place
        var font = new Font("Arial", 12);
        var textBrush = new SolidBrush(Color.White);

        // Speedometer dimensions
        var textSize = graphics.MeasureString(speedText, font);
        var backgroundX = 5; // X position of the background rectangle
        var backgroundY = GameRuntimeContext.GetApplicationBounds().Height - 40; // A little above the screen's bottom
        var backgroundWidth = textSize.Width + 10; // Add padding to the width
        var backgroundHeight = textSize.Height + 5; // Add padding to the height

        // Draw the background rectangle
        graphics.FillRectangle(Brushes.Black, backgroundX, backgroundY, backgroundWidth, backgroundHeight);

        // Draw the speed text
        graphics.DrawString(speedText, font, textBrush, backgroundX + 5, backgroundY + 2);

    }

    public void KeepInBounds(int screenWidth, int screenHeight) => 
        Position.KeepInBounds(screenWidth, screenHeight);

    public void KeepInBounds(Rectangle rectangle) => 
        Position.KeepInBounds(rectangle.Width, rectangle.Height);
}