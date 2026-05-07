namespace Lab6
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            tabControl = new TabControl();
            tabPage1 = new TabPage();
            numericUpDownSeed1 = new NumericUpDown();
            labelSeed1 = new Label();
            buttonNormalize = new Button();
            buttonStart1 = new Button();
            numericUpDownN1 = new NumericUpDown();
            labelNumExp1 = new Label();
            textBox1 = new TextBox();
            panelProbs = new Panel();
            chartFreqs = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tabPage2 = new TabPage();
            numericUpDownSeed2 = new NumericUpDown();
            labelSeed2 = new Label();
            buttonStart2 = new Button();
            numericUpDownN2 = new NumericUpDown();
            numericUpDownVar = new NumericUpDown();
            numericUpDownMean = new NumericUpDown();
            labelN2 = new Label();
            labelVariance = new Label();
            labelMean = new Label();
            textBox2 = new TextBox();
            chartHist = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSeed1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownN1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartFreqs).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSeed2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownN2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownVar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMean).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartHist).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage2);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(884, 561);
            tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(numericUpDownSeed1);
            tabPage1.Controls.Add(labelSeed1);
            tabPage1.Controls.Add(buttonNormalize);
            tabPage1.Controls.Add(buttonStart1);
            tabPage1.Controls.Add(numericUpDownN1);
            tabPage1.Controls.Add(labelNumExp1);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(panelProbs);
            tabPage1.Controls.Add(chartFreqs);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(876, 533);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Lab 6.1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // numericUpDownSeed1
            // 
            numericUpDownSeed1.Font = new Font("Segoe UI", 15F);
            numericUpDownSeed1.Location = new Point(69, 384);
            numericUpDownSeed1.Maximum = new decimal(new int[] { -1, int.MaxValue, 0, 0 });
            numericUpDownSeed1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownSeed1.Name = "numericUpDownSeed1";
            numericUpDownSeed1.Size = new Size(346, 34);
            numericUpDownSeed1.TabIndex = 8;
            numericUpDownSeed1.Value = new decimal(new int[] { 42, 0, 0, 0 });
            // 
            // labelSeed1
            // 
            labelSeed1.AutoSize = true;
            labelSeed1.Font = new Font("Segoe UI", 15F);
            labelSeed1.Location = new Point(8, 384);
            labelSeed1.Name = "labelSeed1";
            labelSeed1.Size = new Size(55, 28);
            labelSeed1.TabIndex = 7;
            labelSeed1.Text = "Seed";
            // 
            // buttonNormalize
            // 
            buttonNormalize.Font = new Font("Segoe UI", 15F);
            buttonNormalize.Location = new Point(215, 465);
            buttonNormalize.Name = "buttonNormalize";
            buttonNormalize.Size = new Size(150, 50);
            buttonNormalize.TabIndex = 6;
            buttonNormalize.Text = "Normalize";
            buttonNormalize.UseVisualStyleBackColor = true;
            buttonNormalize.Click += buttonNormalize_Click;
            // 
            // buttonStart1
            // 
            buttonStart1.Font = new Font("Segoe UI", 15F);
            buttonStart1.Location = new Point(55, 465);
            buttonStart1.Name = "buttonStart1";
            buttonStart1.Size = new Size(150, 50);
            buttonStart1.TabIndex = 5;
            buttonStart1.Text = "Start";
            buttonStart1.UseVisualStyleBackColor = true;
            buttonStart1.Click += buttonStart1_Click;
            // 
            // numericUpDownN1
            // 
            numericUpDownN1.Font = new Font("Segoe UI", 15F);
            numericUpDownN1.Location = new Point(69, 349);
            numericUpDownN1.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            numericUpDownN1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownN1.Name = "numericUpDownN1";
            numericUpDownN1.Size = new Size(346, 34);
            numericUpDownN1.TabIndex = 4;
            numericUpDownN1.Value = new decimal(new int[] { 10000, 0, 0, 0 });
            // 
            // labelNumExp1
            // 
            labelNumExp1.AutoSize = true;
            labelNumExp1.Font = new Font("Segoe UI", 15F);
            labelNumExp1.Location = new Point(8, 349);
            labelNumExp1.Name = "labelNumExp1";
            labelNumExp1.Size = new Size(27, 28);
            labelNumExp1.TabIndex = 3;
            labelNumExp1.Text = "N";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox1.Location = new Point(421, 349);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(447, 176);
            textBox1.TabIndex = 2;
            // 
            // panelProbs
            // 
            panelProbs.AutoScroll = true;
            panelProbs.Location = new Point(8, 6);
            panelProbs.Name = "panelProbs";
            panelProbs.Size = new Size(407, 337);
            panelProbs.TabIndex = 1;
            // 
            // chartFreqs
            // 
            chartArea1.Name = "ChartArea1";
            chartFreqs.ChartAreas.Add(chartArea1);
            chartFreqs.Location = new Point(421, 6);
            chartFreqs.Name = "chartFreqs";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            chartFreqs.Series.Add(series1);
            chartFreqs.Size = new Size(447, 337);
            chartFreqs.TabIndex = 0;
            chartFreqs.Text = "chart1";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(numericUpDownSeed2);
            tabPage2.Controls.Add(labelSeed2);
            tabPage2.Controls.Add(buttonStart2);
            tabPage2.Controls.Add(numericUpDownN2);
            tabPage2.Controls.Add(numericUpDownVar);
            tabPage2.Controls.Add(numericUpDownMean);
            tabPage2.Controls.Add(labelN2);
            tabPage2.Controls.Add(labelVariance);
            tabPage2.Controls.Add(labelMean);
            tabPage2.Controls.Add(textBox2);
            tabPage2.Controls.Add(chartHist);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(876, 533);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Lab 6.2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // numericUpDownSeed2
            // 
            numericUpDownSeed2.Font = new Font("Segoe UI", 15F);
            numericUpDownSeed2.Location = new Point(99, 454);
            numericUpDownSeed2.Maximum = new decimal(new int[] { -1, int.MaxValue, 0, 0 });
            numericUpDownSeed2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownSeed2.Name = "numericUpDownSeed2";
            numericUpDownSeed2.Size = new Size(316, 34);
            numericUpDownSeed2.TabIndex = 10;
            numericUpDownSeed2.Value = new decimal(new int[] { 42, 0, 0, 0 });
            // 
            // labelSeed2
            // 
            labelSeed2.AutoSize = true;
            labelSeed2.Font = new Font("Segoe UI", 15F);
            labelSeed2.Location = new Point(8, 454);
            labelSeed2.Name = "labelSeed2";
            labelSeed2.Size = new Size(55, 28);
            labelSeed2.TabIndex = 9;
            labelSeed2.Text = "Seed";
            // 
            // buttonStart2
            // 
            buttonStart2.Font = new Font("Segoe UI", 15F);
            buttonStart2.Location = new Point(153, 492);
            buttonStart2.Name = "buttonStart2";
            buttonStart2.Size = new Size(114, 36);
            buttonStart2.TabIndex = 8;
            buttonStart2.Text = "Start";
            buttonStart2.UseVisualStyleBackColor = true;
            buttonStart2.Click += buttonStart2_Click;
            // 
            // numericUpDownN2
            // 
            numericUpDownN2.Font = new Font("Segoe UI", 15F);
            numericUpDownN2.Location = new Point(99, 419);
            numericUpDownN2.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            numericUpDownN2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownN2.Name = "numericUpDownN2";
            numericUpDownN2.Size = new Size(316, 34);
            numericUpDownN2.TabIndex = 7;
            numericUpDownN2.Value = new decimal(new int[] { 10000, 0, 0, 0 });
            // 
            // numericUpDownVar
            // 
            numericUpDownVar.DecimalPlaces = 3;
            numericUpDownVar.Font = new Font("Segoe UI", 15F);
            numericUpDownVar.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            numericUpDownVar.Location = new Point(99, 384);
            numericUpDownVar.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            numericUpDownVar.Minimum = new decimal(new int[] { 1, 0, 0, 196608 });
            numericUpDownVar.Name = "numericUpDownVar";
            numericUpDownVar.Size = new Size(316, 34);
            numericUpDownVar.TabIndex = 6;
            numericUpDownVar.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDownMean
            // 
            numericUpDownMean.DecimalPlaces = 3;
            numericUpDownMean.Font = new Font("Segoe UI", 15F);
            numericUpDownMean.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            numericUpDownMean.Location = new Point(99, 349);
            numericUpDownMean.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            numericUpDownMean.Minimum = new decimal(new int[] { 2147483646, 0, 0, int.MinValue });
            numericUpDownMean.Name = "numericUpDownMean";
            numericUpDownMean.Size = new Size(316, 34);
            numericUpDownMean.TabIndex = 5;
            // 
            // labelN2
            // 
            labelN2.AutoSize = true;
            labelN2.Font = new Font("Segoe UI", 15F);
            labelN2.Location = new Point(8, 419);
            labelN2.Name = "labelN2";
            labelN2.Size = new Size(27, 28);
            labelN2.TabIndex = 4;
            labelN2.Text = "N";
            // 
            // labelVariance
            // 
            labelVariance.AutoSize = true;
            labelVariance.Font = new Font("Segoe UI", 15F);
            labelVariance.Location = new Point(8, 384);
            labelVariance.Name = "labelVariance";
            labelVariance.Size = new Size(85, 28);
            labelVariance.TabIndex = 3;
            labelVariance.Text = "Variance";
            // 
            // labelMean
            // 
            labelMean.AutoSize = true;
            labelMean.Font = new Font("Segoe UI", 15F);
            labelMean.Location = new Point(8, 349);
            labelMean.Name = "labelMean";
            labelMean.Size = new Size(61, 28);
            labelMean.TabIndex = 2;
            labelMean.Text = "Mean";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox2.Location = new Point(421, 349);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(447, 176);
            textBox2.TabIndex = 1;
            // 
            // chartHist
            // 
            chartArea2.Name = "ChartArea1";
            chartHist.ChartAreas.Add(chartArea2);
            chartHist.Location = new Point(421, 6);
            chartHist.Name = "chartHist";
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series1";
            chartHist.Series.Add(series2);
            chartHist.Size = new Size(447, 337);
            chartHist.TabIndex = 0;
            chartHist.Text = "Hist";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(tabControl);
            Name = "Form1";
            Text = "Lab6";
            tabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSeed1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownN1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartFreqs).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSeed2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownN2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownVar).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMean).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartHist).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFreqs;
        private Panel panelProbs;
        private NumericUpDown numericUpDownN1;
        private Label labelNumExp1;
        private TextBox textBox1;
        private Button buttonStart1;
        private Button buttonNormalize;
        private NumericUpDown numericUpDownSeed1;
        private Label labelSeed1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHist;
        private TextBox textBox2;
        private Label labelMean;
        private NumericUpDown numericUpDownVar;
        private NumericUpDown numericUpDownMean;
        private Label labelN2;
        private Label labelVariance;
        private NumericUpDown numericUpDownN2;
        private Button buttonStart2;
        private NumericUpDown numericUpDownSeed2;
        private Label labelSeed2;
    }
}
