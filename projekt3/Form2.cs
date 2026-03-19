using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekt3
{
    public partial class Form2 : Form
    {
        public string Imie => textBox1.Text;
        public string Nazwisko => textBox2.Text;
        public int Wiek => (int)numericUpDown1.Value; // upewnij się, że tak się nazywa!
        public string Stanowisko => comboBox1.SelectedItem?.ToString() ?? "Brak";

        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
