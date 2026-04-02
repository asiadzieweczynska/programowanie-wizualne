namespace projekt4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Domyślnie zawsze 90°.
            radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image is null)
            {
                MessageBox.Show(this, "Najpierw wczytaj obraz (Load).", "Brak obrazu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var rotateFlipType = RotateFlipType.Rotate90FlipNone;
            if (radioButton2.Checked)
            {
                rotateFlipType = RotateFlipType.Rotate180FlipNone;
            }
            else if (radioButton3.Checked)
            {
                rotateFlipType = RotateFlipType.Rotate270FlipNone;
            }

            try
            {
                using var source = new Bitmap(pictureBox2.Image);
                source.RotateFlip(rotateFlipType);

                var rotated = new Bitmap(source);
                var oldImage = pictureBox2.Image;
                pictureBox2.Image = rotated;
                oldImage?.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Nie udało się obrócić obrazu.\n\n{ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Title = "Wybierz zdjęcie",
                Filter = "Pliki obrazów|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.tif;*.tiff|Wszystkie pliki|*.*",
                RestoreDirectory = true,
                CheckFileExists = true,
                CheckPathExists = true,
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                using var stream = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                using var image = Image.FromStream(stream);
                var newImage = new Bitmap(image);

                var oldImage = pictureBox2.Image;
                pictureBox2.Image = newImage;
                oldImage?.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Nie udało się wczytać obrazu.\n\n{ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image is null)
            {
                MessageBox.Show(this, "Najpierw wczytaj obraz (Load).", "Brak obrazu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using var source = new Bitmap(pictureBox2.Image);
                var result = new Bitmap(source.Width, source.Height);

                // Proste kryterium: piksel jest "zielony", jeśli kanał G jest wyraźnie większy od R i B.
                const int minGreen = 60;
                const int dominance = 25;

                for (int y = 0; y < source.Height; y++)
                {
                    for (int x = 0; x < source.Width; x++)
                    {
                        var c = source.GetPixel(x, y);
                        bool isGreen = c.G >= minGreen && c.G >= c.R + dominance && c.G >= c.B + dominance;
                        result.SetPixel(x, y, isGreen ? c : Color.Black);
                    }
                }

                var oldImage = pictureBox2.Image;
                pictureBox2.Image = result;
                oldImage?.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Nie udało się przetworzyć obrazu.\n\n{ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
