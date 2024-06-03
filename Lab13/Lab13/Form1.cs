using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab13
{
    public partial class Form1 : Form
    {
        const double u = 0.15;
        const double sd = 0.015;
        const double k = u - 0.5 * sd * sd;

        Random rnd = new Random();

        double Euro, Dollar, NDay, BoxG;

        private double Generator()
        {
            Random rand = new Random();
            var a = rand.NextDouble();
            var b = rand.NextDouble();

            return Math.Sqrt(-2.0 * Math.Log(a)) * Math.Cos(2.0 * Math.PI * b);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Euro = (double)numericUpDown1.Value;
            Dollar = (double)numericUpDown2.Value;
            NDay = 1;

            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(0, Euro);
            chart1.Series[1].Points.Clear();
            chart1.Series[1].Points.AddXY(0, Dollar);

            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Maximum = Math.Ceiling(NDay);
            BoxG = Generator();

            Euro = Euro * Math.Exp(k + sd * BoxG);
            Dollar = Dollar * Math.Exp(k + sd * BoxG);

            chart1.Series[0].Points.AddXY(NDay, Euro);
            chart1.Series[1].Points.AddXY(NDay, Dollar);

            NDay++;
        }
    }
}
