using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using System.Data;

namespace CEV3_Lib
{
    public class NMateria
    {
        //Método que llama al método Insertar de la Capa de Datos de la clase DMateria
        public static string Insertar(string materia)
        {
            DMateria Obj = new DMateria();
            Obj.Materia = materia;
            return Obj.Insertar(Obj);
        }
        //Método que llama al método Actualizar de la Capa de Datos de la clase DMateria
        public static string Editar(int idMateria, string materia)
        {
            DMateria Obj = new DMateria();
            Obj.IdMateria = idMateria;
            Obj.Materia = materia;
            return Obj.Editar(Obj);
        }
         //Método que se encarga de llamar al método Eliminar de la clase DMateria
        public static string Eliminar(int idMateria)
        {
            DMateria Obj = new DMateria();
            Obj.IdMateria = idMateria;

            return Obj.Eliminar(Obj);
        }

        //Método que se encarga de llamar al método Obtener la materia de la clase materia
        public static DataTable Mostrar()
        {
            return new DMateria().Mostrar();
        }

        //Método BuscarNombre que llama al Método BuscarNombre de la clase DMateria de la capa de datos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DMateria Obj = new DMateria();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }

    }
}
