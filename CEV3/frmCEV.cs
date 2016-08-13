using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEV3
{
    public partial class frmCEV : Form
    {
        public string IdProf = "";
        public string ApellidoPaterno = "";
        public string ApellidoMaterno = "";
        public string Nombre = "";
        public string Acceso = "";

        public frmCEV()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void profesoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProfesores frm =frmProfesores.GetInstancia();
            frm.ShowDialog();
        }

        private void alumnosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmInfoAlumno alumno = new frmInfoAlumno();
            alumno.ShowDialog();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMateria materia = new frmMateria();
            materia.Show();
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGrupo grupo = new frmGrupo();
            grupo.Show();

        }

        private void frmCEV_Load(object sender, EventArgs e)
        {
            GestionUsuario();
            
        }
        private void GestionUsuario()
        {
            //Controlar los accesos
            if(Acceso == "PROFESOR")
            {
                //new frmPrincipalProf().Show();
                this.iNGRESAToolStripMenuItem.Enabled = true;
                this.administracionToolStripMenuItem.Enabled = false;
                this.profToolStripMenuItem1.Enabled= true;
                this.alumToolStripMenuItem1.Enabled=false;
                this.herramientasToolStripMenuItem.Enabled = false;
                this.aYUDAToolStripMenuItem.Enabled = true;
            }
            else if (Acceso == "ALUMNO")
            {
                //new frmPrincipalAlum().Show();
                this.iNGRESAToolStripMenuItem.Enabled = true;
                this.administracionToolStripMenuItem.Enabled = false;
                this.profToolStripMenuItem1.Enabled = false;
                this.alumToolStripMenuItem1.Enabled = true;
                this.herramientasToolStripMenuItem.Enabled = false;
                this.aYUDAToolStripMenuItem.Enabled = true;

            }
            else if (Acceso == "ADMINISTRADOR")
            {
               //new frmCEV().Show();
                this.iNGRESAToolStripMenuItem.Enabled = true;
                this.administracionToolStripMenuItem.Enabled = true;
                this.profToolStripMenuItem1.Enabled = true;
                this.alumToolStripMenuItem1.Enabled = true;
                this.herramientasToolStripMenuItem.Enabled = true;
                this.aYUDAToolStripMenuItem.Enabled = true;
               
               
            }
            else
            {
                MessageBox.Show("Usuario no encontrado","CEV3", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.iNGRESAToolStripMenuItem.Enabled = false;
                //this.administracionToolStripMenuItem.Enabled = false;
                //this.profesoresToolStripMenuItem1.Enabled = false;
                //this.alumnosToolStripMenuItem1.Enabled = false;
                //this.herramientasToolStripMenuItem.Enabled = false;
                //this.aYUDAToolStripMenuItem.Enabled = false;


            }
        }

        private void alumToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPrincipalAlum alumno = new frmPrincipalAlum();
            alumno.Show();
      
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAcerdade acerca = new frmAcerdade();
            acerca.Show();
        }

        private void frmCEV_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
          if(MessageBox.Show("Desea cambiar de usuario", "CEV3", MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)== DialogResult.Yes)
          {
              this.Close();
              frmLogin frm = new frmLogin();
              frm.ShowDialog();
              
          }
          else
          {
              
          }


            

        }
    }
}
