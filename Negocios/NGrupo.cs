using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using System.Data;

namespace CEV3_Lib
{
    public class NGrupo
    {
        //Método que llama al método Insertar de la Capa de Datos de la clase DMateria
        public static string Insertar(string grupo)
        {
            DGrupo Obj = new DGrupo();
            Obj.Grupo = grupo;
            return Obj.Insertar(Obj);
        }
        //Método que llama al método Actualizar de la Capa de Datos de la clase DMateria
        public static string Editar(int idGrupo, string grupo)
        {
            DGrupo Obj = new DGrupo();
            Obj.IdGrupo = idGrupo;
            Obj.Grupo = grupo;
            return Obj.Editar(Obj);
        }
        //Método que se encarga de llamar al método Eliminar de la clase DGrupo
        public static string Eliminar(int idGrupo)
        {
            DGrupo Obj = new DGrupo();
            Obj.IdGrupo = idGrupo;

            return Obj.Eliminar(Obj);
        }

        //Método que se encarga de llamar al método Obtener el grupo de la clase grupo
        public static DataTable Mostrar()
        {
            return new DGrupo().Mostrar();
        }

        //Método BuscarNombre que llama al Método BuscarNombre de la clase DGrupo de la capa de datos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DGrupo Obj = new DGrupo();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }

    
}
