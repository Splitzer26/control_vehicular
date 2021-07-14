using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace control_vehicular_aih
{
    public partial class form_agregar_conductor : Form
    {
        private OleDbConnection CONECTAR = new OleDbConnection();
        public form_agregar_conductor()
        {
            InitializeComponent();
            CONECTAR.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + ".\\DB_vehiculos.mdb; Persist Security Info=false;";
        }
        public void limpiar_formulario()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox2.Text = "";
            dateTimePicker1.Value = DateTime.Today;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CONECTAR.Open();
                OleDbCommand COMANDO = new OleDbCommand();
                COMANDO.Connection = CONECTAR;
                COMANDO.CommandText = "INSERT INTO conductores (NOMBRE, ID, TELEFONO, LICENCIA, FECHA_VENCIMIENTO_LICENCIA, VEHICULO_ASOCIADO) VALUES ('" + textBox2.Text + "','" + textBox4.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Value + "','" + comboBox2.Text + "')";
                COMANDO.ExecuteNonQuery();
                MessageBox.Show("Se ha añadido correctamente el nuevo conductor", "Registro añadido exitosamente",MessageBoxButtons.OK);
                limpiar_formulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error= " + ex, "ERROR");
            }
            finally
            {
                CONECTAR.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
