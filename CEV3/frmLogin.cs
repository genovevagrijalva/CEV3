using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CEV3_Lib;

namespace CEV3
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            lblHora.Text = DateTime.Now.ToString();
          
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            DataTable Datos = CEV3_Lib.NInfoProf.Login(this.txtUser.Text,this.txtPassword.Text);
            //Valuar si existe el usuario
            if(Datos.Rows.Count==0)
            {
                MessageBox.Show("NO tiene Acceso al Sistema", "CEV3", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmCEV frm = new frmCEV();
                frm.IdProf = Datos.Rows[0][0].ToString();
                frm.ApellidoPaterno = Datos.Rows[0][1].ToString();
                frm.ApellidoMaterno = Datos.Rows[0][2].ToString();
                frm.Nombre = Datos.Rows[0][3].ToString();
                frm.Acceso = Datos.Rows[0][4].ToString();

                frm.Show();
                this.Hide();
            }
            
        }

        private void aDMINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                frmCEV frm = new frmCEV();
                frm.Show();
            
         
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) txtPassword.Focus();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) btnAceptar.Focus();
        }

      
       

        
    }
}
