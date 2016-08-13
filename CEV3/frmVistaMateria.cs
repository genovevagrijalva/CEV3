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
    public partial class frmVistaMateria : Form
    {
        public frmVistaMateria()
        {
            InitializeComponent();
        }
        //Metodo para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            //this.dataListado.Columns[9].Visible = false;
            //this.dataListado.Columns[10].Visible = false;
            //this.dataListado.Columns[11].Visible = false;

        }

        //Método Mostrar()
        private void mostrar()
        {
            this.dataListado.DataSource = NMateria.Mostrar();
            this.OcultarColumnas();
            LblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NMateria.BuscarNombre(this.txtbuscar.Text);
            this.OcultarColumnas();
            LblTotal.Text = "Total de registros" + Convert.ToString(dataListado.Rows.Count);
        }

        private void frmVistaMateria_Load(object sender, EventArgs e)
        {
            this.mostrar();
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmProfesores form = frmProfesores.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["idMateria"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["materia"].Value);
            form.setMateria(par1, par2);
            this.Hide();
        }
    }
}
