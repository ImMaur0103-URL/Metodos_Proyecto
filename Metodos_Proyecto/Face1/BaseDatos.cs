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
        //string secondname,

        public BaseDatos(string dpi, string name, string address, DateTime fecha, List<string> companies)
        {
             
            DPI = dpi;
            Nombre = name;
            //Apellido = secondname;
            Direccion = address;
            FechaNacimiento = fecha;

            SET_Empresas(companies);
        }

        public string GET()
        {
            string empresas = "";
            for (int i = 0; i < Empresas_Lista.Count; i++)
            {
                if (i > 0)
                    empresas += ",";
                empresas += Convert.ToString(i) + ":" + Empresas_Lista[i].GET_NAME() + " | " + Empresas_Lista[i].GET_DPI_CODIFICADO();
            }
            return "{\"name\":\"" + Nombre + "\"," + "\"dpi\":\"" + DPI + "\"," + "\"datebirth\":\"" + Convert.ToString(FechaNacimiento) +
                "\"," + "\"address\":\"" + Direccion + "\"," + "\"companies\":[" + empresas + "]\"}";
        }
        public string GET_LIST_PRINT()
        {
            string imprimir = "";
            for (int i = 0; i < Empresas_Lista.Count; i++)
            {
                if (i > 0)
                    imprimir += ",\n";
                imprimir += Convert.ToString(i) + ":" + Empresas_Lista[i].GET_NAME() + " | " + Empresas_Lista[i].GET_DPI_CODIFICADO();
            }
            return imprimir;
        }
        public string GET_LIST_SERIALIZADO()
        {
            string imprimir = "";
            for (int i = 0; i < Empresas_Lista.Count; i++)
            {
                if (i > 0)
                    imprimir += ";";
                imprimir += Convert.ToString(i) + ":" + Empresas_Lista[i].GET_NAME() + " | " + Empresas_Lista[i].GET_DPI_CODIFICADO();
            }
            return imprimir;
        }


        public void PATCH(string NDireccion = "Sin Actualizar", string NFecha = "Sin Actualizar", string NEmpresasL = "Sin Actualizar", string NDPI = "Sin Actualizar", string Nname = "Sin Actualizar")
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
            if (NEmpresasL != Parametro)
            {
                SET_Empresas(NEmpresasL);                
            }

            DPI = NDPI;
            Nombre = Nname;
            Direccion = NDireccion;
            FechaNacimiento = Convert.ToDateTime(NFecha);
        }


        private void SET_Empresas(List<string> Insertar)
        {
            Empresas_Lista = new List<Empresas>();
            for (int i = 0; i < Insertar.Count; i++)
            {
                Empresas_Lista.Add(new Empresas(Insertar[i], DPI));
            }
        }
        private void SET_Empresas(string EmpresasSerializada)
        {
            string[] NEmpresas = EmpresasSerializada.Split(';');
            List<string> Lista_Empresas = new List<string>();
            for (int i = 0; i < NEmpresas.Length; i++)
            {
                Lista_Empresas.Add(NEmpresas[i].Split(':')[1].Split('|')[0]);
            }
            SET_Empresas(Lista_Empresas);
        }

    }
}
