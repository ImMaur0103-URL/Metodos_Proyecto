using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodos_Proyecto
{
    public class Codificacion_Huffman_Nodos : IComparable<Codificacion_Huffman_Nodos>
    {
        public string Simbolo;
        public int Frecuencia;
        public string Codigo;
        public Codificacion_Huffman_Nodos Nodo_Padre;
        public Codificacion_Huffman_Nodos Nodo_Hijo_Izq;
        public Codificacion_Huffman_Nodos Nodo_Hijo_Der;
        public bool Hoja;

        public Codificacion_Huffman_Nodos(string value)
        {
            Simbolo = value;
            Frecuencia = Convert.ToInt32("1");      

            Nodo_Hijo_Der = Nodo_Hijo_Izq = Nodo_Padre = null;       

            Codigo = "";          
            Hoja = true;      
        }
        public Codificacion_Huffman_Nodos(Codificacion_Huffman_Nodos node1, Codificacion_Huffman_Nodos node2)
        {
            
            Codigo = "";
            Hoja = false;
            Nodo_Padre = null;


            if (node1.Frecuencia >= node2.Frecuencia)
            {
                Nodo_Hijo_Der = node2;
                Nodo_Hijo_Izq = node1;
                Nodo_Hijo_Der.Nodo_Padre = this;
                Nodo_Hijo_Izq.Nodo_Padre = this;
                Simbolo = Convert.ToString(node2.Frecuencia + node1.Frecuencia);
                Frecuencia = node1.Frecuencia + node2.Frecuencia;
            }
            else if (node1.Frecuencia < node2.Frecuencia)
            {
                Nodo_Hijo_Der = node1;
                Nodo_Hijo_Izq = node2;
                Nodo_Hijo_Der.Nodo_Padre = this;
                Nodo_Hijo_Izq.Nodo_Padre = this;
                Simbolo = Convert.ToString(node2.Frecuencia + node1.Frecuencia);
                Frecuencia = node2.Frecuencia + node1.Frecuencia;
            }
        }
        

        public int CompareTo(Codificacion_Huffman_Nodos otherNode)
        {
            return this.Frecuencia.CompareTo(otherNode.Frecuencia);
        }

        public void Frecuencia_Aumentada()
        {
            Frecuencia++;
        }
    }
}
