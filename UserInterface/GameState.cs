namespace UserInterface;

public class GameState(int startX, int startY)
{
    public Player Player { get; } = new(startX, startY);

    public List<Ground> Grounds { get; } =
    [
        new(new Rectangle(0, 0, 400, 600), GroundType.Tarmac), // Left half is normal tarmac
        new(new Rectangle(400, 0, 400, 600), GroundType.Ice)
    ];

    public GroundType GetGroundType(float x, float y)
    {
        var xInt = Convert.ToInt32(x);
        var yInt = Convert.ToInt32(y);

        return (from ground in Grounds
                where ground.Area.Contains(xInt, yInt)
                select ground.Type)
            .FirstOrDefault();
    }
}