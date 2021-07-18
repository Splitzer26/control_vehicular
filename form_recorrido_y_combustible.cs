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
        public Form currentChildForm;
        public form_recorrido_y_combustible()
        {
            InitializeComponent();
        }
        public void OpenChildForm(Form childForm)
        {

            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(childForm);
            this.panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form_control_de_recorrido code_vehicle = new form_control_de_recorrido();
            code_vehicle.COD_VEHICLE = this.comboBox1.Text;
            //form_control_de_recorrido contro_recorrido = new form_control_de_recorrido();
            //contro_recorrido.Show();
            OpenChildForm(new form_control_de_recorrido());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //form_ingreso_de_combustible form_Ingreso_De_Combustible = new form_ingreso_de_combustible();
            //form_Ingreso_De_Combustible.Show();
            OpenChildForm(new form_ingreso_de_combustible());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //form_combustible_en_vehiculo form_Combustible_En_Vehiculo = new form_combustible_en_vehiculo();
            //form_Combustible_En_Vehiculo.Show();
            OpenChildForm(new form_combustible_en_vehiculo());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void form_recorrido_y_combustible_Load(object sender, EventArgs e)
        {

        }
    }
}
