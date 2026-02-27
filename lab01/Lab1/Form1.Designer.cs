namespace Lab1
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
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            textBox1 = new TextBox();
            numericUpDown4 = new NumericUpDown();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            numericUpDown5 = new NumericUpDown();
            numericUpDown6 = new NumericUpDown();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).BeginInit();
            SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AlignmentOrientation = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal;
            chartArea1.AxisX.LabelStyle.Format = "F2";
            chartArea1.AxisY.LabelStyle.Format = "F2";
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(12, 165);
            chart1.Name = "chart1";
            chart1.Size = new Size(689, 384);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(137, 28);
            label1.TabIndex = 4;
            label1.Text = "Скорость, м/c";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(162, 21);
            label2.Name = "label2";
            label2.Size = new Size(137, 28);
            label2.TabIndex = 5;
            label2.Text = "Угол, градусы";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(312, 21);
            label3.Name = "label3";
            label3.Size = new Size(67, 28);
            label3.TabIndex = 6;
            label3.Text = "Шаг, с";
            // 
            // button1
            // 
            button1.Location = new Point(560, 32);
            button1.Name = "button1";
            button1.Size = new Size(141, 41);
            button1.TabIndex = 7;
            button1.Text = "Запуск";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(731, 32);
            button2.Name = "button2";
            button2.Size = new Size(141, 41);
            button2.TabIndex = 8;
            button2.Text = "Очистка";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 1;
            numericUpDown1.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown1.Location = new Point(12, 50);
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 9;
            numericUpDown1.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // numericUpDown2
            // 
            numericUpDown2.DecimalPlaces = 1;
            numericUpDown2.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown2.Location = new Point(162, 50);
            numericUpDown2.Maximum = new decimal(new int[] { 90, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(120, 23);
            numericUpDown2.TabIndex = 10;
            numericUpDown2.Value = new decimal(new int[] { 45, 0, 0, 0 });
            // 
            // numericUpDown3
            // 
            numericUpDown3.DecimalPlaces = 4;
            numericUpDown3.Increment = new decimal(new int[] { 1, 0, 0, 262144 });
            numericUpDown3.Location = new Point(312, 50);
            numericUpDown3.Minimum = new decimal(new int[] { 1, 0, 0, 262144 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(120, 23);
            numericUpDown3.TabIndex = 11;
            numericUpDown3.Value = new decimal(new int[] { 1, 0, 0, 65536 });
            // 
            // textBox1
            // 
            textBox1.Location = new Point(707, 165);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(165, 384);
            textBox1.TabIndex = 12;
            // 
            // numericUpDown4
            // 
            numericUpDown4.DecimalPlaces = 1;
            numericUpDown4.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown4.Location = new Point(12, 116);
            numericUpDown4.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(120, 23);
            numericUpDown4.TabIndex = 13;
            numericUpDown4.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(12, 87);
            label4.Name = "label4";
            label4.Size = new Size(95, 28);
            label4.TabIndex = 14;
            label4.Text = "Масса, кг";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F);
            label5.Location = new Point(162, 87);
            label5.Name = "label5";
            label5.Size = new Size(137, 28);
            label5.TabIndex = 15;
            label5.Text = "Сечение, м^2";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15F);
            label6.Location = new Point(312, 87);
            label6.Name = "label6";
            label6.Size = new Size(77, 28);
            label6.TabIndex = 16;
            label6.Text = "Коэфф.";
            // 
            // numericUpDown5
            // 
            numericUpDown5.DecimalPlaces = 1;
            numericUpDown5.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown5.Location = new Point(162, 116);
            numericUpDown5.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown5.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(120, 23);
            numericUpDown5.TabIndex = 17;
            numericUpDown5.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // numericUpDown6
            // 
            numericUpDown6.DecimalPlaces = 2;
            numericUpDown6.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDown6.Location = new Point(312, 116);
            numericUpDown6.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.Size = new Size(120, 23);
            numericUpDown6.TabIndex = 18;
            numericUpDown6.Value = new decimal(new int[] { 15, 0, 0, 131072 });
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(numericUpDown6);
            Controls.Add(numericUpDown5);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(numericUpDown4);
            Controls.Add(textBox1);
            Controls.Add(numericUpDown3);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(chart1);
            MaximizeBox = false;
            MaximumSize = new Size(900, 600);
            MinimumSize = new Size(900, 600);
            Name = "Form1";
            Text = "Lab1";
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown3;
        private TextBox textBox1;
        private NumericUpDown numericUpDown4;
        private Label label4;
        private Label label5;
        private Label label6;
        private NumericUpDown numericUpDown5;
        private NumericUpDown numericUpDown6;
        private System.Windows.Forms.Timer timer1;
    }
}
