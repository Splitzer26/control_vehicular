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
    public partial class form_inventario : Form
    {

        Menu padre = new Menu();
        private Form currentChildForm;
        
        public form_inventario()
        {
            InitializeComponent();
        }
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            padre.OpenChildForm(new form_agregar_vehiculo());
            form_agregar_vehiculo agregar_vehiculo = new form_agregar_vehiculo();
            agregar_vehiculo.Show();
            
        }
    }
}
