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
    public partial class form_seguro_vehicular_y_revision_tecnica : Form
    {
        public form_seguro_vehicular_y_revision_tecnica()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form_agregar_seguro_vehicular form_Agregar_Seguro_Vehicular = new form_agregar_seguro_vehicular();
            form_Agregar_Seguro_Vehicular.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form_actualizar_seguro_vehicular form_Actualizar_Seguro_Vehicular = new form_actualizar_seguro_vehicular();
            form_Actualizar_Seguro_Vehicular.Show();
        }
    }
}
