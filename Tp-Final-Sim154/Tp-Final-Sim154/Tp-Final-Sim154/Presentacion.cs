using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tp_Final_Sim154
{
    public partial class Presentacion : Form
    {
        public Presentacion()
        {
            InitializeComponent();
        }

        private void btn_resolucion_Click(object sender, EventArgs e)
        {
            RungeKutta rg = new RungeKutta();
            rg.Show();
        }
    }
}
