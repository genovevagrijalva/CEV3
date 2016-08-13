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
    public partial class frmMateria : Form
    {
        private bool IsNuevo = false;

        private bool IsEditar = false;

        public frmMateria()
        {
            InitializeComponent();
            this.ttMen.SetToolTip(this.txtNomMateria, "Ingrese el Nombre de la Materia");
            this.ttMen.SetToolTip(this.txtbuscar, "Ingrese el Nombre de la Materia a Buscar");
            this.ttMen.SetToolTip(this.btnBuscar, "Busca la Materia ingresada");
            this.ttMen.SetToolTip(this.btnEliminar, "Elimina los registros Seleccionados");
            this.ttMen.SetToolTip(this.btnImprimir, "Imprime");
            this.ttMen.SetToolTip(this.chkEliminar, "Elimina varios registros");
            this.ttMen.SetToolTip(this.btnAlta, "Nuevo registro");
            this.ttMen.SetToolTip(this.btnGuardar, "Guarda el registro");
            this.ttMen.SetToolTip(this.btnModificar, "Modifica el registro");
            this.ttMen.SetToolTip(this.btnCancelar, "Cancela el registro");
            //this.txtIdMat.Visible = false;
        }
         //Mostrar Mensaje de Confirmacion
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Catalago de Materias", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Catalago de Materias", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar Controles del formulario
        private void Limpiar()
        {
            this.txtIdMat.Text = string.Empty;
            this.txtNomMateria.Text = string.Empty;
        }
        //Habilitar los controles del formulario
        private void Habilitar(bool Valor)
        {
            this.txtIdMat.ReadOnly = !Valor;
            this.txtNomMateria.ReadOnly = !Valor;
        }
         //Habilita los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) // Alt + 124
            {
                this.Habilitar(true);
                this.btnAlta.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnModificar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnAlta.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnModificar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }
        //Metodo para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataMaterias.Columns[0].Visible = false;
            this.dataMaterias.Columns[1].Visible = false;
        }
        //Método Mostrar()
        private void mostrar()
        {
            this.dataMaterias.DataSource = NMateria.Mostrar();
            this.OcultarColumnas();
            LblTotalM.Text = "Total de registros: " + Convert.ToString(dataMaterias.Rows.Count);
        }
        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            this.dataMaterias.DataSource = NMateria.BuscarNombre(this.txtbuscar.Text);
            this.OcultarColumnas();
            LblTotalM.Text = "Total de registros" + Convert.ToString(dataMaterias.Rows.Count);
        }

        private void frmMateria_Load(object sender, EventArgs e)
        {

            this.Top = 0;
            this.Left = 0;

            this.mostrar();
            this.Habilitar(false);
            this.Botones();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea Eliminar los Registros", "Catalago Materias", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string IdMateria;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataMaterias.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            IdMateria = Convert.ToString(row.Cells[1].Value);
                            Rpta = NMateria.Eliminar(Convert.ToInt32(IdMateria));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Elimino Correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }

                        }
                    }
                    this.mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNomMateria.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtNomMateria.Text == string.Empty)
                {
                    MensajeError("Falta igresa nombre de la materia");
                    errorIcon.SetError(txtNomMateria, "Ingrese Nombre de la Materia");

                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NMateria.Insertar(this.txtNomMateria.Text.Trim().ToUpper());



                    }
                    else
                    {
                        rpta = NMateria.Editar(Convert.ToInt32(this.txtIdMat.Text),
                            this.txtNomMateria.Text.Trim().ToUpper());
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Guardo de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizo de forma correcta el registro");
                        }
                    }   
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.mostrar();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdMat.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe seleccionar primero el registro a Modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataMaterias.Columns[0].Visible = true;
            }
            else
            {
                this.dataMaterias.Columns[0].Visible = false;
            }
        }

        private void dataMaterias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataMaterias.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataMaterias.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataMaterias_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdMat.Text = Convert.ToString(this.dataMaterias.CurrentRow.Cells["idMateria"].Value);
            this.txtNomMateria.Text = Convert.ToString(this.dataMaterias.CurrentRow.Cells["Materia"].Value);

            this.tabControl1.SelectedIndex = 1;
        } 
    }
}
