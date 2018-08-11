using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            abrirFormInPane(new frmProductos());

        }

        private void PrivilegioUsuario()
        {
            if(Program.Cargo!="Administrador")
            {
                btnCompras.Enabled = false;
                btnReportes.Enabled = false;
                btnConfiguracion.Enabled = false;
            }
        }

        private void MostrarUsuarioActivo()
        {
            lblCargo.Text = Program.Cargo;
            lblNombre.Text = Program.Nombre;
            lblApellido.Text = Program.Apellidos;
            lblCorreo.Text = Program.Correo;
        }

      

        private void btnSlide_Click(object sender, EventArgs e)
        {
            if (menuVertical.Width == 250 )
            {
                if (submenuReportes.Visible==true)
                {
                    submenuReportes.Visible = false;
                    btnConfiguracion.Visible = true;

                }
                menuVertical.Width = 81;
            }
            else               
                menuVertical.Width = 250;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmlogin regresar = new frmlogin();
            regresar.Show();

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


      

        private void abrirFormInPane(object formHijo)
        {

            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
                Form fh = formHijo as Form;
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.panelContenedor.Controls.Add(fh);
                this.panelContenedor.Tag = fh;
                fh.Show();
            
            
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(submenuReportes.Visible==true)
            {
                submenuReportes.Visible = false;
                btnConfiguracion.Visible = true;
            }
            abrirFormInPane(new frmProductos());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            abrirFormInPane(new frmConfiguracion());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (menuVertical.Width == 81)
                menuVertical.Width = 250;
            if (submenuReportes.Visible == false)
            {
                submenuReportes.Visible = true;
                btnConfiguracion.Visible = false;
            }
            
            else
            {
                submenuReportes.Visible = false;
                btnConfiguracion.Visible = true;
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (submenuReportes.Visible == true)
            {
                submenuReportes.Visible = false;
                btnConfiguracion.Visible = true;
            }
            abrirFormInPane(new frmCompras());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (submenuReportes.Visible == true)
            {
                submenuReportes.Visible = false;
                btnConfiguracion.Visible = true;
            }
            abrirFormInPane(new frmVentas());
        }

        private void btnReporteVentas_Click(object sender, EventArgs e)
        {
            submenuReportes.Visible = false;
            btnConfiguracion.Visible = true;
            abrirFormInPane(new frmReportesVentas());
        }

        private void btnReporteCompras_Click(object sender, EventArgs e)
        {
            submenuReportes.Visible = false;
            btnConfiguracion.Visible = true;
            abrirFormInPane(new frmReportesCompras());
        }

        private void menuVertical_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            PrivilegioUsuario();
            MostrarUsuarioActivo();
            
           
        }

        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblHora_Click(object sender, EventArgs e)
        {

        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
