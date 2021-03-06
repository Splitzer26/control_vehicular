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

    public partial class form_control_de_recorrido : Form
    {
        public int COD_VEHICLE;
        private OleDbConnection CONECTAR = new OleDbConnection();

        public form_control_de_recorrido()
        {
            InitializeComponent();
            CONECTAR.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + ".\\DB_vehiculos.mdb; Persist Security Info=false;";
        }
        public form_control_de_recorrido(String vehicle)
        {
            InitializeComponent();
            textBox5.Text = vehicle;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void limpiar_formulario()
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int init = int.Parse(textBox3.Text);
            int end = int.Parse(textBox4.Text);
            int millaje_recorrido = end - init;
            if(init>end)
            {
                MessageBox.Show("El millaje inicial no puede ser mayor que el final", "Error en Millajes", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            else
            {
                try
                {
                    CONECTAR.Open();
                    OleDbCommand COMANDO = new OleDbCommand();
                    COMANDO.Connection = CONECTAR;
                    COMANDO.CommandText = "INSERT INTO recorridos (FECHA_INICIAL, LUGAR_INICIO, MILLAJE_INICIAL, FECHA_FINAL, LUGAR_DESTINO, MILLAJE_FINAL, MILLAJE_RECORRIDOS, CODIGO_VEHICULO) VALUES ('" + dateTimePicker1.Value + "','" + textBox1.Text + "','" + textBox3.Text + "','" + dateTimePicker2.Value + "','" + textBox2.Text + "','" + textBox4.Text + "','" + millaje_recorrido.ToString() + "','" + COD_VEHICLE + "')";
                    COMANDO.ExecuteNonQuery();
                    MessageBox.Show("Se ha añadido correctamente el nuevo recorrido", "Registro añadido exitosamente", MessageBoxButtons.OK);
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

        private void button2_Click(object sender, EventArgs e)
        {

        }
        public void ejecutar( string dato)
        {
            textBox5.Text = dato;
        }
        private void form_control_de_recorrido_Load(object sender, EventArgs e)
        {
            //form_recorrido_y_combustible form = new form_recorrido_y_combustible();
            COD_VEHICLE = int.Parse(textBox5.Text);
            CONECTAR.Open();
            OleDbCommand COMANDO = new OleDbCommand();
            COMANDO.Connection = CONECTAR;
            COMANDO.CommandText = "SELECT * FROM recorridos WHERE CODIGO_VEHICULO=" + COD_VEHICLE + " ORDER BY CODIGO_RECORRIDO ASC";
            OleDbDataReader LEER_carro = COMANDO.ExecuteReader();
            while (LEER_carro.Read())
            {
                textBox3.Text = (LEER_carro["MILLAJE_FINAL"]).ToString();
            }
            CONECTAR.Close();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void Form_pasar_codigo(string codigo)
        {
            throw new NotImplementedException();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //dateTimePicker2.MinValue(dateTimePicker1.Value);
        }
    }
}
