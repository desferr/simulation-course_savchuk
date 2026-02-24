namespace Lab2
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
            button1 = new Button();
            textBox1 = new TextBox();
            plotView1 = new OxyPlot.WindowsForms.PlotView();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            numericUpDown4 = new NumericUpDown();
            numericUpDown5 = new NumericUpDown();
            numericUpDown6 = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            numericUpDown7 = new NumericUpDown();
            numericUpDown8 = new NumericUpDown();
            numericUpDown9 = new NumericUpDown();
            numericUpDown10 = new NumericUpDown();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown10).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15F);
            button1.Location = new Point(786, 141);
            button1.Name = "button1";
            button1.Size = new Size(186, 65);
            button1.TabIndex = 0;
            button1.Text = "Запуск";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(786, 212);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(186, 337);
            textBox1.TabIndex = 1;
            // 
            // plotView1
            // 
            plotView1.Location = new Point(12, 141);
            plotView1.Name = "plotView1";
            plotView1.PanCursor = Cursors.Hand;
            plotView1.Size = new Size(768, 408);
            plotView1.TabIndex = 2;
            plotView1.Text = "plotView1";
            plotView1.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView1.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView1.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(12, 35);
            numericUpDown1.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 3;
            numericUpDown1.Value = new decimal(new int[] { 30, 0, 0, int.MinValue });
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(222, 35);
            numericUpDown2.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(120, 23);
            numericUpDown2.TabIndex = 4;
            numericUpDown2.Value = new decimal(new int[] { 30, 0, 0, int.MinValue });
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(432, 35);
            numericUpDown3.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            numericUpDown3.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(120, 23);
            numericUpDown3.TabIndex = 5;
            numericUpDown3.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // numericUpDown4
            // 
            numericUpDown4.DecimalPlaces = 4;
            numericUpDown4.Increment = new decimal(new int[] { 1, 0, 0, 262144 });
            numericUpDown4.Location = new Point(642, 35);
            numericUpDown4.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDown4.Minimum = new decimal(new int[] { 1, 0, 0, 262144 });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(120, 23);
            numericUpDown4.TabIndex = 6;
            numericUpDown4.Value = new decimal(new int[] { 1, 0, 0, 65536 });
            // 
            // numericUpDown5
            // 
            numericUpDown5.DecimalPlaces = 4;
            numericUpDown5.Increment = new decimal(new int[] { 1, 0, 0, 262144 });
            numericUpDown5.Location = new Point(852, 35);
            numericUpDown5.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDown5.Minimum = new decimal(new int[] { 1, 0, 0, 262144 });
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(120, 23);
            numericUpDown5.TabIndex = 7;
            numericUpDown5.Value = new decimal(new int[] { 1, 0, 0, 65536 });
            // 
            // numericUpDown6
            // 
            numericUpDown6.DecimalPlaces = 2;
            numericUpDown6.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDown6.Location = new Point(12, 100);
            numericUpDown6.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            numericUpDown6.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.Size = new Size(120, 23);
            numericUpDown6.TabIndex = 8;
            numericUpDown6.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(12, 6);
            label1.Name = "label1";
            label1.Size = new Size(62, 28);
            label1.TabIndex = 9;
            label1.Text = "T0, °C";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(222, 6);
            label2.Name = "label2";
            label2.Size = new Size(107, 28);
            label2.TabIndex = 10;
            label2.Text = "T слева, °C";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(432, 6);
            label3.Name = "label3";
            label3.Size = new Size(120, 28);
            label3.TabIndex = 11;
            label3.Text = "T справа, °C";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(642, 6);
            label4.Name = "label4";
            label4.Size = new Size(115, 28);
            label4.TabIndex = 12;
            label4.Text = "Шаг по x, м";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F);
            label5.Location = new Point(852, 6);
            label5.Name = "label5";
            label5.Size = new Size(108, 28);
            label5.TabIndex = 13;
            label5.Text = "Шаг по t, с";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15F);
            label6.Location = new Point(0, 71);
            label6.Name = "label6";
            label6.Size = new Size(157, 28);
            label6.TabIndex = 14;
            label6.Text = "Длительность, с";
            // 
            // numericUpDown7
            // 
            numericUpDown7.DecimalPlaces = 4;
            numericUpDown7.Increment = new decimal(new int[] { 1, 0, 0, 262144 });
            numericUpDown7.Location = new Point(222, 100);
            numericUpDown7.Minimum = new decimal(new int[] { 1, 0, 0, 262144 });
            numericUpDown7.Name = "numericUpDown7";
            numericUpDown7.Size = new Size(120, 23);
            numericUpDown7.TabIndex = 15;
            numericUpDown7.Value = new decimal(new int[] { 5, 0, 0, 131072 });
            // 
            // numericUpDown8
            // 
            numericUpDown8.Location = new Point(432, 100);
            numericUpDown8.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDown8.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown8.Name = "numericUpDown8";
            numericUpDown8.Size = new Size(120, 23);
            numericUpDown8.TabIndex = 16;
            numericUpDown8.Value = new decimal(new int[] { 8900, 0, 0, 0 });
            // 
            // numericUpDown9
            // 
            numericUpDown9.Location = new Point(642, 100);
            numericUpDown9.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDown9.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown9.Name = "numericUpDown9";
            numericUpDown9.Size = new Size(120, 23);
            numericUpDown9.TabIndex = 17;
            numericUpDown9.Value = new decimal(new int[] { 400, 0, 0, 0 });
            // 
            // numericUpDown10
            // 
            numericUpDown10.DecimalPlaces = 2;
            numericUpDown10.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDown10.Location = new Point(852, 100);
            numericUpDown10.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown10.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDown10.Name = "numericUpDown10";
            numericUpDown10.Size = new Size(120, 23);
            numericUpDown10.TabIndex = 18;
            numericUpDown10.Value = new decimal(new int[] { 401, 0, 0, 0 });
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15F);
            label7.Location = new Point(192, 71);
            label7.Name = "label7";
            label7.Size = new Size(187, 28);
            label7.TabIndex = 19;
            label7.Text = "Длина пластины, м";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 15F);
            label8.Location = new Point(403, 71);
            label8.Name = "label8";
            label8.Size = new Size(182, 28);
            label8.TabIndex = 20;
            label8.Text = "Плотность, кг/м^3";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(642, 59);
            label9.Name = "label9";
            label9.Size = new Size(113, 21);
            label9.TabIndex = 21;
            label9.Text = "Теплоёмкость,";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(659, 78);
            label10.Name = "label10";
            label10.Size = new Size(86, 21);
            label10.TabIndex = 22;
            label10.Text = "Дж/(кг*°C)";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(836, 60);
            label11.Name = "label11";
            label11.Size = new Size(148, 21);
            label11.TabIndex = 23;
            label11.Text = "Теплопроводность,";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F);
            label12.Location = new Point(868, 78);
            label12.Name = "label12";
            label12.Size = new Size(76, 21);
            label12.TabIndex = 24;
            label12.Text = "Вт/(м*°C)";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(numericUpDown10);
            Controls.Add(numericUpDown9);
            Controls.Add(numericUpDown8);
            Controls.Add(numericUpDown7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDown6);
            Controls.Add(numericUpDown5);
            Controls.Add(numericUpDown4);
            Controls.Add(numericUpDown3);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(plotView1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Font = new Font("Segoe UI", 9F);
            MaximizeBox = false;
            MaximumSize = new Size(1000, 600);
            MinimumSize = new Size(1000, 600);
            Name = "Form1";
            Text = "Lab2";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown9).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown10).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private OxyPlot.WindowsForms.PlotView plotView1;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown4;
        private NumericUpDown numericUpDown5;
        private NumericUpDown numericUpDown6;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private NumericUpDown numericUpDown7;
        private NumericUpDown numericUpDown8;
        private NumericUpDown numericUpDown9;
        private NumericUpDown numericUpDown10;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
    }
}
