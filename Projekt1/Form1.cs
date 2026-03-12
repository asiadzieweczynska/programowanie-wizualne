using Calculation;

namespace Projekt1
{
    public partial class Form1 : Form
    {
        private readonly calculate calc = new calculate();

        public Form1()
        {
            InitializeComponent();
        }

        private bool GetNumbers(out int a, out int b)
        {
            a = 0;
            b = 0;
            if (!int.TryParse(textBox1.Text, out a))
            {
                MessageBox.Show("Podaj poprawną pierwszą liczbę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(textBox2.Text, out b))
            {
                MessageBox.Show("Podaj poprawną drugą liczbę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (GetNumbers(out int a, out int b))
                textBox3.Text = calc.Add(a, b).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (GetNumbers(out int a, out int b))
                textBox3.Text = calc.Subtract(a, b).ToString();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (GetNumbers(out int a, out int b))
                textBox3.Text = calc.Multiply(a, b).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (GetNumbers(out int a, out int b))
            {
                try
                {
                    textBox3.Text = calc.Divide(a, b).ToString();
                }
                catch (DivideByZeroException)
                {
                    MessageBox.Show("Nie można dzielić przez zero.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
