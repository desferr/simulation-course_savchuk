using System.Text;
using System.Web;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.AxHost;

namespace Lab7
{
    public partial class MainForm : Form
    {
        private double[,] Q = new double[,]
        {
            { -0.4, 0.3, 0.1},
            { 0.4, -0.8, 0.4},
            { 0.1, 0.4, -0.5}
        };
        private double[] theorProbs = new double[] { 0.381, 0.3015, 0.3175 };
        private string[] stateNames = new string[] { "Ясно", "Облачно", "Пасмурно" };
        MCG mcg;
        private int currState = 0;
        private int currDay = 0;
        private double currTime = 0;
        private double remainingTime = 1;
        private double tau = 0;
        private double[] timeInState = new double[] { 0, 0, 0 };
        private List<(double x, double[] y)> probabilityHistory = new List<(double x, double[] y)>();
        private int totalDays;
        private double[] timeSum = new double[3];
        private double[] timeSumSq = new double[3];
        private int[] transitionsAmount = new int[3];
        private double currInterval = 0;
        private int startState = 0;
        private List<int> stateChangesHistory = new List<int>();
        private List<double> timeChangesHistory = new List<double>();

        public MainForm()
        {
            InitializeComponent();
            SetupChart();
        }

        private void SetupChart()
        {
            chartWeather.Series.Clear();
            chartWeather.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.AxisX.Title = "Дни";
            chartArea.AxisY.Title = "Вероятность";
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 1;
            chartArea.AxisX.LabelStyle.Format = "F0";
            chartWeather.ChartAreas.Add(chartArea);
            Color[] colors = { Color.Gold, Color.Gray, Color.DimGray };
            for (int i = 0; i < 3; i++)
            {
                Series series = new Series(stateNames[i]);
                series.ChartType = SeriesChartType.Line;
                series.Color = colors[i];
                series.BorderWidth = 2;
                chartWeather.Series.Add(series);
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            totalDays = (int)numericUpDownDuration.Value;
            ulong seed = (ulong)numericUpDownSeed.Value;
            mcg = new MCG(seed);
            for (int i = 0; i < 100; i++) mcg.Next();
            ResetModel();
            textBoxHistory.Clear();
            textBoxHistory.AppendText($"Начальное состояние: {stateNames[currState]}.\r\n");
            timerSimulation.Start();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (probabilityHistory.Count == 0 || timeInState.Sum() == 0)
            {
                MessageBox.Show("Нет данных для экспорта. Сначала выполните моделирование.",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "CSV файлы (*.csv)|*.csv|Текстовые файлы (*.txt)|*.txt";
                saveDialog.DefaultExt = "csv";
                saveDialog.FileName = $"weather_simulation_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportToCSV(saveDialog.FileName);
                        MessageBox.Show($"Данные успешно экспортированы в:\n{saveDialog.FileName}",
                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при экспорте: {ex.Message}",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExportToCSV(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                double totalTime = timeInState.Sum();

                writer.WriteLine("Моделирование погоды - Марковский процесс с непрерывным временем");
                writer.WriteLine($"Дата экспорта: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
                writer.WriteLine($"Всего дней: {totalDays}");
                writer.WriteLine($"Общее время моделирования: {totalTime:F2} дней");
                writer.WriteLine($"Начальное состояние: {stateNames[startState]}");
                writer.WriteLine($"Seed генератора: {numericUpDownSeed.Value}");
                writer.WriteLine();

                writer.WriteLine("=== МАТРИЦА ИНТЕНСИВНОСТЕЙ (ГЕНЕРАТОР Q) ===");
                writer.WriteLine("Из\\В;Ясно;Облачно;Пасмурно;Интенсивность выхода");
                for (int i = 0; i < 3; i++)
                {
                    double lambda = -Q[i, i];
                    writer.WriteLine($"{stateNames[i]};{Q[i, 0]};{Q[i, 1]};{Q[i, 2]};{lambda}");
                }
                writer.WriteLine();

                writer.WriteLine("=== СТАЦИОНАРНЫЕ РАСПРЕДЕЛЕНИЯ ===");
                writer.WriteLine("Состояние;Время (дни);Эмпирическая вероятность;Теоретическая вероятность;Абсолютная ошибка;Относительная ошибка");
                for (int i = 0; i < 3; i++)
                {
                    double estProb = timeInState[i] / totalTime;
                    double theorProb = theorProbs[i];
                    double absErr = Math.Abs(estProb - theorProb);
                    double relErr = absErr / theorProb;
                    writer.WriteLine($"{stateNames[i]};{timeInState[i]:F4};{estProb:F6};{theorProb:F6};{absErr:F6};{relErr:F6}");
                }
                writer.WriteLine();

                writer.WriteLine("=== ХАРАКТЕРИСТИКИ ВРЕМЕНИ ПРЕБЫВАНИЯ ===");
                writer.WriteLine("Состояние;Интенсивность λ;Количество переходов;Среднее (эмп);Среднее (теор);Дисперсия (эмп);Дисперсия (теор)");
                for (int i = 0; i < 3; i++)
                {
                    double lambda = -Q[i, i];
                    double theorMean = 1.0 / lambda;
                    double theorVar = 1.0 / (lambda * lambda);

                    string estMeanStr = transitionsAmount[i] > 0 ? (timeSum[i] / transitionsAmount[i]).ToString("F6") : "—";
                    string estVarStr = transitionsAmount[i] > 1 ?
                        ((timeSumSq[i] - (timeSum[i] * timeSum[i]) / transitionsAmount[i]) / (transitionsAmount[i] - 1)).ToString("F6") : "—";

                    writer.WriteLine($"{stateNames[i]};{lambda};{transitionsAmount[i]};{estMeanStr};{theorMean:F6};{estVarStr};{theorVar:F6}");
                }
                writer.WriteLine();

                writer.WriteLine("=== ИСТОРИЯ ВЕРОЯТНОСТЕЙ ПО ДНЯМ ===");
                writer.WriteLine("День-Время;Ясно;Облачно;Пасмурно");

                int totalRecords = probabilityHistory.Count;

                for (int i = 0; i < totalRecords; i++)
                {
                    var record = probabilityHistory[i];
                    writer.WriteLine($"{TransformTime(record.x)};{record.y[0]:F6};{record.y[1]:F6};{record.y[2]:F6}");
                }

                writer.WriteLine();

                writer.WriteLine("=== ИСТОРИЯ ПЕРЕХОДОВ ===");

                writer.WriteLine($"Начальное состояние: {stateNames[stateChangesHistory[0]]}");
                for (int i = 0; i < stateChangesHistory.Count(); i++)
                {
                    var record = probabilityHistory[i];
                    string state = stateNames[stateChangesHistory[i]];

                    writer.WriteLine($"{TransformTime(timeChangesHistory[i])};{state}");
                }
                writer.WriteLine($"Итоговое состояние: {stateNames[stateChangesHistory[stateChangesHistory.Count() - 1]]}");
            }
        }

        private void ResetModel()
        {
            timeInState = new double[] { 0, 0, 0 };
            currState = 0;
            currDay = 0;
            currTime = 0;
            remainingTime = 1;
            double[] inititalProbs = { 1.0 / 3, 1.0 / 3, 1.0 / 3 };
            probabilityHistory.Clear();
            probabilityHistory.Add((0, inititalProbs));
            double alpha = mcg.Next();
            for (int i = 0; i < 3; i++)
            {
                alpha -= inititalProbs[i];
                if (alpha < 0)
                {
                    currState = i;
                    break;
                }
            }
            if (alpha >= 0) currState = 2;
            startState = currState;
            tau = GenerateTau(currState);
            timeSum = new double[] { 0.0, 0.0, 0.0 };
            timeSumSq = new double[] { 0.0, 0.0, 0.0 };
            transitionsAmount = new int[] { 0, 0, 0 };
            currInterval = 0;
            stateChangesHistory.Clear();
            timeChangesHistory.Clear();
            UpdateUI();
        }

        private void UpdateUI()
        {
            labelCurrWeatherChanging.Text = stateNames[currState];
            switch (currState)
            {
                case 0:
                    labelCurrWeatherChanging.BackColor = Color.Gold;
                    break;
                case 1:
                    labelCurrWeatherChanging.BackColor = Color.LightGray;
                    break;
                case 2:
                    labelCurrWeatherChanging.BackColor = Color.DimGray;
                    break;
            }
            double total = timeInState.Sum();
            if (total > 0)
            {
                labelEstSPDClearChanging.Text = Math.Round((timeInState[0] / total), 4).ToString();
                labelEstSPDCloudyChanging.Text = Math.Round((timeInState[1] / total), 4).ToString();
                labelEstSPDOvercastChanging.Text = Math.Round((timeInState[2] / total), 4).ToString();
            }
        }

        private double GenerateTau(int state)
        {
            double alpha = mcg.Next();
            double tau = Math.Log(alpha) / Q[state, state];
            return tau;
        }

        private int GetNextState(int currState)
        {
            double alpha = mcg.Next();
            double totalProb = -Q[currState, currState];
            if (currState == 0)
            {
                if (alpha < Q[0, 1] / totalProb) return 1;
                return 2;
            }
            else if (currState == 1)
            {
                if (alpha < Q[1, 0] / totalProb) return 0;
                return 2;
            }
            else
            {
                if (alpha < Q[2, 0] / totalProb) return 0;
                return 1;
            }
        }

        private void UpdateStatisticsAndUI()
        {
            double total = timeInState.Sum();
            if (total > 0)
            {
                double probClear = timeInState[0] / total;
                double probCloudy = timeInState[1] / total;
                double probOvercast = timeInState[2] / total;
                labelEstSPDClearChanging.Text = Math.Round(probClear, 4).ToString();
                labelEstSPDCloudyChanging.Text = Math.Round(probCloudy, 4).ToString();
                labelEstSPDOvercastChanging.Text = Math.Round(probOvercast, 4).ToString();
                probabilityHistory.Add((currTime, new double[] { probClear, probCloudy, probOvercast}));
            }
            labelCurrWeatherChanging.Text = stateNames[currState];
            switch (currState)
            {
                case 0:
                    labelCurrWeatherChanging.BackColor = Color.Gold;
                    break;
                case 1:
                    labelCurrWeatherChanging.BackColor = Color.LightGray;
                    break;
                case 2:
                    labelCurrWeatherChanging.BackColor = Color.DimGray;
                    break;
            }
            UpdateChart();
        }

        private void UpdateChart()
        {
            for (int i = 0; i < 3; i++)
            {
                chartWeather.Series[i].Points.Clear();
            }

            foreach (var dayProbs in probabilityHistory)
            {
                chartWeather.Series["Ясно"].Points.AddXY(dayProbs.x, dayProbs.y[0]);
                chartWeather.Series["Облачно"].Points.AddXY(dayProbs.x, dayProbs.y[1]);
                chartWeather.Series["Пасмурно"].Points.AddXY(dayProbs.x, dayProbs.y[2]);
            }
        }

        private void timerSimulation_Tick(object sender, EventArgs e)
        {
            if (currDay >= totalDays)
            {
                timerSimulation.Stop();
                buttonStart.Enabled = true;
                UpdateChart();
                return;
            }
            ProcessDayEvents();
        }

        private void ProcessDayEvents()
        {
            remainingTime = 1;
            while (true)
            {
                if (tau + currTime >= totalDays)
                {
                    timeInState[currState] += totalDays - currTime;
                    currDay = totalDays;
                    currTime = totalDays;
                    textBoxHistory.AppendText($"Итоговое состояние: {stateNames[currState]}!\r\n");
                    textBoxHistory.AppendText($"Стационарные распределения:\r\n");
                    textBoxHistory.AppendText($"Состояние|Оценка|Теор. Вероятность|Отн. Погрешность\r\n");
                    double totalTime = timeInState.Sum();
                    for (int i = 0; i < 3; i++)
                    {
                        string stateName = stateNames[i];
                        double estProb = timeInState[i] / totalTime;
                        double theorProb = theorProbs[i];
                        double err = Math.Abs(estProb - theorProb) / theorProb;
                        textBoxHistory.AppendText($"{stateName}|{Math.Round(estProb, 4)}|{Math.Round(theorProb, 4)}|{Math.Round(err, 6)}\r\n");
                    }
                    textBoxHistory.AppendText($"Характеристики:\r\n");
                    textBoxHistory.AppendText($"Состояние|Оценка M|Теор. М|Оценка D|Теор. D\r\n");
                    for (int i = 0; i < 3; i++)
                    {
                        string stateName = stateNames[i];
                        double estMean = timeSum[i] / transitionsAmount[i];
                        double theorMean = 1.0 / -Q[i, i];
                        double estVar = (timeSumSq[i] - (timeSum[i] * timeSum[i]) / transitionsAmount[i]) / (transitionsAmount[i] - 1);
                        double theorVar = 1 / (-Q[i, i] * -Q[i, i]);
                        textBoxHistory.AppendText($"{stateName}|{Math.Round(estMean, 4)}|{Math.Round(theorMean, 4)}|{Math.Round(estVar, 4)}|{Math.Round(theorVar, 4)}\r\n");
                    }
                    UpdateStatisticsAndUI();
                    return;
                }
                else if (tau < remainingTime)
                {
                    remainingTime -= tau;
                    timeInState[currState] += tau;
                    currTime += tau;
                    UpdateStatisticsAndUI();
                    currInterval += tau;
                    timeSum[currState] += currInterval;
                    timeSumSq[currState] += currInterval * currInterval;
                    currInterval = 0;
                    transitionsAmount[currState]++;
                    currState = GetNextState(currState);
                    tau = GenerateTau(currState);
                    textBoxHistory.AppendText(TransformTime(currTime));
                    textBoxHistory.AppendText($" {stateNames[currState]}.\r\n");
                    stateChangesHistory.Add(currState);
                    timeChangesHistory.Add(currTime);
                }
                else if (tau >= remainingTime)
                {
                    currInterval += remainingTime;
                    tau -= remainingTime;
                    currDay++;
                    currTime += remainingTime;
                    timeInState[currState] += remainingTime;
                    UpdateStatisticsAndUI();
                    return;
                }
            }
        }

        private string TransformTime(double time)
        {
            int day = (int)time;
            double hours = (time - day) * 24;
            int minutes = (int)((hours - (int)hours) * 60);
            return $"[День {day}. {(int)hours:D2}:{minutes:D2}]";
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