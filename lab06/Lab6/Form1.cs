using System;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Reflection.Metadata.BlobBuilder;

namespace Lab6
{
    public partial class Form1 : Form
    {
        private List<ProbRow> rows;
        private bool isUpdatingInternally = false;
        private List<double> chiSqCritForAlpha005 = new List<double>() { 3.841, 5.991, 7.815, 9.488, 11.070, 12.592, 14.067, 15.507, 16.919, 18.307, 19.675, 21.026, 22.362, 23.685, 24.996, 26.296, 27.587, 28.869, 30.144, 31.410 };

        public Form1()
        {
            InitializeComponent();
            rows = new List<ProbRow>();
            AddNewRow();
        }

        private void AddNewRow()
        {
            int newIndex = rows.Count + 1;
            int x = 25;
            int y = 10 + (newIndex - 1) * 44;

            Label label = new Label();
            label.Text = $"Prob {newIndex}";
            label.Location = new Point(x, y);
            label.Size = new Size(165, 34);
            label.Font = new Font("Segoe UI", 15);
            label.TextAlign = ContentAlignment.MiddleRight;
            label.Margin = new Padding(0);

            NumericUpDown nud = new NumericUpDown();
            nud.Minimum = 0;
            nud.Maximum = 1;
            nud.Increment = 0.00001m;
            nud.DecimalPlaces = 5;
            nud.Location = new Point(x + 170, y);
            nud.Size = new Size(120, 34);
            nud.Font = new Font("Segoe UI", 15);
            nud.Value = 0;

            ProbRow row = new ProbRow(label, nud);
            row.PrevValue = 0.0;
            rows.Add(row);

            panelProbs.Controls.Add(label);
            panelProbs.Controls.Add(nud);
            nud.ValueChanged += Nud_ValueChanged;

            UpdateScrollArea();
            RenumberRows();
        }

        private void RemoveLastRow()
        {
            if (rows.Count <= 1) return;
            ProbRow last = rows[rows.Count - 1];
            panelProbs.Controls.Remove(last.Label);
            panelProbs.Controls.Remove(last.Nud);
            last.Label.Dispose();
            last.Nud.Dispose();
            rows.RemoveAt(rows.Count - 1);

            UpdateScrollArea();
            RenumberRows();
        }

        private void RenumberRows()
        {
            for (int i = 0; i < rows.Count; i++)
            {
                rows[i].Label.Text = $"Prob {i + 1}";
                rows[i].Label.Location = new Point(25, 10 + i * 44);
                rows[i].Nud.Location = new Point(195, 10 + i * 44);
            }
        }

        private void UpdateScrollArea()
        {
            if (rows.Count == 0) return;
            int totalHeight = 10 + rows.Count * 44;
            panelProbs.AutoScrollMinSize = new Size(0, totalHeight);
            panelProbs.AutoScrollPosition = new Point(0, 0);
        }

        private List<(int Index, double Prob)> GetProbs(bool sort = false)
        {
            List<(int Index, double Prob)> list = new List<(int Index, double Prob)>();
            for (int i = 0; i < rows.Count - 1; i++)
            {
                list.Add((i + 1, (double)rows[i].Nud.Value));
            }
            if (sort) list = list.OrderByDescending(p => p.Prob).ToList();
            return list;
        }

        private List<int> getDiscreteSample(List<(int Index, double Prob)> probs, int N, ulong seed = 42)
        {
            MCG mcg = new MCG(seed);
            for (int i = 0; i < 100; i++) mcg.Next();
            List<int> sample = new List<int>(N);
            for (int i = 0; i < N; i++)
            {
                double alpha = mcg.Next();
                foreach (var (index, prob) in probs)
                {
                    alpha -= prob;
                    if (alpha <= 0)
                    {
                        sample.Add(index);
                        break;
                    }
                }
                if (alpha > 0) sample.Add(probs.Last().Index);
            }
            return sample;
        }

