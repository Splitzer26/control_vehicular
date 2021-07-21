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
    public partial class form_recorrido_y_combustible : Form
    {
        public Form currentChildForm;
        private OleDbConnection CONECTAR = new OleDbConnection();
        public form_recorrido_y_combustible()
        {
            InitializeComponent();
            CONECTAR.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + ".\\DB_vehiculos.mdb; Persist Security Info=false;";
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
            OpenChildForm(new form_control_de_recorrido());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form_ingreso_de_combustible ingreso_De_Combustible = new form_ingreso_de_combustible();
            ingreso_De_Combustible.cod_vehicle = comboBox1.Text;
            OpenChildForm(new form_ingreso_de_combustible());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new form_combustible_en_vehiculo());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void form_recorrido_y_combustible_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            CONECTAR.Open();
            OleDbCommand COMANDO = new OleDbCommand();
            COMANDO.Connection = CONECTAR;
            COMANDO.CommandText = "SELECT CODIGO_VEHICULO FROM vehiculos";
            OleDbDataReader LEER = COMANDO.ExecuteReader();
            while (LEER.Read())
            {
                comboBox1.Items.Add(LEER["CODIGO_VEHICULO"]).ToString();
            }
            CONECTAR.Close();
            CONECTAR.Open();
            COMANDO.Connection = CONECTAR;
            COMANDO.CommandText = "SELECT VEHICULO FROM vehiculos";
            OleDbDataReader LEER_2 = COMANDO.ExecuteReader();
            while (LEER_2.Read())
            {
                comboBox2.Items.Add(LEER_2["VEHICULO"]).ToString();
            }
            CONECTAR.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.Text=="" && comboBox1.Text != "")
            {
                String codigo = comboBox1.Text;
                CONECTAR.Open();
                OleDbCommand COMANDO = new OleDbCommand();
                COMANDO.Connection = CONECTAR;
                COMANDO.CommandText = "SELECT * FROM vehiculos WHERE CODIGO_VEHICULO=" + codigo + "";
                OleDbDataReader LEER_carro = COMANDO.ExecuteReader();
                while (LEER_carro.Read())
                {
                    comboBox2.Text = (LEER_carro["VEHICULO"]).ToString();
                }
                CONECTAR.Close();
            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            
            if(comboBox1.Text=="" && comboBox2.Text != "")
            {

                String codigo = comboBox2.Text;
                CONECTAR.Open();
                OleDbCommand COMANDO = new OleDbCommand();
                COMANDO.Connection = CONECTAR;
                COMANDO.CommandText = "SELECT * FROM vehiculos WHERE VEHICULO='" + codigo + "'";
                OleDbDataReader LEER_carro = COMANDO.ExecuteReader();
                while (LEER_carro.Read())
                {
                    comboBox1.Text = (LEER_carro["CODIGO_VEHICULO"]).ToString();
                }
                CONECTAR.Close();
            }

        }
    }
}
