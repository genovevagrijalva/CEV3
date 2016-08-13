using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DB
{
    public class DGrupo
    {
    private int _IdGrupo;
        private string _Grupo;
        private string _TextoBuscar;

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
        public string Grupo
        {
            get
            { 
                return _Grupo;
            }
            set 
            { 
                _Grupo = value; 
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
        public DGrupo()
        {

        }
        //Constructor con parametros
        public DGrupo(int idGrupo, string grupo, string textobuscar)
        {
            this.IdGrupo = idGrupo;
            this.Grupo = grupo;
            this.TextoBuscar = textobuscar;
           
        }
        //Metodo Insertar
        public string Insertar(DGrupo Grupo)
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
                SqlCmd.CommandText = "spinsertar_grupo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdGrupo = new SqlParameter();
                ParIdGrupo.ParameterName = "@idGrupo";
                ParIdGrupo.SqlDbType = SqlDbType.Int;
                ParIdGrupo.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdGrupo);

                SqlParameter ParGrupo = new SqlParameter();
                ParGrupo.ParameterName = "@grupo";
                ParGrupo.SqlDbType = SqlDbType.VarChar;
                ParGrupo.Size = 50;
                ParGrupo.Value = Grupo.Grupo;
                SqlCmd.Parameters.Add(ParGrupo);

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
        public string Editar(DGrupo Grupo)
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
                SqlCmd.CommandText = "speditar_grupo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdGrupo = new SqlParameter();
                ParIdGrupo.ParameterName = "@idGrupo";
                ParIdGrupo.SqlDbType = SqlDbType.Int;
                ParIdGrupo.Value = Grupo.IdGrupo; 
                SqlCmd.Parameters.Add(ParIdGrupo);

                SqlParameter ParGrupo = new SqlParameter();
                ParGrupo.ParameterName = "@grupo";
                ParGrupo.SqlDbType = SqlDbType.VarChar;
                ParGrupo.Size = 50;
                ParGrupo.Value = Grupo.Grupo;
                SqlCmd.Parameters.Add(ParGrupo);

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
        public string Eliminar(DGrupo Grupo)
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
                SqlCmd.CommandText = "speliminar_grupo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdGrupo = new SqlParameter();
                ParIdGrupo.ParameterName = "@idGrupo";
                ParIdGrupo.SqlDbType = SqlDbType.Int;
                ParIdGrupo.Value = Grupo.IdGrupo;
                SqlCmd.Parameters.Add(ParIdGrupo);


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
            DataTable DtResultado = new DataTable("grupo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //1. Establecer la cadena de conexion
                SqlCon.ConnectionString = Conexion.Cn;

                //2. Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;//La conexión que va a usar el comando
                SqlCmd.CommandText = "spmostrar_grupos";//El comando a ejecutar
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
        public DataTable BuscarNombre(DGrupo Grupo)
        {
            DataTable DtResultado = new DataTable("grupo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //1. Establecer la cadena de conexion
                SqlCon.ConnectionString = Conexion.Cn;

                //2. Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;//La conexión que va a usar el comando
                SqlCmd.CommandText = "spbuscar_grupo";//El comando a ejecutar
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //Decirle al comando que va a ejecutar una sentencia SQL

                //3.Enviamos el parámetro de Búsqueda
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Grupo.TextoBuscar;
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
