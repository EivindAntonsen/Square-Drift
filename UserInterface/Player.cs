namespace UserInterface;

public class Player(float startX, float startY)
{
    private float X { get; set; } = startX; // Player X position
    private float Y { get; set; } = startY; // Player Y position
    private float VelocityX { get; set; } // Horizontal velocity
    private float VelocityY { get; set; } // Vertical velocity
    private const int Size = 20; // Player size

    private const float Acceleration = 1.0f;
    private const float Friction = 0.95f;

    public void Move(bool upPressed, bool downPressed, bool leftPressed, bool rightPressed)
    {
        // Apply acceleration based on key presses
        if (upPressed) VelocityY -= Acceleration;
        if (downPressed) VelocityY += Acceleration;
        if (leftPressed) VelocityX -= Acceleration;
        if (rightPressed) VelocityX += Acceleration;

        // Apply friction
        VelocityX *= Friction;
        VelocityY *= Friction;

        // Update position
        X += VelocityX;
        Y += VelocityY;
    }

    public void KeepInBounds(int screenWidth, int screenHeight)
    {
        // Keep the player within the game window boundaries
        X = Math.Max(0, Math.Min(screenWidth - Size, X));
        Y = Math.Max(0, Math.Min(screenHeight - Size, Y));
    }

    public void Draw(Graphics graphics)
    {
        // Draw the player as a blue rectangle
        graphics.FillRectangle(Brushes.Blue, X, Y, Size, Size);
    }
}