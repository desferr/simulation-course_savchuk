namespace Lab9
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            labelLambda = new Label();
            numericUpDownLambda = new NumericUpDown();
            labelMu = new Label();
            numericUpDownMu = new NumericUpDown();
            labelQueueLength = new Label();
            numericUpDownQueueLength = new NumericUpDown();
            checkBoxQueueInf = new CheckBox();
            labelEndIf = new Label();
            numericUpDownDurationTime = new NumericUpDown();
            labelDurationTime = new Label();
            checkBoxDurationTime = new CheckBox();
            labelDurationAmount = new Label();
            numericUpDownDurationAmount = new NumericUpDown();
            checkBoxDurationAmount = new CheckBox();
            labelSeed = new Label();
            numericUpDownSeed = new NumericUpDown();
            buttonStart = new Button();
            labelChartDistribution = new Label();
            labelChartQueue = new Label();
            chartDistribution = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartQueue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            labelLog = new Label();
            textBoxLog = new TextBox();
            timerSimulation = new System.Windows.Forms.Timer(components);
            checkBoxLogAll = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLambda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQueueLength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDurationTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDurationAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartDistribution).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartQueue).BeginInit();
            SuspendLayout();
            // 
            // labelLambda
            // 
            labelLambda.Font = new Font("Segoe UI", 15F);
            labelLambda.Location = new Point(10, 10);
            labelLambda.Name = "labelLambda";
            labelLambda.Size = new Size(150, 34);
            labelLambda.TabIndex = 0;
            labelLambda.Text = "Лямбда";
            labelLambda.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numericUpDownLambda
            // 
            numericUpDownLambda.DecimalPlaces = 3;
            numericUpDownLambda.Font = new Font("Segoe UI", 15F);
            numericUpDownLambda.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            numericUpDownLambda.Location = new Point(10, 49);
            numericUpDownLambda.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownLambda.Minimum = new decimal(new int[] { 1, 0, 0, 196608 });
            numericUpDownLambda.Name = "numericUpDownLambda";
            numericUpDownLambda.Size = new Size(150, 34);
            numericUpDownLambda.TabIndex = 1;
            numericUpDownLambda.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // labelMu
            // 
            labelMu.Font = new Font("Segoe UI", 15F);
            labelMu.Location = new Point(10, 88);
            labelMu.Name = "labelMu";
            labelMu.Size = new Size(150, 34);
            labelMu.TabIndex = 2;
            labelMu.Text = "Мю";
            labelMu.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numericUpDownMu
            // 
            numericUpDownMu.DecimalPlaces = 3;
            numericUpDownMu.Font = new Font("Segoe UI", 15F);
            numericUpDownMu.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            numericUpDownMu.Location = new Point(10, 127);
            numericUpDownMu.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownMu.Minimum = new decimal(new int[] { 1, 0, 0, 196608 });
            numericUpDownMu.Name = "numericUpDownMu";
            numericUpDownMu.Size = new Size(150, 34);
            numericUpDownMu.TabIndex = 3;
            numericUpDownMu.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // labelQueueLength
            // 
            labelQueueLength.Font = new Font("Segoe UI", 15F);
            labelQueueLength.Location = new Point(10, 166);
            labelQueueLength.Name = "labelQueueLength";
            labelQueueLength.Size = new Size(150, 34);
            labelQueueLength.TabIndex = 4;
            labelQueueLength.Text = "Очередь";
            labelQueueLength.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numericUpDownQueueLength
            // 
            numericUpDownQueueLength.Font = new Font("Segoe UI", 15F);
            numericUpDownQueueLength.Location = new Point(10, 205);
            numericUpDownQueueLength.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownQueueLength.Name = "numericUpDownQueueLength";
            numericUpDownQueueLength.Size = new Size(150, 34);
            numericUpDownQueueLength.TabIndex = 5;
            // 
            // checkBoxQueueInf
            // 
            checkBoxQueueInf.Font = new Font("Segoe UI", 15F);
            checkBoxQueueInf.Location = new Point(10, 244);
            checkBoxQueueInf.Name = "checkBoxQueueInf";
            checkBoxQueueInf.Size = new Size(150, 34);
            checkBoxQueueInf.TabIndex = 6;
            checkBoxQueueInf.Text = "Бесконечная";
            checkBoxQueueInf.UseVisualStyleBackColor = true;
            checkBoxQueueInf.CheckedChanged += checkBoxQueueInf_CheckedChanged;
            // 
            // labelEndIf
            // 
            labelEndIf.Font = new Font("Segoe UI", 15F);
            labelEndIf.Location = new Point(10, 283);
            labelEndIf.Name = "labelEndIf";
            labelEndIf.Size = new Size(150, 34);
            labelEndIf.TabIndex = 7;
            labelEndIf.Text = "Длительность";
            labelEndIf.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numericUpDownDurationTime
            // 
            numericUpDownDurationTime.DecimalPlaces = 3;
            numericUpDownDurationTime.Font = new Font("Segoe UI", 15F);
            numericUpDownDurationTime.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            numericUpDownDurationTime.Location = new Point(10, 361);
            numericUpDownDurationTime.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numericUpDownDurationTime.Minimum = new decimal(new int[] { 1, 0, 0, 196608 });
            numericUpDownDurationTime.Name = "numericUpDownDurationTime";
            numericUpDownDurationTime.Size = new Size(120, 34);
            numericUpDownDurationTime.TabIndex = 8;
            numericUpDownDurationTime.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // labelDurationTime
            // 
            labelDurationTime.Font = new Font("Segoe UI", 15F);
            labelDurationTime.Location = new Point(10, 322);
            labelDurationTime.Name = "labelDurationTime";
            labelDurationTime.Size = new Size(150, 34);
            labelDurationTime.TabIndex = 9;
            labelDurationTime.Text = "Время";
            labelDurationTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // checkBoxDurationTime
            // 
            checkBoxDurationTime.CheckAlign = ContentAlignment.MiddleCenter;
            checkBoxDurationTime.Checked = true;
            checkBoxDurationTime.CheckState = CheckState.Checked;
            checkBoxDurationTime.Font = new Font("Segoe UI", 15F);
            checkBoxDurationTime.Location = new Point(135, 361);
            checkBoxDurationTime.Name = "checkBoxDurationTime";
            checkBoxDurationTime.Size = new Size(25, 34);
            checkBoxDurationTime.TabIndex = 10;
            checkBoxDurationTime.UseVisualStyleBackColor = true;
            checkBoxDurationTime.CheckedChanged += checkBoxDurationTime_CheckedChanged;
            // 
            // labelDurationAmount
            // 
            labelDurationAmount.Font = new Font("Segoe UI", 15F);
            labelDurationAmount.Location = new Point(10, 400);
            labelDurationAmount.Name = "labelDurationAmount";
            labelDurationAmount.Size = new Size(150, 34);
            labelDurationAmount.TabIndex = 11;
            labelDurationAmount.Text = "Заявок";
            labelDurationAmount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numericUpDownDurationAmount
            // 
            numericUpDownDurationAmount.Enabled = false;
            numericUpDownDurationAmount.Font = new Font("Segoe UI", 15F);
            numericUpDownDurationAmount.Location = new Point(10, 439);
            numericUpDownDurationAmount.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numericUpDownDurationAmount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownDurationAmount.Name = "numericUpDownDurationAmount";
            numericUpDownDurationAmount.Size = new Size(120, 34);
            numericUpDownDurationAmount.TabIndex = 12;
            numericUpDownDurationAmount.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // checkBoxDurationAmount
            // 
            checkBoxDurationAmount.CheckAlign = ContentAlignment.MiddleCenter;
            checkBoxDurationAmount.Font = new Font("Segoe UI", 15F);
            checkBoxDurationAmount.Location = new Point(135, 439);
            checkBoxDurationAmount.Name = "checkBoxDurationAmount";
            checkBoxDurationAmount.Size = new Size(25, 34);
            checkBoxDurationAmount.TabIndex = 13;
            checkBoxDurationAmount.UseVisualStyleBackColor = true;
            checkBoxDurationAmount.CheckedChanged += checkBoxDurationAmount_CheckedChanged;
            // 
            // labelSeed
            // 
            labelSeed.Font = new Font("Segoe UI", 15F);
            labelSeed.Location = new Point(10, 478);
            labelSeed.Name = "labelSeed";
            labelSeed.Size = new Size(150, 34);
            labelSeed.TabIndex = 14;
            labelSeed.Text = "Seed";
            labelSeed.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numericUpDownSeed
            // 
            numericUpDownSeed.Font = new Font("Segoe UI", 15F);
            numericUpDownSeed.Location = new Point(10, 517);
            numericUpDownSeed.Maximum = new decimal(new int[] { -1, int.MaxValue, 0, 0 });
            numericUpDownSeed.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownSeed.Name = "numericUpDownSeed";
            numericUpDownSeed.Size = new Size(150, 34);
            numericUpDownSeed.TabIndex = 15;
            numericUpDownSeed.Value = new decimal(new int[] { 42, 0, 0, 0 });
            // 
            // buttonStart
            // 
            buttonStart.Font = new Font("Segoe UI", 15F);
            buttonStart.Location = new Point(10, 556);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(150, 93);
            buttonStart.TabIndex = 16;
            buttonStart.Text = "Запуск";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // labelChartDistribution
            // 
            labelChartDistribution.Font = new Font("Segoe UI", 15F);
            labelChartDistribution.Location = new Point(165, 10);
            labelChartDistribution.Name = "labelChartDistribution";
            labelChartDistribution.Size = new Size(400, 34);
            labelChartDistribution.TabIndex = 17;
            labelChartDistribution.Text = "Распределение числа заявок в системе";
            labelChartDistribution.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelChartQueue
            // 
            labelChartQueue.Font = new Font("Segoe UI", 15F);
            labelChartQueue.Location = new Point(165, 334);
            labelChartQueue.Name = "labelChartQueue";
            labelChartQueue.Size = new Size(400, 34);
            labelChartQueue.TabIndex = 18;
            labelChartQueue.Text = "Время ожидания в очереди";
            labelChartQueue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chartDistribution
            // 
            chartArea3.Name = "ChartArea1";
            chartDistribution.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chartDistribution.Legends.Add(legend3);
            chartDistribution.Location = new Point(165, 49);
            chartDistribution.Name = "chartDistribution";
            chartDistribution.Size = new Size(400, 280);
            chartDistribution.TabIndex = 19;
            chartDistribution.Text = "chart1";
            // 
            // chartQueue
            // 
            chartArea4.Name = "ChartArea1";
            chartQueue.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            chartQueue.Legends.Add(legend4);
            chartQueue.Location = new Point(165, 373);
            chartQueue.Name = "chartQueue";
            chartQueue.Size = new Size(400, 280);
            chartQueue.TabIndex = 20;
            chartQueue.Text = "chart2";
            // 
            // labelLog
            // 
            labelLog.Font = new Font("Segoe UI", 15F);
            labelLog.Location = new Point(570, 10);
            labelLog.Name = "labelLog";
            labelLog.Size = new Size(302, 34);
            labelLog.TabIndex = 21;
            labelLog.Text = "Логи";
            labelLog.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxLog
            // 
            textBoxLog.Location = new Point(570, 49);
            textBoxLog.Multiline = true;
            textBoxLog.Name = "textBoxLog";
            textBoxLog.ReadOnly = true;
            textBoxLog.ScrollBars = ScrollBars.Vertical;
            textBoxLog.Size = new Size(302, 565);
            textBoxLog.TabIndex = 22;
            // 
            // timerSimulation
            // 
            timerSimulation.Interval = 10;
            timerSimulation.Tick += timerSimulation_Tick;
            // 
            // checkBoxLogAll
            // 
            checkBoxLogAll.Font = new Font("Segoe UI", 15F);
            checkBoxLogAll.Location = new Point(570, 618);
            checkBoxLogAll.Name = "checkBoxLogAll";
            checkBoxLogAll.Size = new Size(302, 34);
            checkBoxLogAll.TabIndex = 23;
            checkBoxLogAll.Text = "Подробное логирование";
            checkBoxLogAll.TextAlign = ContentAlignment.MiddleCenter;
            checkBoxLogAll.UseVisualStyleBackColor = true;
            checkBoxLogAll.CheckedChanged += checkBoxLogAll_CheckedChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 661);
            Controls.Add(checkBoxLogAll);
            Controls.Add(textBoxLog);
            Controls.Add(labelLog);
            Controls.Add(chartQueue);
            Controls.Add(chartDistribution);
            Controls.Add(labelChartQueue);
            Controls.Add(labelChartDistribution);
            Controls.Add(buttonStart);
            Controls.Add(numericUpDownSeed);
            Controls.Add(labelSeed);
            Controls.Add(checkBoxDurationAmount);
            Controls.Add(numericUpDownDurationAmount);
            Controls.Add(labelDurationAmount);
            Controls.Add(checkBoxDurationTime);
            Controls.Add(labelDurationTime);
            Controls.Add(numericUpDownDurationTime);
            Controls.Add(labelEndIf);
            Controls.Add(checkBoxQueueInf);
            Controls.Add(numericUpDownQueueLength);
            Controls.Add(labelQueueLength);
            Controls.Add(numericUpDownMu);
            Controls.Add(labelMu);
            Controls.Add(numericUpDownLambda);
            Controls.Add(labelLambda);
            MaximizeBox = false;
            MaximumSize = new Size(900, 700);
            MinimumSize = new Size(900, 700);
            Name = "MainForm";
            Text = "Lab9";
            ((System.ComponentModel.ISupportInitialize)numericUpDownLambda).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMu).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQueueLength).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDurationTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDurationAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartDistribution).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartQueue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelLambda;
        private NumericUpDown numericUpDownLambda;
        private Label labelMu;
        private NumericUpDown numericUpDownMu;
        private Label labelQueueLength;
        private NumericUpDown numericUpDownQueueLength;
        private CheckBox checkBoxQueueInf;
        private Label labelEndIf;
        private NumericUpDown numericUpDownDurationTime;
        private Label labelDurationTime;
        private CheckBox checkBoxDurationTime;
        private Label labelDurationAmount;
        private NumericUpDown numericUpDownDurationAmount;
        private CheckBox checkBoxDurationAmount;
        private Label labelSeed;
        private NumericUpDown numericUpDownSeed;
        private Button buttonStart;
        private Label labelChartDistribution;
        private Label labelChartQueue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDistribution;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartQueue;
        private Label labelLog;
        private TextBox textBoxLog;
        private System.Windows.Forms.Timer timerSimulation;
        private CheckBox checkBoxLogAll;
    }
}
