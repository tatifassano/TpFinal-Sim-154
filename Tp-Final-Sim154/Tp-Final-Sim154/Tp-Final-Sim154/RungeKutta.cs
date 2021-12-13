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
    public partial class RungeKutta : Form
    {

        private double fin;
        private double y1_0;
        private double y2_0;
        private double K1;
        private double L1;
        private double K2;
        private double L2;
        private double K3;
        private double L3;
        private double K4;
        private double L4;
        private double h;
        private double t0;
        private double tf;
        private double Y1;
        private double Y2;
        private double desde;
        private double hasta;
        private double a;
        private double b;
        private double c = (double)1 / 6;
        private double ti;
        private double y1i;
        private double y2i;
        private double t;
        private double cantIteraciones;
        


        public RungeKutta()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void RungeKutta_Load(object sender, EventArgs e)
        {
            txt_to.Text = Convert.ToString(0);
            txt_h.Text = Convert.ToString(0.5);
            txt_y1_o.Text = Convert.ToString(4);
            txt_y2_o.Text = Convert.ToString(6);
            txt_tf.Text = Convert.ToString(2);
            txt_desde.Text = Convert.ToString(0);
            txt_hasta.Text = Convert.ToString(1.5);
            cantIteraciones = (Convert.ToDouble(txt_tf.Text) - Convert.ToDouble(txt_to.Text)) / Convert.ToDouble(txt_h.Text);
            txt_iteraciones.Text = Convert.ToString(cantIteraciones);
        }

        private void btn_calcularIteraciones_Click(object sender, EventArgs e)
        {
            double cant = 0;
            cant = (Convert.ToDouble(txt_tf.Text) - Convert.ToDouble(txt_to.Text)) / Convert.ToDouble(txt_h.Text);
            lbl_iteraciones.Text = "Cantidad de iteraciones: " + cant;
        }

        private void btn_simularCon3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            
            fin = Convert.ToDouble(txt_iteraciones.Text);
            y1_0 = Convert.ToDouble(txt_y1_o.Text);
            y2_0 = Convert.ToDouble(txt_y2_o.Text);
            h = Convert.ToDouble(txt_h.Text);
            t0 = Convert.ToDouble(txt_to.Text);
            desde = Convert.ToDouble(txt_desde.Text);
            hasta = Convert.ToDouble(txt_hasta.Text);
            ti = Math.Round(t0, 2);
            y1i = Math.Round(y1_0, 4);
            y2i = Math.Round(y2_0, 4);
            tf = Convert.ToDouble(txt_tf.Text);
            t = Convert.ToDouble(txt_to.Text);

            for (int i = 0; t <= tf; i++)
            {

                t = Math.Round(ti, 2);
                Y1 = Math.Round(y1i, 2);
                Y2 = Math.Round(y2i, 2);
                K1 = Math.Round(h * (-0.5 * Y1), 2);
                L1 = Math.Round(h * (4 - 0.3 * Y2 - 0.1 * Y1), 2);
                K2 = Math.Round(h * (-0.5 * (Y1 + K1 / 2)), 2);
                L2 = Math.Round(h * (4 - (0.3 * (Y2 + L1 / 2)) - (0.1 * (Y1 + K1 / 2))), 2);
                K3 = Math.Round(h * (-0.5 * (Y1 + K2 / 2)), 2);
                L3 = Math.Round(h * (4 - (0.3 * (Y2 + L2 / 2)) - (0.1 * (Y1 + K2 / 2))), 2);
                K4 = Math.Round(h * (-0.5 * (Y1 + K3)), 2);
                L4 = Math.Round(h * (4 - (0.3 * (Y2 + L3)) - (0.1 * (Y1 + K3))), 2);
                ti = Math.Round(t + h, 2);
                a = (K1 + 2 * K2 + 2 * K3 + K4);
                b = (L1 + 2 * L2 + 2 * L3 + L4);
                y1i = Math.Round(Y1 + c * a, 2);
                y2i = Math.Round(Y2 + c * b, 2);

                //en la aplicacion se usa, y no .

                if (t >= desde && t <= hasta)
                {
                    dataGridView1.Rows.Add(t, Y1, Y2, K1, L1, K2, L2, K3, L3, K4, L4, ti, y1i, y2i);
                    y1vsy2.Series["Y1"].Points.AddXY(t, Y1);
                    y1vsy2.Series["Y2"].Points.AddXY(t, Y2);
                    y1.Series["Y1"].Points.AddXY(t, Y1);
                    y2.Series["Y2"].Points.AddXY(t, Y2);
                }
                if (i == fin)
                {
                    dataGridView1.Rows.Add(t, Y1, Y2, K1, L1, K2, L2, K3, L3, K4, L4, ti, y1i, y2i);
                    y1vsy2.Series["Y1"].Points.AddXY(t, Y1);
                    y1vsy2.Series["Y2"].Points.AddXY(t, Y2);
                    y1.Series["Y1"].Points.AddXY(t, Y1);
                    y2.Series["Y2"].Points.AddXY(t, Y2);
                    MessageBox.Show("> > Fin Simulacion < < \n\n Y1(" + Convert.ToString(txt_tf.Text) + ") = " + Y1 + "\n\n Y2(" + Convert.ToString(txt_tf.Text) + ") = " + Y2, "Resultado:", MessageBoxButtons.OK);
                    lbl_y1.Text = "Y1(" + Convert.ToString(txt_tf.Text) + ") = " + Y1;
                    lbl_y2.Text = "Y2(" + Convert.ToString(txt_tf.Text) + ") = " + Y2;
                }

            }

        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            y1vsy2.Series["Y1"].Points.Clear();
            y1vsy2.Series["Y2"].Points.Clear();
            y1.Series["Y1"].Points.Clear();
            y2.Series["Y2"].Points.Clear();
        }

        private void btn_simlarCon4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            fin = Convert.ToDouble(txt_iteraciones.Text);
            y1_0 = Convert.ToDouble(txt_y1_o.Text);
            y2_0 = Convert.ToDouble(txt_y2_o.Text);
            h = Convert.ToDouble(txt_h.Text);
            t0 = Convert.ToDouble(txt_to.Text);
            desde = Convert.ToDouble(txt_desde.Text);
            hasta = Convert.ToDouble(txt_hasta.Text);
            ti = Math.Round(t0, 2);
            y1i = Math.Round(y1_0, 4);
            y2i = Math.Round(y2_0, 4);
            tf = Convert.ToDouble(txt_tf.Text);
            t = Convert.ToDouble(txt_to.Text);

            for (int i = 0; t <= tf; i++)
            {

                t = Math.Round(ti, 3);
                Y1 = Math.Round(y1i, 3);
                Y2 = Math.Round(y2i, 3);
                K1 = Math.Round(h * (-0.5 * Y1), 3);
                L1 = Math.Round(h * (4 - 0.3 * Y2 - 0.1 * Y1), 3);
                K2 = Math.Round(h * (-0.5 * (Y1 + K1 / 2)), 3);
                L2 = Math.Round(h * (4 - (0.3 * (Y2 + L1 / 2)) - (0.1 * (Y1 + K1 / 2))), 3);
                K3 = Math.Round(h * (-0.5 * (Y1 + K2 / 2)), 3);
                L3 = Math.Round(h * (4 - (0.3 * (Y2 + L2 / 2)) - (0.1 * (Y1 + K2 / 2))), 3);
                K4 = Math.Round(h * (-0.5 * (Y1 + K3)), 3);
                L4 = Math.Round(h * (4 - (0.3 * (Y2 + L3)) - (0.1 * (Y1 + K3))), 3);
                ti = Math.Round(t + h, 3);
                a = (K1 + 2 * K2 + 2 * K3 + K4);
                b = (L1 + 2 * L2 + 2 * L3 + L4);
                y1i = Math.Round(Y1 + c * a, 3);
                y2i = Math.Round(Y2 + c * b, 3);

                //en la aplicacion se usa, y no .

                if (t >= desde && t <= hasta)
                {
                    dataGridView1.Rows.Add(t, Y1, Y2, K1, L1, K2, L2, K3, L3, K4, L4, ti, y1i, y2i);
                    y1vsy2.Series["Y1"].Points.AddXY(t, Y1);
                    y1vsy2.Series["Y2"].Points.AddXY(t, Y2);
                    y1.Series["Y1"].Points.AddXY(t, Y1);
                    y2.Series["Y2"].Points.AddXY(t, Y2);
                }
                if (i == fin)
                {
                    dataGridView1.Rows.Add(t, Y1, Y2, K1, L1, K2, L2, K3, L3, K4, L4, ti, y1i, y2i);
                    y1vsy2.Series["Y1"].Points.AddXY(t, Y1);
                    y1vsy2.Series["Y2"].Points.AddXY(t, Y2);
                    y1.Series["Y1"].Points.AddXY(t, Y1);
                    y2.Series["Y2"].Points.AddXY(t, Y2);
                    MessageBox.Show("> > Fin Simulacion < < \n\n Y1(" + Convert.ToString(txt_tf.Text) + ") = " + Y1 + "\n\n Y2(" + Convert.ToString(txt_tf.Text) + ") = " + Y2, "Resultado:", MessageBoxButtons.OK);
                    lbl_y1.Text = "Y1(" + Convert.ToString(txt_tf.Text) + ") = " + Y1;
                    lbl_y2.Text = "Y2(" + Convert.ToString(txt_tf.Text) + ") = " + Y2;
                }

            }
        }
    }
}
