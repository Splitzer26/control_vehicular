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
    public partial class form_actualizar_vehiculo : Form
    {
        private OleDbConnection CONECTAR = new OleDbConnection();
        public form_actualizar_vehiculo()
        {
            InitializeComponent();
            CONECTAR.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + ".\\DB_vehiculos.mdb; Persist Security Info=false;";
        }
        public void limpiar_formulario()
        {
            comboBox2.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            comboBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void form_actualizar_vehiculo_Load(object sender, EventArgs e)
        {

            CONECTAR.Open();
            OleDbCommand COMANDO = new OleDbCommand();
            COMANDO.Connection = CONECTAR;
            COMANDO.CommandText = "SELECT COMBUSTIBLE FROM combustible";
            OleDbDataReader LEER = COMANDO.ExecuteReader();
            while (LEER.Read())
            {
                comboBox1.Items.Add(LEER["COMBUSTIBLE"]).ToString();
            }
            CONECTAR.Close();
            CONECTAR.Open();
            OleDbCommand COMAND = new OleDbCommand();
            COMAND.Connection = CONECTAR;
            COMAND.CommandText = "SELECT CODIGO_VEHICULO FROM vehiculos";
            OleDbDataReader LEER_2 = COMAND.ExecuteReader();
            while (LEER_2.Read())
            {
                comboBox2.Items.Add(LEER_2["CODIGO_VEHICULO"]).ToString();
            }
            CONECTAR.Close();

        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if(comboBox2.Text=="")
            {

            }
            else
            {
                String codigo = comboBox2.Text;
                CONECTAR.Open();
                OleDbCommand COMANDO = new OleDbCommand();
                COMANDO.Connection = CONECTAR;
                COMANDO.CommandText = "SELECT * FROM vehiculos WHERE CODIGO_VEHICULO=" + codigo + "";
                OleDbDataReader LEER_carro = COMANDO.ExecuteReader();
                while (LEER_carro.Read())
                {
                    textBox2.Text = (LEER_carro["VEHICULO"]).ToString();
                    textBox3.Text = (LEER_carro["PLACA"]).ToString();
                    textBox5.Text = (LEER_carro["MARCA"]).ToString();
                    textBox6.Text = (LEER_carro["MODELO"]).ToString();
                    textBox7.Text = (LEER_carro["COLOR"]).ToString();
                    textBox8.Text = (LEER_carro["SERIE_DE_MOTOR"]).ToString();
                    dateTimePicker1.Value = DateTime.Parse((LEER_carro["FECHA_ADQUISICION"]).ToString());
                    numericUpDown2.Value = int.Parse(LEER_carro["GARANTIA"].ToString());
                    comboBox1.Text = (LEER_carro["COMBUSTIBLE"]).ToString();
                }
                CONECTAR.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                CONECTAR.Open();
                OleDbCommand COMANDO = new OleDbCommand();
                COMANDO.Connection = CONECTAR;
                COMANDO.CommandText = "UPDATE vehiculos SET VEHICULO= @vehicle, PLACA=@plate, MARCA=@sing, MODELO=@model, COLOR=@color, SERIE_DE_MOTOR=@serial, FECHA_ADQUISICION=@date, GARANTIA=@end_date, COMBUSTIBLE=@gas WHERE CODIGO_VEHICULO=@code";
                COMANDO.Parameters.AddWithValue("@vehicle", textBox2.Text);
                COMANDO.Parameters.AddWithValue("@plate", textBox3.Text);
                COMANDO.Parameters.AddWithValue("@sing", textBox5.Text);
                COMANDO.Parameters.AddWithValue("@model", textBox6.Text);
                COMANDO.Parameters.AddWithValue("@color",textBox7.Text);
                COMANDO.Parameters.AddWithValue("@serial",textBox8.Text);
                COMANDO.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                COMANDO.Parameters.AddWithValue("@end_date", numericUpDown2.Value);
                COMANDO.Parameters.AddWithValue("@gas", comboBox1.Text);
                COMANDO.Parameters.AddWithValue("@code", comboBox2.Text);
                COMANDO.ExecuteNonQuery();
                CONECTAR.Close();
                MessageBox.Show("Actualizacion Completa", "Se ha actualizado exitosamente");
                form_conductores form1 = new form_conductores();
                form1.cargar_data();
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

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
