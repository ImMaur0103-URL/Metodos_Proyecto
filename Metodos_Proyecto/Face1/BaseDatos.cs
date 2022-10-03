using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodos_Proyecto
{
    public class BaseDatos
    {
        public string DPI;
        public string Nombre;
        private string Apellido;
        private string Direccion;
        private DateTime FechaNacimiento;
        private List<Empresas> Empresas_Lista;
        private List<String> EmpresasL;
        //string secondname,

        public BaseDatos(string dpi, string name, string address, DateTime fecha, List<string> companies)
        {
             
            DPI = dpi;
            Nombre = name;
            //Apellido = secondname;
            Direccion = address;
            FechaNacimiento = fecha;

            EmpresasL = companies;
        }

        public string GET()
        {
            string empresas = "";
            for (int i = 0; i < EmpresasL.Count; i++)
            {
                empresas += EmpresasL[i];
                if(EmpresasL.Count - 1 != i)
                    empresas += ",";
            }
            return "{\"name\":\"" + Nombre + "\"," + "\"dpi\":\"" + DPI + "\"," + "\"datebirth\":\"" + Convert.ToString(FechaNacimiento) +
                "\"," + "\"address\":\"" + Direccion + "\"," + "\"companies\":[" + empresas + "]\"}";
        }
        public List<string> GET_LIST()
        {
            string imprimir = "\t" + Convert.ToString(j) + ":" + baseDatos.GET_LIST()[j] + "\n";
            return EmpresasL;
        }

        public void PATCH(string NDireccion = "Sin Actualizar", string NFecha = "Sin Actualizar", List<string> NEmpresasL = null, string NDPI = "Sin Actualizar", string Nname = "Sin Actualizar")
        {
            string Parametro = "Sin Actualizar";
            if (NDPI == Parametro)
                NDPI = DPI;
            if (Nname == Parametro)
                Nname = Nombre;
            if (NDireccion == Parametro)
                NDireccion = Direccion;
            if (NFecha == Parametro)
                NFecha = Convert.ToString(FechaNacimiento);
            if (NEmpresasL == null)
                NEmpresasL = EmpresasL;

            DPI = NDPI;
            Nombre = Nname;
            Direccion = NDireccion;
            FechaNacimiento = Convert.ToDateTime(NFecha);
        }


        private void SET_Empresas(List<string> Insertar)
        {
              
        }

    }
}
