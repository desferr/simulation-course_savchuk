namespace Lab1
{
    public partial class Form1 : Form
    {
        int series_amount = 0;
        private List<Color> colors = new List<Color>
        {
            Color.Red,
            Color.Green,
            Color.Blue,
            Color.Orange,
            Color.Purple,
            Color.Brown,
            Color.Pink,
            Color.Cyan,
            Color.Black
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            series_amount += 1;
            const double g = 9.8;
            double x = 0, y = 0, v0 = 0, alpha = 0, t_step = 0, t = 0, vx = 0, vy = 0, max_height = 0;
            v0 = (double)numericUpDown1.Value;
            alpha = (double)numericUpDown2.Value;
            t_step = (double)numericUpDown3.Value;
            string series_name = "Симуляция_" + series_amount.ToString();
            textBox1.AppendText($"{series_name}." + Environment.NewLine);
            textBox1.AppendText("Параметры:" + Environment.NewLine);
            textBox1.AppendText($"Начальная скорость: {v0} м/c," + Environment.NewLine);
            textBox1.AppendText($"Угол начала полёта: {alpha}°," + Environment.NewLine);
            textBox1.AppendText($"Шаг моделирования: {t_step} с." + Environment.NewLine);
            chart1.Series.Add(series_name);
            chart1.Series[series_name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[series_name].Color = colors[(series_amount - 1) % 9];
            chart1.Series[series_name].Points.AddXY(x, y);
            alpha *= Math.PI / 180;
            do
            {
                t += t_step;
                x = v0 * Math.Cos(alpha) * t;
                y = v0 * Math.Sin(alpha) * t - ((g * t * t) / 2);
                if (y > max_height) { max_height = y; }
                chart1.Series[series_name].Points.AddXY(x, y);
            } while (y >= 0);
            vx = v0 * Math.Cos(alpha);
            vy = v0 * Math.Sin(alpha) - g * t;
            textBox1.AppendText("Результаты:" + Environment.NewLine);
            textBox1.AppendText($"Дальность полёта: {Math.Round(x, 3)} м," + Environment.NewLine);
            textBox1.AppendText($"Максимальная высота: {Math.Round(max_height, 3)} м," + Environment.NewLine);
            textBox1.AppendText($"Скорость в конечной точке: {Math.Round(Math.Sqrt((vx * vx) + (vy * vy)), 3)} м/c." + Environment.NewLine);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string series_name;
            for (int i = 1; i <= series_amount; i++) {
                series_name = "Симуляция_" + i.ToString();
                chart1.Series.Remove(chart1.Series[series_name]);
            }
            series_amount = 0;
            textBox1.Clear();
        }
    }
}
