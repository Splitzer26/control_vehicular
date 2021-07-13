using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace control_vehicular_aih
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void txt_usuario_Enter(object sender, EventArgs e)
        {
            if(txt_usuario.Text=="USUARIO")
            {
                txt_usuario.Text = "";
                txt_usuario.ForeColor = Color.LightGray;
            }
        }

        private void txt_usuario_Leave(object sender, EventArgs e)
        {
            if (txt_usuario.Text == "")
            {
                txt_usuario.Text = "USUARIO";
                txt_usuario.ForeColor = Color.DimGray;
            }
        }

        private void txt_contraseña_Enter(object sender, EventArgs e)
        {
            if(txt_contraseña.Text=="CONTRASEÑA")
            {
                txt_contraseña.Text = "";
                txt_contraseña.ForeColor = Color.LightGray;
                txt_contraseña.UseSystemPasswordChar = true;
            }
        }

        private void txt_contraseña_Leave(object sender, EventArgs e)
        {
            if (txt_contraseña.Text == "")
            {
                txt_contraseña.Text = "CONTRASEÑA";
                txt_contraseña.ForeColor = Color.DimGray;
                txt_contraseña.UseSystemPasswordChar = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Usuario: admin Contraseña: admin");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txt_contraseña.Text=="admin" && txt_usuario.Text=="admin")
            {

            }
            else
            {
                MessageBox.Show("Usuario o contraseña son incorrectos, verifique los datos.", "Error al iniciar sesion.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_usuario.Focus();
                txt_contraseña.Text = "";
            }
        }

        private void txt_contraseña_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
