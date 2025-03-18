namespace UserInterface;

public class Position(float x, float y)
{
    public float X { get; private set; } = x;
    public float Y { get; private set; } = y;

    public void Update(float x, float y)
    {
        X = x;
        Y = y;
    }
    
    public void KeepInBounds(int screenWidth, int screenHeight)
    {
        X = Math.Max(0, Math.Min(screenWidth - 1, X));
        Y = Math.Max(0, Math.Min(screenHeight - 1, Y));
    }
}