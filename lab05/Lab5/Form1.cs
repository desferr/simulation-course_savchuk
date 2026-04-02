using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        public static BindingList<ProbabilityMessage> customList = new BindingList<ProbabilityMessage>();

        public Form1()
        {
            InitializeComponent();
            dataGridViewCustom.AutoGenerateColumns = false; dataGridViewCustom.DataSource = customList;
            dataGridViewCustom.CellValidating += CellValidating;
            dataGridViewCustom.CellMouseDown += CellMouseDown;
        }

        private void buttonAskYesNo_Click(object sender, EventArgs e)
        {
            List<(double, string)> list = new List<(double, string)>();
            MessageFormer.FormYesNo(list);
            if (!MCG.CheckNorm(list))
            {
                MessageBox.Show("Вероятности не нормированы!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string text = textBoxYesNo.Text;
            ulong seed = 1;
            if (checkBoxTextToSeedYesNo.Checked)
            {
                seed = MCG.TextToSign(text);
            }
            else
            {
                seed = (ulong)System.Diagnostics.Stopwatch.GetTimestamp() % MCG.getM();
                if (seed == 0) seed = 1;
            }
            MCG mcg = new MCG(seed);
            for (int i = 0; i < 100; i++) mcg.Next();
            double alpha = mcg.Next();
            foreach (var (prob, message) in list)
            {
                alpha -= prob;
                if (alpha <= 0)
                {
                    labelYesNo.Text = message;
                    return;
                }
            }
            labelYesNo.Text = list.Last().Item2;
        }

        private void buttonAskEightBall_Click(object sender, EventArgs e)
        {
            List<(double, string)> list = new List<(double, string)>();
            MessageFormer.FormEightBall(list);
            if (!MCG.CheckNorm(list))
            {
                MessageBox.Show("Вероятности не нормированы!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string text = textBoxEightBall.Text;
            ulong seed = 1;
            if (checkBoxTextToSeedEightBall.Checked)
            {
                seed = MCG.TextToSign(text);
            }
            else
            {
                seed = (ulong)System.Diagnostics.Stopwatch.GetTimestamp() % MCG.getM();
                if (seed == 0) seed = 1;
            }
            MCG mcg = new MCG(seed);
            for (int i = 0; i < 100; i++) mcg.Next();
            double alpha = mcg.Next();
            foreach (var (prob, message) in list)
            {
                alpha -= prob;
                if (alpha <= 0)
                {
                    labelEightBall.Text = message;
                    return;
                }
            }
            labelEightBall.Text = list.Last().Item2;
        }

        private void buttonAskCustom_Click(object sender, EventArgs e)
        {
            if (customList.Count() == 0)
            {
                MessageFormer.FormEmptyCustom(customList);
            }
            if (!MCG.CheckNormProbMessage(customList))
            {
                MessageBox.Show("Вероятности не нормированы!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string text = textBoxCustom.Text;
            ulong seed = 1;
            if (checkBoxTextToSeedCustom.Checked)
            {
                seed = MCG.TextToSign(text);
            }
            else
            {
                seed = (ulong)System.Diagnostics.Stopwatch.GetTimestamp() % MCG.getM();
                if (seed == 0) seed = 1;
            }
            MCG mcg = new MCG(seed);
            for (int i = 0; i < 100; i++) mcg.Next();
            double alpha = mcg.Next();
            foreach (ProbabilityMessage probMessage in customList)
            {
                alpha -= probMessage.Probability;
                if (alpha <= 0)
                {
                    labelCustom.Text = probMessage.Message;
                    return;
                }
            }
            labelCustom.Text = customList.Last().Message;
        }

        private void CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridViewCustom.Columns[e.ColumnIndex].Name == "Probability")
            {
                if (e.FormattedValue == null || string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    dataGridViewCustom.Rows[e.RowIndex].ErrorText = "Вероятность не может быть пустой!";
                    e.Cancel = true;
                    return;
                }
                if (!double.TryParse(e.FormattedValue.ToString(), out double prob))
                {
                    dataGridViewCustom.Rows[e.RowIndex].ErrorText = "Введите число.";
                    e.Cancel = true;
                    return;
                }
                if (prob < 0 || prob > 1)
                {
                    dataGridViewCustom.Rows[e.RowIndex].ErrorText = "Вероятность должна быть в диапазоне от 0 до 1!";
                    e.Cancel = true;
                    return;
                }
                dataGridViewCustom.Rows[e.RowIndex].ErrorText = "";
            }
        }

        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustom.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridViewCustom.SelectedRows[0].Index;

                if (!dataGridViewCustom.Rows[rowIndex].IsNewRow)
                {
                    dataGridViewCustom.CellValidating -= CellValidating;

                    try
                    {
                        customList.RemoveAt(rowIndex);
                    }
                    finally
                    {
                        dataGridViewCustom.CellValidating += CellValidating;
                    }
                }
            }
            else
            {
                MessageBox.Show("Не выбрана строка для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridViewCustom.ClearSelection();
                dataGridViewCustom.Rows[e.RowIndex].Selected = true;
            }
        }
    }

    public class MessageFormer
    {
        static public  void FormYesNo(List<(double, string)> list)
        {
            list.Clear();
            list.Add((0.5, "Да"));
            list.Add((0.5, "Нет"));
            list = list.OrderByDescending(item => item.Item1).ToList();
        }

        static public void FormEightBall(List<(double, string)> list)
        {
            list.Clear();
            list.Add((0.05, "Бесспорно"));
            list.Add((0.05, "Предрешено"));
            list.Add((0.05, "Никаких сомнений"));
            list.Add((0.05, "Определённо да"));
            list.Add((0.05, "Можешь быть уверен в этом"));
            list.Add((0.05, "Мне кажется — «да»"));
            list.Add((0.05, "Вероятнее всего"));
            list.Add((0.05, "Хорошие перспективы"));
            list.Add((0.05, "Знаки говорят «да»"));
            list.Add((0.05, "Да"));
            list.Add((0.05, "Пока не ясно, попробуй снова"));
            list.Add((0.05, "Спроси позже"));
            list.Add((0.05, "Лучше не рассказывать"));
            list.Add((0.05, "Сейчас нельзя предсказать"));
            list.Add((0.05, "Сконцентрируйся и спроси опять"));
            list.Add((0.05, "Даже не думай"));
            list.Add((0.05, "Мой ответ — «нет»"));
            list.Add((0.05, "По моим данным — «нет»"));
            list.Add((0.05, "Перспективы не очень хорошие"));
            list.Add((0.05, "Вряд ли"));
            list = list.OrderByDescending(item => item.Item1).ToList();
        }

        static public void FormEmptyCustom(BindingList<ProbabilityMessage> list)
        {
            list.Clear();
            list.Add(new ProbabilityMessage { Probability = 1, Message = "Параметры -> [Редактировать \"Custom\"]" });
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

        static public ulong TextToSign(string text)
        {
            ulong seed = 0;
            if (string.IsNullOrEmpty(text))
            {
                return 1;
            }
            foreach (char ch in text)
            {
                uint code = ch;
                seed += code;
                seed %= M;
            }
            if (seed == 0) seed = 1;
            return seed;
        }

        static public bool CheckNorm(List<(double, string)> list)
        {
            double summ = 0;
            foreach (var (prob, text) in list)
            {
                summ += prob;
            }
            if (Math.Abs(summ - 1.0) < 1e-10) return true;
            return false;
        }

        static public bool CheckNormProbMessage(BindingList<ProbabilityMessage> list)
        {
            double summ = 0;
            foreach (ProbabilityMessage probMessage in list)
            {
                summ += probMessage.Probability;
            }
            if (Math.Abs(summ - 1.0) < 1e-10) return true;
            return false;
        }

        static public ulong getM() { return M; }
    }

    public class ProbabilityMessage : INotifyPropertyChanged
    {
        private double probability;
        private string message;

        public double Probability
        {
            get => probability;
            set
            {
                if (probability != value)
                {
                    probability = value;
                    OnPropertyChanged(nameof(Probability));
                }
            }
        }

        public string Message
        {
            get => message;
            set
            {
                if (message != value)
                {
                    message = value;
                    OnPropertyChanged(nameof(Message));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
