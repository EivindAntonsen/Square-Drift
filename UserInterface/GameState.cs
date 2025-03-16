namespace UserInterface;

public class GameState(int startX, int startY)
{
    public Player Player { get; } = new(startX, startY);
}