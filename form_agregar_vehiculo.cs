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
    public partial class form_agregar_vehiculo : Form
    {
        private OleDbConnection CONECTAR = new OleDbConnection();
        public form_agregar_vehiculo()
        {
            InitializeComponent();
            CONECTAR.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + ".\\DB_vehiculos.mdb; Persist Security Info=false;";
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
        public void limpiar_formulario()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CONECTAR.Open();
                OleDbCommand COMANDO = new OleDbCommand();
                COMANDO.Connection = CONECTAR;
                COMANDO.CommandText = "INSERT INTO vehiculos (CODIGO_VEHICULO, VEHICULO, PLACA, MARCA, MODELO, COLOR, SERIE_DE_MOTOR, FECHA_ADQUISICION, GARANTIA, COMBUSTIBLE) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + dateTimePicker1.Value + "','" + numericUpDown1.Value + "')";
                COMANDO.ExecuteNonQuery();
                MessageBox.Show("Se ha añadido correctamente el nuevo vehiculo", "Registro añadido exitosamente", MessageBoxButtons.OK);
                limpiar_formulario();
                form_conductores form1 = new form_conductores();
                form1.cargar_data();
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
    }
}
