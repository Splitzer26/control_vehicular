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
    public partial class form_conductores : Form
    {
        private OleDbConnection CONECTAR = new OleDbConnection();
        public form_conductores()
        {
            InitializeComponent();
            CONECTAR.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + ".\\DB_vehiculos.mdb; Persist Security Info=false;";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form_agregar_conductor form_Agregar_Conductor = new form_agregar_conductor();
            form_Agregar_Conductor.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form_actualizar_conductor form_Actualizar_Conductor = new form_actualizar_conductor();
            form_Actualizar_Conductor.Show();
        }
        public void cargar_data()
        {
            try
            {
                CONECTAR.Open();
                OleDbCommand COMANDO = new OleDbCommand();
                COMANDO.Connection = CONECTAR;
                COMANDO.CommandText = "SELECT * FROM conductores";
                OleDbDataReader LEER = COMANDO.ExecuteReader();
                while (LEER.Read())
                {
                    int N = dataGridView1.Rows.Add();
                    dataGridView1.Rows[N].Cells[0].Value = LEER["CODIGO_CONDUCTOR"].ToString();
                    dataGridView1.Rows[N].Cells[1].Value = LEER["NOMBRE"].ToString();
                    dataGridView1.Rows[N].Cells[2].Value = LEER["ID"].ToString();
                    dataGridView1.Rows[N].Cells[3].Value = LEER["TELEFONO"].ToString();
                    dataGridView1.Rows[N].Cells[4].Value = LEER["LICENCIA"].ToString();
                    dataGridView1.Rows[N].Cells[5].Value = LEER["FECHA_VENCIMIENTO_LICENCIA"].ToString();
                    dataGridView1.Rows[N].Cells[6].Value = LEER["VEHICULO_ASOCIADO"].ToString();
                    dataGridView1.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                Console.Beep();
                MessageBox.Show("Error= " + ex, "ERROR");
            }
            CONECTAR.Close();
        }
        private void form_conductores_Load(object sender, EventArgs e)
        {
            cargar_data();
        }
    }
}
