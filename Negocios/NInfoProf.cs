using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB;
using System.Data;

namespace CEV3_Lib
{
    public class NInfoProf
    {
        //Método que llama al método Insertar de la Capa de Datos de la clase DProfesores
        public static string Insertar(string nombre, string apellidoPaterno, string apellidoMaterno, string sexo, DateTime fechaNacimiento, string numExpediente, string direccion, string telefono, string email, string acceso, string usuario, string password,byte[] imagen,  int idMateria, int idGrupo)
        {
           DInfoProf Obj = new DInfoProf();
            Obj.Nombre = nombre;
            Obj.ApellidoPaterno = apellidoPaterno;

            Obj.ApellidoMaterno = apellidoMaterno;
            Obj.Sexo = sexo;
            
           
            Obj.FechaNacimiento = fechaNacimiento;
            Obj.NumExpediente = numExpediente;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;
            Obj.Imagen = imagen;
           
            Obj.IdMateria = idMateria;
            Obj.IdGrupo = idGrupo;
            return Obj.Insertar(Obj);
        }
        //Método que llama al método Actualizar de la Capa de Datos de la clase Dproductos
        public static string Editar(int idProf, string nombre, string apellidoPaterno, string apellidoMaterno, string sexo, DateTime fechaNacimiento,string numExpediente, string direccion, string telefono, string email, string acceso, string usuario, string password,byte[] imagen, int idMateria, int idGrupo)
        {
            DInfoProf Obj = new DInfoProf();
            Obj.IdProf = idProf;
            Obj.Nombre = nombre;
            Obj.ApellidoPaterno = apellidoPaterno;
            Obj.ApellidoMaterno = apellidoMaterno;
            Obj.Sexo = sexo;
            Obj.FechaNacimiento = fechaNacimiento;
            Obj.NumExpediente = numExpediente;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;
            Obj.Imagen = imagen;
            
            Obj.IdMateria = idMateria;
            Obj.IdGrupo = idGrupo;
            return Obj.Editar(Obj);
        }

        //Método que se encarga de llamar al método Eliminar de la clase DInfoProf
        public static string Eliminar(int Idprof)
        {
            DInfoProf Obj = new DInfoProf();
            Obj.IdProf = Idprof;

            return Obj.Eliminar(Obj);
        }

        //Método que se encarga de llamar al método Mostrar de la clase DInfoProf
        public static DataTable Mostrar()
        {
            return new DInfoProf().Mostrar();
        }

        //Método BuscarNombre que llama al Método BuscarNombre de la clase DInfoProf de la capa de datos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DInfoProf Obj = new DInfoProf();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
        //Método que busca al profesor mediante su numero de expediente, llamando al Método en la clase DInfoProf
        public static DataTable BuscarNum_Expediente(string textobuscar)
        {
            DInfoProf Obj = new DInfoProf();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_Expediente(Obj);
        }
        public static DataTable Login(string usuario, string password)
        {
            DInfoProf Obj = new DInfoProf();
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Login(Obj);
        }

    }
}