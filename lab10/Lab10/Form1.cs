using System.Diagnostics.Eventing.Reader;
using System.Drawing.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab10
{
    public partial class MainForm : Form
    {
        private Queue<Client> queue = new Queue<Client>();
        private List<Client> clientsHistory = new List<Client>();
        private List<double> waitTimes = new List<double>();
        private Client nextClient;
        private Client clientOnService;
        private List<Operator> operators = new List<Operator>();
        private List<double> timeInStateBusy = new List<double>();

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
        private double handlersAmount;
        private int nextOperator;

        private bool logAll = false;
        private bool queueInf = false;
        private string duration = "time";

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
            currState = 0;
            timeInState.Clear();
            waitTimes.Clear();
            denialCounter = 0;
            operators.Clear();
            handlersAmount = 0;
            timeInStateBusy.Clear();
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
            handlersAmount = (int)numericUpDownHandlersAmount.Value;
            for (int i = 0; i < handlersAmount; i++)
            {
                operators.Add(new Operator(i));
            }
            textBoxLog.Clear();
            textBoxLog.AppendText($"Параметры:\r\n");
            textBoxLog.AppendText($"Лямбда: {lambda},\r\n");
            textBoxLog.AppendText($"Мю: {mu},\r\n");
            if (queueInf) textBoxLog.AppendText($"Очередь: Бесконечная,\r\n");
            else textBoxLog.AppendText($"Очередь: {queueLength},\r\n"); 
            if (duration == "time") textBoxLog.AppendText($"Длительность: {maxTime} ед.,\r\n");
            else textBoxLog.AppendText($"Длительность: до обработки {maxClients} запросов,\r\n");
            textBoxLog.AppendText($"Обработчики: {handlersAmount}.\r\n");
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
                DrawBusyDistribution();
                printSummary();
                return;
            }
            ProcessDayEvents();
        }

        private void ProcessDayEvents()
        {
            DrawDistribution();
            DrawQueueWaiting();
            DrawBusyDistribution();
            double timeLeft = 1;
            while (true)
            {
                double nextServiceEnd = double.MaxValue;
                int nextOperator = -1;
                for (int i = 0; i < handlersAmount; i++)
                {
                    double et = operators[i].getServiceEndTime();
                    if (et < nextServiceEnd)
                    {
                        nextServiceEnd = et;
                        nextOperator = i;
                    }
                }
                double nextEventTime = Math.Min(nextArrival, nextServiceEnd);
                double delta = nextEventTime - currTime;
                int currentState = GetCurrentState();
                while (timeInState.Count <= currentState) timeInState.Add(0);
                int busyCount = GetBusyCount();
                while (timeInStateBusy.Count <= busyCount) timeInStateBusy.Add(0);
                if (duration == "time" && currTime + delta >= maxTime)
                {
                    timeInState[currentState] += maxTime - currTime;
                    timeInStateBusy[busyCount] += maxTime - currTime;
                    currTime = maxTime;
                    return;
                }
                if (duration == "amount" && totalClients >= maxClients) return;
                if (delta < timeLeft)
                {
                    timeInState[currentState] += delta;
                    timeInStateBusy[busyCount] += delta;
                    currTime += delta;
                    timeLeft -= delta;
                    if (Math.Abs(currTime - nextArrival) < 1e-12)
                    {
                        if (logAll) textBoxLog.AppendText($"{TransformTime(currTime)} Прибыла заявка.\r\n");
                        int freeOp = -1;
                        for (int i = 0; i < handlersAmount; i++) if (operators[i].getStatus()) { freeOp = i; break; }
                        if (freeOp != -1)
                        {
                            operators[freeOp].StartService(nextClient, currTime, getNextServiceEnd());
                            if (logAll) textBoxLog.AppendText($"{TransformTime(currTime)} Оператор {freeOp} начал обработку.\r\n");
                        }
                        else
                        {
                            if (queue.Count >= queueLength && queueLength != -1)
                            {
                                if (logAll) textBoxLog.AppendText($"{TransformTime(currTime)} Заявка отклонена.\r\n");
                                denialCounter++;
                            }
                            else
                            {
                                queue.Enqueue(nextClient);
                                if (logAll) textBoxLog.AppendText($"{TransformTime(currTime)} Заявка в очередь. Длина очереди = {queue.Count}\r\n");
                            }
                        }
                        nextClient = getNextClient();
                        nextArrival = nextClient.getArrivalTime();
                    }
                    else
                    {
                        if (logAll) textBoxLog.AppendText($"{TransformTime(currTime)} Оператор {nextOperator} завершил обслуживание.\r\n");
                        Client finished = operators[nextOperator].FinishService();
                        waitTimes.Add(finished.getWaitingTime());
                        clientsHistory.Add(finished);
                        totalClients++;
                        if (queue.Count > 0)
                        {
                            Client fromQueue = queue.Dequeue();
                            operators[nextOperator].StartService(fromQueue, currTime, getNextServiceEnd());
                            if (logAll) textBoxLog.AppendText($"{TransformTime(currTime)} Оператор {nextOperator} начал обслуживание из очереди. Остаток очереди = {queue.Count}\r\n");
                        }
                    }
                }
                else
                {
                    timeInState[currentState] += timeLeft;
                    timeInStateBusy[busyCount] += timeLeft;
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

            double totalTime = timeInState.Sum();
            if (totalTime == 0) return;

            Series hist = new Series("Гистограмма") 
            {
                ChartType = SeriesChartType.Column, 
                Color = Color.SteelBlue 
            };
            Series poly = new Series("Полигон частот") 
            { 
                ChartType = SeriesChartType.Line, 
                Color = Color.Red, 
                BorderWidth = 2
            
            };
            for (int k = 0; k < timeInState.Count; k++)
            {
                double prob = timeInState[k] / totalTime;
                hist.Points.AddXY(k, prob);
                poly.Points.AddXY(k, prob);
            }
            chartDistribution.Series.Add(hist);
            chartDistribution.Series.Add(poly);


            int c = (int)handlersAmount;
            double rho_c = lambda / (c * mu);
            double[] theoryProbs = null;

            if (queueInf)
            {
                if (rho_c < 1.0)
                {
                    theoryProbs = new double[timeInState.Count];
                    double sum = 0;
                    for (int k = 0; k < c; k++)
                        sum += Math.Pow(c * rho_c, k) / Factorial(k);
                    sum += Math.Pow(c * rho_c, c) / Factorial(c) * (1.0 / (1.0 - rho_c));
                    double P0 = 1.0 / sum;
                    for (int k = 0; k < theoryProbs.Length; k++)
                    {
                        if (k < c)
                            theoryProbs[k] = P0 * Math.Pow(c * rho_c, k) / Factorial(k);
                        else
                            theoryProbs[k] = P0 * Math.Pow(c * rho_c, k) / (Factorial(c) * Math.Pow(c, k - c));
                    }
                }
            }
            else 
            {
                int N = c + queueLength;
                if (N < timeInState.Count)
                    theoryProbs = new double[N + 1];
                else
                    theoryProbs = new double[timeInState.Count];

                if (Math.Abs(rho_c - 1.0) < 1e-9)
                {
                    return;
                }
                else
                {
                    double sum = 0;
                    for (int k = 0; k <= c; k++)
                        sum += Math.Pow(c * rho_c, k) / Factorial(k);
                    for (int k = c + 1; k <= N; k++)
                        sum += Math.Pow(c * rho_c, k) / (Factorial(c) * Math.Pow(c, k - c));
                    double P0 = 1.0 / sum;
                    for (int k = 0; k < theoryProbs.Length; k++)
                    {
                        if (k <= c)
                            theoryProbs[k] = P0 * Math.Pow(c * rho_c, k) / Factorial(k);
                        else
                            theoryProbs[k] = P0 * Math.Pow(c * rho_c, k) / (Factorial(c) * Math.Pow(c, k - c));
                    }
                }
            }

            if (theoryProbs != null)
            {
                Series theory = new Series("Теоретическая")
                {
                    ChartType = SeriesChartType.Line,
                    Color = Color.Green,
                    BorderWidth = 2,
                    BorderDashStyle = ChartDashStyle.Dash
                };
                for (int k = 0; k < theoryProbs.Length; k++)
                    theory.Points.AddXY(k, theoryProbs[k]);
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

        private void DrawBusyDistribution()
        {
            chartOperators.Series.Clear();
            chartOperators.ChartAreas[0].AxisX.Title = "Число занятых операторов (k)";
            chartOperators.ChartAreas[0].AxisY.Title = "Вероятность P(k)";
            chartOperators.ChartAreas[0].AxisX.Minimum = 0;
            chartOperators.ChartAreas[0].AxisY.Minimum = 0;
            double totalTime = timeInStateBusy.Sum();
            if (totalTime == 0) return;

            Series histSeries = new Series("Гистограмма")
            { 
                ChartType = SeriesChartType.Column,
                Color = Color.SteelBlue
            };
            Series polySeries = new Series("Полигон")
            { 
                ChartType = SeriesChartType.Line,
                Color = Color.Red,
                BorderWidth = 2
            };
            for (int k = 0; k < timeInStateBusy.Count(); k++)
            { 
                double prob = timeInStateBusy[k] / totalTime;
                histSeries.Points.AddXY(k, prob);
                polySeries.Points.AddXY(k, prob);
            }
            chartOperators.Series.Add(histSeries);
            chartOperators.Series.Add(polySeries);
            int c = (int)handlersAmount;
            double rho_c = lambda / (c * mu);
            bool canDrawTheory = false;
            double[] theoryBusy = null;
            if (queueInf && rho_c < 1.0)
            {
                canDrawTheory = true;
                theoryBusy = new double[c + 1];
                double sum = 0;
                for (int k = 0; k < c; k++)
                    sum += Math.Pow(c * rho_c, k) / Factorial(k);
                sum += Math.Pow(c * rho_c, c) / Factorial(c) * (1.0 / (1.0 - rho_c));
                double P0 = 1.0 / sum;
                double sumBusy = 0;
                for (int k = 0; k < c; k++)
                {
                    theoryBusy[k] = P0 * Math.Pow(c * rho_c, k) / Factorial(k);
                    sumBusy += theoryBusy[k];
                }
                theoryBusy[c] = 1 - sumBusy;
            }
            else if (!queueInf)
            {
                int N = c + queueLength;
                if (Math.Abs(rho_c - 1.0) > 1e-9)
                {
                    canDrawTheory = true;
                    theoryBusy = new double[c + 1];
                    double sum = 0;
                    for (int k = 0; k <= c; k++)
                        sum += Math.Pow(c * rho_c, k) / Factorial(k);
                    for (int k = c + 1; k <= N; k++)
                        sum += Math.Pow(c * rho_c, k) / (Factorial(c) * Math.Pow(c, k - c));
                    double P0 = 1.0 / sum;
                    double sumBusy = 0;
                    for (int k = 0; k < c; k++)
                    {
                        theoryBusy[k] = P0 * Math.Pow(c * rho_c, k) / Factorial(k);
                        sumBusy += theoryBusy[k];
                    }
                    theoryBusy[c] = 1 - sumBusy;
                }
            }
            if (canDrawTheory && theoryBusy != null)
            {
                Series theory = new Series("Теоретическая")
                {
                    ChartType = SeriesChartType.Line,
                    Color = Color.Green,
                    BorderWidth = 2,
                    BorderDashStyle = ChartDashStyle.Dash
                };
                for (int k = 0; k < theoryBusy.Length; k++)
                    theory.Points.AddXY(k, theoryBusy[k]);
                chartOperators.Series.Add(theory);
            }
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
            double totalTime = timeInState.Sum();
            if (totalTime == 0) return;

            int c = (int)handlersAmount;
            textBoxLog.AppendText($"Итог моделирования:\r\n");
            double L = 0;
            for (int k = 0; k < timeInState.Count; k++)
                L += k * (timeInState[k] / totalTime);
            textBoxLog.AppendText($"\nСреднее число заявок в системе L (эмп.) = {L}\r\n");
            double avgBusy = 0;
            for (int k = 0; k < timeInState.Count; k++)
                avgBusy += Math.Min(k, c) * (timeInState[k] / totalTime);
            double load = avgBusy / c;
            textBoxLog.AppendText($"Среднее число занятых операторов = {avgBusy}\r\n");
            textBoxLog.AppendText($"Загрузка каналов (эмп.) = {load}\r\n");
            double rho_c_teor = lambda / (c * mu);
            textBoxLog.AppendText($"Теоретическая загрузка ро_теор = {rho_c_teor}\r\n");

            double Lq = 0;
            for (int k = c + 1; k < timeInState.Count; k++)
                Lq += (k - c) * (timeInState[k] / totalTime);
            textBoxLog.AppendText($"Средняя длина очереди (эмп.) = {Lq:F4}\r\n");
            double avgWait = waitTimes.Count > 0 ? waitTimes.Average() : 0;
            textBoxLog.AppendText($"Среднее время ожидания в очереди (эмп.) = {avgWait}\r\n");
            double avgStay = 0;
            if (clientsHistory.Count > 0)
                avgStay = clientsHistory.Average(c => c.getServiceTime() + c.getWaitingTime());
            textBoxLog.AppendText($"Среднее время пребывания в системе (эмп.) = {avgStay}\r\n");
            double zeroWaitProb = waitTimes.Count > 0 ? waitTimes.Count(t => t < 1e-9) / (double)waitTimes.Count : 0;
            textBoxLog.AppendText($"Вероятность нулевого ожидания (среди обслуженных) = {zeroWaitProb}\r\n");
            int totalArrived = totalClients + (int)denialCounter;
            textBoxLog.AppendText($"Обслужено заявок: {totalClients}, отклонено: {denialCounter}\r\n");
            if (!queueInf)
                textBoxLog.AppendText($"Вероятность отказа = {(totalArrived > 0 ? denialCounter / totalArrived : 0):F4}\r\n");
            if (c == 1)
            {
                double rho = lambda / mu;
                textBoxLog.AppendText($"\n--- Сравнение с теорией для M/M/1 ---\r\n");
                if (queueInf && rho < 1)
                {
                    textBoxLog.AppendText($"Среднее число заявок (теор.) = {rho / (1 - rho):F4}\r\n");
                    textBoxLog.AppendText($"Средняя длина очереди (теор.) = {rho * rho / (1 - rho):F4}\r\n");
                    textBoxLog.AppendText($"Среднее время ожидания (теор.) = {rho / (mu - lambda):F4}\r\n");
                    textBoxLog.AppendText($"Среднее время пребывания (теор.) = {1 / (mu - lambda):F4}\r\n");
                    textBoxLog.AppendText($"Вероятность нулевого ожидания (теор.) = {1 - rho:F4}\r\n");
                }
                else if (!queueInf)
                {
                    int N = queueLength + 1;
                    if (Math.Abs(rho - 1.0) < 1e-9)
                    {
                        textBoxLog.AppendText($"Среднее число заявок (теор.) = {N / 2.0:F4}\r\n");
                        textBoxLog.AppendText($"Вероятность отказа (теор.) = {1.0 / (N + 1):F4}\r\n");
                    }
                    else
                    {
                        double p0 = (1 - rho) / (1 - Math.Pow(rho, N + 1));
                        double L_theory = rho / (1 - rho) - (N + 1) * Math.Pow(rho, N + 1) / (1 - Math.Pow(rho, N + 1));
                        double Lq_theory = L_theory - (1 - p0);
                        double p_reject = ((1 - rho) * Math.Pow(rho, N)) / (1 - Math.Pow(rho, N + 1));
                        textBoxLog.AppendText($"Среднее число заявок (теор.) = {L_theory:F4}\r\n");
                        textBoxLog.AppendText($"Средняя длина очереди (теор.) = {Lq_theory:F4}\r\n");
                        textBoxLog.AppendText($"Вероятность отказа (теор.) = {p_reject:F4}\r\n");
                    }
                }
                else if (rho >= 1)
                {
                    textBoxLog.AppendText("Система нестационарна (ρ≥1), теоретические средние бесконечны.\r\n");
                }
            }
        }

        private int GetCurrentState()
        {
            int busy = 0;
            for (int i = 0; i < handlersAmount; i++) if (!operators[i].getStatus()) busy++;
            return busy + queue.Count();
        }

        private int GetBusyCount()
        {
            int busy = 0;
            for (int i = 0; i < handlersAmount; i++) if (!operators[i].getStatus()) busy++;
            return busy;
        }

        private double Factorial(int n)
        {
            double result = 1.0;
            for (int i = 2; i <= n; i++) result *= i;
            return result;
        }
    }

    public class Operator
    {
        private int Id;
        public bool isFree;
        public double serviceEndTime;
        private Client currentClient;


        public Operator(int id)
        {
            Id = id;
            serviceEndTime = double.MaxValue;
            isFree = true;
            currentClient = null;
        }

        public void StartService(Client client, double startTime, double nextServiceEndTime)
        {
            currentClient = client;
            serviceEndTime = nextServiceEndTime;
            client.setServiceStart(startTime);
            isFree = false;
        }

        public bool getStatus()
        {
            return isFree;
        }

        public double getServiceEndTime()
        { 
            return serviceEndTime;
        }

        public Client FinishService()
        {
            Client lastClient = currentClient;
            if (currentClient != null) currentClient.setServiceEnd(serviceEndTime);
            currentClient = null;
            serviceEndTime = double.MaxValue;
            isFree = true;
            return lastClient;
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