using System.Windows.Forms.DataVisualization.Charting;

namespace Lab8
{
    public partial class MainForm : Form
    {
        ulong seed;
        double lambda;
        double length;
        double currTime;
        int N;
        int eventCounter;
        List<int> eventCounters = new List<int>();
        List<int> freqs = new List<int>();
        List<double> relFreqs = new List<double>();
        MCG mcg;

        public MainForm()
        {
            InitializeComponent();
            SetupChart();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            RestartModel();
            textBoxInfo.AppendText($"Параметры:\r\n");
            textBoxInfo.AppendText($"Lambda: {lambda}, T: {length}, Seed: {seed}, N: {N}.\r\n");
            for (int i = 0; i < N; i++)
            {
                currTime = 0;
                eventCounter = 0;
                while (currTime <= length)
                {
                    double alpha = mcg.Next();
                    double tau = (-Math.Log(alpha) / lambda);
                    if (currTime + tau <= length)
                    {
                        currTime += tau;
                        eventCounter++;
                    }
                    else
                    {
                        currTime = length;
                        break;
                    }
                }
                eventCounters.Add(eventCounter);
                textBoxInfo.AppendText($"{i}. Кол-во событий: {eventCounter}.\r\n");
            }
            int freqsLength = eventCounters.Max();
            for (int i = 0; i <= freqsLength; i++)
            {
                freqs.Add(0);
                relFreqs.Add(0);
            }
            for (int i = 0; i < N; i++)
            {
                freqs[eventCounters[i]]++;
            }
            for (int i = 0; i <= freqsLength; i++)
            {
                relFreqs[i] = (double)freqs[i] / N;
                chartPoisson.Series[0].Points.AddXY(i, relFreqs[i]);
            }
            DrawPoisson(freqsLength);
            double mean = CalcMean(eventCounters);
            double theorMean = lambda * length;
            double relErrMean = (Math.Abs(mean - theorMean)) / theorMean;
            double var = CalcVar(eventCounters, mean);
            double theorVar = lambda * length;
            double relErrVar = (Math.Abs(var - theorVar)) / theorVar;
            textBoxInfo.AppendText($"Числовые характеристики:\r\n");
            textBoxInfo.AppendText($"Мат. Ожидание:\r\n");
            textBoxInfo.AppendText($"Теоретическое: {theorMean}.\r\n");
            textBoxInfo.AppendText($"Эмпирическое: {mean}.\r\n");
            textBoxInfo.AppendText($"Отн. Ошибка: {relErrMean}.\r\n");
            textBoxInfo.AppendText($"Дисперсия:\r\n");
            textBoxInfo.AppendText($"Теоретическое: {theorVar}.\r\n");
            textBoxInfo.AppendText($"Эмпирическое: {var}.\r\n");
            textBoxInfo.AppendText($"Отн. Ошибка: {relErrVar}.\r\n");
        }

        private void SetupChart()
        {
            chartPoisson.Series.Clear();
            chartPoisson.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.AxisX.Title = "События";
            chartArea.AxisY.Title = "Вероятность";
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 1;
            chartArea.AxisX.LabelStyle.Format = "F0";
            chartPoisson.ChartAreas.Add(chartArea);
            Series series = new Series("Эмпирическое Распределение");
            series.ChartType = SeriesChartType.Column;
            series.BorderWidth = 2;
            chartPoisson.Series.Add(series);
            series = new Series("Теор. Фунцкия");
            series.ChartType = SeriesChartType.Line;
            series.Color = Color.Green;
            chartPoisson.Series.Add(series);
        }

        private void RestartModel()
        {
            seed = (ulong)numericUpDownSeed.Value;
            mcg = new MCG(seed);
            for (int i = 0; i < 100; i++)
            {
                mcg.Next();
            }
            lambda = (double)numericUpDownLambda.Value;
            length = (double)numericUpDownLength.Value;
            N = (int)numericUpDownN.Value;
            currTime = 0;
            eventCounter = 0;
            eventCounters.Clear();
            freqs.Clear();
            relFreqs.Clear();
            textBoxInfo.Clear();
            SetupChart();
        }

        private double CalcMean(List<int> events)
        {
            double Mean = (double)events.Sum() / events.Count();
            return Mean;
        }

        private double CalcVar(List<int> events, double mean = -1)
        {
            if (mean == -1) mean = CalcMean(events);
            double var = 0;
            for (int i = 0; i < events.Count; i++)
            {
                var += (events[i] - mean) * (events[i] - mean);
            }
            var /= events.Count - 1;
            return var;
        }

        private void DrawPoisson(int maxK)
        {
            double lambdaT = lambda * length;
            double p = Math.Exp(-lambdaT);
            chartPoisson.Series[1].Points.AddXY(0, p);
            for (int k = 1; k <= maxK; k++)
            {
                p = p * lambdaT / k;
                chartPoisson.Series[1].Points.AddXY(k, p);
            }
        }
    }

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
}
