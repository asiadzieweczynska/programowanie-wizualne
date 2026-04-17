namespace projekt6
{
    partial class Ustawienia
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            X = new NumericUpDown();
            Y = new NumericUpDown();
            dydelfy = new NumericUpDown();
            krokodyle = new NumericUpDown();
            szopy = new NumericUpDown();
            czas = new NumericUpDown();
            ok = new Button();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)X).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Y).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dydelfy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)krokodyle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)szopy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)czas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 70);
            label1.Name = "label1";
            label1.Size = new Size(59, 20);
            label1.TabIndex = 0;
            label1.Text = "plansza";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 100);
            label2.Name = "label2";
            label2.Size = new Size(18, 20);
            label2.TabIndex = 1;
            label2.Text = "X";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 184);
            label3.Name = "label3";
            label3.Size = new Size(17, 20);
            label3.TabIndex = 2;
            label3.Text = "Y";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 264);
            label4.Name = "label4";
            label4.Size = new Size(37, 20);
            label4.TabIndex = 3;
            label4.Text = "czas";
            // 
            // X
            // 
            X.Location = new Point(68, 93);
            X.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            X.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            X.Name = "X";
            X.Size = new Size(88, 27);
            X.TabIndex = 4;
            X.Value = new decimal(new int[] { 3, 0, 0, 0 });
            X.ValueChanged += X_ValueChanged;
            // 
            // Y
            // 
            Y.Location = new Point(68, 182);
            Y.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            Y.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            Y.Name = "Y";
            Y.Size = new Size(88, 27);
            Y.TabIndex = 5;
            Y.Value = new decimal(new int[] { 3, 0, 0, 0 });
            Y.ValueChanged += Y_ValueChanged;
            // 
            // dydelfy
            // 
            dydelfy.Location = new Point(321, 93);
            dydelfy.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            dydelfy.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            dydelfy.Name = "dydelfy";
            dydelfy.Size = new Size(87, 27);
            dydelfy.TabIndex = 6;
            dydelfy.Value = new decimal(new int[] { 1, 0, 0, 0 });
            dydelfy.ValueChanged += dydelfy_ValueChanged;
            // 
            // krokodyle
            // 
            krokodyle.Location = new Point(321, 182);
            krokodyle.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            krokodyle.Name = "krokodyle";
            krokodyle.Size = new Size(87, 27);
            krokodyle.TabIndex = 7;
            krokodyle.ValueChanged += krokodyle_ValueChanged;
            // 
            // szopy
            // 
            szopy.Location = new Point(321, 272);
            szopy.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            szopy.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            szopy.Name = "szopy";
            szopy.Size = new Size(87, 27);
            szopy.TabIndex = 8;
            szopy.Value = new decimal(new int[] { 3, 0, 0, 0 });
            szopy.ValueChanged += szopy_ValueChanged;

            // 
            // czas
            // 
            czas.Location = new Point(68, 257);
            czas.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            czas.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            czas.Name = "czas";
            czas.Size = new Size(88, 27);
            czas.TabIndex = 12;
            czas.Value = new decimal(new int[] { 30, 0, 0, 0 });
            czas.ValueChanged += czas_ValueChanged;

            // 
            // ok
            // 
            ok.Location = new Point(321, 309);
            ok.Name = "ok";
            ok.Size = new Size(87, 27);
            ok.TabIndex = 13;
            ok.Text = "OK";
            ok.UseVisualStyleBackColor = true;
            ok.Click += ok_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(321, 249);
            label5.Name = "label5";
            label5.Size = new Size(47, 20);
            label5.TabIndex = 9;
            label5.Text = "szopy";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(321, 159);
            label6.Name = "label6";
            label6.Size = new Size(74, 20);
            label6.TabIndex = 10;
            label6.Text = "krokodyle";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(321, 70);
            label7.Name = "label7";
            label7.Size = new Size(58, 20);
            label7.TabIndex = 11;
            label7.Text = "dydelfy";
            // 
            // ustawienia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(445, 348);
            Controls.Add(ok);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(czas);
            Controls.Add(szopy);
            Controls.Add(krokodyle);
            Controls.Add(dydelfy);
            Controls.Add(Y);
            Controls.Add(X);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ustawienia";
            Text = "ustawienia";
            ((System.ComponentModel.ISupportInitialize)X).EndInit();
            ((System.ComponentModel.ISupportInitialize)Y).EndInit();
            ((System.ComponentModel.ISupportInitialize)dydelfy).EndInit();
            ((System.ComponentModel.ISupportInitialize)krokodyle).EndInit();
            ((System.ComponentModel.ISupportInitialize)szopy).EndInit();
            ((System.ComponentModel.ISupportInitialize)czas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private NumericUpDown X;
        private NumericUpDown Y;
        private NumericUpDown dydelfy;
        private NumericUpDown krokodyle;
        private NumericUpDown szopy;
        private NumericUpDown czas;
        private Button ok;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}