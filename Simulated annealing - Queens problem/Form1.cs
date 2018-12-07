using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Simulated_annealing___Queens_problem
{
    public partial class Form1 : Form
    {
        SimulatedAnnealing sa;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetWorking();
            this.Refresh();

            int fieldSize = Int32.Parse(tbFieldSize.Text);
            double temperature = Convert.ToDouble(tbTemperature.Text);
            double coolingRate = Convert.ToDouble(tbCoolingRate.Text);

            sa = new SimulatedAnnealing(fieldSize, temperature, coolingRate);
            sa.Run();

            DrawField(sa);
        }

        void SetWorking()
        {
            richTextBox1.Text = "Working...";
        }

        void ClearField()
        {
            richTextBox1.Text = "";
        }

        void DrawField(SimulatedAnnealing sa)
        {
            ClearField();

            int fieldSize = sa.GetFieldSize();
            List<Queen> cfg = sa.GetBestConfiguration().GetList();

            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    bool contains = false;
                    for (int k = 0; k < cfg.Count; k++)
                    {
                        if (cfg[k].i == i && cfg[k].j == j)
                        {
                            contains = true;
                        }
                    }
                    if (contains)
                    {
                        richTextBox1.Text += "Q\t";
                    }
                    else
                    {
                        richTextBox1.Text += "#\t";
                    }
                }
                richTextBox1.Text += "\n\n";
            }
            richTextBox1.Text += "Cost: " + sa.GetBestConfiguration().Cost();
            richTextBox1.Text += "\nIterations: " + sa.iterations;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
