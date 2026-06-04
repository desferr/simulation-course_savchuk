using System.Diagnostics.Eventing.Reader;
using System.Drawing.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab9
{
    public partial class MainForm : Form
    {
        private Queue<Client> queue = new Queue<Client>();
        private List<Client> clientsHistory = new List<Client>();
        private List<double> waitTimes = new List<double>();
        private Client nextClient;
        private Client clientOnService;

        private double lambda;
        private double mu;

        private int queueLength;
        private double maxTime;
        private int maxClients;
        private double totalTime;
        private int totalClients;
        private double nextArrival;
        private double nextServiceEnd;
        private double currTime;
        private double tau;
        private double denialCounter;

        private bool logAll = false;
        private bool queueInf = false;
        private string duration = "time";
        private bool handlerFree;

        private bool updating = false;

        private MCG mcg;

        private int currState;
        private List<double> timeInState = new List<double>();

        public MainForm()
        {
            InitializeComponent();
            RestartModel();
        }

        private void RestartModel()
        {
            queue.Clear();
            clientsHistory.Clear();
            lambda = 0;
            mu = 0;
            queueLength = 0;
            maxTime = 0;
            maxClients = 0;
            totalTime = 0;
            totalClients = 0;
            nextArrival = -1;
            nextServiceEnd = double.MaxValue;
            currTime = 0;
            tau = 0;
            handlerFree = true;
            currState = 0;
            timeInState.Clear();
            waitTimes.Clear();
            denialCounter = 0;
        }

        private void checkBoxDurationTime_CheckedChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            if (checkBoxDurationTime.Checked)
            {
                checkBoxDurationAmount.Checked = false;
                numericUpDownDurationTime.Enabled = true;
                numericUpDownDurationAmount.Enabled = false;
                duration = "time";
            }
            else
            {
                if (!checkBoxDurationAmount.Checked)
                {
                    checkBoxDurationTime.Checked = true;
                }
            }
            updating = false;
        }

        private void checkBoxDurationAmount_CheckedChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            if (checkBoxDurationAmount.Checked)
            {
                checkBoxDurationTime.Checked = false;
                numericUpDownDurationAmount.Enabled = true;
                numericUpDownDurationTime.Enabled = false;
                duration = "amount";
            }
            else
            {
                if (!checkBoxDurationTime.Checked)
                {
                    checkBoxDurationAmount.Checked = true;
                }
            }
            updating = false;
        }

        private void checkBoxQueueInf_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxQueueInf.Checked)
            {
                numericUpDownQueueLength.Enabled = false;
                queueInf = true;
            }
            else
            {
                numericUpDownQueueLength.Enabled = true;
                queueInf = false;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            RestartModel();
            buttonStart.Enabled = false;
            if (queueInf) queueLength = -1;
            else queueLength = (int)numericUpDownQueueLength.Value;
            if (duration == "time") maxTime = (double)numericUpDownDurationTime.Value;
            else if (duration == "amount") maxClients = (int)numericUpDownDurationAmount.Value;
            lambda = (double)numericUpDownLambda.Value;
            mu = (double)numericUpDownMu.Value;
            ulong seed = (ulong)numericUpDownSeed.Value;
            mcg = new MCG(seed);
            for (int i = 0; i < 100; i++) mcg.Next();
            textBoxLog.Clear();
            textBoxLog.AppendText($"Параметры:\r\n");
            textBoxLog.AppendText($"Лямбда: {lambda},\r\n");
            textBoxLog.AppendText($"Мю: {mu},\r\n");
            if (queueInf) textBoxLog.AppendText($"Очередь: Бесконечная,\r\n");
            else textBoxLog.AppendText($"Очередь: {queueLength},\r\n"); 
            if (duration == "time") textBoxLog.AppendText($"Длительность: {maxTime} ед.,\r\n");
            else textBoxLog.AppendText($"Длительность: до обработки {maxClients} запросов,\r\n");
            textBoxLog.AppendText($"Seed: {seed}.\r\n");
            if (logAll) textBoxLog.AppendText($"Начало моделирования.\r\n");
            nextClient = getNextClient();
            nextArrival = nextClient.getArrivalTime();
            timerSimulation.Start();
        }

        private Client getNextClient()
        {
            Client client;
            double alpha = mcg.Next();
            tau = (-Math.Log(alpha)) / lambda;
            client = new Client(currTime + tau);
            return client;
        }

        private double getNextServiceEnd()
        {
            double alpha = mcg.Next();
            return currTime + (-Math.Log(1 - alpha)) / mu;
        }

        private void timerSimulation_Tick(object sender, EventArgs e)
        {
            if ((duration == "time" && currTime >= maxTime) || (duration == "amount" && totalClients >= maxClients))
            {
                timerSimulation.Stop();
                buttonStart.Enabled = true;
                if (logAll) textBoxLog.AppendText($"Конец моделирования.\r\n");
                DrawDistribution();
                DrawQueueWaiting();
                printSummary();
                return;
            }
            ProcessDayEvents();
        }

        private void ProcessDayEvents()
        {
            DrawDistribution();
            DrawQueueWaiting();
            double timeLeft = 1;
            string closest = "arrival";
            double closestDiff = 0;
            if (nextArrival < nextServiceEnd)
            {
                closestDiff = nextArrival - currTime;
                closest = "arrival";
            }
            else
            {
                closestDiff = nextServiceEnd - currTime;
                closest = "service";
            }
            while (true)
            {
                if ((currState + 1) > timeInState.Count())
                {
                    for (int i = 0; i < ((currState + 1) - currState); i++) timeInState.Add(0);
                }
                if (duration == "time" && currTime + closestDiff >= maxTime)
                {
                    timeInState[currState] += maxTime - currTime;
                    currTime = maxTime;
                    return;
                }
                else if (closestDiff < timeLeft)
                {

                    currTime += closestDiff;
                    timeLeft -= closestDiff;
                    if (closest == "arrival")
                    {
                        timeInState[currState] += closestDiff;
                        currState++;
                        if (logAll) textBoxLog.AppendText($"{TransformTime(currTime)} Прибыла заявка.\r\n");
                        if (handlerFree)
                        {
                            handlerFree = false;
                            nextServiceEnd = getNextServiceEnd();
                            clientOnService = nextClient;
                            clientOnService.setServiceStart(currTime);
                            if (logAll) textBoxLog.AppendText($"{TransformTime(currTime)} Начата обработка заявки.\r\n");
                        }
                        else
                        {
                            if (queue.Count() >= queueLength && queueLength != -1)
                            {
                                if (logAll) textBoxLog.AppendText($"{TransformTime(currTime)} Заявка отклонена.\r\n");
                                currState--;
                                denialCounter++;
                            }
                            else
                            {
                                queue.Enqueue(nextClient);
                                if (logAll) textBoxLog.AppendText($"{TransformTime(currTime)} Заявка помещена в очередь.\r\n");
                                if (logAll) textBoxLog.AppendText($"{TransformTime(currTime)} Длина очереди - {queue.Count()}.\r\n");
                            }
                        }
                        nextClient = getNextClient();
                        nextArrival = nextClient.getArrivalTime();
                    }
                    else if (closest == "service")
                    {
                        timeInState[currState] += closestDiff;
                        currState--;
                        if (logAll) textBoxLog.AppendText($"{TransformTime(currTime)} Заявка обработана.\r\n");
                        clientOnService.setServiceEnd(currTime);
                        waitTimes.Add(clientOnService.getWaitingTime());
                        clientsHistory.Add(clientOnService);
                        totalClients++;
                        if (queue.Count() > 0)
                        {
                            clientOnService = queue.Dequeue();
                            clientOnService.setServiceStart(currTime);
                            nextServiceEnd = getNextServiceEnd();
                            if (logAll) textBoxLog.AppendText($"{TransformTime(currTime)} Начата обработка заявки из очереди.\r\n");
                            if (logAll) textBoxLog.AppendText($"{TransformTime(currTime)} Длина очереди - {queue.Count()}.\r\n");
                        }
                        else
                        {
                            handlerFree = true;
                            nextServiceEnd = double.MaxValue;
                        }
                    }
                    if (nextArrival < nextServiceEnd)
                    {
                        closestDiff = nextArrival - currTime;
                        closest = "arrival";
                    }
                    else
                    {
                        closestDiff = nextServiceEnd - currTime;
                        closest = "service";
                    }
                }
                else if (closestDiff >= timeLeft)
                {
                    timeInState[currState] += timeLeft;
                    currTime += timeLeft;
                    if (logAll) textBoxLog.AppendText($"День - {(int)Math.Floor(currTime)}\r\n");
                    return;
                }
            }
        }

        private void DrawDistribution()
        {
            chartDistribution.Series.Clear();
            chartDistribution.ChartAreas[0].AxisX.Title = "Число заявок в системе (k)";
            chartDistribution.ChartAreas[0].AxisY.Title = "Вероятность P(k)";
            chartDistribution.ChartAreas[0].AxisX.Minimum = 0;
            chartDistribution.ChartAreas[0].AxisY.Minimum = 0;

            totalTime = timeInState.Sum();
            if (totalTime == 0) return;

            Series histSeries = new Series("Гистограмма")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.SteelBlue
            };
            Series polySeries = new Series("Полигон частот")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Red,
                BorderWidth = 2
            };
            polySeries.Points.AddXY(-1, 0);
            for (int k = 0; k < timeInState.Count(); k++)
            {
                double prob = timeInState[k] / totalTime;
                histSeries.Points.AddXY(k, prob);
                polySeries.Points.AddXY(k, prob);
            }
            polySeries.Points.AddXY(timeInState.Count(), 0);
            chartDistribution.Series.Add(histSeries);
            chartDistribution.Series.Add(polySeries);

            double rho = lambda / mu;
            Series theory = new Series("Теоретическая")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Green,
                BorderWidth = 2,
                BorderDashStyle = ChartDashStyle.Dash
            };
            if (queueInf)
            {
                if (rho < 1)
                {
                    for (int k = 0; k < timeInState.Count(); k++)
                    {
                        double p = (1 - rho) * Math.Pow(rho, k);
                        theory.Points.AddXY(k, p);
                    }
                    chartDistribution.Series.Add(theory);
                }
            }
            else
            {
                int N = queueLength + 1;
                if (Math.Abs(rho - 1.0) < 1e-9)
                {
                    for (int k = 0; k <= N && k < timeInState.Count(); k++)
                    {
                        theory.Points.AddXY(k, 1.0 / (N + 1));
                    }
                }
                else
                {
                    double denom = 1 - Math.Pow(rho, N + 1);
                    double p0 = (1 - rho) / denom;
                    for (int k = 0; k <= N && k < timeInState.Count(); k++)
                    {
                        double p = p0 * Math.Pow(rho, k);
                        theory.Points.AddXY(k, p);
                    }
                }
                chartDistribution.Series.Add(theory);
            }
        }

        private void DrawQueueWaiting()
        {
            chartQueue.Series.Clear();
            chartQueue.ChartAreas[0].AxisX.Title = "Время ожидания в очереди";
            chartQueue.ChartAreas[0].AxisY.Title = "Плотность вероятности";
            chartQueue.ChartAreas[0].AxisX.Minimum = 0;
            chartQueue.ChartAreas[0].AxisY.Minimum = 0;
            if (waitTimes.Count == 0) return;
            int bins = (int)Math.Ceiling(Math.Sqrt(waitTimes.Count));
            double min = waitTimes.Min();
            double max = waitTimes.Max();
            if (Math.Abs(max - min) < 1e-9)
            {
                max = min + 1.0;
                bins = 1;
            }
            double width = (max - min) / bins;
            int[] counts = new int[bins];
            foreach (double t in waitTimes)
            {
                int idx = (int)Math.Floor((t - min) / width);
                if (idx >= bins) idx = bins - 1;
                counts[idx]++;
            }
            Series histSeries = new Series("Гистограмма")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.SteelBlue
            };
            Series polySeries = new Series("Полигон")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.DarkRed,
                BorderWidth = 2
            };
            for (int i = 0; i < bins; i++)
            {
                double center = min + (i + 0.5) * width;
                double density = counts[i] / (double)waitTimes.Count / width;
                histSeries.Points.AddXY(center, density);
                polySeries.Points.AddXY(center, density);
            }
            chartQueue.Series.Add(histSeries);
            chartQueue.Series.Add(polySeries);
        }

        private string TransformTime(double time)
        {
            int day = (int)time;
            double hours = (time - day) * 24;
            int minutes = (int)((hours - (int)hours) * 60);
            return $"[День {day}. {(int)hours:D2}:{minutes:D2}]";
        }

        private void checkBoxLogAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLogAll.Checked) logAll = true;
            else logAll = false;
        }

        private void printSummary()
        {
            textBoxLog.AppendText($"Итог моделирования:\r\n");
            double totalTime = timeInState.Sum();
            double rho = lambda / mu;
            int N = queueLength + 1;
            double empRho = 1 - (timeInState[0] / totalTime);
            textBoxLog.AppendText($"Коэффициент загрузки:\r\n");
            textBoxLog.AppendText($"Эмпирически: {empRho},\r\n");
            if (!queueInf)
            {
                double p0_theory = (Math.Abs(rho - 1) < 1e-9) ? 1.0 / (N + 1) : (1 - rho) / (1 - Math.Pow(rho, N + 1));
                textBoxLog.AppendText($"Теоретически: {1 - p0_theory}.\r\n");
            }
            else textBoxLog.AppendText($"Теоретически: {rho}.\r\n");
            double avgClientsAmount = 0;
            for (int k = 0; k < timeInState.Count(); k++)
            {
                avgClientsAmount += k * (timeInState[k] / totalTime);
            }
            textBoxLog.AppendText($"Среднее число заявок в системе:\r\n");
            textBoxLog.AppendText($"Эмпирически: {avgClientsAmount},\r\n");
            if (queueInf && rho < 1) textBoxLog.AppendText($"Теоретически: {rho / (1 - rho)}.\r\n");
            else if (!queueInf) textBoxLog.AppendText($"Теоретически: {(rho / (1 - rho)) - (((N + 1) * Math.Pow(rho, N + 1)) / (1 - Math.Pow(rho, N + 1)))}.\r\n");
            double avgQueueLength = 0;
            textBoxLog.AppendText($"Средняя длина очереди:\r\n");
            for (int k = 1; k < timeInState.Count(); k++)
            {
                avgQueueLength += (k - 1) * (timeInState[k] / totalTime);
            }
            textBoxLog.AppendText($"Эмпирически: {avgQueueLength},\r\n");
            if (queueInf && rho < 1) textBoxLog.AppendText($"Теоретически: {(rho * rho) / (1 - rho)}.\r\n");
            else if (!queueInf) textBoxLog.AppendText($"Теоретически: {((rho / (1 - rho)) - (((N + 1) * Math.Pow(rho, N + 1)) / (1 - Math.Pow(rho, N + 1)))) - (1 - ((1 - rho) / (1 - Math.Pow(rho, N + 1))))}.\r\n");
            double avgQueueWait = waitTimes.Sum() / clientsHistory.Count();
            textBoxLog.AppendText($"Среднее время ожидания в очереди:\r\n");
            textBoxLog.AppendText($"Эмпирически: {avgQueueWait},\r\n");
            if (queueInf && rho < 1) textBoxLog.AppendText($"Теоретически: {rho / (mu - lambda)}.\r\n");
            double avgModelTime = 0;
            for (int i = 0; i < clientsHistory.Count(); i++)
            {
                avgModelTime += clientsHistory[i].getServiceTime() + clientsHistory[i].getWaitingTime();
            }
            avgModelTime /= clientsHistory.Count();
            textBoxLog.AppendText($"Среднее время пребывания в системе:\r\n");
            textBoxLog.AppendText($"Эмпирически: {avgModelTime},\r\n");
            if (queueInf && rho < 1) textBoxLog.AppendText($"Теоретически: {1 / (mu - lambda)}.\r\n");
            double probZeroWait = waitTimes.Count(t => t < 1e-9) / (double)waitTimes.Count;
            textBoxLog.AppendText($"Вероятность нулевого ожидания:\r\n");
            textBoxLog.AppendText($"Эмпирически: {probZeroWait},\r\n");
            if (queueInf && rho < 1) textBoxLog.AppendText($"Теоретически: {1 - (lambda / mu)}.\r\n");
            else if (!queueInf && rho != 1) textBoxLog.AppendText($"Теоретически: {(1 - rho) / (1 - Math.Pow(rho, N + 1))}.\r\n");
            else if (!queueInf && rho == 1) textBoxLog.AppendText($"Теоретически: {1 / (N + 1)}.\r\n");
            textBoxLog.AppendText($"Обработанных заявок: {clientsHistory.Count()}.\r\n");
            if (!queueInf)
            {
                textBoxLog.AppendText($"Отказов: {denialCounter}.\r\n");
                textBoxLog.AppendText($"Вероятность отказа:\r\n");
                textBoxLog.AppendText($"Эмпирически: {denialCounter / (clientsHistory.Count() + denialCounter)},\r\n");
                if (rho == 1) textBoxLog.AppendText($"Теоретически: {1 / (N + 1)},\r\n");
                else textBoxLog.AppendText($"Теоретически: {((1 - rho) * Math.Pow(rho, N)) / (1 - Math.Pow(rho, N + 1))},\r\n");
            }
            textBoxLog.AppendText($"Время моделирования: {currTime}.\r\n");
        }
    }

    public class Client
    {
        private double arrivalTime;
        private double serviceStart;
        private double serviceEnd;
        private double serviceTime;
        private double waitingTime;

        public Client(double arrival)
        {
            arrivalTime = arrival;
            serviceStart = -1;
            serviceEnd = -1;
        }

        public double getArrivalTime()
        {
            return arrivalTime;
        }

        public double getServiceStart()
        {
            return serviceStart;
        }

        public double getServiceEnd()
        {
            return serviceEnd;
        }

        public double getServiceTime()
        {
            return serviceTime;
        }

        public double getWaitingTime()
        {
            return waitingTime;
        }

        public void setServiceStart(double currTime)
        {
            serviceStart = currTime;
            waitingTime = serviceStart - arrivalTime;
        }

        public void setServiceEnd(double currTime)
        {
            serviceEnd = currTime;
            serviceTime = serviceEnd - serviceStart;
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