using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace projekt3
{
    public partial class Form1 : Form
    {
        private DataTable dataTable;
        private BindingSource bindingSource = new BindingSource();
        private int nextId = 1;
        public Form1()
        {
            InitializeComponent();
            SetupDataTable();
        }

        private void SetupDataTable()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Imiê", typeof(string));
            dataTable.Columns.Add("Nazwisko", typeof(string));
            dataTable.Columns.Add("Wiek", typeof(int));
            dataTable.Columns.Add("Stanowisko", typeof(string));
            bindingSource.DataSource = dataTable;
            dataGridView1.DataSource = bindingSource;
            dataGridView1.AllowUserToAddRows = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                MessageBox.Show("Pracownik zosta³ usuniêty.");
            }
            else
            {
                MessageBox.Show("Najpierw zaznacz wiersz do usuniêcia!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pliki CSV (*.csv)|*.csv";
            saveFileDialog.Title = "Zapisz listê pracowników";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Tworzymy nag³ówek (pierwsza linia w pliku)
                    string csvContent = "ID,Imiê,Nazwisko,Wiek,Stanowisko" + Environment.NewLine;

                    // Pêtla przez wszystkie wiersze w naszej tabeli danych
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // £¹czymy elementy wiersza przecinkami
                        csvContent += string.Join(",", row.ItemArray) + Environment.NewLine;
                    }

                    // Zapisujemy wszystko do wybranego pliku
                    File.WriteAllText(saveFileDialog.FileName, csvContent);
                    MessageBox.Show("Dane zosta³y zapisane do pliku .csv");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wyst¹pi³ b³¹d podczas zapisu: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (Form2 oknoDodawania = new Form2())
            {
                // Jeœli u¿ytkownik klikn¹³ "Zapisz" (DialogResult.OK)
                if (oknoDodawania.ShowDialog() == DialogResult.OK)
                {
                    // Dodajemy dane z okna do naszej g³ównej tabeli
                    dataTable.Rows.Add(
                        nextId++,
                        oknoDodawania.Imie,
                        oknoDodawania.Nazwisko,
                        oknoDodawania.Wiek,
                        oknoDodawania.Stanowisko
                    );

                    MessageBox.Show("Dodano nowego pracownika!");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Pliki CSV (*.csv)|*.csv";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] lines = File.ReadAllLines(ofd.FileName);
                    dataTable.Rows.Clear();
                    for (int i = 1; i < lines.Length; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(lines[i]))
                        {
                            string[] dane = lines[i].Split(',');
                            dataTable.Rows.Add(dane);
                            int idZPliku = int.Parse(dane[0]);
                            if (idZPliku >= nextId) nextId = idZPliku + 1;
                        }
                    }
                    MessageBox.Show("Dane zosta³y wczytane!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("B³¹d podczas odczytu: " + ex.Message);
                }
            }
        }
    }

}
