namespace projekt6
{
    public partial class Form1 : Form
    {
        private GameSettings _settings = GameSettings.Default;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void start_Click(object sender, EventArgs e)
        {
            if (_settings.TotalCreatures > _settings.TotalCells)
            {
                MessageBox.Show(
                    $"Za mała plansza na tyle zwierząt. Komórki: {_settings.TotalCells}, zwierzęta: {_settings.TotalCreatures}.",
                    "Błąd ustawień",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Hide();
            try
            {
                using var game = new Plansza(_settings);
                game.StartPosition = FormStartPosition.CenterScreen;
                game.ShowDialog(this);
            }
            finally
            {
                Show();
            }
        }

        private void ustaiwienia_Click(object sender, EventArgs e)
        {
            using var dialog = new Ustawienia(_settings);
            dialog.StartPosition = FormStartPosition.CenterParent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                _settings = dialog.SelectedSettings;
            }
        }

        private void koniec_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
