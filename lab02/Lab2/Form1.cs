using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double T0 = 0, T_left = 0, T_right = 0;
            T0 = (double)numericUpDown1.Value;
            T_left = (double)numericUpDown2.Value;
            T_right = (double)numericUpDown3.Value;
            double x_step = 0, t_step = 0, t_max = 0, length = 0;
            x_step = (double)numericUpDown4.Value;
            t_step = (double)numericUpDown5.Value;
            t_max = (double)numericUpDown6.Value;
            length = (double)numericUpDown7.Value;
            double ro = 0, c = 0, lambda = 0;
            ro = (double)numericUpDown8.Value;
            c = (double)numericUpDown9.Value;
            lambda = (double)numericUpDown10.Value;
            int x_points = (int)Math.Ceiling(length / x_step) + 1;
            int t_points = (int)Math.Ceiling(t_max / t_step) + 1;
            double[] alpha = new double[x_points], beta = new double[x_points];
            double[] x = new double[x_points], t = new double[t_points];
            double[,] T = new double[t_points, x_points];
            x[0] = 0;
            for (int i = 1; i < x_points - 1; i++)
            {
                T[0, i] = T0;
                x[i] = x[i - 1] + x_step;
            }
            T[0, 0] = T_left;
            T[0, x_points - 1] = T_right;
            x[x_points - 1] = x[x_points - 2] + x_step;
            t[0] = 0;
            double A = lambda / (x_step * x_step);
            double C = A;
            double B = ((2 * lambda) / (x_step * x_step)) + ((ro * c) / t_step);
            double F = 0;
            for (int i = 1; i < t_points; i++)
            {
                t[i] = t[i - 1] + t_step;
                alpha[0] = 0;
                beta[0] = T_left;
                for (int j = 1; j < x_points - 1; j++)
                {
                    alpha[j] = A / (B - C * alpha[j - 1]);
                    F = -((ro * c) / t_step) * T[i - 1, j];
                    beta[j] = (C * beta[j - 1] - F) / (B - C * alpha[j - 1]);
                }
                T[i, x_points - 1] = T_right;
                for (int j = x_points - 2; j > 0; j--)
                {
                    T[i, j] = alpha[j] * T[i, j + 1] + beta[j];
                }
                T[i, 0] = T_left;
            }

            double[,] T_transposed = new double[x_points, t_points];
            for (int i = 0; i < t_points; i++)
            {
                for (int j = 0; j < x_points; j++)
                {
                    T_transposed[j, i] = T[i, j];
                }
            }
            var plot_model = new PlotModel { Title = "Тепловая карта температуры" };
            var heat_map_series = new HeatMapSeries
            {
                X0 = x[0],
                X1 = x[^1],
                Y0 = t[0],
                Y1 = t[^1],
                Data = T_transposed,
                Interpolate = false,
                RenderMethod = HeatMapRenderMethod.Rectangles,
            };
            plot_model.Series.Add(heat_map_series);
            var color_axis = new LinearColorAxis
            {
                Position = AxisPosition.Right,
                Title = "Температура, °C",
                Minimum = double.NaN,
                Maximum = double.NaN,
            };
            plot_model.Axes.Add(color_axis);
            plot_model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "x, м", Minimum = x[0], Maximum = x[^1] });
            plot_model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Время, с", Minimum = t[0], Maximum = t[^1] });
            plotView1.Model = plot_model;

            int x_mid = 0;
            if (x_points % 2 == 1)
            {
                x_mid = x_points / 2;
                textBox1.AppendText($"t_step: {t_step}, x_step: {x_step}, T_mid: {Math.Round(T[t_points - 1, x_mid], 2)}" + Environment.NewLine);
            }
            else
            {
                x_mid = x_points / 2;
                textBox1.AppendText($"t_step: {t_step}, x_step: {x_step}, T_mid: {Math.Round((T[t_points - 1, x_mid - 1] + T[t_points - 1, x_mid]) / 2, 2)}" + Environment.NewLine);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
