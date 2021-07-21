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
    public partial class form_ingreso_de_combustible : Form
    {
        public string cod_vehicle;
        private OleDbConnection CONECTAR = new OleDbConnection();
        public form_ingreso_de_combustible()
        {
            InitializeComponent();
            CONECTAR.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + ".\\DB_vehiculos.mdb; Persist Security Info=false;";
        }

        private void form_ingreso_de_combustible_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }
        public void limpiar_formulario()
        {
            dateTimePicker1.Value = DateTime.Now;
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CONECTAR.Open();
                OleDbCommand COMANDO = new OleDbCommand();
                COMANDO.Connection = CONECTAR;
                COMANDO.CommandText = "INSERT INTO recorridos (COMBUSTIBLE,FECHA_FINAL,CODIGO_VEHICULO) VALUES ('" + textBox1.Text + "','"+dateTimePicker1.Value+"','"+cod_vehicle+"')";
                COMANDO.ExecuteNonQuery();
                MessageBox.Show("Se ha añadido correctamente la recarga de combustible", "Registro añadido exitosamente", MessageBoxButtons.OK);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
