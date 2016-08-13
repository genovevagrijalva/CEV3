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
    public partial class frmGrupo : Form
    {
        private bool IsNuevo = false;

        private bool IsEditar = false;

        public frmGrupo()
        {
            InitializeComponent();
            this.ttM.SetToolTip(this.txtGrupo, "Ingrese el Nombre del Grupo");
            this.ttM.SetToolTip(this.btnBuscar, "Busca el Grupo ingresado");
            this.ttM.SetToolTip(this.btnEliminar, "Elimina los registros Seleccionados");
            this.ttM.SetToolTip(this.btnImprimir, "Imprime");
            this.ttM.SetToolTip(this.chkEliminar, "Elimina varios registros");
            this.ttM.SetToolTip(this.btnAlta, "Nuevo registro");
            this.ttM.SetToolTip(this.btnGuardar, "Guarda el registro");
            this.ttM.SetToolTip(this.btnModificar, "Modifica el registro");
            this.ttM.SetToolTip(this.btnCancelar, "Cancela el registro");
            //this.txtIdGrupo.Visible = false;
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
            this.txtIdGrupo.Text = string.Empty;
            this.txtGrupo.Text = string.Empty;
        }
        //Habilitar los controles del formulario
        private void Habilitar(bool Valor)
        {
            this.txtIdGrupo.ReadOnly = !Valor;
            this.txtGrupo.ReadOnly = !Valor;
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
            this.dataGrupo.Columns[0].Visible = false;
            this.dataGrupo.Columns[1].Visible = false;
        }
        //Método Mostrar()
        private void mostrar()
        {
            this.dataGrupo.DataSource = NGrupo.Mostrar();
            this.OcultarColumnas();
            LblTotalG.Text = "Total de registros: " + Convert.ToString(dataGrupo.Rows.Count);
        }
        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            this.dataGrupo.DataSource = NGrupo.BuscarNombre(this.txtbuscar.Text);
            this.OcultarColumnas();
            LblTotalG.Text = "Total de registros" + Convert.ToString(dataGrupo.Rows.Count);
        }

        private void frmGrupo_Load(object sender, EventArgs e)
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
                Opcion = MessageBox.Show("Realmente desea Eliminar los Registros", "Catalago Grupos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string IdGrupo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataGrupo.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            IdGrupo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NGrupo.Eliminar(Convert.ToInt32(IdGrupo));

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
            this.txtGrupo.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtGrupo.Text == string.Empty)
                {
                    MensajeError("Falta ingresar Nombre");
                    errorIco.SetError(txtGrupo, "Ingrese Nombre del Grupo");

                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NGrupo.Insertar(this.txtGrupo.Text.Trim().ToUpper());



                    }
                    else
                    {
                        rpta = NGrupo.Editar(Convert.ToInt32(this.txtIdGrupo.Text),
                            this.txtGrupo.Text.Trim().ToUpper());
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
            if (!this.txtIdGrupo.Text.Equals(""))
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
                this.dataGrupo.Columns[0].Visible = true;
            }
            else
            {
                this.dataGrupo.Columns[0].Visible = false;
            }
        }

        private void dataGrupo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGrupo.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataGrupo.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataGrupo_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdGrupo.Text = Convert.ToString(this.dataGrupo.CurrentRow.Cells["idGrupo"].Value);
            this.txtGrupo.Text = Convert.ToString(this.dataGrupo.CurrentRow.Cells["grupo"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

    }
}
