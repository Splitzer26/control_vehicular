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
                COMANDO.CommandText = "UPDATE conductores SET NOMBRE= @name, ID=@id, TELEFONO=@phone, LICENCIA=@manager, FECHA_VENCIMIENTO_LICENCIA=@date, VEHICULO_ASOCIADO=@vehicle WHERE CODIGO_CONDUCTOR=@code";
                COMANDO.Parameters.AddWithValue("@name", textBox2.Text);
                COMANDO.Parameters.AddWithValue("@id", textBox4.Text);
                COMANDO.Parameters.AddWithValue("@phone", textBox3.Text);
                COMANDO.Parameters.AddWithValue("@manager", textBox1.Text);
                COMANDO.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                COMANDO.Parameters.AddWithValue("@vehicle", comboBox2.Text);
                COMANDO.Parameters.AddWithValue("@code", int.Parse(comboBox3.Text));
                COMANDO.ExecuteNonQuery();
                CONECTAR.Close();
                MessageBox.Show("Actualizacion Completa", "Se ha actualizado exitosamente");
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
            CONECTAR.Open();
            OleDbCommand COMANDO = new OleDbCommand();
            COMANDO.Connection = CONECTAR;
            COMANDO.CommandText = "SELECT * FROM conductores WHERE CODIGO_CONDUCTOR=" + codigo + "";
            OleDbDataReader LEER_carro = COMANDO.ExecuteReader();
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
