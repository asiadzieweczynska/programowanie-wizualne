using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using System.Text.Json;
using System.IO;

namespace projekt3
{
    public partial class Form1 : Form
    {
        private DataTable dataTable = null!;
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
            dataTable.Columns.Add("Imie", typeof(string));
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
                MessageBox.Show("Pracownik zosta� usuni�ty.");
            }
            else
            {
                MessageBox.Show("Najpierw zaznacz wiersz do usuni�cia!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pliki CSV (*.csv)|*.csv";
            saveFileDialog.Title = "Zapisz list� pracownik�w";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Tworzymy nag��wek (pierwsza linia w pliku)
                    string csvContent = "ID,Imie,Nazwisko,Wiek,Stanowisko" + Environment.NewLine;

                    // P�tla przez wszystkie wiersze w naszej tabeli danych
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // ��czymy elementy wiersza przecinkami
                        csvContent += string.Join(",", row.ItemArray) + Environment.NewLine;
                    }

                    // Zapisujemy wszystko do wybranego pliku
                    File.WriteAllText(saveFileDialog.FileName, csvContent);
                    MessageBox.Show("Dane zosta�y zapisane do pliku .csv");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wyst�pi� b��d podczas zapisu: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (Form2 oknoDodawania = new Form2())
            {
                // Je�li u�ytkownik klikn�� "Zapisz" (DialogResult.OK)
                if (oknoDodawania.ShowDialog() == DialogResult.OK)
                {
                    // Dodajemy dane z okna do naszej g��wnej tabeli
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
                    MessageBox.Show("Dane zosta�y wczytane!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("B��d podczas odczytu: " + ex.Message);
                }
            }
        }

        private static string GetString(DataRow row, params string[] columnNames)
        {
            foreach (string columnName in columnNames)
            {
                if (row.Table.Columns.Contains(columnName))
                {
                    return row[columnName]?.ToString() ?? string.Empty;
                }
            }

            return string.Empty;
        }

        private static int GetInt(DataRow row, params string[] columnNames)
        {
            foreach (string columnName in columnNames)
            {
                if (!row.Table.Columns.Contains(columnName))
                {
                    continue;
                }

                object? value = row[columnName];
                if (value is int intValue)
                {
                    return intValue;
                }

                if (value is null)
                {
                    return 0;
                }

                if (int.TryParse(value.ToString(), out int parsed))
                {
                    return parsed;
                }
            }

            return 0;
        }

        private List<Osoba> GetOsobyFromDataTable()
        {
            var osoby = new List<Osoba>(dataTable.Rows.Count);

            foreach (DataRow row in dataTable.Rows)
            {
                if (row.RowState == DataRowState.Deleted)
                {
                    continue;
                }

                osoby.Add(new Osoba
                {
                    ID = GetInt(row, "ID"),
                    Imie = GetString(row, "Imie"),
                    Nazwisko = GetString(row, "Nazwisko"),
                    Wiek = GetInt(row, "Wiek"),
                    Stanowisko = GetString(row, "Stanowisko"),
                });
            }

            return osoby;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Pliki JSON (*.json)|*.json";
            sfd.Title = "Zapisz listę pracowników (JSON)";

            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                List<Osoba> osoby = GetOsobyFromDataTable();
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(osoby, options);
                File.WriteAllText(sfd.FileName, json);
                MessageBox.Show("Dane zostały zapisane do pliku JSON.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas zapisu JSON: " + ex.Message);
            }
        }
    }

}