        private List<double> getNormSample(double mean, double var, int N, ulong seed)
        {
            MCG mcg = new MCG(seed);
            for (int i = 0; i < 100; i++) mcg.Next();
            List<double> sample = new List<double>(N);
            for (int i = 0; i < N; i++)
            {
                double dzeta = 0;
                double alpha = mcg.Next();
                for (int j = 0; j < 12; j++)
                {
                    dzeta += alpha;
                    alpha = mcg.Next();
                }
                dzeta -= 6;
                dzeta = dzeta + (1.0 / 240) * ((dzeta * dzeta * dzeta) - 3 * dzeta);
                sample.Add(Math.Sqrt(var) * dzeta + mean);
            }
            return sample;
        }

        private void Nud_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdatingInternally) return;

            NumericUpDown nud = sender as NumericUpDown;
            if (nud == null) return;

            int index = -1;
            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].Nud == nud)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1) return;

            double newValue = (double)nud.Value;
            double oldValue = rows[index].PrevValue;

            if (newValue > 0.0 && index == rows.Count - 1)
            {
                rows[index].PrevValue = newValue;
                AddNewRow();
                return;
            }

            if (newValue == 0.0)
            {
                bool isLast = (index == rows.Count - 1);
                bool isPreLast = (index == rows.Count - 2);

                if (!isLast && !isPreLast)
                {
                    MessageBox.Show("Обнуление разрешено только для последнего или предпоследнего поля!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isUpdatingInternally = true;
                    nud.ValueChanged -= Nud_ValueChanged;
                    nud.Value = (decimal)oldValue;
                    nud.ValueChanged += Nud_ValueChanged;
                    isUpdatingInternally = false;
                    return;
                }
                else if (isPreLast && rows.Count >= 2)
                {
                    RemoveLastRow();
                    rows[index].PrevValue = 0.0;
                    return;
                }
                else if (isLast)
                {
                    rows[index].PrevValue = 0.0;
                    return;
                }
            }

            rows[index].PrevValue = newValue;
        }

        private void buttonNormalize_Click(object sender, EventArgs e)
        {
            if (rows.Count == 0) return;
            foreach (var row in rows)
            {
                row.Nud.ValueChanged -= Nud_ValueChanged;
            }

            const double targetSum = 1.0;
            const double epsilon = 1e-10;
            int maxIterations = 5;

            for (int iter = 0; iter < maxIterations; iter++)
            {
                double sum = 0.0;
                for (int i = 0; i < rows.Count - 1; i++)
                {
                    sum += (double)rows[i].Nud.Value;
                }
                if (Math.Abs(sum - targetSum) < epsilon) break;
                if (Math.Abs(sum) < epsilon)
                {
                    MessageBox.Show("Невозможно нормализовать: все вероятности равны нулю!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                double factor = targetSum / sum;
                for (int i = 0; i < rows.Count - 1; i++)
                {
                    double newVal = (double)rows[i].Nud.Value * factor;
                    if (newVal <= 0.00001) newVal = 0.00001;
                    if (newVal > 1) newVal = 1;
                    rows[i].Nud.Value = (decimal)newVal;
                }
            }

            foreach (ProbRow row in rows)
            {
                row.PrevValue = (double)row.Nud.Value;
                row.Nud.ValueChanged += Nud_ValueChanged;
            }
        }

        private void buttonStart1_Click(object sender, EventArgs e)
        {
            double sum = 0.0;
            for (int i = 0; i < rows.Count - 1; i++)
            {
                sum += (double)rows[i].Nud.Value;
            }
            const double targetSum = 1.0;
            const double epsilon = 1e-10;
            if (!(Math.Abs(sum - targetSum) < epsilon))
            {
                MessageBox.Show("Вероятности не нормализованы!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<(int Index, double Prob)> probs = GetProbs(true);
            int N = (int)numericUpDownN1.Value;
            ulong seed = (ulong)numericUpDownSeed1.Value;
            List<int> sample = getDiscreteSample(probs, N, seed);
            Dictionary<int, int> freqs = Calculate.CalculateFreqDiscrete(sample, probs.Count);
            Dictionary<int, double> freqsProbs = new Dictionary<int, double>(probs.Count);
            foreach (var (index, freq) in freqs)
            {
                freqsProbs[index] = (double)freq / N;
            }
            textBox1.Clear();
            double empMean = 0;
            foreach (var (index, freq) in freqsProbs)
            {
                empMean += index * freq;
            }
            double theoMean = 0;
            foreach (var (index, prob) in probs)
            {
                theoMean += index * prob;
            }
            double meanError = (Math.Abs(empMean - theoMean) / Math.Abs(theoMean));
            textBox1.AppendText($"Average: {Math.Round(empMean, 3)} (error = {Math.Round(meanError, 3)})" + Environment.NewLine);
            double empVar = 0;
            foreach (var (index, freq) in freqsProbs)
            {
                empVar += index * index * freq;
            }
            empVar -= empMean * empMean;
            double theoVar = 0;
            foreach (var (index, prob) in probs)
            {
                theoVar += (index * index) * prob;
            }
            theoVar -= theoMean * theoMean;
            double varError = (Math.Abs(empVar - theoVar) / theoVar);
            textBox1.AppendText($"Variance: {Math.Round(empVar, 3)} (error = {Math.Round(varError, 3)})" + Environment.NewLine);
            if (probs.Count >= 2 && probs.Count <= 21)
            {
                double chiSq = 0;
                foreach (var (index, prob) in probs)
                {
                    chiSq += ((double)freqs[index] * freqs[index]) / ((double)sample.Count * prob);
                }
                chiSq -= sample.Count;
                double chiSqCrit = chiSqCritForAlpha005[probs.Count - 2];
                bool isTrue = chiSq > chiSqCrit;
                textBox1.AppendText($"Chi-squared for alpha = 0.05:" + Environment.NewLine);
                textBox1.AppendText($"{chiSq} > {chiSqCrit} is {isTrue}" + Environment.NewLine);
            }
            else
            {
                textBox1.AppendText($"Chi-squared worked only when 2 <= m <= 21!" + Environment.NewLine);
            }
            chartFreqs.Series.Clear();
            chartFreqs.ChartAreas.Clear();
            ChartArea area = new ChartArea();
            chartFreqs.ChartAreas.Add(area);
            area.AxisX.MajorGrid.Enabled = false;
            chartFreqs.Titles.Clear();
            chartFreqs.Titles.Add("Freq.");
            Series series = new Series
            {
                Name = "series_1",
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };
            chartFreqs.Series.Add(series);
            foreach (var pair in freqs)
            {
                series.Points.AddXY((double)pair.Key, (double)pair.Value / sample.Count);
            }
        }

        private void buttonStart2_Click(object sender, EventArgs e)
        {
            double mean = (double)numericUpDownMean.Value;
            double var = (double)numericUpDownVar.Value;
            int N = (int)numericUpDownN2.Value;
            ulong seed = (ulong)numericUpDownSeed2.Value;
            List<double> sample = getNormSample(mean, var, N, seed);
            double empMean = Calculate.CalculateMean(sample);
            double meanError = (Math.Abs(mean - empMean) / mean);
            textBox2.Clear();
            textBox2.AppendText($"Average: {Math.Round(empMean, 3)} (error = {Math.Round(meanError, 3)})" + Environment.NewLine);
            double empVar = Calculate.CalculateVariance(sample);
            double varError = (Math.Abs(var - empVar) / var);
            textBox2.AppendText($"Variance: {Math.Round(empVar, 3)} (error = {Math.Round(varError, 3)})" + Environment.NewLine);
            int k = (int)Math.Ceiling(Math.Sqrt(N));
            if (k > 21) k = 21;
            var (freqs, intervals) = Calculate.CalculateFreq(sample, k);
            if (k >= 2 && k <= 21)
            {
                double chiSq = 0;
                for (int i = 0; i < k; i++)
                {
                    double mid = (intervals[i].right + intervals[i].left) / 2;
                    double pi = (intervals[i].right - intervals[i].left) * (Math.Exp(-(((mid - mean) * (mid - mean)) / (2 * var))) / (Math.Sqrt(2 * Math.PI * var)));
                    chiSq += (freqs[i] * freqs[i]) / (N * pi);
                }
                chiSq -= N;
                double chiSqCrit = chiSqCritForAlpha005[k - 2];
                bool isTrue = chiSq > chiSqCrit;
                textBox2.AppendText($"Chi-squared for alpha = 0.05:" + Environment.NewLine);
                textBox2.AppendText($"{chiSq} > {chiSqCrit} is {isTrue}" + Environment.NewLine);
            }
            else
            {
                textBox2.AppendText($"Chi-squared worked only when 2 <= k <= 21!" + Environment.NewLine);
            }
            double min = sample.Min();
            double max = sample.Max();
            double step = (max - min) / k;
            chartHist.Series.Clear();
            chartHist.ChartAreas.Clear();
            ChartArea area = new ChartArea();
            chartHist.ChartAreas.Add(area);
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.Interval = 1;
            area.AxisX.Minimum = Math.Floor(min);
            area.AxisX.Maximum = Math.Ceiling(max);
            area.AxisX.LabelStyle.Format = "0";
            chartHist.Titles.Clear();
            chartHist.Titles.Add("");
            Series histSeries = new Series
            {
                Name = "hist",
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = false,
            };
            histSeries["PointWidth"] = "1.0";
            chartHist.Series.Add(histSeries);
            for (int i = 0; i < k; i++)
            {
                double left = min + i * step;
                double right = left + step;
                double center = (left + right) / 2;
                double density = (double)freqs[i] / (sample.Count * step);
                histSeries.Points.AddXY(center, density);
            }
            Series densitySeries = new Series
            {
                Name = "density",
                ChartType = SeriesChartType.Line,
                Color = Color.Green,
                IsXValueIndexed = false
            };
            chartHist.Series.Add(densitySeries);
            int NPoints = 1000;
            double stepPoints = (Math.Ceiling(max) - Math.Floor(min)) / NPoints;
            for (int i = 0; i <= NPoints; i++)
            {
                double x = Math.Floor(min) + i * stepPoints;
                double y = Math.Exp(-(((x - mean) * (x - mean)) / (2 * var))) / (Math.Sqrt(2 * Math.PI * var));
                densitySeries.Points.AddXY(x, y);
            }
        }
    }

    public class ProbRow 
    { 
        public Label Label { get; set; }
        public NumericUpDown Nud { get; set; }
        public double PrevValue { get; set; }

        public ProbRow(Label label, NumericUpDown nud)
        {
            Label = label;
            Nud = nud;
            PrevValue = 0.0;
        }
    };

    public class MCG
    {
        private ulong state;
        static private ulong M = 9223372036854775808;
        static private ulong beta = 4294967299;

        public MCG(ulong seed = 42)
        {
            if (seed == 0) seed = 1;
            state = seed;
        }

        public double Next()
        {
            state = (beta * state) % M;
            return (double)state / M;
        }

        static public ulong getM() { return M; }
    }

    public static class Calculate
    {
        public static double CalculateMean(List<double> sample)
        {
            int N = sample.Count();
            double summ = sample.Sum();
            return summ / N;
        }

        public static double CalculateVariance(List<double> sample, double mean = -1)
        {
            if (mean == -1) mean = CalculateMean(sample);
            int N = sample.Count();
            double summ = 0;
            for (int i = 0; i < N; i++)
            {
                summ += sample[i] * sample[i];
            }
            summ /= N;
            return summ - (mean * mean);
        }

        public static (Dictionary<int, int>, List<(double left, double right)>) CalculateFreq(List<double> sample, int bins = 20)
        {
            Dictionary<int, int> freqs = new Dictionary<int, int>(bins);
            List<(double left, double right)> intervals = new List<(double left, double right)>();
            for (int i = 0; i < bins; i++)
            {
                freqs[i] = 0;
            }
            List<double> sorted_sample = new List<double>(sample);
            sorted_sample.Sort();
            int N = sorted_sample.Count();
            double minimum = sorted_sample.First();
            double maximum = sorted_sample.Last();
            double step = (maximum - minimum) / bins;
            double curr_bin = minimum + step;
            int j = 0;
            for (int i = 0; i < bins; i++)
            {
                while (j < N && sorted_sample[j] <= curr_bin)
                {
                    freqs[i]++;
                    j++;
                }
                intervals.Add((curr_bin - step, curr_bin));
                curr_bin += step;
            }
            return (freqs, intervals);
        }

        public static Dictionary<int, int> CalculateFreqDiscrete(List<int> sample, int valuesAmount)
        {
            var freqs = new Dictionary<int, int>();
            for (int i = 1; i <= valuesAmount; i++)
                freqs[i] = 0;
            foreach (int val in sample)
            {
                freqs[val]++;
            }
            return freqs;
        }
    }
}
