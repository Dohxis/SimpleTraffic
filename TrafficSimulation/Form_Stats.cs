using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrafficSimulation.Rules;
using TrafficSimulation.Actions;
using System.Timers;

namespace TrafficSimulation
{
    public partial class Form_Stats : Form
    {

        public Form_Stats(int carsspawned, int carsquit, TimeSpan ts)
        {

            InitializeComponent();
            tbCarsSpawned.Text = carsspawned.ToString();
            tbCarsQuit.Text = carsquit.ToString();
            if (ts != null)
            {
                tb_timeran.Text = ts.ToString(@"hh\:mm\:ss");
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
