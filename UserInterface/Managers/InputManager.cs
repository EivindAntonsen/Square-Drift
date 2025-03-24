namespace UserInterface.Managers;

public static class InputManager
{
    private static readonly HashSet<Keys> _keysPressed = [];

    public static void KeyDown(Keys key) =>
        _keysPressed.Add(key);

    public static void KeyUp(Keys key) =>
        _keysPressed.Remove(key);

    public static bool IsKeyPressed(Keys key) =>
        _keysPressed.Contains(key);
}