namespace UserInterface;

public class Velocity(float x, float y)
{
    public float X { get; set; } = x;
    public float Y { get; set; } = y;

    public void Update(float x, float y)
    {
        X = x;
        Y = y;
    }
}