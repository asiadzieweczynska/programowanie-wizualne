using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace laby9
{
    public partial class Form1 : Form
    {
        private readonly DatabaseManager _db;

        public Form1()
        {
            InitializeComponent();

            var dbPath = Path.Combine(AppContext.BaseDirectory, "wnioski.db");
            _db = new DatabaseManager(dbPath);
        }

        private sealed class RecordListItem
        {
            public long Id { get; init; }
            public string Display { get; init; } = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                LoadLogoIfAvailable();
                _db.EnsureCreated();
                RefreshEntries();

                BeginInvoke(new Action(CenterPaper));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd inicjalizacji bazy danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            CenterPaper();
        }

        private void CenterPaper()
        {
            if (pnlScroll is null || pnlPaper is null) return;
            if (pnlPaper.Width <= 0) return;

            var clientWidth = pnlScroll.ClientSize.Width;
            var left = (clientWidth - pnlPaper.Width) / 2;
            if (left < pnlScroll.Padding.Left) left = pnlScroll.Padding.Left;

            pnlPaper.Left = left;
            pnlPaper.Top = pnlScroll.Padding.Top;
        }

        private void LoadLogoIfAvailable()
        {
            try
            {
                var logoPath = Path.Combine(AppContext.BaseDirectory, "logo.png");
                if (!File.Exists(logoPath)) return;
                if (picLogo is null) return;

                using var img = Image.FromFile(logoPath);
                picLogo.Image = new Bitmap(img);
            }
            catch
            {
                // Brak logo nie powinien blokować aplikacji.
            }
        }

        private void RefreshEntries()
        {
            var summaries = _db.ListSummaries();
            var items = summaries.Select(s => new RecordListItem
            {
                Id = s.Id,
                Display = $"#{s.Id} | {s.CreatedAt:yyyy-MM-dd HH:mm} | {s.FullName} | album: {s.AlbumNumber}"
            }).ToList();

            cmbRecords.DataSource = items;
            cmbRecords.DisplayMember = nameof(RecordListItem.Display);
            cmbRecords.ValueMember = nameof(RecordListItem.Id);
        }

        private WniosekRecord ReadForm()
        {
            var decision = "";
            if (rbDecisionYes.Checked) decision = rbDecisionYes.Text;
            else if (rbDecisionNo.Checked) decision = rbDecisionNo.Text;

            return new WniosekRecord
            {
                CityDateTop = txtCityDateTop.Text.Trim(),
                AlbumNumber = txtAlbumNumber.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                SemesterYear = txtSemesterYear.Text.Trim(),
                MajorDegree = txtMajorDegree.Text.Trim(),

                Subject = txtSubject.Text.Trim(),
                Points = (int)nudPoints.Value,
                ConductedBy = txtConductedBy.Text.Trim(),

                Justification = txtJustification.Text.Trim(),
                StudentDateSignature = txtStudentDateSignature.Text.Trim(),

                Decision = decision.Trim(),
                Commission1 = txtCommission1.Text.Trim(),
                Commission2 = txtCommission2.Text.Trim(),
                Commission3 = txtCommission3.Text.Trim(),
                BottomDateStampSignature = EncodeBottom(txtBottomCityDate.Text.Trim(), txtStampSignature.Text.Trim()),
            };
        }

        private void WriteForm(WniosekRecord record)
        {
            txtCityDateTop.Text = record.CityDateTop;
            txtAlbumNumber.Text = record.AlbumNumber;
            txtFullName.Text = record.FullName;
            txtSemesterYear.Text = record.SemesterYear;
            txtMajorDegree.Text = record.MajorDegree;

            txtSubject.Text = record.Subject;
            nudPoints.Value = Math.Clamp(record.Points, (int)nudPoints.Minimum, (int)nudPoints.Maximum);
            txtConductedBy.Text = record.ConductedBy;

            txtJustification.Text = record.Justification;
            txtStudentDateSignature.Text = record.StudentDateSignature;

            rbDecisionYes.Checked = string.Equals(record.Decision, rbDecisionYes.Text, StringComparison.OrdinalIgnoreCase);
            rbDecisionNo.Checked = string.Equals(record.Decision, rbDecisionNo.Text, StringComparison.OrdinalIgnoreCase);
            if (!rbDecisionYes.Checked && !rbDecisionNo.Checked)
            {
                rbDecisionYes.Checked = false;
                rbDecisionNo.Checked = false;
            }

            txtCommission1.Text = record.Commission1;
            txtCommission2.Text = record.Commission2;
            txtCommission3.Text = record.Commission3;

            DecodeBottom(record.BottomDateStampSignature, out var bottomDate, out var stamp);
            txtBottomCityDate.Text = bottomDate;
            txtStampSignature.Text = stamp;
        }

        private static string EncodeBottom(string bottomDate, string stamp)
        {
            // Prosty format: pierwsza linia = data, reszta = pieczątka/podpis.
            return string.Join("\n", new[] { bottomDate ?? string.Empty, stamp ?? string.Empty });
        }

        private static void DecodeBottom(string combined, out string bottomDate, out string stamp)
        {
            combined ??= string.Empty;
            var normalized = combined.Replace("\r\n", "\n");
            var parts = normalized.Split('\n');
            bottomDate = parts.Length > 0 ? parts[0] : string.Empty;
            stamp = parts.Length > 1 ? string.Join("\n", parts.Skip(1)) : string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var record = ReadForm();
                var id = _db.Insert(record);
                RefreshEntries();

                // Ustaw na zapisany wpis
                cmbRecords.SelectedValue = id;

                MessageBox.Show("Zapisano wpis do bazy.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd zapisu do bazy: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshEntries();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd odświeżania listy: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbRecords.SelectedItem is not RecordListItem item)
                {
                    MessageBox.Show("Wybierz wpis z listy.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var id = item.Id;

                var record = _db.GetById(id);
                if (record is null)
                {
                    MessageBox.Show("Nie znaleziono wpisu.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                WriteForm(record);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd odczytu z bazy: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
