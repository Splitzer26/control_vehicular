using System;
using System.Runtime.InteropServices;
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
    

    public partial class Menu : Form
    {
        private OleDbConnection CONECTAR = new OleDbConnection();
        private Panel leftBorderBtn;
        public Form currentChildForm;
        public Menu()
        {
            InitializeComponent();
            CONECTAR.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + ".\\DB_vehiculos.mdb; Persist Security Info=false;";
            //Añadir alerta de registros vehiculares y taller

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
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new form_inventario());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new form_recorrido_y_combustible());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new form_seguro_vehicular_y_revision_tecnica());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new form_historial_de_recorrido());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenChildForm(new form_conductores());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenChildForm(new form_reportes());
        }
    }
}
