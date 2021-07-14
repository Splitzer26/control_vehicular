using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace control_vehicular_aih
{
    public partial class form_recorrido_y_combustible : Form
    {
        public form_recorrido_y_combustible()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form_control_de_recorrido contro_recorrido = new form_control_de_recorrido();
            contro_recorrido.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form_ingreso_de_combustible form_Ingreso_De_Combustible = new form_ingreso_de_combustible();
            form_Ingreso_De_Combustible.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            form_combustible_en_vehiculo form_Combustible_En_Vehiculo = new form_combustible_en_vehiculo();
            form_Combustible_En_Vehiculo.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
