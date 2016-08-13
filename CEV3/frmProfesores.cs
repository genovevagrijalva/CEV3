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
    public partial class frmProfesores : Form
    {
        private bool IsNuevo = false;

        private bool IsEditar = false;

        private static frmProfesores _Instancia;

        public static frmProfesores GetInstancia()
        {
            if(_Instancia==null)
            {
                _Instancia = new frmProfesores();
            }
            return _Instancia;
        }

        public void setMateria (string idMateria, string nomMateria)
        {
            this.txtIdMateria.Text = idMateria;
            this.txtMateria.Text = nomMateria;
        }

        public frmProfesores()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtApellidoPaterno, "Ingrese el Apellido Paterno del Profesor");
            this.ttMensaje.SetToolTip(this.txtApellidoMaterno, "Ingrese el Apellido Materno del Profesor");
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Profesor");
            this.ttMensaje.SetToolTip(this.pxImagen, "Seleccione la Foto del Profesor");
            this.ttMensaje.SetToolTip(this.dateTimeFecha, "Selecione la Fecha de Nacimiento del Profesor");
            this.ttMensaje.SetToolTip(this.txtExpediente, "Ingrese el Numero de Expediente del Profesor");
            this.ttMensaje.SetToolTip(this.cmbSexo, "Seleccione el Sexo del Profesor");
            this.ttMensaje.SetToolTip(this.txtTelefono, "Ingrese el Telefono del Profesor");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la Direccion del Profesor");
            this.ttMensaje.SetToolTip(this.txtUsuario, "Ingrese Usuario del Profesor");
            this.ttMensaje.SetToolTip(this.txtUsuario, "Ingrese el Password del Profesor");
            this.ttMensaje.SetToolTip(this.txtMateria, "Seleccione la Materia");
            this.ttMensaje.SetToolTip(this.cmbIdGrupo, "Seleccione el Grupo");
            this.txtIdMateria.Visible = false;
            this.txtMateria.ReadOnly = true;
            this.LlenarComboGrupo();
            this.txtMatricula.Enabled = false;

            cmbProf.Text = cmbProf.Items[0].ToString();
            cmbSexo.Text = cmbSexo.Items[0].ToString();
            cmbBuscar.Text = cmbBuscar.Items[0].ToString();

        }
        //Mostrar Mensaje de Confirmacion
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Administracion de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Administracion de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar Controles del formulario
        private void Limpiar()
        {
            this.txtMatricula.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApellidoPaterno.Text = string.Empty;
            this.txtApellidoMaterno.Text = string.Empty;
            this.dateTimeFecha.Text = string.Empty;
            this.txtExpediente.Text = string.Empty;
            this.cmbSexo.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.pxImagen.Image = global::CEV3.Properties.Resources.file;
            this.txtUsuario.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.txtIdMateria.Text = string.Empty;
            this.txtMateria.Text = string.Empty;
           // this.cmbIdGrupo.Text = string.Empty;
           
        }
        //Habilitar los controles del formulario
        private void Habilitar(bool Valor)
        {
            this.txtMatricula.ReadOnly = !Valor;
            this.txtNombre.ReadOnly = !Valor;
            this.txtApellidoPaterno.ReadOnly = !Valor;
            this.txtApellidoMaterno.ReadOnly = !Valor;
            this.dateTimeFecha.Enabled = Valor;
            this.txtExpediente.ReadOnly = !Valor;
            this.cmbSexo.Enabled = Valor;
            this.txtTelefono.ReadOnly = !Valor;
            this.txtDireccion.ReadOnly = !Valor;
            this.txtEmail.ReadOnly = !Valor;
            this.cmbIdGrupo.Enabled = Valor;
            //this.txtIdMateria.ReadOnly = !Valor;
            this.btnBuscarMateria.Enabled = Valor;
            this.pxImagen.Enabled = Valor;

           
            this.btnLimpiar.Enabled = Valor;
            
         
        
        }
        //Habilita los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
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
            this.dataRegistros.Columns[0].Visible = false;
            this.dataRegistros.Columns[1].Visible = false;
            this.dataRegistros.Columns[15].Visible = false;
            this.dataRegistros.Columns[17].Visible = false;
      
        }

        //Método Mostrar()
        private void mostrar()
        {
            this.dataRegistros.DataSource = NInfoProf.Mostrar();
            this.OcultarColumnas();
            LblTotal.Text = "Total de registros: " + Convert.ToString(dataRegistros.Rows.Count);
        }
        //Método BuscarNombre
        private void BuscarNombre()
        {
            this.dataRegistros.DataSource = NInfoProf.BuscarNombre(this.txtbuscar.Text);
            this.OcultarColumnas();
            LblTotal.Text = "Total de registros" + Convert.ToString(dataRegistros.Rows.Count);
        }
        //Método Buscar por numero de expediente
        private void BuscarNum_Expediente()
        {
            this.dataRegistros.DataSource = NInfoProf.BuscarNum_Expediente(this.txtbuscar.Text);
            this.OcultarColumnas();
            LblTotal.Text = "Total de registros" + Convert.ToString(dataRegistros.Rows.Count);
        }

        private void LlenarComboGrupo()
        {
            cmbIdGrupo.DataSource = NGrupo.Mostrar();
            cmbIdGrupo.ValueMember = "idGrupo";
            cmbIdGrupo.DisplayMember = "grupo";
        }
        private void frmProfesores_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbBuscar.Text.Equals("NOMBRE"))
            {
                this.BuscarNombre();
            }
            else if (cmbBuscar.Text.Equals("EXPEDIENTE"))
            {
                this.BuscarNum_Expediente();
            }
           
        }

        //private void txtbuscar_TextChanged(object sender, EventArgs e)
        //{
        //    this.BuscarNombre();
        //}

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea Eliminar los Registros", "Administracion",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string IdProf;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataRegistros.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            IdProf = Convert.ToString(row.Cells[1].Value);
                            Rpta = NInfoProf.Eliminar(Convert.ToInt32(IdProf));

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

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataRegistros.Columns[0].Visible = true;
            }
            else
            {
                this.dataRegistros.Columns[0].Visible = false;
            }
        }

        private void dataRegistros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataRegistros.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataRegistros.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtApellidoPaterno.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtApellidoPaterno.Text == string.Empty || this.txtApellidoMaterno.Text == string.Empty || this.txtNombre.Text == string.Empty
                    || this.cmbSexo.Text == string.Empty || this.txtTelefono.Text == string.Empty || this.txtDireccion.Text == string.Empty
                    || this.txtEmail.Text == string.Empty || this.txtUsuario.Text == string.Empty || this.txtPassword.Text == string.Empty
                    || this.txtIdMateria.Text == string.Empty || this.txtMateria.Text == string.Empty || this.cmbIdGrupo.Text == string.Empty)
                {
                    MensajeError("Falta igresar algunos datos, seran remarcados");
                    //errorIcono.SetError(txtApellidoPaterno, "Ingrese Apellido");
                    //errorIcono.SetError(txtApellidoMat, "Ingrese Apellido");
                    //errorIcono.SetError(txtNombre, "Ingrese Nombre");
                    //errorIcono.SetError(cmbSexo, "Seleccione Sexo");
                    //errorIcono.SetError(txtTelefono, "Ingrese Telefono");
                    //errorIcono.SetError(txtDireccion, "Ingrese Direccion");
                    //errorIcono.SetError(txtEmail, "Ingrese Email");
                    //errorIcono.SetError(txtUsuario, "Ingrese Usuario");
                    //errorIcono.SetError(txtPassword, "Ingrese Password");
                    //errorIcono.SetError(txtMateria, "Seleccione Materia");
                    //errorIcono.SetError(cmbIdGrupo, "Seleccione Grupo");
                }
                else
                {
                    //Para almacenar la imagen en el Buffer y despues llamar a nuestra variable imagen a nuestro metodo insertar
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                    byte[] imagen = ms.GetBuffer();
                    
                    if (this.IsNuevo)
                    {
                        rpta = NInfoProf.Insertar(
                            this.txtNombre.Text.Trim().ToUpper(), 
                            this.txtApellidoPaterno.Text.Trim().ToUpper(), 
                            this.txtApellidoMaterno.Text.Trim().ToUpper(),
                            this.cmbSexo.Text, 
                            dateTimeFecha.Value,this.txtExpediente.Text, this.txtDireccion.Text, this.txtTelefono.Text, this.txtEmail.Text, this.cmbProf.Text, this.txtUsuario.Text,
                            this.txtPassword.Text, imagen, Convert.ToInt32(this.cmbIdGrupo.SelectedValue), Convert.ToInt32(this.txtIdMateria.Text));


                       

                    }
                    else
                    {
                        rpta = NInfoProf.Editar(
                                Convert.ToInt32(this.txtMatricula.Text), 
                                this.txtNombre.Text.Trim().ToUpper(), 
                                this.txtApellidoPaterno.Text.Trim().ToUpper(), 
                                this.txtApellidoMaterno.Text.Trim().ToUpper(),
                                this.cmbSexo.Text, dateTimeFecha.Value,
                                this.txtExpediente.Text, 
                                this.txtDireccion.Text, 
                                this.txtTelefono.Text, this.txtEmail.Text, 
                                this.cmbProf.Text, 
                                this.txtUsuario.Text,
                                this.txtPassword.Text, 
                                imagen, 
                                Convert.ToInt32(this.cmbIdGrupo.SelectedValue), 
                                Convert.ToInt32(this.txtIdMateria.Text));
                        this.txtbuscar.Focus();
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
                MessageBox.Show("Error 100", ex.Message + ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.txtMatricula.Text = string.Empty;
            this.txtApellidoPaterno.Focus();
        }

        private void dataRegistros_DoubleClick(object sender, EventArgs e)
        {
            this.txtMatricula.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["idProf"].Value);
            this.txtApellidoPaterno.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["apellidoPaterno"].Value);
            this.txtApellidoMaterno.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["apellidoMaterno"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["nombre"].Value);
            this.cmbSexo.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["sexo"].Value);
            this.dateTimeFecha.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["fechaNacimiento"].Value);
            this.txtExpediente.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["numExpediente"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["email"].Value);
            this.cmbProf.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["acceso"].Value);
            this.txtUsuario.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["usuario"].Value);
            this.txtPassword.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["password"].Value);
            

            byte[] imagenBuffer = (byte[])this.dataRegistros.CurrentRow.Cells["imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);

            this.pxImagen.Image = Image.FromStream(ms);
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;

            this.txtIdMateria.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["idMateria"].Value);
            this.txtMateria.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["materia"].Value);
            this.cmbIdGrupo.SelectedValue = Convert.ToString(this.dataRegistros.CurrentRow.Cells["idGrupo"].Value);



            this.tabControl1.SelectedIndex = 1;

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(!this.txtMatricula.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);

            }
            else
            {
                this.MensajeError("Debe seleccionar primero el registro a modificar ");
            }
        }

        private void pxImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();

            if (result==DialogResult.OK)
            {
                this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pxImagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pxImagen.Image = global::CEV3.Properties.Resources.file;

        }

        private void btnBuscarMateria_Click(object sender, EventArgs e)
        {
            frmVistaMateria form = new frmVistaMateria();
            form.ShowDialog();
        }

        private void dataRegistros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtMatricula.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["idProf"].Value);
            this.txtApellidoPaterno.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["apellidoPaterno"].Value);
            this.txtApellidoMaterno.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["apellidoMaterno"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["nombre"].Value);
            this.cmbSexo.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["sexo"].Value);
            this.dateTimeFecha.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["fechaNacimiento"].Value);
            this.txtExpediente.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["numExpediente"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["email"].Value);
            this.cmbProf.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["acceso"].Value);
            this.txtUsuario.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["usuario"].Value);
            this.txtPassword.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["password"].Value);


            byte[] imagenBuffer = (byte[])this.dataRegistros.CurrentRow.Cells["imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);

            this.pxImagen.Image = Image.FromStream(ms);
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;

            this.txtIdMateria.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["idMateria"].Value);
            this.txtMateria.Text = Convert.ToString(this.dataRegistros.CurrentRow.Cells["materia"].Value);
            this.cmbIdGrupo.SelectedValue = Convert.ToString(this.dataRegistros.CurrentRow.Cells["idGrupo"].Value);



            this.tabControl1.SelectedIndex = 1;
        }

    }
}