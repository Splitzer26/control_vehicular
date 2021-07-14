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
    public partial class form_actualizar_conductor : Form
    {
        private OleDbConnection CONECTAR = new OleDbConnection();
        public form_actualizar_conductor()
        {
            InitializeComponent();
            CONECTAR.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + ".\\DB_vehiculos.mdb; Persist Security Info=false;";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CONECTAR.Open();
                OleDbCommand COMANDO = new OleDbCommand();
                COMANDO.Connection = CONECTAR;
                COMANDO.CommandText = "UPDATE conductores SET NOMBRE='" + textBox2.Text + "', ID='" + textBox4.Text + "', TELEFONO= '" + textBox3.Text + "', LICENCIA='" + textBox1.Text + "',FECHA_VENCIMIENTO_LICENCIA='" + dateTimePicker1.Value + "', VEHICULO_ASOCIADO='" + comboBox2.Text + "' WHERE CODIGO_CONDUCTOR='" + comboBox3.Text + "'";
                CONECTAR.Close();
                MessageBox.Show("Actualizacion Completa", "Se ha actualizado exitosamente");
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

        private void form_actualizar_conductor_Load(object sender, EventArgs e)
        {
            
            CONECTAR.Open();
            OleDbCommand COMANDO = new OleDbCommand();
            COMANDO.Connection = CONECTAR;
            COMANDO.CommandText = "SELECT CODIGO_CONDUCTOR FROM conductores";
            OleDbDataReader LEER = COMANDO.ExecuteReader();
            while(LEER.Read())
            {
                comboBox3.Items.Add(LEER["CODIGO_CONDUCTOR"]).ToString();
            }
            CONECTAR.Close();
            CONECTAR.Open();
            COMANDO.CommandText = "SELECT VEHICULO FROM vehiculos";
            OleDbDataReader LEER_vehiculo = COMANDO.ExecuteReader();
            while (LEER_vehiculo.Read())
            {
                comboBox2.Items.Add(LEER_vehiculo["VEHICULO"]).ToString();
            }
            CONECTAR.Close();
           
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
       

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            String codigo = comboBox3.Text;
            MessageBox.Show("Codigo guardado: " + codigo);
            
            CONECTAR.Open();
            MessageBox.Show("Conexion abierta");
            OleDbCommand COMANDO = new OleDbCommand();
            MessageBox.Show("comando creado");
            COMANDO.Connection = CONECTAR;
            MessageBox.Show("conexion establecida");
            COMANDO.CommandText = "SELECT * FROM conductores WHERE CODIGO_CONDUCTOR=" + codigo + "";
            MessageBox.Show("Comando especificado");
            OleDbDataReader LEER_carro = COMANDO.ExecuteReader();
            MessageBox.Show("Comando ejecutado");
            while (LEER_carro.Read())
            {
                textBox2.Text = (LEER_carro["NOMBRE"]).ToString();
                textBox3.Text = (LEER_carro["TELEFONO"]).ToString();
                textBox4.Text = (LEER_carro["ID"]).ToString();
                textBox1.Text = (LEER_carro["LICENCIA"]).ToString();
                dateTimePicker1.Value = DateTime.Parse((LEER_carro["FECHA_VENCIMIENTO_LICENCIA"]).ToString());
                comboBox2.Text = (LEER_carro["VEHICULO_ASOCIADO"]).ToString();
            }
            CONECTAR.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
