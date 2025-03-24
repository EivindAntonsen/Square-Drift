namespace UserInterface;

public static class GameRuntimeContext
{
    private static int ApplicationWindowWidth { get; set; } = 1920;
    private static int ApplicationWindowHeight { get; set; } = 1080;
    
    
    public static Rectangle GetApplicationBounds()
    {
        return new Rectangle(0, 0, ApplicationWindowWidth, ApplicationWindowHeight);
    }

    public static void SetApplicationBounds(int width, int height)
    {
        ApplicationWindowWidth = width;
        ApplicationWindowHeight = height;
    }
}