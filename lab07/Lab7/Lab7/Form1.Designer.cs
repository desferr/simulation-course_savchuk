namespace Lab7
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
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chartWeather = new System.Windows.Forms.DataVisualization.Charting.Chart();
            labelCurrWeather = new Label();
            labelCurrWeatherChanging = new Label();
            labelEstSPDTitle = new Label();
            labelEstSPDClear = new Label();
            labelEstSPDCloudy = new Label();
            labelEstSPDOvercast = new Label();
            labelEstSPDClearChanging = new Label();
            labelEstSPDCloudyChanging = new Label();
            labelEstSPDOvercastChanging = new Label();
            textBoxHistory = new TextBox();
            labelDuration = new Label();
            numericUpDownDuration = new NumericUpDown();
            buttonStart = new Button();
            buttonExport = new Button();
            labelSeed = new Label();
            numericUpDownSeed = new NumericUpDown();
            timerSimulation = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)chartWeather).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSeed).BeginInit();
            SuspendLayout();
            // 
            // chartWeather
            // 
            chartArea1.Name = "ChartArea1";
            chartWeather.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartWeather.Legends.Add(legend1);
            chartWeather.Location = new Point(10, 10);
            chartWeather.Name = "chartWeather";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartWeather.Series.Add(series1);
            chartWeather.Size = new Size(600, 300);
            chartWeather.TabIndex = 0;
            chartWeather.Text = "chart1";
            // 
            // labelCurrWeather
            // 
            labelCurrWeather.AutoSize = true;
            labelCurrWeather.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelCurrWeather.Location = new Point(152, 315);
            labelCurrWeather.Name = "labelCurrWeather";
            labelCurrWeather.Size = new Size(191, 28);
            labelCurrWeather.TabIndex = 1;
            labelCurrWeather.Text = "Текущее состояние:";
            // 
            // labelCurrWeatherChanging
            // 
            labelCurrWeatherChanging.BackColor = SystemColors.Control;
            labelCurrWeatherChanging.Font = new Font("Segoe UI", 15F);
            labelCurrWeatherChanging.Location = new Point(348, 315);
            labelCurrWeatherChanging.Name = "labelCurrWeatherChanging";
            labelCurrWeatherChanging.Size = new Size(120, 28);
            labelCurrWeatherChanging.TabIndex = 2;
            labelCurrWeatherChanging.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelEstSPDTitle
            // 
            labelEstSPDTitle.Font = new Font("Segoe UI", 15F);
            labelEstSPDTitle.Location = new Point(615, 10);
            labelEstSPDTitle.Name = "labelEstSPDTitle";
            labelEstSPDTitle.Size = new Size(275, 85);
            labelEstSPDTitle.TabIndex = 3;
            labelEstSPDTitle.Text = "Оценка Стационарного Распределения Вероятностей";
            labelEstSPDTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelEstSPDClear
            // 
            labelEstSPDClear.Font = new Font("Segoe UI", 15F);
            labelEstSPDClear.Location = new Point(615, 100);
            labelEstSPDClear.Name = "labelEstSPDClear";
            labelEstSPDClear.Size = new Size(105, 28);
            labelEstSPDClear.TabIndex = 4;
            labelEstSPDClear.Text = "Ясно";
            labelEstSPDClear.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelEstSPDCloudy
            // 
            labelEstSPDCloudy.Font = new Font("Segoe UI", 15F);
            labelEstSPDCloudy.Location = new Point(615, 133);
            labelEstSPDCloudy.Name = "labelEstSPDCloudy";
            labelEstSPDCloudy.Size = new Size(105, 28);
            labelEstSPDCloudy.TabIndex = 5;
            labelEstSPDCloudy.Text = "Облачно";
            labelEstSPDCloudy.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelEstSPDOvercast
            // 
            labelEstSPDOvercast.Font = new Font("Segoe UI", 15F);
            labelEstSPDOvercast.Location = new Point(615, 166);
            labelEstSPDOvercast.Name = "labelEstSPDOvercast";
            labelEstSPDOvercast.Size = new Size(105, 28);
            labelEstSPDOvercast.TabIndex = 6;
            labelEstSPDOvercast.Text = "Пасмурно";
            labelEstSPDOvercast.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelEstSPDClearChanging
            // 
            labelEstSPDClearChanging.Font = new Font("Segoe UI", 15F);
            labelEstSPDClearChanging.Location = new Point(725, 100);
            labelEstSPDClearChanging.Name = "labelEstSPDClearChanging";
            labelEstSPDClearChanging.Size = new Size(165, 28);
            labelEstSPDClearChanging.TabIndex = 7;
            labelEstSPDClearChanging.Text = "0.3333";
            labelEstSPDClearChanging.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelEstSPDCloudyChanging
            // 
            labelEstSPDCloudyChanging.Font = new Font("Segoe UI", 15F);
            labelEstSPDCloudyChanging.Location = new Point(725, 133);
            labelEstSPDCloudyChanging.Name = "labelEstSPDCloudyChanging";
            labelEstSPDCloudyChanging.Size = new Size(165, 28);
            labelEstSPDCloudyChanging.TabIndex = 8;
            labelEstSPDCloudyChanging.Text = "0.3333";
            labelEstSPDCloudyChanging.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelEstSPDOvercastChanging
            // 
            labelEstSPDOvercastChanging.Font = new Font("Segoe UI", 15F);
            labelEstSPDOvercastChanging.Location = new Point(725, 166);
            labelEstSPDOvercastChanging.Name = "labelEstSPDOvercastChanging";
            labelEstSPDOvercastChanging.Size = new Size(165, 28);
            labelEstSPDOvercastChanging.TabIndex = 9;
            labelEstSPDOvercastChanging.Text = "0.3333";
            labelEstSPDOvercastChanging.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxHistory
            // 
            textBoxHistory.Location = new Point(615, 199);
            textBoxHistory.Multiline = true;
            textBoxHistory.Name = "textBoxHistory";
            textBoxHistory.ReadOnly = true;
            textBoxHistory.ScrollBars = ScrollBars.Vertical;
            textBoxHistory.Size = new Size(260, 350);
            textBoxHistory.TabIndex = 10;
            // 
            // labelDuration
            // 
            labelDuration.Font = new Font("Segoe UI", 15F);
            labelDuration.Location = new Point(10, 390);
            labelDuration.Name = "labelDuration";
            labelDuration.Size = new Size(139, 34);
            labelDuration.TabIndex = 11;
            labelDuration.Text = "Длительность";
            labelDuration.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDownDuration
            // 
            numericUpDownDuration.Font = new Font("Segoe UI", 15F);
            numericUpDownDuration.Location = new Point(154, 390);
            numericUpDownDuration.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownDuration.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownDuration.Name = "numericUpDownDuration";
            numericUpDownDuration.Size = new Size(120, 34);
            numericUpDownDuration.TabIndex = 12;
            numericUpDownDuration.Value = new decimal(new int[] { 365, 0, 0, 0 });
            // 
            // buttonStart
            // 
            buttonStart.Font = new Font("Segoe UI", 15F);
            buttonStart.Location = new Point(10, 429);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(264, 50);
            buttonStart.TabIndex = 13;
            buttonStart.Text = "Запуск";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // buttonExport
            // 
            buttonExport.Font = new Font("Segoe UI", 15F);
            buttonExport.Location = new Point(10, 485);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(264, 49);
            buttonExport.TabIndex = 14;
            buttonExport.Text = "Сохранить Вывод";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += buttonExport_Click;
            // 
            // labelSeed
            // 
            labelSeed.Font = new Font("Segoe UI", 15F);
            labelSeed.Location = new Point(279, 390);
            labelSeed.Name = "labelSeed";
            labelSeed.Size = new Size(55, 34);
            labelSeed.TabIndex = 16;
            labelSeed.Text = "Seed";
            labelSeed.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numericUpDownSeed
            // 
            numericUpDownSeed.Font = new Font("Segoe UI", 15F);
            numericUpDownSeed.Location = new Point(339, 390);
            numericUpDownSeed.Maximum = new decimal(new int[] { -1, int.MaxValue, 0, 0 });
            numericUpDownSeed.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownSeed.Name = "numericUpDownSeed";
            numericUpDownSeed.Size = new Size(120, 34);
            numericUpDownSeed.TabIndex = 17;
            numericUpDownSeed.Value = new decimal(new int[] { 42, 0, 0, 0 });
            // 
            // timerSimulation
            // 
            timerSimulation.Interval = 20;
            timerSimulation.Tick += timerSimulation_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(numericUpDownSeed);
            Controls.Add(labelSeed);
            Controls.Add(buttonExport);
            Controls.Add(buttonStart);
            Controls.Add(numericUpDownDuration);
            Controls.Add(labelDuration);
            Controls.Add(textBoxHistory);
            Controls.Add(labelEstSPDOvercastChanging);
            Controls.Add(labelEstSPDCloudyChanging);
            Controls.Add(labelEstSPDClearChanging);
            Controls.Add(labelEstSPDOvercast);
            Controls.Add(labelEstSPDCloudy);
            Controls.Add(labelEstSPDClear);
            Controls.Add(labelEstSPDTitle);
            Controls.Add(labelCurrWeatherChanging);
            Controls.Add(labelCurrWeather);
            Controls.Add(chartWeather);
            MaximizeBox = false;
            MaximumSize = new Size(900, 600);
            MinimumSize = new Size(900, 600);
            Name = "MainForm";
            Text = "Lab7";
            ((System.ComponentModel.ISupportInitialize)chartWeather).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSeed).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartWeather;
        private Label labelCurrWeather;
        private Label labelCurrWeatherChanging;
        private Label labelEstSPDTitle;
        private Label labelEstSPDClear;
        private Label labelEstSPDCloudy;
        private Label labelEstSPDOvercast;
        private Label labelEstSPDClearChanging;
        private Label labelEstSPDCloudyChanging;
        private Label labelEstSPDOvercastChanging;
        private TextBox textBoxHistory;
        private Label labelDuration;
        private NumericUpDown numericUpDownDuration;
        private Button buttonStart;
        private Button buttonExport;
        private Label labelSeed;
        private NumericUpDown numericUpDownSeed;
        private System.Windows.Forms.Timer timerSimulation;
    }
}
