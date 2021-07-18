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
    public partial class form_inventario : Form
    {

        Menu padre = new Menu();
        private Form currentChildForm;
        private OleDbConnection CONECTAR = new OleDbConnection();

        public form_inventario()
        {
            InitializeComponent();
            CONECTAR.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + ".\\DB_vehiculos.mdb; Persist Security Info=false;";
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
        public void cargar_data()
        {
            try
            {
                CONECTAR.Open();
                OleDbCommand COMANDO = new OleDbCommand();
                COMANDO.Connection = CONECTAR;
                COMANDO.CommandText = "SELECT * FROM vehiculos";
                OleDbDataReader LEER = COMANDO.ExecuteReader();
                while (LEER.Read())
                {
                    int N = dataGridView1.Rows.Add();
                    dataGridView1.Rows[N].Cells[0].Value = LEER["CODIGO_VEHICULO"].ToString();
                    dataGridView1.Rows[N].Cells[1].Value = LEER["VEHICULO"].ToString();
                    dataGridView1.Rows[N].Cells[2].Value = LEER["PLACA"].ToString();
                    dataGridView1.Rows[N].Cells[3].Value = LEER["MARCA"].ToString();
                    dataGridView1.Rows[N].Cells[4].Value = LEER["MODELO"].ToString();
                    dataGridView1.Rows[N].Cells[5].Value = LEER["COLOR"].ToString();
                    dataGridView1.Rows[N].Cells[6].Value = LEER["SERIE_DE_MOTOR"].ToString();
                    dataGridView1.Rows[N].Cells[7].Value = LEER["FECHA_ADQUISICION"].ToString();
                    dataGridView1.Rows[N].Cells[8].Value = LEER["GARANTIA"].ToString();
                    dataGridView1.Rows[N].Cells[9].Value = LEER["COMBUSTIBLE"].ToString();

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

        private void form_inventario_Load(object sender, EventArgs e)
        {
            cargar_data();
        }
    }
}
