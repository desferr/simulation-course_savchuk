namespace Lab8
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chartPoisson = new System.Windows.Forms.DataVisualization.Charting.Chart();
            textBoxInfo = new TextBox();
            labelLambda = new Label();
            numericUpDownLambda = new NumericUpDown();
            labelLength = new Label();
            numericUpDownLength = new NumericUpDown();
            labelSeed = new Label();
            numericUpDownSeed = new NumericUpDown();
            buttonStart = new Button();
            labelN = new Label();
            numericUpDownN = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)chartPoisson).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLambda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownN).BeginInit();
            SuspendLayout();
            // 
            // chartPoisson
            // 
            chartArea2.Name = "ChartArea1";
            chartPoisson.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartPoisson.Legends.Add(legend2);
            chartPoisson.Location = new Point(10, 10);
            chartPoisson.Name = "chartPoisson";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartPoisson.Series.Add(series2);
            chartPoisson.Size = new Size(600, 400);
            chartPoisson.TabIndex = 0;
            chartPoisson.Text = "chart1";
            // 
            // textBoxInfo
            // 
            textBoxInfo.Font = new Font("Segoe UI", 15F);
            textBoxInfo.Location = new Point(615, 10);
            textBoxInfo.Multiline = true;
            textBoxInfo.Name = "textBoxInfo";
            textBoxInfo.ReadOnly = true;
            textBoxInfo.ScrollBars = ScrollBars.Vertical;
            textBoxInfo.Size = new Size(265, 400);
            textBoxInfo.TabIndex = 1;
            // 
            // labelLambda
            // 
            labelLambda.Font = new Font("Segoe UI", 15F);
            labelLambda.Location = new Point(20, 431);
            labelLambda.Name = "labelLambda";
            labelLambda.Size = new Size(152, 34);
            labelLambda.TabIndex = 2;
            labelLambda.Text = "Интенсивность";
            labelLambda.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numericUpDownLambda
            // 
            numericUpDownLambda.DecimalPlaces = 3;
            numericUpDownLambda.Font = new Font("Segoe UI", 15F);
            numericUpDownLambda.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            numericUpDownLambda.Location = new Point(177, 431);
            numericUpDownLambda.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownLambda.Minimum = new decimal(new int[] { 1, 0, 0, 196608 });
            numericUpDownLambda.Name = "numericUpDownLambda";
            numericUpDownLambda.Size = new Size(100, 34);
            numericUpDownLambda.TabIndex = 3;
            numericUpDownLambda.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelLength
            // 
            labelLength.Font = new Font("Segoe UI", 15F);
            labelLength.Location = new Point(287, 431);
            labelLength.Name = "labelLength";
            labelLength.Size = new Size(175, 34);
            labelLength.TabIndex = 4;
            labelLength.Text = "Длина Интервала";
            labelLength.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numericUpDownLength
            // 
            numericUpDownLength.DecimalPlaces = 3;
            numericUpDownLength.Font = new Font("Segoe UI", 15F);
            numericUpDownLength.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            numericUpDownLength.Location = new Point(462, 431);
            numericUpDownLength.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericUpDownLength.Minimum = new decimal(new int[] { 1, 0, 0, 196608 });
            numericUpDownLength.Name = "numericUpDownLength";
            numericUpDownLength.Size = new Size(100, 34);
            numericUpDownLength.TabIndex = 5;
            numericUpDownLength.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // labelSeed
            // 
            labelSeed.Font = new Font("Segoe UI", 15F);
            labelSeed.Location = new Point(572, 431);
            labelSeed.Name = "labelSeed";
            labelSeed.Size = new Size(55, 34);
            labelSeed.TabIndex = 6;
            labelSeed.Text = "Seed";
            labelSeed.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numericUpDownSeed
            // 
            numericUpDownSeed.Font = new Font("Segoe UI", 15F);
            numericUpDownSeed.Location = new Point(632, 431);
            numericUpDownSeed.Maximum = new decimal(new int[] { -1, int.MaxValue, 0, 0 });
            numericUpDownSeed.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownSeed.Name = "numericUpDownSeed";
            numericUpDownSeed.Size = new Size(100, 34);
            numericUpDownSeed.TabIndex = 7;
            numericUpDownSeed.Value = new decimal(new int[] { 42, 0, 0, 0 });
            // 
            // buttonStart
            // 
            buttonStart.Font = new Font("Segoe UI", 15F);
            buttonStart.Location = new Point(350, 490);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(200, 50);
            buttonStart.TabIndex = 8;
            buttonStart.Text = "Запуск";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // labelN
            // 
            labelN.Font = new Font("Segoe UI", 15F);
            labelN.Location = new Point(742, 431);
            labelN.Name = "labelN";
            labelN.Size = new Size(27, 34);
            labelN.TabIndex = 9;
            labelN.Text = "N";
            labelN.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numericUpDownN
            // 
            numericUpDownN.Font = new Font("Segoe UI", 15F);
            numericUpDownN.Location = new Point(774, 432);
            numericUpDownN.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericUpDownN.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownN.Name = "numericUpDownN";
            numericUpDownN.Size = new Size(100, 34);
            numericUpDownN.TabIndex = 10;
            numericUpDownN.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(numericUpDownN);
            Controls.Add(labelN);
            Controls.Add(buttonStart);
            Controls.Add(numericUpDownSeed);
            Controls.Add(labelSeed);
            Controls.Add(numericUpDownLength);
            Controls.Add(labelLength);
            Controls.Add(numericUpDownLambda);
            Controls.Add(labelLambda);
            Controls.Add(textBoxInfo);
            Controls.Add(chartPoisson);
            MaximumSize = new Size(900, 600);
            MinimumSize = new Size(900, 600);
            Name = "MainForm";
            Text = "Lab8";
            ((System.ComponentModel.ISupportInitialize)chartPoisson).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLambda).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLength).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownN).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartPoisson;
        private TextBox textBoxInfo;
        private Label labelLambda;
        private NumericUpDown numericUpDownLambda;
        private Label labelLength;
        private NumericUpDown numericUpDownLength;
        private Label labelSeed;
        private NumericUpDown numericUpDownSeed;
        private Button buttonStart;
        private Label labelN;
        private NumericUpDown numericUpDownN;
    }
}
