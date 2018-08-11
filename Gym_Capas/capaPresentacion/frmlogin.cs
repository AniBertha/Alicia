using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaNegocios;
using MySql.Data.MySqlClient;

namespace capaPresentacion
{
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if(txtUsuario.Text=="USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtContra_Enter(object sender, EventArgs e)
        {
            if (txtContra.Text == "CONTRASEÑA")
            {
                txtContra.Text = "";
                txtContra.ForeColor = Color.DimGray;
                txtContra.UseSystemPasswordChar = true;
            }
        }

        private void txtContra_Leave(object sender, EventArgs e)
        {
            if (txtContra.Text == "")
            {
                txtContra.Text = "CONTRASEÑA";
                txtContra.ForeColor = Color.DimGray;
                txtContra.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CNEmpleados objEmpleado = new CNEmpleados();
            MySqlDataReader Loguear;
            objEmpleado.Usuario = txtUsuario.Text;
            objEmpleado.Contrasenia = txtContra.Text;
            if(objEmpleado.Usuario == txtUsuario.Text)
            {
                lblErrorUsuario.Visible = false;

                if (objEmpleado.Contrasenia == txtContra.Text)
                {
                    lblErrorContra.Visible = false;

                    Loguear = objEmpleado.iniciarSesion();
                    if (Loguear.Read() == true)
                    {
                        this.Hide();
                        frmPrincipal objFP = new frmPrincipal();
                        Program.Cargo = Loguear["tipo_de_usuario"].ToString();
                        Program.Nombre=Loguear["nombre"].ToString();
                        Program.Apellidos = Loguear["apellido"].ToString();
                        Program.Correo=Loguear["correo_elec"].ToString();
                        objFP.Show();
                    }
                    else
                    {
                        lblErrorLogin.Text = "¡Usuario o contraseña invalidos!";
                        lblErrorLogin.Visible = true;
                        txtContra.Text = "";
                        txtContra_Leave(null,e);
                        txtContra_Enter(null,e);
                        txtContra.Focus();
                    }
                }
                else
                {
                    lblErrorContra.Text = objEmpleado.Contrasenia;
                    lblErrorLogin.Visible = false;
                    lblErrorContra.Visible = true;
                }
            }
            else
            {
                lblErrorUsuario.Text = objEmpleado.Usuario;
                lblErrorUsuario.Visible = true;
            }

        }

        private void txtContra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==Convert.ToChar(Keys.Enter))
            {
                btnLogin.PerformClick();
            }
        }

        private void linkContra_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRecuperarContra objRP = new frmRecuperarContra();
            objRP.Show();

        }
    }
}
