using Timer = System.Windows.Forms.Timer;

namespace UserInterface;

public sealed partial class GameForm : Form
{
    private readonly Timer _gameTimer;
    private readonly InputManager _inputManager;
    private readonly GameState _gameState;

    private GameForm()
    {
        // Initialize form
        Text = "Cubic Drift!";
        Size = new Size(800, 600);
        DoubleBuffered = true;

        // Initialize game components
        _inputManager = new InputManager();
        _gameState = new GameState(50, 50);

        // Set up game timer
        _gameTimer = new Timer();
        _gameTimer.Interval = 16; // 60 FPS
        _gameTimer.Tick += GameTimer_Tick;
        _gameTimer.Start();

        // Event handlers for input
        KeyDown += (_, eventArgs) => _inputManager.KeyDown(eventArgs.KeyCode);
        KeyUp += (_, eventArgs) => _inputManager.KeyUp(eventArgs.KeyCode);
    }

    private void GameTimer_Tick(object sender, EventArgs eventArgs)
    {
        // Update player movement
        var player = _gameState.Player;
        player.Move(
                    _inputManager.IsKeyPressed(Keys.Up),
                    _inputManager.IsKeyPressed(Keys.Down),
                    _inputManager.IsKeyPressed(Keys.Left),
                    _inputManager.IsKeyPressed(Keys.Right)
                   );

        // Keep player within boundaries
        player.KeepInBounds(ClientSize.Width, ClientSize.Height);

        // Redraw the screen
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs eventArgs)
    {
        base.OnPaint(eventArgs);

        // Draw the player
        _gameState.Player.Draw(eventArgs.Graphics);
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new GameForm());
    }
}