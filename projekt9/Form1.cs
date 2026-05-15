namespace projekt9
{
    public partial class Form1 : Form
    {
        private readonly DatabaseManager _db;

        private TextBox? _topDateTextBox;
        private TextBox? _albumTextBox;
        private TextBox? _nameTextBox;
        private TextBox? _semestrRokTextBox;
        private TextBox? _kierunekStopienTextBox;
        private TextBox? _przedmiotTextBox;
        private TextBox? _punktyTextBox;
        private TextBox? _prowadzacyTextBox;
        private TextBox? _uzasadnienieTextBox;
        private TextBox? _dataPodpisStudentaTextBox;
        private ComboBox? _decyzjaComboBox;
        private TextBox? _komisja1TextBox;
        private TextBox? _komisja2TextBox;
        private TextBox? _komisja3TextBox;

        private TextBox? _bottomDateTextBox;
        private TextBox? _bottomStampTextBox;
        private ComboBox? _entriesComboBox;
        private Button? _loadButton;
        private Button? _saveButton;
        private Button? _deleteButton;

        public Form1()
        {
            InitializeComponent();

            var dbPath = Path.Combine(Application.StartupPath, "data", "formularz.db");
            _db = new DatabaseManager(dbPath);

            BuildUi();
            Load += Form1_Load;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            try
            {
                _db.Initialize();
                RefreshEntriesList(selectId: null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuildUi()
        {
            Text = "Formularz danych (SQLite .db)";
            AutoScroll = false;

            Controls.Clear();

            var scroll = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(0),
            };
            Controls.Add(scroll);

            // A4 at 96 DPI is ~794 px wide. Use a slightly narrower width for margins.
            const int pageWidth = 790;

            var pageWrapper = new Panel
            {
                Width = pageWidth,
                Height = 10,
                BackColor = SystemColors.Control,
            };
            scroll.Controls.Add(pageWrapper);

            var page = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(18),
                ColumnCount = 1,
                Width = pageWidth,
            };
            page.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            pageWrapper.Controls.Add(page);

            void LayoutPage()
            {
                pageWrapper.Width = pageWidth;
                pageWrapper.Height = page.Height;

                var x = Math.Max(0, (scroll.ClientSize.Width - pageWidth) / 2);
                pageWrapper.Left = x;
                pageWrapper.Top = 0;
            }

            scroll.Resize += (_, _) => LayoutPage();
            page.SizeChanged += (_, _) => LayoutPage();
            LayoutPage();

            // Logo (optional): place a file next to the exe (or in ./assets/) and it will be displayed.
            var logoBox = new PictureBox
            {
                Width = 1000,
                Height = 200,
                SizeMode = PictureBoxSizeMode.Zoom,
                Margin = new Padding(0, 0, 0, 8),
                Anchor = AnchorStyles.Top,
            };
            TryLoadLogoInto(logoBox);

            var logoRow = new Panel
            {
                Dock = DockStyle.Top,
                Height = logoBox.Height,
                Margin = new Padding(0, 0, 0, 0)
            };
            logoRow.Controls.Add(logoBox);
            logoBox.Left = (pageWidth - logoBox.Width) / 2;
            logoBox.Top = 0;
            logoRow.Resize += (_, _) => logoBox.Left = (logoRow.ClientSize.Width - logoBox.Width) / 2;

            page.RowCount += 1;
            page.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            page.Controls.Add(logoRow, 0, page.RowCount - 1);

            TextBox CreateLineBox(int width)
            {
                return new TextBox
                {
                    Width = width,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(0, 0, 0, 0)
                };
            }

            Control CreateCaptionedLine(TextBox box, string caption, int width, ContentAlignment captionAlign = ContentAlignment.MiddleCenter)
            {
                box.Width = width;
                var panel = new TableLayoutPanel
                {
                    ColumnCount = 1,
                    RowCount = 2,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Margin = new Padding(0, 6, 0, 0),
                };
                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                var captionLabel = new Label
                {
                    Text = caption,
                    AutoSize = true,
                    TextAlign = captionAlign,
                    Dock = DockStyle.Fill,
                    Font = new Font(Font, FontStyle.Regular),
                    Margin = new Padding(0, 2, 0, 0)
                };
                panel.Controls.Add(box, 0, 0);
                panel.Controls.Add(captionLabel, 0, 1);
                return panel;
            }

            // Field mapping (15):
            // 1) Top date, 2) album, 3) name, 4) semestr/rok, 5) kierunek/stopień,
            // 6) przedmiot, 7) punkty, 8) prowadzący, 9) uzasadnienie,
            // 10) data i podpis studenta, 11) decyzja, 12-14) komisja, 15) bottom date+stamp (stored combined)
            _topDateTextBox = CreateLineBox(220);
            _albumTextBox = CreateLineBox(520);
            _nameTextBox = CreateLineBox(520);
            _semestrRokTextBox = CreateLineBox(520);
            _kierunekStopienTextBox = CreateLineBox(520);

            _przedmiotTextBox = CreateLineBox(420);
            _punktyTextBox = CreateLineBox(90);
            _prowadzacyTextBox = CreateLineBox(520);

            _uzasadnienieTextBox = new TextBox
            {
                Width = 650,
                BorderStyle = BorderStyle.FixedSingle,
                Multiline = true,
                Height = 110,
                ScrollBars = ScrollBars.Vertical,
                Margin = new Padding(0, 0, 0, 0)
            };

            _dataPodpisStudentaTextBox = CreateLineBox(260);
            _decyzjaComboBox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 260,
                Margin = new Padding(0, 0, 0, 0)
            };
            _decyzjaComboBox.Items.AddRange(new object[]
            {
                "",
                "Wyrażam zgodę",
                "Nie wyrażam zgody"
            });
            _decyzjaComboBox.SelectedIndex = 0;

            _komisja1TextBox = CreateLineBox(520);
            _komisja2TextBox = CreateLineBox(520);
            _komisja3TextBox = CreateLineBox(520);
            _bottomDateTextBox = CreateLineBox(220);
            _bottomStampTextBox = CreateLineBox(220);

            // Top line: Poznań, dnia ________
            var topLine = new FlowLayoutPanel
            {
                AutoSize = true,
                WrapContents = false,
                FlowDirection = FlowDirection.LeftToRight,
                Margin = new Padding(0, 0, 0, 0)
            };
            topLine.Controls.Add(new Label { Text = "Poznań, dnia ", AutoSize = true, Padding = new Padding(0, 6, 0, 0) });
            topLine.Controls.Add(_topDateTextBox);

            page.RowCount += 1;
            page.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            page.Controls.Add(topLine, 0, page.RowCount - 1);

            // Identification block (as in template: line then caption)
            page.RowCount += 1;
            page.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            page.Controls.Add(CreateCaptionedLine(_albumTextBox, FormSchema.Labels[1], 520), 0, page.RowCount - 1);

            page.RowCount += 1;
            page.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            page.Controls.Add(CreateCaptionedLine(_nameTextBox, FormSchema.Labels[2], 520), 0, page.RowCount - 1);

            page.RowCount += 1;
            page.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            page.Controls.Add(CreateCaptionedLine(_semestrRokTextBox, FormSchema.Labels[3], 520), 0, page.RowCount - 1);

            page.RowCount += 1;
            page.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            page.Controls.Add(CreateCaptionedLine(_kierunekStopienTextBox, FormSchema.Labels[4], 520), 0, page.RowCount - 1);

            // Spacer
            page.RowCount += 1;
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 12));
            page.Controls.Add(new Panel { Height = 12, Dock = DockStyle.Top }, 0, page.RowCount - 1);

            // Headings
            var prodziekan = new Label
            {
                Text = "PRODZIEKAN WYDZIAŁU\r\nINFORMATYKI I TELEKOMUNIKACJI",
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Font = new Font(Font, FontStyle.Regular),
                Margin = new Padding(0, 0, 0, 0)
            };
            page.RowCount += 1;
            page.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            page.Controls.Add(prodziekan, 0, page.RowCount - 1);

            var title = new Label
            {
                Text = "WNIOSEK O PRZEPROWADZENIE EGZAMINU KOMISYJNEGO",
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Font = new Font(Font.FontFamily, Font.Size + 1, FontStyle.Bold),
                Margin = new Padding(0, 10, 0, 6)
            };
            page.RowCount += 1;
            page.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            page.Controls.Add(title, 0, page.RowCount - 1);

            // Main request section
            var request = new TableLayoutPanel
            {
                ColumnCount = 4,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = DockStyle.Top,
                Margin = new Padding(0, 6, 0, 0)
            };
            request.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            request.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            request.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            request.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            var intro = new Label
            {
                Text = "Proszę o umożliwienie mi przystąpienia do egzaminu komisyjnego z",
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 6)
            };
            request.RowCount += 1;
            request.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            request.Controls.Add(intro, 0, request.RowCount - 1);
            request.SetColumnSpan(intro, 4);

            request.RowCount += 1;
            request.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            request.Controls.Add(new Label { Text = "przedmiotu ", AutoSize = true, Padding = new Padding(0, 6, 0, 0) }, 0, request.RowCount - 1);
            request.Controls.Add(_przedmiotTextBox, 1, request.RowCount - 1);
            request.Controls.Add(new Label { Text = " - punkty ", AutoSize = true, Padding = new Padding(0, 6, 0, 0) }, 2, request.RowCount - 1);
            request.Controls.Add(_punktyTextBox, 3, request.RowCount - 1);

            request.RowCount += 1;
            request.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            request.Controls.Add(new Label { Text = "prowadzonego przez ", AutoSize = true, Padding = new Padding(0, 6, 0, 0) }, 0, request.RowCount - 1);
            request.Controls.Add(_prowadzacyTextBox, 1, request.RowCount - 1);
            request.SetColumnSpan(_prowadzacyTextBox, 3);

            page.RowCount += 1;
            page.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            page.Controls.Add(request, 0, page.RowCount - 1);

            // Uzasadnienie
            var uzasadPanel = new TableLayoutPanel
            {
                ColumnCount = 1,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = DockStyle.Top,
                Margin = new Padding(0, 10, 0, 0)
            };
            uzasadPanel.RowCount = 2;
            uzasadPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            uzasadPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            uzasadPanel.Controls.Add(new Label { Text = "Uzasadnienie wniosku:", AutoSize = true, Margin = new Padding(0, 0, 0, 4) }, 0, 0);
            uzasadPanel.Controls.Add(_uzasadnienieTextBox, 0, 1);

            page.RowCount += 1;
            page.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            page.Controls.Add(uzasadPanel, 0, page.RowCount - 1);

            // Student signature (right-aligned)
            var studentSig = new TableLayoutPanel
            {
                ColumnCount = 1,
                AutoSize = true,
                Dock = DockStyle.Top,
                Margin = new Padding(0, 12, 0, 0)
            };
            studentSig.Controls.Add(_dataPodpisStudentaTextBox, 0, 0);
            studentSig.Controls.Add(new Label { Text = "data i podpis studenta", AutoSize = true, TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill, Margin = new Padding(0, 2, 0, 0) }, 0, 1);
            studentSig.Anchor = AnchorStyles.Right;

            page.RowCount += 1;
            page.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            page.Controls.Add(studentSig, 0, page.RowCount - 1);

            // DECYZJA
            var decyzjaTitle = new Label
            {
                Text = "DECYZJA",
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Font = new Font(Font, FontStyle.Bold),
                Margin = new Padding(0, 18, 0, 6)
            };
            page.RowCount += 1;
            page.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            page.Controls.Add(decyzjaTitle, 0, page.RowCount - 1);

            var decyzjaLine = new TableLayoutPanel
            {
                ColumnCount = 2,
                AutoSize = true,
                Dock = DockStyle.Top,
                Margin = new Padding(0, 0, 0, 0)
            };
            decyzjaLine.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            decyzjaLine.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            decyzjaLine.Controls.Add(new Label
            {
                Text = "Wyrażam / nie wyrażam zgod(ę)y na przeprowadzenie egzaminu komisyjnego",
                AutoSize = true,
                Padding = new Padding(0, 6, 12, 0)
            }, 0, 0);
            decyzjaLine.Controls.Add(_decyzjaComboBox, 1, 0);

            page.RowCount += 1;
            page.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            page.Controls.Add(decyzjaLine, 0, page.RowCount - 1);

            // Komisja
            var komisjaPanel = new TableLayoutPanel
            {
                ColumnCount = 1,
                AutoSize = true,
                Dock = DockStyle.Top,
                Margin = new Padding(0, 10, 0, 0)
            };
            komisjaPanel.RowCount = 5;
            komisjaPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            komisjaPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            komisjaPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            komisjaPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            komisjaPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 8));
            komisjaPanel.Controls.Add(new Label { Text = "Skład komisji:", AutoSize = true, Margin = new Padding(0, 0, 0, 4) }, 0, 0);
            komisjaPanel.Controls.Add(_komisja1TextBox, 0, 1);
            komisjaPanel.Controls.Add(_komisja2TextBox, 0, 2);
            komisjaPanel.Controls.Add(_komisja3TextBox, 0, 3);

            page.RowCount += 1;
            page.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            page.Controls.Add(komisjaPanel, 0, page.RowCount - 1);

            // Bottom signatures
            var bottom = new TableLayoutPanel
            {
                ColumnCount = 2,
                AutoSize = true,
                Dock = DockStyle.Top,
                Margin = new Padding(0, 18, 0, 0)
            };
            bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            var bottomLeft = new TableLayoutPanel { ColumnCount = 1, AutoSize = true, Dock = DockStyle.Top };
            var bottomRight = new TableLayoutPanel { ColumnCount = 1, AutoSize = true, Dock = DockStyle.Top };
            bottomLeft.Controls.Add(_bottomDateTextBox, 0, 0);
            bottomLeft.Controls.Add(new Label { Text = "Poznań, dnia", AutoSize = true, Margin = new Padding(0, 2, 0, 0) }, 0, 1);
            bottomRight.Controls.Add(_bottomStampTextBox, 0, 0);
            bottomRight.Controls.Add(new Label { Text = "Pieczątka i podpis", AutoSize = true, Margin = new Padding(0, 2, 0, 0) }, 0, 1);
            bottomRight.Anchor = AnchorStyles.Right;

            bottom.Controls.Add(bottomLeft, 0, 0);
            bottom.Controls.Add(bottomRight, 1, 0);

            page.RowCount += 1;
            page.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            page.Controls.Add(bottom, 0, page.RowCount - 1);

            // Database actions section (separate, so the form looks like the template)
            var dbGroup = new GroupBox
            {
                Text = "Baza danych",
                AutoSize = true,
                Dock = DockStyle.Top,
                Padding = new Padding(12),
                Margin = new Padding(0, 22, 0, 0)
            };

            var actionsPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
            };

            _saveButton = new Button { Text = "Zapisz do bazy", AutoSize = true };
            _saveButton.Click += SaveButton_Click;

            _entriesComboBox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 250
            };

            _loadButton = new Button { Text = "Wczytaj wpis", AutoSize = true };
            _loadButton.Click += LoadButton_Click;

            _deleteButton = new Button { Text = "Usuń wpis", AutoSize = true };
            _deleteButton.Click += DeleteButton_Click;

            actionsPanel.Controls.Add(_saveButton);
            actionsPanel.Controls.Add(new Label { Text = "Poprzednie wpisy:", AutoSize = true, Padding = new Padding(12, 8, 0, 0) });
            actionsPanel.Controls.Add(_entriesComboBox);
            actionsPanel.Controls.Add(_loadButton);
            actionsPanel.Controls.Add(_deleteButton);
            dbGroup.Controls.Add(actionsPanel);

            page.RowCount += 1;
            page.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            page.Controls.Add(dbGroup, 0, page.RowCount - 1);
        }

        private void SaveButton_Click(object? sender, EventArgs e)
        {
            try
            {
                var fields = GetFieldsFromUi();

                var id = _db.InsertEntry(fields);
                RefreshEntriesList(selectId: id);
                MessageBox.Show(this, "Zapisano.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadButton_Click(object? sender, EventArgs e)
        {
            if (_entriesComboBox?.SelectedItem is not EntrySummary summary)
                return;

            try
            {
                var fields = _db.GetEntryFieldsById(summary.Id);
                if (fields is null)
                {
                    MessageBox.Show(this, "Nie znaleziono wpisu.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SetFieldsToUi(fields);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Błąd odczytu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string?[] GetFieldsFromUi()
        {
            var fields = new string?[15];
            fields[0] = _topDateTextBox?.Text ?? string.Empty;
            fields[1] = _albumTextBox?.Text ?? string.Empty;
            fields[2] = _nameTextBox?.Text ?? string.Empty;
            fields[3] = _semestrRokTextBox?.Text ?? string.Empty;
            fields[4] = _kierunekStopienTextBox?.Text ?? string.Empty;
            fields[5] = _przedmiotTextBox?.Text ?? string.Empty;
            fields[6] = _punktyTextBox?.Text ?? string.Empty;
            fields[7] = _prowadzacyTextBox?.Text ?? string.Empty;
            fields[8] = _uzasadnienieTextBox?.Text ?? string.Empty;
            fields[9] = _dataPodpisStudentaTextBox?.Text ?? string.Empty;
            fields[10] = _decyzjaComboBox?.SelectedItem?.ToString() ?? string.Empty;
            fields[11] = _komisja1TextBox?.Text ?? string.Empty;
            fields[12] = _komisja2TextBox?.Text ?? string.Empty;
            fields[13] = _komisja3TextBox?.Text ?? string.Empty;

            var bottomDate = _bottomDateTextBox?.Text ?? string.Empty;
            var bottomStamp = _bottomStampTextBox?.Text ?? string.Empty;
            fields[14] = $"{bottomDate}||{bottomStamp}";

            return fields;
        }

        private void SetFieldsToUi(string?[] fields)
        {
            if (fields.Length != 15)
                throw new ArgumentException("Expected exactly 15 fields.", nameof(fields));

            if (_topDateTextBox is not null) _topDateTextBox.Text = fields[0] ?? string.Empty;
            if (_albumTextBox is not null) _albumTextBox.Text = fields[1] ?? string.Empty;
            if (_nameTextBox is not null) _nameTextBox.Text = fields[2] ?? string.Empty;
            if (_semestrRokTextBox is not null) _semestrRokTextBox.Text = fields[3] ?? string.Empty;
            if (_kierunekStopienTextBox is not null) _kierunekStopienTextBox.Text = fields[4] ?? string.Empty;
            if (_przedmiotTextBox is not null) _przedmiotTextBox.Text = fields[5] ?? string.Empty;
            if (_punktyTextBox is not null) _punktyTextBox.Text = fields[6] ?? string.Empty;
            if (_prowadzacyTextBox is not null) _prowadzacyTextBox.Text = fields[7] ?? string.Empty;
            if (_uzasadnienieTextBox is not null) _uzasadnienieTextBox.Text = fields[8] ?? string.Empty;
            if (_dataPodpisStudentaTextBox is not null) _dataPodpisStudentaTextBox.Text = fields[9] ?? string.Empty;

            if (_decyzjaComboBox is not null)
            {
                var value = (fields[10] ?? string.Empty).Trim();
                var index = 0;
                for (var i = 0; i < _decyzjaComboBox.Items.Count; i++)
                {
                    if (string.Equals(_decyzjaComboBox.Items[i]?.ToString(), value, StringComparison.OrdinalIgnoreCase))
                    {
                        index = i;
                        break;
                    }
                }
                _decyzjaComboBox.SelectedIndex = index;
            }

            if (_komisja1TextBox is not null) _komisja1TextBox.Text = fields[11] ?? string.Empty;
            if (_komisja2TextBox is not null) _komisja2TextBox.Text = fields[12] ?? string.Empty;
            if (_komisja3TextBox is not null) _komisja3TextBox.Text = fields[13] ?? string.Empty;

            var combined = fields[14] ?? string.Empty;
            var parts = combined.Split(new[] { "||" }, 2, StringSplitOptions.None);
            if (parts.Length == 2)
            {
                if (_bottomDateTextBox is not null) _bottomDateTextBox.Text = parts[0];
                if (_bottomStampTextBox is not null) _bottomStampTextBox.Text = parts[1];
            }
            else
            {
                if (_bottomDateTextBox is not null) _bottomDateTextBox.Text = combined;
                if (_bottomStampTextBox is not null) _bottomStampTextBox.Text = string.Empty;
            }
        }

        private void RefreshEntriesList(long? selectId)
        {
            if (_entriesComboBox is null)
                return;

            var summaries = _db.GetEntrySummaries();
            _entriesComboBox.DataSource = summaries;
            _entriesComboBox.DisplayMember = nameof(EntrySummary.Display);

            if (selectId is null)
            {
                if (summaries.Count > 0)
                    _entriesComboBox.SelectedIndex = 0;
                return;
            }

            for (var i = 0; i < summaries.Count; i++)
            {
                if (summaries[i].Id == selectId.Value)
                {
                    _entriesComboBox.SelectedIndex = i;
                    break;
                }
            }
        }

        private void DeleteButton_Click(object? sender, EventArgs e)
        {
            if (_entriesComboBox?.SelectedItem is not EntrySummary summary)
                return;

            var result = MessageBox.Show(
                this,
                $"Czy na pewno usunąć wpis Id={summary.Id}?",
                "Potwierdzenie",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                var deleted = _db.DeleteEntryById(summary.Id);
                RefreshEntriesList(selectId: null);
                if (deleted)
                    MessageBox.Show(this, "Usunięto wpis.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(this, "Wpis już nie istnieje.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Błąd usuwania", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void TryLoadLogoInto(PictureBox pictureBox)
        {
            try
            {
                var baseDir = Application.StartupPath;
                var candidates = new[]
                {
                    Path.Combine(baseDir, "logo.png"),
                    Path.Combine(baseDir, "logo.jpg"),
                    Path.Combine(baseDir, "assets", "logo.png"),
                    Path.Combine(baseDir, "assets", "logo.jpg"),
                };

                foreach (var path in candidates)
                {
                    if (!File.Exists(path))
                        continue;

                    // Use Image.FromFile directly (simple). If file is missing, logo will stay empty.
                    pictureBox.Image = Image.FromFile(path);
                    pictureBox.Visible = true;
                    return;
                }

                pictureBox.Visible = false;
            }
            catch
            {
                pictureBox.Visible = false;
            }
        }
    }
}
