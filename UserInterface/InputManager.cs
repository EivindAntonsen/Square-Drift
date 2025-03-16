namespace UserInterface;

public class InputManager
{
    private readonly HashSet<Keys> _keysPressed = [];

    public void KeyDown(Keys key)
    {
        _keysPressed.Add(key);
    }

    public void KeyUp(Keys key)
    {
        _keysPressed.Remove(key);
    }

    public bool IsKeyPressed(Keys key)
    {
        return _keysPressed.Contains(key);
    }
}