using UserInterface.Map;
using Timer = System.Windows.Forms.Timer;

namespace UserInterface;

public partial class GameForm : Form
{
    private readonly Timer _gameTimer;
    private readonly GameState _gameState;
    private const string Title = "Square Drift!";
    

    private GameForm()
    {
        Text = Title;
        Size = new Size(1900, 1000);
        DoubleBuffered = true;

        _gameState = new GameState(1900, 1000);

        _gameTimer = new Timer();
        _gameTimer.Interval = 1000 / 144;
        _gameTimer.Tick += GameTimer_Tick;
        _gameTimer.Start();

        KeyDown += (_, args) => InputManager.KeyDown(args.KeyCode);
        KeyUp += (_, args) => InputManager.KeyUp(args.KeyCode);

        Icon = new Icon(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/Icons/icon2.ico"));
    }

    private void GameTimer_Tick(object sender, EventArgs args)
    {
        HandleInput();
        UpdateGameState();
        Invalidate();
    }

    private void UpdateGameState() => 
        GameState.Update(_gameTimer.Interval / 1000f);

    private void HandleInput()
    {
        var player = _gameState.Player;
        var car = player.Car;
        
        var forward = InputManager.IsKeyPressed(Keys.Up) || InputManager.IsKeyPressed(Keys.W);
        var backward = InputManager.IsKeyPressed(Keys.Down) || InputManager.IsKeyPressed(Keys.S);
        var left = InputManager.IsKeyPressed(Keys.Left) || InputManager.IsKeyPressed(Keys.A);
        var right = InputManager.IsKeyPressed(Keys.Right) || InputManager.IsKeyPressed(Keys.D);
        
        var carVelocity = PhysicsManager.CalculatePhysics(
            car, 
            _gameState.Terrain.Select(terrain => terrain.Type), 
            forward, backward, left, right, 
            _gameTimer.Interval / 1000f);
    }

    protected override void OnPaint(PaintEventArgs args)
    {
        base.OnPaint(args);

        foreach (var ground in _gameState.Terrain)
        {
            var brush = ground.Type switch
            {
                TerrainType.Tarmac => Brushes.DimGray,
                TerrainType.Ice => Brushes.LightBlue,
                TerrainType.Dirt => Brushes.Brown,
                _ => Brushes.Gray
            };

            args.Graphics.FillRectangle(brush, ground.Area);
        }
        
        GameState.DrawEntities(args.Graphics);
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new GameForm());
    }
}