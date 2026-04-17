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
    public partial class Ustawienia : Form
    {
        private GameSettings _settings;

        public GameSettings SelectedSettings => _settings;

        public Ustawienia(GameSettings settings)
        {
            InitializeComponent();

            _settings = settings;
            X.Value = _settings.BoardWidth;
            Y.Value = _settings.BoardHeight;
            dydelfy.Value = _settings.DydelfCount;
            szopy.Value = _settings.SzopCount;
            krokodyle.Value = _settings.KrokodylCount;
            czas.Value = _settings.TimeSeconds;

            AcceptButton = ok;
        }

        private void X_ValueChanged(object sender, EventArgs e)
        {
            _settings = _settings with { BoardWidth = (int)X.Value };
        }

        private void Y_ValueChanged(object sender, EventArgs e)
        {
            _settings = _settings with { BoardHeight = (int)Y.Value };
        }

        private void dydelfy_ValueChanged(object sender, EventArgs e)
        {
            _settings = _settings with { DydelfCount = (int)dydelfy.Value };
        }

        private void krokodyle_ValueChanged(object sender, EventArgs e)
        {
            _settings = _settings with { KrokodylCount = (int)krokodyle.Value };
        }

        private void szopy_ValueChanged(object sender, EventArgs e)
        {
            _settings = _settings with { SzopCount = (int)szopy.Value };
        }

        private void czas_ValueChanged(object sender, EventArgs e)
        {
            _settings = _settings with { TimeSeconds = (int)czas.Value };
        }

        private void ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
