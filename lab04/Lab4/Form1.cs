using System.Reflection;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int N = (int)numericUpDown1.Value;
            ulong seed = (ulong)numericUpDown2.Value;
            List<double> sample = new List<double>();
            MCG mcg = new MCG(seed);
            for (int i = 0; i < N; i++)
            {
                sample.Add(mcg.Next());
            }
            textBox1.Clear();
            textBox1.AppendText("MCG:" + Environment.NewLine);
            double mean = Calculate.CalculateMean(sample);
            textBox1.AppendText("Выборочное среднее:" + Environment.NewLine);
            textBox1.AppendText(mean.ToString() + Environment.NewLine);
            double variance = Calculate.CalculateVariance(sample, mean);
            textBox1.AppendText("Выборочная дисперсия:" + Environment.NewLine);
            textBox1.AppendText(variance.ToString() + Environment.NewLine);

            int bins = 20;
            Dictionary<int, int> freqs = Calculate.CalculateFreq(sample, bins);
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            ChartArea area = new ChartArea();
            chart1.ChartAreas.Add(area);
            area.AxisX.MajorGrid.Enabled = false;
            chart1.Titles.Clear();
            chart1.Titles.Add("Гистограмма MCG");
            Series series = new Series
            {
                Name = "Частота",
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };
            chart1.Series.Add(series);
            foreach (var pair in freqs)
            { 
                series.Points.AddXY((double)pair.Key / bins, pair.Value);
            }

            Random random = new Random((int)seed);
            List<double> sample_random = new List<double>();
            for (int i = 0; i < N; i++)
            {
                sample_random.Add(random.NextDouble());
            }
            textBox1.AppendText("Random:" + Environment.NewLine);
            double mean_random = Calculate.CalculateMean(sample_random);
            textBox1.AppendText("Выборочное среднее:" + Environment.NewLine);
            textBox1.AppendText(mean_random.ToString() + Environment.NewLine);
            double variance_random = Calculate.CalculateVariance(sample_random, mean_random);
            textBox1.AppendText("Выборочная дисперсия:" + Environment.NewLine);
            textBox1.AppendText(variance_random.ToString() + Environment.NewLine);

            Dictionary<int, int> freqs_random = Calculate.CalculateFreq(sample_random, bins);
            chart2.Series.Clear();
            chart2.ChartAreas.Clear();
            ChartArea area_random = new ChartArea();
            chart2.ChartAreas.Add(area_random);
            area_random.AxisX.MajorGrid.Enabled = false;
            chart2.Titles.Clear();
            chart2.Titles.Add("Гистограмма Random");
            Series series_random = new Series
            {
                Name = "Частота",
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };
            chart2.Series.Add(series_random);
            foreach (var pair in freqs_random)
            {
                series_random.Points.AddXY((double)pair.Key / bins, pair.Value);
            }

            textBox1.AppendText("Теория:" + Environment.NewLine);
            textBox1.AppendText("Выборочное среднее:" + Environment.NewLine);
            textBox1.AppendText((1.0 / 2).ToString() + Environment.NewLine);
            textBox1.AppendText("Выборочная дисперсия:" + Environment.NewLine);
            textBox1.AppendText((1.0 / 12).ToString());
        }
    }

    public class MCG
    {
        private ulong state;
        private ulong M = 9223372036854775808;
        private ulong beta = 4294967299;

        public MCG(ulong seed = 42)
        {
            state = seed;
        }

        public double Next()
        {
            state = (beta * state) % M;
            return (double)state / M;
        }
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
                summ += (sample[i] - mean) * (sample[i] - mean);
            }
            return summ / N;
        }

        public static Dictionary<int, int> CalculateFreq(List<double> sample, int bins = 20)
        {
            Dictionary<int, int> freqs = new Dictionary<int, int>(bins);
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
                curr_bin += step;
            }
            return freqs;
        }
    }
}
