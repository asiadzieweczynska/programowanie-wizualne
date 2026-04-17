using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekt6
{
    public partial class Plansza : Form
    {
        private enum CellContent
        {
            Empty,
            Dydelf,
            Szop,
            Krokodyl,
        }

        private readonly GameSettings _settings;
        private readonly Random _random = new();

        private Button[,]? _buttons;
        private CellContent[,]? _contents;
        private bool[,]? _revealed;
        private bool[,]? _emptyConsumed;
        private readonly HashSet<(int x, int y)> _foundDydelfs = new();

        private int _remainingSeconds;
        private System.Windows.Forms.Timer? _countdownTimer;

        private (int x, int y)? _activeCrocodile;
        private System.Windows.Forms.Timer? _crocodileFailTimer;

        private bool _gameEnded;

        public Plansza(GameSettings settings)
        {
            InitializeComponent();
            _settings = settings;
            Load += plansza_Load;
        }

        private void plansza_Load(object? sender, EventArgs e)
        {
            SetupBoard();
            StartCountdown();
        }

        private void SetupBoard()
        {
            _gameEnded = false;
            _foundDydelfs.Clear();

            var width = _settings.BoardWidth;
            var height = _settings.BoardHeight;

            _buttons = new Button[width, height];
            _contents = new CellContent[width, height];
            _revealed = new bool[width, height];
            _emptyConsumed = new bool[width, height];

            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            tableLayoutPanel1.ColumnCount = width;
            tableLayoutPanel1.RowCount = height;

            for (var x = 0; x < width; x++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / width));
            }

            for (var y = 0; y < height; y++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / height));
            }

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var btn = new Button
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(1),
                        Tag = new Point(x, y),
                        Text = string.Empty,
                        BackColor = Color.LightGray,
                        UseVisualStyleBackColor = false,
                    };
                    btn.Click += CellButton_Click;

                    _buttons[x, y] = btn;
                    tableLayoutPanel1.Controls.Add(btn, x, y);
                }
            }

            tableLayoutPanel1.ResumeLayout(true);
            RandomizeContents();
            UpdateTimerLabel();
        }

        private void RandomizeContents()
        {
            if (_contents is null)
            {
                return;
            }

            var width = _settings.BoardWidth;
            var height = _settings.BoardHeight;

            var all = new List<(int x, int y)>(width * height);
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    all.Add((x, y));
                }
            }

            // Fisher–Yates shuffle
            for (var i = all.Count - 1; i > 0; i--)
            {
                var j = _random.Next(i + 1);
                (all[i], all[j]) = (all[j], all[i]);
            }

            var idx = 0;
            for (var i = 0; i < _settings.DydelfCount; i++, idx++)
            {
                var (x, y) = all[idx];
                _contents[x, y] = CellContent.Dydelf;
            }

            for (var i = 0; i < _settings.SzopCount; i++, idx++)
            {
                var (x, y) = all[idx];
                _contents[x, y] = CellContent.Szop;
            }

            for (var i = 0; i < _settings.KrokodylCount; i++, idx++)
            {
                var (x, y) = all[idx];
                _contents[x, y] = CellContent.Krokodyl;
            }

            for (; idx < all.Count; idx++)
            {
                var (x, y) = all[idx];
                _contents[x, y] = CellContent.Empty;
            }
        }

        private void StartCountdown()
        {
            _remainingSeconds = _settings.TimeSeconds;

            _countdownTimer?.Stop();
            _countdownTimer?.Dispose();

            _countdownTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            _countdownTimer.Tick += (_, _) =>
            {
                if (_gameEnded)
                {
                    return;
                }

                _remainingSeconds--;
                UpdateTimerLabel();

                if (_remainingSeconds <= 0)
                {
                    EndGame(win: false, reason: "Czas minął.");
                }
            };
            _countdownTimer.Start();
            UpdateTimerLabel();
        }

        private void UpdateTimerLabel()
        {
            label1.Text = $"Czas: {_remainingSeconds}s";
        }

        private void CellButton_Click(object? sender, EventArgs e)
        {
            if (_gameEnded)
            {
                return;
            }

            if (sender is not Button btn)
            {
                return;
            }

            if (btn.Tag is not Point p)
            {
                return;
            }

            var x = p.X;
            var y = p.Y;

            if (_buttons is null || _contents is null || _revealed is null || _emptyConsumed is null)
            {
                return;
            }

            // Krokodyl: drugi klik w 2 sek. zamyka kosz
            if (_activeCrocodile is { } active && active.x == x && active.y == y && _revealed[x, y] && _contents[x, y] == CellContent.Krokodyl)
            {
                CloseCrocodile(x, y);
                return;
            }

            // Puste pole tylko raz
            if (_emptyConsumed[x, y])
            {
                return;
            }

            // Klik w odkryte (poza krokodylem) ignorujemy
            if (_revealed[x, y])
            {
                return;
            }

            RevealCell(x, y);
        }

        private void RevealCell(int x, int y)
        {
            if (_buttons is null || _contents is null || _revealed is null || _emptyConsumed is null)
            {
                return;
            }

            var btn = _buttons[x, y];
            var content = _contents[x, y];

            _revealed[x, y] = true;
            btn.BackColor = Color.White;

            switch (content)
            {
                case CellContent.Empty:
                    btn.Text = string.Empty;
                    btn.Enabled = false;
                    _emptyConsumed[x, y] = true;
                    break;

                case CellContent.Dydelf:
                    btn.Text = "D";
                    btn.Enabled = false;
                    _foundDydelfs.Add((x, y));
                    CheckWin();
                    break;

                case CellContent.Szop:
                    btn.Text = "S";
                    btn.Enabled = false;
                    StartSzopCloseTimer(x, y);
                    break;

                case CellContent.Krokodyl:
                    btn.Text = "K";
                    btn.Enabled = true;
                    StartCrocodileReactionTimer(x, y);
                    break;
            }
        }

        private void HideCell(int x, int y)
        {
            if (_buttons is null || _contents is null || _revealed is null || _emptyConsumed is null)
            {
                return;
            }

            if (!_revealed[x, y])
            {
                return;
            }

            // Jeśli szop "zamyka" znalezionego dydelfa, cofamy postęp
            if (_contents[x, y] == CellContent.Dydelf)
            {
                _foundDydelfs.Remove((x, y));
            }

            // Jeśli szop zamknął krokodyla w trakcie odliczania, anulujemy karę
            if (_activeCrocodile is { } active && active.x == x && active.y == y)
            {
                CancelCrocodileTimer();
            }

            var btn = _buttons[x, y];
            _revealed[x, y] = false;
            btn.Text = string.Empty;
            btn.BackColor = Color.LightGray;

            if (_emptyConsumed[x, y])
            {
                btn.Enabled = false;
            }
            else
            {
                btn.Enabled = true;
            }
        }

        private void StartSzopCloseTimer(int x, int y)
        {
            var timer = new System.Windows.Forms.Timer { Interval = 2000 };
            timer.Tick += (_, _) =>
            {
                timer.Stop();
                timer.Dispose();

                if (_gameEnded)
                {
                    return;
                }

                foreach (var (nx, ny) in GetNeighborsIncludingSelf(x, y))
                {
                    HideCell(nx, ny);
                }
            };
            timer.Start();
        }

        private IEnumerable<(int x, int y)> GetNeighborsIncludingSelf(int x, int y)
        {
            var width = _settings.BoardWidth;
            var height = _settings.BoardHeight;

            for (var dy = -1; dy <= 1; dy++)
            {
                for (var dx = -1; dx <= 1; dx++)
                {
                    var nx = x + dx;
                    var ny = y + dy;
                    if (nx < 0 || ny < 0 || nx >= width || ny >= height)
                    {
                        continue;
                    }

                    yield return (nx, ny);
                }
            }
        }

        private void StartCrocodileReactionTimer(int x, int y)
        {
            // Jeśli krokodyl był już aktywny, nie uruchamiamy kolejnego (w spec jest max 1)
            if (_activeCrocodile is not null)
            {
                return;
            }

            _activeCrocodile = (x, y);

            _crocodileFailTimer?.Stop();
            _crocodileFailTimer?.Dispose();

            _crocodileFailTimer = new System.Windows.Forms.Timer { Interval = 2000 };
            _crocodileFailTimer.Tick += (_, _) =>
            {
                CancelCrocodileTimer();

                if (!_gameEnded)
                {
                    EndGame(win: false, reason: "Krokodyl! Nie zdążyłeś zamknąć kosza w 2 sekundy.");
                }
            };
            _crocodileFailTimer.Start();
        }

        private void CloseCrocodile(int x, int y)
        {
            CancelCrocodileTimer();
            HideCell(x, y);
        }

        private void CancelCrocodileTimer()
        {
            _crocodileFailTimer?.Stop();
            _crocodileFailTimer?.Dispose();
            _crocodileFailTimer = null;
            _activeCrocodile = null;
        }

        private void CheckWin()
        {
            if (_foundDydelfs.Count >= _settings.DydelfCount)
            {
                EndGame(win: true, reason: "Udało się odnaleźć wszystkie Dydelfy!");
            }
        }

        private void EndGame(bool win, string reason)
        {
            if (_gameEnded)
            {
                return;
            }

            _gameEnded = true;

            _countdownTimer?.Stop();
            CancelCrocodileTimer();

            if (_buttons is not null)
            {
                foreach (var btn in _buttons)
                {
                    btn.Enabled = false;
                }
            }

            MessageBox.Show(
                reason,
                win ? "Wygrana" : "Porażka",
                MessageBoxButtons.OK,
                win ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Intentionally left blank (designer event).
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Intentionally left blank (designer event).
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _countdownTimer?.Stop();
            _countdownTimer?.Dispose();
            _countdownTimer = null;
            CancelCrocodileTimer();
            base.OnFormClosing(e);
        }
    }
}
