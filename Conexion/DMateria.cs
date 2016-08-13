using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DB
{
   public class DMateria
    {
        private int _IdMateria;
        private string _Materia;
        private string _TextoBuscar;

        public int IdMateria
        {
            get 
            { 
                return _IdMateria;
            }
            set 
            { 
                _IdMateria = value;
            }
        }
        public string Materia
        {
            get
            { 
                return _Materia;
            }
            set 
            { 
                _Materia = value; 
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
        public DMateria()
        {

        }
        //Constructor con parametros
        public DMateria(int idMateria, string materia, string textobuscar)
        {
            this.IdMateria = idMateria;
            this.Materia = materia;
            this.TextoBuscar = textobuscar;
           
        }
        //Metodo Insertar
        public string Insertar(DMateria Materia)
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
                SqlCmd.CommandText = "spinsertar_materia";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdMateria = new SqlParameter();
                ParIdMateria.ParameterName = "@idMateria";
                ParIdMateria.SqlDbType = SqlDbType.Int;
                ParIdMateria.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdMateria);

                SqlParameter ParMateria = new SqlParameter();
                ParMateria.ParameterName = "@materia";
                ParMateria.SqlDbType = SqlDbType.VarChar;
                ParMateria.Size = 50;
                ParMateria.Value = Materia.Materia;
                SqlCmd.Parameters.Add(ParMateria);

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
        public string Editar(DMateria Materia)
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
                SqlCmd.CommandText = "speditar_materia";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdMateria = new SqlParameter();
                ParIdMateria.ParameterName = "@idMateria";
                ParIdMateria.SqlDbType = SqlDbType.Int;
                ParIdMateria.Value = Materia.IdMateria; 
                SqlCmd.Parameters.Add(ParIdMateria);

                SqlParameter ParMateria = new SqlParameter();
                ParMateria.ParameterName = "@materia";
                ParMateria.SqlDbType = SqlDbType.VarChar;
                ParMateria.Size = 50;
                ParMateria.Value = Materia.Materia;
                SqlCmd.Parameters.Add(ParMateria);

                //Ejecutamos nuestros comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizo el registro";



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
        public string Eliminar(DMateria Materia)
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
                SqlCmd.CommandText = "speliminar_materia";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdMateria = new SqlParameter();
                ParIdMateria.ParameterName = "@idMateria";
                ParIdMateria.SqlDbType = SqlDbType.Int;
                ParIdMateria.Value = Materia.IdMateria;
                SqlCmd.Parameters.Add(ParIdMateria);


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
        //Método utilizado para obtener todos las materias de la base de datos
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("materia");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //1. Establecer la cadena de conexion
                SqlCon.ConnectionString = Conexion.Cn;

                //2. Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;//La conexión que va a usar el comando
                SqlCmd.CommandText = "spmostrar_materia";//El comando a ejecutar
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //Decirle al comando que va a ejecutar una sentencia SQL

                //3. No hay parámetros

                //4. El DataAdapter que va a ejecutar el comando y es el encargado de llenar el DataTable
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);//Llenamos el DataTable
            }
            catch (Exception)
            {
                DtResultado = null;

            }
            return DtResultado;
        }
        public DataTable BuscarNombre(DMateria Materia)
        {
            DataTable DtResultado = new DataTable("materia");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //1. Establecer la cadena de conexion
                SqlCon.ConnectionString = Conexion.Cn;

                //2. Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;//La conexión que va a usar el comando
                SqlCmd.CommandText = "spbuscar_materia";//El comando a ejecutar
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //Decirle al comando que va a ejecutar una sentencia SQL

                //3.Enviamos el parámetro de Búsqueda
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Materia.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

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
