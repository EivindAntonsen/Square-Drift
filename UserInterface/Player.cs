namespace UserInterface;

public class Player(float startX, float startY)
{
    public float X { get; private set; } = startX;
    public float Y { get; private set; } = startY;
    private float VelocityX { get; set; }
    private float VelocityY { get; set; }
    private const int Size = 20;

    private float _acceleration = 1.0f; // Default acceleration
    private float _friction = 0.95f; // Default friction

    public void UpdateGroundProperties(GroundType groundType)
    {
        switch (groundType)
        {
            case GroundType.Tarmac:
                _acceleration = 0.9f;
                _friction = 0.87f;
                break;
            case GroundType.Ice:
                _acceleration = 0.28f; // Makes it harder to accelerate
                _friction = 1f; // Makes deceleration more gradual (slippery)
                break;
            case GroundType.Dirt:
                _acceleration = 0.5f; // Faster bursts of speed
                _friction = 0.75f; // Strong deceleration (sticky)
                break;
        }
    }

    public void Move(bool upPressed, bool downPressed, bool leftPressed, bool rightPressed)
    {
        if (upPressed) VelocityY -= _acceleration;
        if (downPressed) VelocityY += _acceleration;
        if (leftPressed) VelocityX -= _acceleration;
        if (rightPressed) VelocityX += _acceleration;

        VelocityX *= _friction;
        VelocityY *= _friction;

        X += VelocityX;
        Y += VelocityY;
    }

    public void KeepInBounds(int screenWidth, int screenHeight)
    {
        X = Math.Max(0, Math.Min(screenWidth - Size, X));
        Y = Math.Max(0, Math.Min(screenHeight - Size, Y));
    }

    public void Draw(Graphics g)
    {
        g.FillRectangle(Brushes.Blue, X, Y, Size, Size);
    }
}