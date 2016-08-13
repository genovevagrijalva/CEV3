using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;

namespace CEV3_Lib
{
    public class Acceso
    {
        private static DInfoProf datos;
        public static void inicio()
        {
            datos = new DInfoProf();
        }
        public static void establecerId(int id)
        {
            datos.IdProf = id;
        }
        public static int obtenerId()
        {
            return datos.IdProf;
        }
        public static void establecerNumExp(string numExpediente)
        {
            datos.NumExpediente = numExpediente;
        }
        public static string obtenerApePat()
        {
            return datos.ApellidoPaterno;
        }
        public static void establecerApePat(string apellidoPaterno)
        {
            datos.ApellidoPaterno=apellidoPaterno;
        }
        public static string obtenerApePat()
        {
            return datos.ApellidoPaterno;
        }
        public static void establecerApeMat(string apellidoMaterno)
        {
            datos.ApellidoMaterno = apellidoMaterno;
        }
        public static string obtenerApeMat()
        {
            return datos.ApellidoMaterno;
        }
        public static void establecerNombre(string nombre)
        {
            datos.Nombre = nombre;
        }
        public static string obtenerNombre()
        {
            return datos.Nombre;
        }
      
    }
}
