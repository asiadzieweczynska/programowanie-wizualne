namespace projekt6
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
            label1 = new Label();
            start = new Button();
            ustaiwienia = new Button();
            koniec = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 34);
            label1.Name = "label1";
            label1.Size = new Size(147, 20);
            label1.TabIndex = 0;
            label1.Text = "GDZIE JEST DYDELF?";
            label1.Click += label1_Click;
            // 
            // start
            // 
            start.Location = new Point(51, 175);
            start.Name = "start";
            start.Size = new Size(135, 60);
            start.TabIndex = 1;
            start.Text = "start";
            start.UseVisualStyleBackColor = true;
            start.Click += start_Click;
            // 
            // ustaiwienia
            // 
            ustaiwienia.Location = new Point(51, 266);
            ustaiwienia.Name = "ustaiwienia";
            ustaiwienia.Size = new Size(135, 57);
            ustaiwienia.TabIndex = 2;
            ustaiwienia.Text = "ustawienia";
            ustaiwienia.UseVisualStyleBackColor = true;
            ustaiwienia.Click += ustaiwienia_Click;
            // 
            // koniec
            // 
            koniec.Location = new Point(51, 354);
            koniec.Name = "koniec";
            koniec.Size = new Size(135, 60);
            koniec.TabIndex = 3;
            koniec.Text = "koniec";
            koniec.UseVisualStyleBackColor = true;
            koniec.Click += koniec_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(247, 450);
            Controls.Add(koniec);
            Controls.Add(ustaiwienia);
            Controls.Add(start);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button start;
        private Button ustaiwienia;
        private Button koniec;
    }
}
