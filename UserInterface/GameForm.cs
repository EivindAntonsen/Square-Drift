using Timer = System.Windows.Forms.Timer;

namespace UserInterface;

public partial class GameForm : Form
{
    private readonly Timer _gameTimer;
    private readonly InputManager _inputManager;
    private readonly GameState _gameState;

    private GameForm()
    {
        Text = "Mini Game with Dynamic Ground Types";
        Size = new Size(800, 600);
        DoubleBuffered = true;

        _inputManager = new InputManager();
        _gameState = new GameState(50, 50);

        _gameTimer = new Timer();
        _gameTimer.Interval = 16; // 60 FPS
        _gameTimer.Tick += GameTimer_Tick;
        _gameTimer.Start();

        KeyDown += (_, args) => _inputManager.KeyDown(args.KeyCode);
        KeyUp += (_, args) => _inputManager.KeyUp(args.KeyCode);
    }

    private void GameTimer_Tick(object sender, EventArgs e)
    {
        var player = _gameState.Player;

        // Check the ground type
        var groundType = _gameState.GetGroundType(player.X, player.Y);
        player.UpdateGroundProperties(groundType);

        // Move the player
        player.Move(
                    _inputManager.IsKeyPressed(Keys.Up),
                    _inputManager.IsKeyPressed(Keys.Down),
                    _inputManager.IsKeyPressed(Keys.Left),
                    _inputManager.IsKeyPressed(Keys.Right)
                   );

        player.KeepInBounds(ClientSize.Width, ClientSize.Height);
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Draw the ground areas
        foreach (var ground in _gameState.Grounds)
        {
            var brush = ground.Type switch
            {
                GroundType.Tarmac => Brushes.Gray,
                GroundType.Ice => Brushes.LightBlue,
                GroundType.Dirt => Brushes.Brown,
                _ => Brushes.Gray
            };

            e.Graphics.FillRectangle(brush, ground.Area);
        }

        // Draw the player
        _gameState.Player.Draw(e.Graphics);
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new GameForm());
    }
}