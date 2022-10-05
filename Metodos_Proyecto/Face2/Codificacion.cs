using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metodos_Proyecto.Fase2;


namespace Metodos_Proyecto
{
    public class Codificacion
    {
        private Codificacion_Aritmetica codificacion_Aritmetica;
        private Codificacion_Huffman _Huffman;


        public Codificacion(string Palabra, int eleccion)
        {
            if (eleccion == 0)
            {
                _Huffman = new Codificacion_Huffman(Palabra);
            }
            else
            {
                codificacion_Aritmetica = new Codificacion_Aritmetica(Palabra);
            }
        }

        public string GET(string DECCOD)
        {
            if (DECCOD == "decodificacion")
            {
                if (_Huffman == null)
                    return codificacion_Aritmetica.Get_Decodificacion();
                else
                    return _Huffman.Get("1");
            }
            else
            {
                if (_Huffman == null)
                    return codificacion_Aritmetica.Get_Codificado().ToString();
                else
                    return _Huffman.Get("0");
            }
        }

    }
}
