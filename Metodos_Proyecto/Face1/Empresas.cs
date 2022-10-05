using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodos_Proyecto
{
    class Empresas
    {
        private string Name;
        private string DPI;
        private string Codificado;
        private int Decodificacion = 0;
        //private int Decodificacion = new Random().Next(0,10);
        private string Metodo;
        private Codificacion codificacion;

        public Empresas(string Nombre, string DPI_Decodificado)
        {
            Name = Nombre;
            DPI = DPI_Decodificado;

            if(Decodificacion < 7)
            {
                Metodo = "Huffman";
                codificacion = new Codificacion(DPI, Decodificacion);
                Codificado = codificacion.GET("codificar");
            }
            else
            {
                Metodo = "Aritmetica";
                codificacion = new Codificacion(DPI, Decodificacion);
                Codificado = codificacion.GET("codificado");
            }

        }

        public string GET_NAME()
        {
            return Name;
        }
        public string GET_DPI_CODIFICADO()
        {
            return Codificado;
        }

    }
}
