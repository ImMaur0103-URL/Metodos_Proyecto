using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodos_Proyecto.Fase2
{
    public class Codificacion_Huffman
    {
        private Codificacion_Huffman_Nodos Raiz;
        private string Frace_Sucia = "";
        private string Frace_Limpia = "";

        public Codificacion_Huffman( string frace_limpia)
        {
            List<Codificacion_Huffman_Nodos> Lista = new List<Codificacion_Huffman_Nodos>();
            List<char> Simbolos = new List<char>();

            for (int i = 0; i < frace_limpia.Length; i++)
            {
                if (Simbolos == null)
                {
                    Simbolos.Add(frace_limpia[i]);
                    Lista.Add(new Codificacion_Huffman_Nodos(Convert.ToString(frace_limpia[i])));
                }
                else if (!Simbolos.Contains(frace_limpia[i]))
                {
                    Simbolos.Add(frace_limpia[i]);
                    Lista.Add(new Codificacion_Huffman_Nodos(Convert.ToString(frace_limpia[i])));
                }
                else
                {
                    for (int j = 0; j < Lista.Count; j++)
                    {
                        if ((new Codificacion_Huffman_Nodos(frace_limpia[i].ToString()).Simbolo == Lista[j].Simbolo))
                        {
                            Lista[j].Frecuencia_Aumentada();
                            break;
                        }
                        else
                            continue;
                    }

                }
            }


            CrearArbol(Lista);
            Setear_Arbol();
            Frace_Limpia = frace_limpia;
            Codificar();
        }
        public Codificacion_Huffman(string frace_sucia, Codificacion_Huffman_Nodos Nodo_Raiz)
        {
            Raiz = Nodo_Raiz;
            Frace_Sucia = frace_sucia;
            Decodificar();
        }

        public string Get(string Eleccion)
        {
            if (Eleccion == "1")
                return Frace_Limpia;
            else
                return Frace_Sucia;
        }

        private void CrearArbol(List<Codificacion_Huffman_Nodos> Nodos)
        {
            Nodos.Sort();
            while (Nodos.Count > 1)  // 1 because a tree need 2 leaf to make a new parent.
            {
                Codificacion_Huffman_Nodos node1 = Nodos[0];    // Get the node of the first index of List,
                Nodos.RemoveAt(0);               // and delete it.
                Codificacion_Huffman_Nodos node2 = Nodos[0];    // Get the node of the first index of List,
                Nodos.RemoveAt(0);               // and delete it.
                Nodos.Add(new Codificacion_Huffman_Nodos(node1, node2));    // Sending the constructor to make a new Node from this nodes.
                Nodos.Sort();        // and sort it again according to frequency.
            }
            Raiz = Nodos[0];
        }

        private void Codificar()
        {
            for (int i = 0; i < Frace_Limpia.Length; i++)
            {
                if (i > 0)
                    Frace_Sucia += "|";
                Frace_Sucia += Buscar(Frace_Limpia[i]);
            }
        }

        private void Decodificar()
        {
            string[] Array_Codificado = Frace_Sucia.Split('|');
            for (int i = 0; i < Array_Codificado.Length; i++)
            {
                Frace_Limpia += Buscar(Array_Codificado[i]);
            }
        }

        private void Setear_Arbol(Codificacion_Huffman_Nodos Nodo_Raiz = null, string Codigo = "")
        {
            if (Nodo_Raiz == null)
                Nodo_Raiz = Raiz;

            if (!Nodo_Raiz.Hoja)
            {
                Setear_Arbol(Nodo_Raiz.Nodo_Hijo_Izq, Codigo + "0");
                Setear_Arbol(Nodo_Raiz.Nodo_Hijo_Der, Codigo + "1");
            }
            else
            {
                Nodo_Raiz.Codigo = Codigo;
            }
        }

        private string Buscar(char Letra, Codificacion_Huffman_Nodos Nodo_Raiz = null, string Codigo = "")
        {
            string Buscando = Letra.ToString();
            if (Nodo_Raiz == null)
                Nodo_Raiz = Raiz;

            if (!Nodo_Raiz.Hoja)
            {
                string aux = Buscar(Letra, Nodo_Raiz.Nodo_Hijo_Izq);
                if (aux == "")
                {
                    aux = Buscar(Letra, Nodo_Raiz.Nodo_Hijo_Der);
                    return aux;
                }
                else
                    return aux;
            }
            else if (Buscando == Nodo_Raiz.Simbolo)
            {
                return Nodo_Raiz.Codigo;
            }
            else
                return "";
        }
        private string Buscar(string Segmento, Codificacion_Huffman_Nodos Nodo_Raiz = null)
        {
            if (Nodo_Raiz == null)
                Nodo_Raiz = Raiz;

            if (!Nodo_Raiz.Hoja)
            {
                string aux = "";
                if (Segmento[0] == '0')
                {
                    aux = Buscar(Segmento.Remove(0, 1), Nodo_Raiz.Nodo_Hijo_Izq);
                    return aux;
                }
                else
                {
                    aux = Buscar(Segmento.Remove(0,1), Nodo_Raiz.Nodo_Hijo_Der);
                    return aux;
                }
            }
            else
                return Nodo_Raiz.Simbolo;
        }

    }
}
