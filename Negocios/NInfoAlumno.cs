using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using System.Data;


namespace CEV3_Lib
{
    public class NInfoAlumno
    {
        //Método que llama al método Insertar de la Capa de Datos de la clase DProfesores
        public static string Insertar(string nombre, string apellidoPaterno, string apellidoMaterno, string sexo, DateTime fechaNacimiento, string numExpediente, string direccion, string telefono, string email, string acceso, string usuario, string password, byte[] imagen, int idGrupo)
        {
            DInfoAlumno Obj = new DInfoAlumno();
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

      
            Obj.IdGrupo = idGrupo;
            return Obj.Insertar(Obj);
        }
        //Método que llama al método Actualizar de la Capa de Datos de la clase Dproductos
        public static string Editar(int idAlumno, string nombre, string apellidoPaterno, string apellidoMaterno, string sexo, DateTime fechaNacimiento, string numExpediente, string direccion, string telefono, string email, string acceso, string usuario, string password, byte[] imagen, int idGrupo)
        {
            DInfoAlumno Obj = new DInfoAlumno();
            Obj.IdAlumno = idAlumno;
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

        
            Obj.IdGrupo = idGrupo;
            return Obj.Editar(Obj);
        }

        //Método que se encarga de llamar al método Eliminar de la clase DInfoProf
        public static string Eliminar(int idAlumno)
        {
            DInfoAlumno Obj = new DInfoAlumno();
            Obj.IdAlumno = idAlumno;

            return Obj.Eliminar(Obj);
        }

        //Método que se encarga de llamar al método Mostrar de la clase DInfoProf
        public static DataTable Mostrar()
        {
            return new DInfoAlumno().Mostrar();
        }

        //Método BuscarNombre que llama al Método BuscarNombre de la clase DInfoProf de la capa de datos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DInfoAlumno Obj = new DInfoAlumno();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
       
        public static DataTable Login(string usuario, string password)
        {
            DInfoAlumno Obj = new DInfoAlumno();
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Login(Obj);
        }
    }

    
}
