namespace laby9
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.pnlScroll = new System.Windows.Forms.Panel();
            this.pnlPaper = new System.Windows.Forms.Panel();
            this.tblPaper = new System.Windows.Forms.TableLayoutPanel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.flCityDateTop = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCityDatePrefix = new System.Windows.Forms.Label();
            this.txtCityDateTop = new System.Windows.Forms.TextBox();
            this.tblAlbum = new System.Windows.Forms.TableLayoutPanel();
            this.txtAlbumNumber = new System.Windows.Forms.TextBox();
            this.lblAlbumHint = new System.Windows.Forms.Label();
            this.tblName = new System.Windows.Forms.TableLayoutPanel();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblNameHint = new System.Windows.Forms.Label();
            this.tblSemester = new System.Windows.Forms.TableLayoutPanel();
            this.txtSemesterYear = new System.Windows.Forms.TextBox();
            this.lblSemesterHint = new System.Windows.Forms.Label();
            this.tblMajor = new System.Windows.Forms.TableLayoutPanel();
            this.txtMajorDegree = new System.Windows.Forms.TextBox();
            this.lblMajorHint = new System.Windows.Forms.Label();
            this.lblProdziekan = new System.Windows.Forms.Label();
            this.lblInstitute = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblRequestIntro = new System.Windows.Forms.Label();
            this.flSubjectPoints = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSubjectPrefix = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.lblPointsPrefix = new System.Windows.Forms.Label();
            this.nudPoints = new System.Windows.Forms.NumericUpDown();
            this.lblPointsSuffix = new System.Windows.Forms.Label();
            this.flConductedBy = new System.Windows.Forms.FlowLayoutPanel();
            this.lblConductedByPrefix = new System.Windows.Forms.Label();
            this.txtConductedBy = new System.Windows.Forms.TextBox();
            this.flJustification = new System.Windows.Forms.FlowLayoutPanel();
            this.lblJustificationPrefix = new System.Windows.Forms.Label();
            this.txtJustification = new System.Windows.Forms.TextBox();
            this.tblStudentSignature = new System.Windows.Forms.TableLayoutPanel();
            this.pnlStudentSignatureRight = new System.Windows.Forms.Panel();
            this.txtStudentDateSignature = new System.Windows.Forms.TextBox();
            this.lblStudentSignatureHint = new System.Windows.Forms.Label();
            this.lblDecisionSection = new System.Windows.Forms.Label();
            this.flDecisionLine = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDecisionText = new System.Windows.Forms.Label();
            this.flDecisionRadios = new System.Windows.Forms.FlowLayoutPanel();
            this.rbDecisionYes = new System.Windows.Forms.RadioButton();
            this.rbDecisionNo = new System.Windows.Forms.RadioButton();
            this.lblCommission = new System.Windows.Forms.Label();
            this.txtCommission1 = new System.Windows.Forms.TextBox();
            this.txtCommission2 = new System.Windows.Forms.TextBox();
            this.txtCommission3 = new System.Windows.Forms.TextBox();
            this.tblBottom = new System.Windows.Forms.TableLayoutPanel();
            this.flBottomDate = new System.Windows.Forms.FlowLayoutPanel();
            this.lblBottomDatePrefix = new System.Windows.Forms.Label();
            this.txtBottomCityDate = new System.Windows.Forms.TextBox();
            this.tblStamp = new System.Windows.Forms.TableLayoutPanel();
            this.txtStampSignature = new System.Windows.Forms.TextBox();
            this.lblStampHint = new System.Windows.Forms.Label();
            this.grpDb = new System.Windows.Forms.GroupBox();
            this.tblDb = new System.Windows.Forms.TableLayoutPanel();
            this.lblRecords = new System.Windows.Forms.Label();
            this.cmbRecords = new System.Windows.Forms.ComboBox();
            this.pnlDbButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.pnlScroll.SuspendLayout();
            this.pnlPaper.SuspendLayout();
            this.tblPaper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.flCityDateTop.SuspendLayout();
            this.tblAlbum.SuspendLayout();
            this.tblName.SuspendLayout();
            this.tblSemester.SuspendLayout();
            this.tblMajor.SuspendLayout();
            this.flSubjectPoints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoints)).BeginInit();
            this.flConductedBy.SuspendLayout();
            this.flJustification.SuspendLayout();
            this.tblStudentSignature.SuspendLayout();
            this.pnlStudentSignatureRight.SuspendLayout();
            this.flDecisionLine.SuspendLayout();
            this.flDecisionRadios.SuspendLayout();
            this.tblBottom.SuspendLayout();
            this.flBottomDate.SuspendLayout();
            this.tblStamp.SuspendLayout();
            this.grpDb.SuspendLayout();
            this.tblDb.SuspendLayout();
            this.pnlDbButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitMain.IsSplitterFixed = true;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.pnlScroll);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.grpDb);
            this.splitMain.Size = new System.Drawing.Size(1040, 820);
            this.splitMain.SplitterDistance = 720;
            this.splitMain.TabIndex = 0;
            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.Controls.Add(this.pnlPaper);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.Location = new System.Drawing.Point(0, 0);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Padding = new System.Windows.Forms.Padding(16);
            this.pnlScroll.Size = new System.Drawing.Size(1040, 720);
            this.pnlScroll.TabIndex = 0;
            // 
            // pnlPaper
            // 
            this.pnlPaper.AutoSize = true;
            this.pnlPaper.BackColor = System.Drawing.Color.White;
            this.pnlPaper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPaper.Controls.Add(this.tblPaper);
            this.pnlPaper.Location = new System.Drawing.Point(16, 16);
            this.pnlPaper.Name = "pnlPaper";
            this.pnlPaper.Padding = new System.Windows.Forms.Padding(24);
            this.pnlPaper.Size = new System.Drawing.Size(860, 1200);
            this.pnlPaper.TabIndex = 0;
            // 
            // tblPaper
            // 
            this.tblPaper.AutoSize = true;
            this.tblPaper.ColumnCount = 1;
            this.tblPaper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPaper.Controls.Add(this.picLogo, 0, 0);
            this.tblPaper.Controls.Add(this.flCityDateTop, 0, 1);
            this.tblPaper.Controls.Add(this.tblAlbum, 0, 2);
            this.tblPaper.Controls.Add(this.tblName, 0, 3);
            this.tblPaper.Controls.Add(this.tblSemester, 0, 4);
            this.tblPaper.Controls.Add(this.tblMajor, 0, 5);
            this.tblPaper.Controls.Add(this.lblProdziekan, 0, 6);
            this.tblPaper.Controls.Add(this.lblInstitute, 0, 7);
            this.tblPaper.Controls.Add(this.lblTitle, 0, 8);
            this.tblPaper.Controls.Add(this.lblRequestIntro, 0, 9);
            this.tblPaper.Controls.Add(this.flSubjectPoints, 0, 10);
            this.tblPaper.Controls.Add(this.flConductedBy, 0, 11);
            this.tblPaper.Controls.Add(this.flJustification, 0, 12);
            this.tblPaper.Controls.Add(this.tblStudentSignature, 0, 13);
            this.tblPaper.Controls.Add(this.lblDecisionSection, 0, 14);
            this.tblPaper.Controls.Add(this.flDecisionLine, 0, 15);
            this.tblPaper.Controls.Add(this.lblCommission, 0, 16);
            this.tblPaper.Controls.Add(this.txtCommission1, 0, 17);
            this.tblPaper.Controls.Add(this.txtCommission2, 0, 18);
            this.tblPaper.Controls.Add(this.txtCommission3, 0, 19);
            this.tblPaper.Controls.Add(this.tblBottom, 0, 20);
            this.tblPaper.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblPaper.Location = new System.Drawing.Point(24, 24);
            this.tblPaper.Name = "tblPaper";
            this.tblPaper.RowCount = 21;
            this.tblPaper.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblPaper.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblPaper.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblPaper.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblPaper.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblPaper.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblPaper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tblPaper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tblPaper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tblPaper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tblPaper.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblPaper.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblPaper.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblPaper.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblPaper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tblPaper.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblPaper.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblPaper.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblPaper.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblPaper.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblPaper.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblPaper.Size = new System.Drawing.Size(810, 1150);
            this.tblPaper.TabIndex = 0;
            // 
            // picLogo
            // 
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.picLogo.Location = new System.Drawing.Point(3, 3);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(804, 120);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // flCityDateTop
            // 
            this.flCityDateTop.AutoSize = true;
            this.flCityDateTop.Controls.Add(this.lblCityDatePrefix);
            this.flCityDateTop.Controls.Add(this.txtCityDateTop);
            this.flCityDateTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flCityDateTop.Location = new System.Drawing.Point(3, 129);
            this.flCityDateTop.Name = "flCityDateTop";
            this.flCityDateTop.Size = new System.Drawing.Size(804, 29);
            this.flCityDateTop.TabIndex = 1;
            this.flCityDateTop.WrapContents = false;
            // 
            // lblCityDatePrefix
            // 
            this.lblCityDatePrefix.AutoSize = true;
            this.lblCityDatePrefix.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lblCityDatePrefix.Name = "lblCityDatePrefix";
            this.lblCityDatePrefix.Size = new System.Drawing.Size(83, 21);
            this.lblCityDatePrefix.TabIndex = 0;
            this.lblCityDatePrefix.Text = "Poznań, dnia";
            // 
            // txtCityDateTop
            // 
            this.txtCityDateTop.Location = new System.Drawing.Point(92, 3);
            this.txtCityDateTop.Name = "txtCityDateTop";
            this.txtCityDateTop.Size = new System.Drawing.Size(260, 23);
            this.txtCityDateTop.TabIndex = 1;
            // 
            // tblAlbum
            // 
            this.tblAlbum.AutoSize = true;
            this.tblAlbum.ColumnCount = 1;
            this.tblAlbum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblAlbum.Controls.Add(this.txtAlbumNumber, 0, 0);
            this.tblAlbum.Controls.Add(this.lblAlbumHint, 0, 1);
            this.tblAlbum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblAlbum.Location = new System.Drawing.Point(3, 164);
            this.tblAlbum.Name = "tblAlbum";
            this.tblAlbum.RowCount = 2;
            this.tblAlbum.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblAlbum.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tblAlbum.Size = new System.Drawing.Size(804, 44);
            this.tblAlbum.TabIndex = 2;
            // 
            // txtAlbumNumber
            // 
            this.txtAlbumNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtAlbumNumber.Location = new System.Drawing.Point(3, 3);
            this.txtAlbumNumber.Name = "txtAlbumNumber";
            this.txtAlbumNumber.Size = new System.Drawing.Size(798, 23);
            this.txtAlbumNumber.TabIndex = 0;
            // 
            // lblAlbumHint
            // 
            this.lblAlbumHint.AutoSize = true;
            this.lblAlbumHint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlbumHint.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblAlbumHint.Location = new System.Drawing.Point(3, 29);
            this.lblAlbumHint.Name = "lblAlbumHint";
            this.lblAlbumHint.Size = new System.Drawing.Size(798, 18);
            this.lblAlbumHint.TabIndex = 1;
            this.lblAlbumHint.Text = "numer albumu";
            // 
            // tblName
            // 
            this.tblName.AutoSize = true;
            this.tblName.ColumnCount = 1;
            this.tblName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblName.Controls.Add(this.txtFullName, 0, 0);
            this.tblName.Controls.Add(this.lblNameHint, 0, 1);
            this.tblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblName.Location = new System.Drawing.Point(3, 214);
            this.tblName.Name = "tblName";
            this.tblName.RowCount = 2;
            this.tblName.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tblName.Size = new System.Drawing.Size(804, 44);
            this.tblName.TabIndex = 3;
            // 
            // txtFullName
            // 
            this.txtFullName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtFullName.Location = new System.Drawing.Point(3, 3);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(798, 23);
            this.txtFullName.TabIndex = 0;
            // 
            // lblNameHint
            // 
            this.lblNameHint.AutoSize = true;
            this.lblNameHint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNameHint.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblNameHint.Location = new System.Drawing.Point(3, 29);
            this.lblNameHint.Name = "lblNameHint";
            this.lblNameHint.Size = new System.Drawing.Size(798, 18);
            this.lblNameHint.TabIndex = 1;
            this.lblNameHint.Text = "nazwisko i imię";
            // 
            // tblSemester
            // 
            this.tblSemester.AutoSize = true;
            this.tblSemester.ColumnCount = 1;
            this.tblSemester.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSemester.Controls.Add(this.txtSemesterYear, 0, 0);
            this.tblSemester.Controls.Add(this.lblSemesterHint, 0, 1);
            this.tblSemester.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSemester.Location = new System.Drawing.Point(3, 264);
            this.tblSemester.Name = "tblSemester";
            this.tblSemester.RowCount = 2;
            this.tblSemester.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblSemester.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tblSemester.Size = new System.Drawing.Size(804, 44);
            this.tblSemester.TabIndex = 4;
            // 
            // txtSemesterYear
            // 
            this.txtSemesterYear.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSemesterYear.Location = new System.Drawing.Point(3, 3);
            this.txtSemesterYear.Name = "txtSemesterYear";
            this.txtSemesterYear.Size = new System.Drawing.Size(798, 23);
            this.txtSemesterYear.TabIndex = 0;
            // 
            // lblSemesterHint
            // 
            this.lblSemesterHint.AutoSize = true;
            this.lblSemesterHint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSemesterHint.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblSemesterHint.Location = new System.Drawing.Point(3, 29);
            this.lblSemesterHint.Name = "lblSemesterHint";
            this.lblSemesterHint.Size = new System.Drawing.Size(798, 18);
            this.lblSemesterHint.TabIndex = 1;
            this.lblSemesterHint.Text = "semestr, rok";
            // 
            // tblMajor
            // 
            this.tblMajor.AutoSize = true;
            this.tblMajor.ColumnCount = 1;
            this.tblMajor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMajor.Controls.Add(this.txtMajorDegree, 0, 0);
            this.tblMajor.Controls.Add(this.lblMajorHint, 0, 1);
            this.tblMajor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMajor.Location = new System.Drawing.Point(3, 314);
            this.tblMajor.Name = "tblMajor";
            this.tblMajor.RowCount = 2;
            this.tblMajor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblMajor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tblMajor.Size = new System.Drawing.Size(804, 62);
            this.tblMajor.TabIndex = 5;
            // 
            // txtMajorDegree
            // 
            this.txtMajorDegree.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtMajorDegree.Location = new System.Drawing.Point(3, 3);
            this.txtMajorDegree.Multiline = true;
            this.txtMajorDegree.Name = "txtMajorDegree";
            this.txtMajorDegree.Size = new System.Drawing.Size(798, 38);
            this.txtMajorDegree.TabIndex = 0;
            // 
            // lblMajorHint
            // 
            this.lblMajorHint.AutoSize = true;
            this.lblMajorHint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMajorHint.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblMajorHint.Location = new System.Drawing.Point(3, 44);
            this.lblMajorHint.Name = "lblMajorHint";
            this.lblMajorHint.Size = new System.Drawing.Size(798, 18);
            this.lblMajorHint.TabIndex = 1;
            this.lblMajorHint.Text = "kierunek i stopień studiów";
            // 
            // lblProdziekan
            // 
            this.lblProdziekan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProdziekan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProdziekan.Location = new System.Drawing.Point(3, 379);
            this.lblProdziekan.Name = "lblProdziekan";
            this.lblProdziekan.Size = new System.Drawing.Size(804, 26);
            this.lblProdziekan.TabIndex = 6;
            this.lblProdziekan.Text = "PRODZIEKAN WYDZIAŁU";
            this.lblProdziekan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInstitute
            // 
            this.lblInstitute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInstitute.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblInstitute.Location = new System.Drawing.Point(3, 405);
            this.lblInstitute.Name = "lblInstitute";
            this.lblInstitute.Size = new System.Drawing.Size(804, 26);
            this.lblInstitute.TabIndex = 7;
            this.lblInstitute.Text = "INFORMATYKI I TELEKOMUNIKACJI";
            this.lblInstitute.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(3, 431);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(804, 42);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "WNIOSEK O PRZEPROWADZENIE EGZAMINU KOMISYJNEGO";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRequestIntro
            // 
            this.lblRequestIntro.AutoSize = true;
            this.lblRequestIntro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRequestIntro.Location = new System.Drawing.Point(3, 473);
            this.lblRequestIntro.Name = "lblRequestIntro";
            this.lblRequestIntro.Size = new System.Drawing.Size(804, 26);
            this.lblRequestIntro.TabIndex = 9;
            this.lblRequestIntro.Text = "Proszę o umożliwienie mi przystąpienia do egzaminu komisyjnego z";
            // 
            // flSubjectPoints
            // 
            this.flSubjectPoints.AutoSize = true;
            this.flSubjectPoints.Controls.Add(this.lblSubjectPrefix);
            this.flSubjectPoints.Controls.Add(this.txtSubject);
            this.flSubjectPoints.Controls.Add(this.lblPointsPrefix);
            this.flSubjectPoints.Controls.Add(this.nudPoints);
            this.flSubjectPoints.Controls.Add(this.lblPointsSuffix);
            this.flSubjectPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flSubjectPoints.Location = new System.Drawing.Point(3, 502);
            this.flSubjectPoints.Name = "flSubjectPoints";
            this.flSubjectPoints.Size = new System.Drawing.Size(804, 29);
            this.flSubjectPoints.TabIndex = 10;
            this.flSubjectPoints.WrapContents = false;
            // 
            // lblSubjectPrefix
            // 
            this.lblSubjectPrefix.AutoSize = true;
            this.lblSubjectPrefix.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lblSubjectPrefix.Name = "lblSubjectPrefix";
            this.lblSubjectPrefix.Size = new System.Drawing.Size(67, 21);
            this.lblSubjectPrefix.TabIndex = 0;
            this.lblSubjectPrefix.Text = "przedmiotu";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(76, 3);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(360, 23);
            this.txtSubject.TabIndex = 1;
            // 
            // lblPointsPrefix
            // 
            this.lblPointsPrefix.AutoSize = true;
            this.lblPointsPrefix.Padding = new System.Windows.Forms.Padding(6, 6, 0, 0);
            this.lblPointsPrefix.Name = "lblPointsPrefix";
            this.lblPointsPrefix.Size = new System.Drawing.Size(45, 21);
            this.lblPointsPrefix.TabIndex = 2;
            this.lblPointsPrefix.Text = "- punkty";
            // 
            // nudPoints
            // 
            this.nudPoints.Location = new System.Drawing.Point(524, 3);
            this.nudPoints.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudPoints.Name = "nudPoints";
            this.nudPoints.Size = new System.Drawing.Size(90, 23);
            this.nudPoints.TabIndex = 3;
            // 
            // lblPointsSuffix
            // 
            this.lblPointsSuffix.AutoSize = true;
            this.lblPointsSuffix.Padding = new System.Windows.Forms.Padding(4, 6, 0, 0);
            this.lblPointsSuffix.Name = "lblPointsSuffix";
            this.lblPointsSuffix.Size = new System.Drawing.Size(0, 21);
            this.lblPointsSuffix.TabIndex = 4;
            // 
            // flConductedBy
            // 
            this.flConductedBy.AutoSize = true;
            this.flConductedBy.Controls.Add(this.lblConductedByPrefix);
            this.flConductedBy.Controls.Add(this.txtConductedBy);
            this.flConductedBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flConductedBy.Location = new System.Drawing.Point(3, 537);
            this.flConductedBy.Name = "flConductedBy";
            this.flConductedBy.Size = new System.Drawing.Size(804, 29);
            this.flConductedBy.TabIndex = 11;
            this.flConductedBy.WrapContents = false;
            // 
            // lblConductedByPrefix
            // 
            this.lblConductedByPrefix.AutoSize = true;
            this.lblConductedByPrefix.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lblConductedByPrefix.Name = "lblConductedByPrefix";
            this.lblConductedByPrefix.Size = new System.Drawing.Size(106, 21);
            this.lblConductedByPrefix.TabIndex = 0;
            this.lblConductedByPrefix.Text = "prowadzonego przez";
            // 
            // txtConductedBy
            // 
            this.txtConductedBy.Location = new System.Drawing.Point(115, 3);
            this.txtConductedBy.Name = "txtConductedBy";
            this.txtConductedBy.Size = new System.Drawing.Size(540, 23);
            this.txtConductedBy.TabIndex = 1;
            // 
            // flJustification
            // 
            this.flJustification.AutoSize = true;
            this.flJustification.Controls.Add(this.lblJustificationPrefix);
            this.flJustification.Controls.Add(this.txtJustification);
            this.flJustification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flJustification.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flJustification.Location = new System.Drawing.Point(3, 572);
            this.flJustification.Name = "flJustification";
            this.flJustification.Size = new System.Drawing.Size(804, 164);
            this.flJustification.TabIndex = 12;
            this.flJustification.WrapContents = false;
            // 
            // lblJustificationPrefix
            // 
            this.lblJustificationPrefix.AutoSize = true;
            this.lblJustificationPrefix.Name = "lblJustificationPrefix";
            this.lblJustificationPrefix.Size = new System.Drawing.Size(116, 15);
            this.lblJustificationPrefix.TabIndex = 0;
            this.lblJustificationPrefix.Text = "Uzasadnienie wniosku:";
            // 
            // txtJustification
            // 
            this.txtJustification.Location = new System.Drawing.Point(3, 18);
            this.txtJustification.Multiline = true;
            this.txtJustification.Name = "txtJustification";
            this.txtJustification.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtJustification.Size = new System.Drawing.Size(798, 143);
            this.txtJustification.TabIndex = 1;
            // 
            // tblStudentSignature
            // 
            this.tblStudentSignature.AutoSize = true;
            this.tblStudentSignature.ColumnCount = 2;
            this.tblStudentSignature.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblStudentSignature.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblStudentSignature.Controls.Add(this.pnlStudentSignatureRight, 1, 0);
            this.tblStudentSignature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblStudentSignature.Location = new System.Drawing.Point(3, 742);
            this.tblStudentSignature.Name = "tblStudentSignature";
            this.tblStudentSignature.RowCount = 1;
            this.tblStudentSignature.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblStudentSignature.Size = new System.Drawing.Size(804, 52);
            this.tblStudentSignature.TabIndex = 13;
            // 
            // pnlStudentSignatureRight
            // 
            this.pnlStudentSignatureRight.AutoSize = true;
            this.pnlStudentSignatureRight.Controls.Add(this.lblStudentSignatureHint);
            this.pnlStudentSignatureRight.Controls.Add(this.txtStudentDateSignature);
            this.pnlStudentSignatureRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlStudentSignatureRight.Location = new System.Drawing.Point(530, 3);
            this.pnlStudentSignatureRight.Name = "pnlStudentSignatureRight";
            this.pnlStudentSignatureRight.Size = new System.Drawing.Size(271, 46);
            this.pnlStudentSignatureRight.TabIndex = 0;
            // 
            // txtStudentDateSignature
            // 
            this.txtStudentDateSignature.Location = new System.Drawing.Point(0, 0);
            this.txtStudentDateSignature.Name = "txtStudentDateSignature";
            this.txtStudentDateSignature.Size = new System.Drawing.Size(270, 23);
            this.txtStudentDateSignature.TabIndex = 0;
            // 
            // lblStudentSignatureHint
            // 
            this.lblStudentSignatureHint.AutoSize = true;
            this.lblStudentSignatureHint.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblStudentSignatureHint.Location = new System.Drawing.Point(78, 26);
            this.lblStudentSignatureHint.Name = "lblStudentSignatureHint";
            this.lblStudentSignatureHint.Size = new System.Drawing.Size(98, 13);
            this.lblStudentSignatureHint.TabIndex = 1;
            this.lblStudentSignatureHint.Text = "data i podpis studenta";
            // 
            // lblDecisionSection
            // 
            this.lblDecisionSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDecisionSection.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDecisionSection.Location = new System.Drawing.Point(3, 797);
            this.lblDecisionSection.Name = "lblDecisionSection";
            this.lblDecisionSection.Size = new System.Drawing.Size(804, 36);
            this.lblDecisionSection.TabIndex = 14;
            this.lblDecisionSection.Text = "DECYZJA";
            // 
            // flDecisionLine
            // 
            this.flDecisionLine.AutoSize = true;
            this.flDecisionLine.Controls.Add(this.lblDecisionText);
            this.flDecisionLine.Controls.Add(this.flDecisionRadios);
            this.flDecisionLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flDecisionLine.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flDecisionLine.Location = new System.Drawing.Point(3, 836);
            this.flDecisionLine.Name = "flDecisionLine";
            this.flDecisionLine.Size = new System.Drawing.Size(804, 29);
            this.flDecisionLine.TabIndex = 15;
            this.flDecisionLine.WrapContents = false;
            // 
            // lblDecisionText
            // 
            this.lblDecisionText.AutoSize = true;
            this.lblDecisionText.Name = "lblDecisionText";
            this.lblDecisionText.Size = new System.Drawing.Size(418, 15);
            this.lblDecisionText.TabIndex = 0;
            this.lblDecisionText.Text = "Wyrażam / nie wyrażam zgod(ę)y na przeprowadzenie egzaminu komisyjnego";
            // 
            // flDecisionRadios
            // 
            this.flDecisionRadios.AutoSize = true;
            this.flDecisionRadios.Controls.Add(this.rbDecisionYes);
            this.flDecisionRadios.Controls.Add(this.rbDecisionNo);
            this.flDecisionRadios.Location = new System.Drawing.Point(3, 18);
            this.flDecisionRadios.Name = "flDecisionRadios";
            this.flDecisionRadios.Size = new System.Drawing.Size(255, 25);
            this.flDecisionRadios.TabIndex = 1;
            this.flDecisionRadios.WrapContents = false;
            // 
            // rbDecisionYes
            // 
            this.rbDecisionYes.AutoSize = true;
            this.rbDecisionYes.Location = new System.Drawing.Point(3, 3);
            this.rbDecisionYes.Name = "rbDecisionYes";
            this.rbDecisionYes.Size = new System.Drawing.Size(106, 19);
            this.rbDecisionYes.TabIndex = 0;
            this.rbDecisionYes.TabStop = true;
            this.rbDecisionYes.Text = "Wyrażam zgodę";
            this.rbDecisionYes.UseVisualStyleBackColor = true;
            // 
            // rbDecisionNo
            // 
            this.rbDecisionNo.AutoSize = true;
            this.rbDecisionNo.Location = new System.Drawing.Point(130, 3);
            this.rbDecisionNo.Name = "rbDecisionNo";
            this.rbDecisionNo.Size = new System.Drawing.Size(122, 19);
            this.rbDecisionNo.TabIndex = 1;
            this.rbDecisionNo.TabStop = true;
            this.rbDecisionNo.Text = "Nie wyrażam zgody";
            this.rbDecisionNo.UseVisualStyleBackColor = true;
            // 
            // lblCommission
            // 
            this.lblCommission.AutoSize = true;
            this.lblCommission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCommission.Location = new System.Drawing.Point(3, 868);
            this.lblCommission.Name = "lblCommission";
            this.lblCommission.Size = new System.Drawing.Size(804, 15);
            this.lblCommission.TabIndex = 16;
            this.lblCommission.Text = "Skład komisji:";
            // 
            // txtCommission1
            // 
            this.txtCommission1.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCommission1.Location = new System.Drawing.Point(3, 886);
            this.txtCommission1.Name = "txtCommission1";
            this.txtCommission1.Size = new System.Drawing.Size(804, 23);
            this.txtCommission1.TabIndex = 17;
            // 
            // txtCommission2
            // 
            this.txtCommission2.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCommission2.Location = new System.Drawing.Point(3, 915);
            this.txtCommission2.Name = "txtCommission2";
            this.txtCommission2.Size = new System.Drawing.Size(804, 23);
            this.txtCommission2.TabIndex = 18;
            // 
            // txtCommission3
            // 
            this.txtCommission3.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCommission3.Location = new System.Drawing.Point(3, 944);
            this.txtCommission3.Name = "txtCommission3";
            this.txtCommission3.Size = new System.Drawing.Size(804, 23);
            this.txtCommission3.TabIndex = 19;
            // 
            // tblBottom
            // 
            this.tblBottom.AutoSize = true;
            this.tblBottom.ColumnCount = 2;
            this.tblBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tblBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tblBottom.Controls.Add(this.flBottomDate, 0, 0);
            this.tblBottom.Controls.Add(this.tblStamp, 1, 0);
            this.tblBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblBottom.Location = new System.Drawing.Point(3, 973);
            this.tblBottom.Name = "tblBottom";
            this.tblBottom.RowCount = 1;
            this.tblBottom.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblBottom.Size = new System.Drawing.Size(804, 52);
            this.tblBottom.TabIndex = 20;
            // 
            // flBottomDate
            // 
            this.flBottomDate.AutoSize = true;
            this.flBottomDate.Controls.Add(this.lblBottomDatePrefix);
            this.flBottomDate.Controls.Add(this.txtBottomCityDate);
            this.flBottomDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flBottomDate.Location = new System.Drawing.Point(3, 3);
            this.flBottomDate.Name = "flBottomDate";
            this.flBottomDate.Size = new System.Drawing.Size(436, 46);
            this.flBottomDate.TabIndex = 0;
            this.flBottomDate.WrapContents = false;
            // 
            // lblBottomDatePrefix
            // 
            this.lblBottomDatePrefix.AutoSize = true;
            this.lblBottomDatePrefix.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lblBottomDatePrefix.Name = "lblBottomDatePrefix";
            this.lblBottomDatePrefix.Size = new System.Drawing.Size(83, 21);
            this.lblBottomDatePrefix.TabIndex = 0;
            this.lblBottomDatePrefix.Text = "Poznań, dnia";
            // 
            // txtBottomCityDate
            // 
            this.txtBottomCityDate.Location = new System.Drawing.Point(92, 3);
            this.txtBottomCityDate.Name = "txtBottomCityDate";
            this.txtBottomCityDate.Size = new System.Drawing.Size(260, 23);
            this.txtBottomCityDate.TabIndex = 1;
            // 
            // tblStamp
            // 
            this.tblStamp.AutoSize = true;
            this.tblStamp.ColumnCount = 1;
            this.tblStamp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblStamp.Controls.Add(this.txtStampSignature, 0, 0);
            this.tblStamp.Controls.Add(this.lblStampHint, 0, 1);
            this.tblStamp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblStamp.Location = new System.Drawing.Point(445, 3);
            this.tblStamp.Name = "tblStamp";
            this.tblStamp.RowCount = 2;
            this.tblStamp.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblStamp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tblStamp.Size = new System.Drawing.Size(356, 46);
            this.tblStamp.TabIndex = 1;
            // 
            // txtStampSignature
            // 
            this.txtStampSignature.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtStampSignature.Location = new System.Drawing.Point(3, 3);
            this.txtStampSignature.Name = "txtStampSignature";
            this.txtStampSignature.Size = new System.Drawing.Size(350, 23);
            this.txtStampSignature.TabIndex = 0;
            // 
            // lblStampHint
            // 
            this.lblStampHint.AutoSize = true;
            this.lblStampHint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStampHint.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblStampHint.Location = new System.Drawing.Point(3, 29);
            this.lblStampHint.Name = "lblStampHint";
            this.lblStampHint.Size = new System.Drawing.Size(350, 18);
            this.lblStampHint.TabIndex = 1;
            this.lblStampHint.Text = "Pieczątka i podpis";
            // 
            // grpDb
            // 
            this.grpDb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDb.Controls.Add(this.tblDb);
            this.grpDb.Name = "grpDb";
            this.grpDb.Size = new System.Drawing.Size(1040, 96);
            this.grpDb.TabIndex = 0;
            this.grpDb.TabStop = false;
            this.grpDb.Text = "Baza danych (.db)";
            // 
            // tblDb
            // 
            this.tblDb.AutoSize = true;
            this.tblDb.ColumnCount = 2;
            this.tblDb.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tblDb.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblDb.Controls.Add(this.lblRecords, 0, 0);
            this.tblDb.Controls.Add(this.cmbRecords, 1, 0);
            this.tblDb.Controls.Add(this.pnlDbButtons, 1, 1);
            this.tblDb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDb.Location = new System.Drawing.Point(3, 19);
            this.tblDb.Name = "tblDb";
            this.tblDb.RowCount = 2;
            this.tblDb.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDb.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblDb.Size = new System.Drawing.Size(1034, 74);
            this.tblDb.TabIndex = 0;
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRecords.Location = new System.Drawing.Point(3, 0);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lblRecords.Size = new System.Drawing.Size(214, 30);
            this.lblRecords.TabIndex = 0;
            this.lblRecords.Text = "Poprzednie wpisy:";
            // 
            // cmbRecords
            // 
            this.cmbRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbRecords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecords.FormattingEnabled = true;
            this.cmbRecords.Location = new System.Drawing.Point(223, 3);
            this.cmbRecords.Name = "cmbRecords";
            this.cmbRecords.Size = new System.Drawing.Size(808, 23);
            this.cmbRecords.TabIndex = 1;
            // 
            // pnlDbButtons
            // 
            this.pnlDbButtons.AutoSize = true;
            this.pnlDbButtons.Controls.Add(this.btnRefresh);
            this.pnlDbButtons.Controls.Add(this.btnLoad);
            this.pnlDbButtons.Controls.Add(this.btnSave);
            this.pnlDbButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDbButtons.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.pnlDbButtons.Location = new System.Drawing.Point(223, 33);
            this.pnlDbButtons.Name = "pnlDbButtons";
            this.pnlDbButtons.Size = new System.Drawing.Size(808, 38);
            this.pnlDbButtons.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.Location = new System.Drawing.Point(3, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(112, 25);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Odśwież listę";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.AutoSize = true;
            this.btnLoad.Location = new System.Drawing.Point(121, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(110, 25);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Wczytaj";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Location = new System.Drawing.Point(237, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 25);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Zapisz do bazy";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 820);
            this.Controls.Add(this.splitMain);
            this.MinimumSize = new System.Drawing.Size(900, 650);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wniosek o przeprowadzenie egzaminu komisyjnego";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.pnlScroll.ResumeLayout(false);
            this.pnlScroll.PerformLayout();
            this.pnlPaper.ResumeLayout(false);
            this.pnlPaper.PerformLayout();
            this.tblPaper.ResumeLayout(false);
            this.tblPaper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.flCityDateTop.ResumeLayout(false);
            this.flCityDateTop.PerformLayout();
            this.tblAlbum.ResumeLayout(false);
            this.tblAlbum.PerformLayout();
            this.tblName.ResumeLayout(false);
            this.tblName.PerformLayout();
            this.tblSemester.ResumeLayout(false);
            this.tblSemester.PerformLayout();
            this.tblMajor.ResumeLayout(false);
            this.tblMajor.PerformLayout();
            this.flSubjectPoints.ResumeLayout(false);
            this.flSubjectPoints.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoints)).EndInit();
            this.flConductedBy.ResumeLayout(false);
            this.flConductedBy.PerformLayout();
            this.flJustification.ResumeLayout(false);
            this.flJustification.PerformLayout();
            this.tblStudentSignature.ResumeLayout(false);
            this.tblStudentSignature.PerformLayout();
            this.pnlStudentSignatureRight.ResumeLayout(false);
            this.pnlStudentSignatureRight.PerformLayout();
            this.flDecisionLine.ResumeLayout(false);
            this.flDecisionLine.PerformLayout();
            this.flDecisionRadios.ResumeLayout(false);
            this.flDecisionRadios.PerformLayout();
            this.tblBottom.ResumeLayout(false);
            this.tblBottom.PerformLayout();
            this.flBottomDate.ResumeLayout(false);
            this.flBottomDate.PerformLayout();
            this.tblStamp.ResumeLayout(false);
            this.tblStamp.PerformLayout();
            this.grpDb.ResumeLayout(false);
            this.grpDb.PerformLayout();
            this.tblDb.ResumeLayout(false);
            this.tblDb.PerformLayout();
            this.pnlDbButtons.ResumeLayout(false);
            this.pnlDbButtons.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.Panel pnlScroll;
        private System.Windows.Forms.Panel pnlPaper;
        private System.Windows.Forms.TableLayoutPanel tblPaper;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.FlowLayoutPanel flCityDateTop;
        private System.Windows.Forms.Label lblCityDatePrefix;
        private System.Windows.Forms.GroupBox grpDb;
        private System.Windows.Forms.TableLayoutPanel tblDb;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.ComboBox cmbRecords;
        private System.Windows.Forms.FlowLayoutPanel pnlDbButtons;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;

        private System.Windows.Forms.TextBox txtCityDateTop;

        private System.Windows.Forms.TableLayoutPanel tblAlbum;
        private System.Windows.Forms.TextBox txtAlbumNumber;
        private System.Windows.Forms.Label lblAlbumHint;

        private System.Windows.Forms.TableLayoutPanel tblName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblNameHint;

        private System.Windows.Forms.TableLayoutPanel tblSemester;
        private System.Windows.Forms.TextBox txtSemesterYear;
        private System.Windows.Forms.Label lblSemesterHint;

        private System.Windows.Forms.TableLayoutPanel tblMajor;
        private System.Windows.Forms.TextBox txtMajorDegree;
        private System.Windows.Forms.Label lblMajorHint;

        private System.Windows.Forms.Label lblProdziekan;
        private System.Windows.Forms.Label lblInstitute;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRequestIntro;

        private System.Windows.Forms.FlowLayoutPanel flSubjectPoints;
        private System.Windows.Forms.Label lblSubjectPrefix;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label lblPointsPrefix;
        private System.Windows.Forms.NumericUpDown nudPoints;
        private System.Windows.Forms.Label lblPointsSuffix;

        private System.Windows.Forms.FlowLayoutPanel flConductedBy;
        private System.Windows.Forms.Label lblConductedByPrefix;
        private System.Windows.Forms.TextBox txtConductedBy;

        private System.Windows.Forms.FlowLayoutPanel flJustification;
        private System.Windows.Forms.Label lblJustificationPrefix;
        private System.Windows.Forms.TextBox txtJustification;

        private System.Windows.Forms.TableLayoutPanel tblStudentSignature;
        private System.Windows.Forms.Panel pnlStudentSignatureRight;
        private System.Windows.Forms.TextBox txtStudentDateSignature;
        private System.Windows.Forms.Label lblStudentSignatureHint;

        private System.Windows.Forms.Label lblDecisionSection;
        private System.Windows.Forms.FlowLayoutPanel flDecisionLine;
        private System.Windows.Forms.Label lblDecisionText;
        private System.Windows.Forms.FlowLayoutPanel flDecisionRadios;
        private System.Windows.Forms.RadioButton rbDecisionYes;
        private System.Windows.Forms.RadioButton rbDecisionNo;

        private System.Windows.Forms.Label lblCommission;
        private System.Windows.Forms.TextBox txtCommission1;
        private System.Windows.Forms.TextBox txtCommission2;
        private System.Windows.Forms.TextBox txtCommission3;

        private System.Windows.Forms.TableLayoutPanel tblBottom;
        private System.Windows.Forms.FlowLayoutPanel flBottomDate;
        private System.Windows.Forms.Label lblBottomDatePrefix;
        private System.Windows.Forms.TextBox txtBottomCityDate;
        private System.Windows.Forms.TableLayoutPanel tblStamp;
        private System.Windows.Forms.TextBox txtStampSignature;
        private System.Windows.Forms.Label lblStampHint;
    }
}
