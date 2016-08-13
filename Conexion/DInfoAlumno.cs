using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DB
{
    public class DInfoAlumno
    {
        private int _IdAlumno;
        private string _Nombre;
        private string _ApellidoPaterno;
        private string _ApellidoMaterno;
        private string _Sexo;
        private DateTime _FechaNacimiento;
        private string _NumExpediente;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Acceso;
        private string _Usuario;
        private string _Password;
        private byte[] _Imagen;
          
     
        private int _IdGrupo;
        private string _TextoBuscar;

        public int IdAlumno
        {
            get
            {
                return _IdAlumno;
            }

            set
            {
                _IdAlumno = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }
        public string ApellidoPaterno
        {
            get
            { 
                return _ApellidoPaterno; 
            }
            set 
            { 
                _ApellidoPaterno = value; 
            }
        }
        public string ApellidoMaterno
        {
            get 
            { 
                return _ApellidoMaterno; 
            }
            set 
            {
                _ApellidoMaterno = value; 
            }
        }
        public string Sexo
        {
            get 
            { 
                return _Sexo;
            }
            set
            {
                _Sexo = value;
            }
        }
        public DateTime FechaNacimiento
        {
            get
            {
                return _FechaNacimiento; 
            }
            set 
            { 
                _FechaNacimiento = value;
            }
        }
        public string NumExpediente
        {
            get 
            { 
                return _NumExpediente;
            }
            set
            { 
                _NumExpediente = value; 
            }
        }
        public string Direccion
        {
            get
            {
                return _Direccion;
            }

            set
            {
                _Direccion = value;
            }
        }
        public string Telefono
        {
            get 
            { 
                return _Telefono; 
            }
            set 
            { 
                _Telefono = value; 
            }
        }
        public string Email
        {
            get
            { 
                return _Email; 
            }
            set
            {
                _Email = value; 
            }
        }
        public string Acceso
        {
            get
            { 
                return _Acceso;
            }
            set
            { 
                _Acceso = value; 
            }
        }
        public string Usuario
        {
            get
            { 
                return _Usuario;
            }
            set 
            { 
                _Usuario = value;
            }
        }
        public string Password
        {
            get 
            { 
                return _Password;
            }
            set 
            { 
                _Password = value; 
            }
        }
        public byte[] Imagen
        {
            get
            {
                return _Imagen;
            }
            set
            {
                _Imagen = value;
            }
        }
        
        
        
        public int IdGrupo
        {
            get
            { 
                return _IdGrupo;
            }
            set
            { 
                _IdGrupo = value;
            }
        }

        public string TextoBuscar
        {
            get
            {
                return _TextoBuscar;
            }

            set
            {
                _TextoBuscar = value;
            }
        }
        
        //Constructor vacio
        public DInfoAlumno()
        {

        }
        //Constructor con parametros
        public DInfoAlumno(int idAlumno, string nombre, string apellidoPaterno, string apellidoMaterno, string sexo, DateTime fechaNacimiento,string numExpediente, string direccion,string telefono, string email, string acceso,
                          string usuario, string password, byte[] imagen, int idGrupo, string textobuscar)
        {
            this.IdAlumno = idAlumno;
            this.Nombre = nombre;
            this.ApellidoPaterno = apellidoPaterno;
            this.ApellidoMaterno = apellidoMaterno;
            this.Sexo = sexo;
            this.FechaNacimiento = fechaNacimiento;
            this.NumExpediente = numExpediente;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Acceso = acceso;
            this.Usuario = usuario;
            this.Password = password;
            this.Imagen = imagen;
            
           
            this.IdGrupo = idGrupo;
            this.TextoBuscar = textobuscar;
        }

        //Metodo Insertar
        public string Insertar(DInfoAlumno Alumno)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_alumno";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdAlumno = new SqlParameter();
                ParIdAlumno.ParameterName = "@idAlumno";
                ParIdAlumno.SqlDbType = SqlDbType.Int;
                ParIdAlumno.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdAlumno);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Alumno.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidoPaterno = new SqlParameter();
                ParApellidoPaterno.ParameterName = "@apellidoPaterno";
                ParApellidoPaterno.SqlDbType = SqlDbType.VarChar;
                ParApellidoPaterno.Size = 50;
                ParApellidoPaterno.Value = Alumno.ApellidoPaterno;
                SqlCmd.Parameters.Add(ParApellidoPaterno);

                SqlParameter ParApellidoMaterno = new SqlParameter();
                ParApellidoMaterno.ParameterName = "@apellidoMaterno";
                ParApellidoMaterno.SqlDbType = SqlDbType.VarChar;
                ParApellidoMaterno.Size = 50;
                ParApellidoMaterno.Value = Alumno.ApellidoMaterno;
                SqlCmd.Parameters.Add(ParApellidoMaterno);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 1;
                ParSexo.Value = Alumno.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParFechaNacimiento = new SqlParameter();
                ParSexo.ParameterName = "@fechaNacimiento";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 50;
                ParSexo.Value = Alumno.FechaNacimiento;
                SqlCmd.Parameters.Add(ParFechaNacimiento);

                SqlParameter ParNumExpediente = new SqlParameter();
                ParNumExpediente.ParameterName = "@numExpediente";
                ParNumExpediente.SqlDbType = SqlDbType.VarChar;
                ParNumExpediente.Size = 8;
                ParNumExpediente.Value = Alumno.NumExpediente;
                SqlCmd.Parameters.Add(ParNumExpediente);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 50;
                ParDireccion.Value = Alumno.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 10;
                ParTelefono.Value = Alumno.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size =50;
                ParEmail.Value = Alumno.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 20;
                ParAcceso.Value = Alumno.Acceso;
                SqlCmd.Parameters.Add(ParAcceso);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Alumno.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.Int;
                ParPassword.Size = 20;
                ParPassword.Value = Alumno.Password;
                SqlCmd.Parameters.Add(ParPassword);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Alumno.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                
               

                SqlParameter ParIdGrupo = new SqlParameter();
                ParIdGrupo.ParameterName = "@idGrupo";
                ParIdGrupo.SqlDbType = SqlDbType.VarChar;
                ParIdGrupo.Value = Alumno.IdGrupo;
                SqlCmd.Parameters.Add(ParIdGrupo);

                //Ejecutamos nuestros comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";

            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        //Metodo Editar
        public string Editar(DInfoAlumno Alumno)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_alumno";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdAlumno = new SqlParameter();
                ParIdAlumno.ParameterName = "@idAlumno";
                ParIdAlumno.SqlDbType = SqlDbType.Int;
                ParIdAlumno.Value = Alumno.IdAlumno;
                SqlCmd.Parameters.Add(ParIdAlumno);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Alumno.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidoPaterno = new SqlParameter();
                ParApellidoPaterno.ParameterName = "@apellidoPaterno";
                ParApellidoPaterno.SqlDbType = SqlDbType.VarChar;
                ParApellidoPaterno.Size = 50;
                ParApellidoPaterno.Value = Alumno.ApellidoPaterno;
                SqlCmd.Parameters.Add(ParApellidoPaterno);

                SqlParameter ParApellidoMaterno = new SqlParameter();
                ParApellidoMaterno.ParameterName = "@apellidoMaterno";
                ParApellidoMaterno.SqlDbType = SqlDbType.VarChar;
                ParApellidoMaterno.Size = 50;
                ParApellidoMaterno.Value = Alumno.ApellidoMaterno;
                SqlCmd.Parameters.Add(ParApellidoMaterno);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 1;
                ParSexo.Value = Alumno.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParFechaNacimiento = new SqlParameter();
                ParSexo.ParameterName = "@fechaNacimiento";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 50;
                ParSexo.Value = Alumno.FechaNacimiento;
                SqlCmd.Parameters.Add(ParFechaNacimiento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 256;
                ParDireccion.Value = Alumno.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 10;
                ParTelefono.Value = Alumno.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 30;
                ParEmail.Value = Alumno.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 30;
                ParAcceso.Value = Alumno.Acceso;
                SqlCmd.Parameters.Add(ParAcceso);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 30;
                ParUsuario.Value = Alumno.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.Int;
                ParPassword.Size = 10;
                ParPassword.Value = Alumno.Password;
                SqlCmd.Parameters.Add(ParPassword);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                
                ParImagen.Value = Alumno.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                

              

                SqlParameter ParIdGrupo = new SqlParameter();
                ParIdGrupo.ParameterName = "@idGrupo";
                ParIdGrupo.SqlDbType = SqlDbType.VarChar;
                ParIdGrupo.Value = Alumno.IdGrupo;
                SqlCmd.Parameters.Add(ParIdGrupo);

                //Ejecutamos nuestros comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se actualizo el registro";

            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;

        }

        //Metodo Eliminar
        public string Eliminar(DInfoAlumno Alumno)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_alumno";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdAlumno = new SqlParameter();
                ParIdAlumno.ParameterName = "@idAlumno";
                ParIdAlumno.SqlDbType = SqlDbType.Int;
                ParIdAlumno.Value = Alumno.IdAlumno;
                SqlCmd.Parameters.Add(ParIdAlumno);


                //Ejecutamos nuestros comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el registro";
            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;

        }

        //Método utilizado para obtener todos los profesor de la base de datos
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("alumno");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //1. Establecer la cadena de conexion
                SqlCon.ConnectionString = Conexion.Cn;

                //2. Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;//La conexión que va a usar el comando
                SqlCmd.CommandText = "spmostrar_alumno";//El comando a ejecutar
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //Decirle al comando que va a ejecutar una sentencia SQL

                //3. No hay parámetros

                //4. El DataAdapter que va a ejecutar el comando y
                //es el encargado de llena el DataTable
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);//Llenamos el DataTable
            }
            catch (Exception )
            {
                DtResultado = null;

            }
            return DtResultado;
        }

        public DataTable BuscarNombre(DInfoAlumno Alumno)
        {
            DataTable DtResultado = new DataTable("alumno");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //1. Establecer la cadena de conexion
                SqlCon.ConnectionString = Conexion.Cn;

                //2. Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;//La conexión que va a usar el comando
                SqlCmd.CommandText = "spbuscar_alumno";//El comando a ejecutar
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //Decirle al comando que va a ejecutar una sentencia SQL

                //3.Enviamos el parámetro de Búsqueda
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Alumno.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                //4. El DataAdapter que va a ejecutar el comando y es el encargado de llena el DataTable
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);//Llenamos el DataTable
            }
            catch (Exception )
            {
                DtResultado = null;

            }
            return DtResultado;
        }
        
        
        public DataTable Login(DInfoAlumno Alumno)
        {
            DataTable DtResultado = new DataTable("alumno");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //1. Establecer la cadena de conexion
                SqlCon.ConnectionString = Conexion.Cn;

                //2. Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;//La conexión que va a usar el comando
                SqlCmd.CommandText = "splogin_alumno";//El comando a ejecutar
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //Decirle al comando que va a ejecutar una sentencia SQL

                //3.Enviamos el parámetro de Búsqueda
                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Alumno.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.Int;
               ParPassword.Size = 20;
                ParPassword.Value = Alumno.Password;
                SqlCmd.Parameters.Add(ParPassword);

                //4. El DataAdapter que va a ejecutar el comando y es el encargado de llena el DataTable
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);//Llenamos el DataTable
            }
            catch (Exception)
            {
                DtResultado = null;

            }
            return DtResultado;
        }


    }

    
}
