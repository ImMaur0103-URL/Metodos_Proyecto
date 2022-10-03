using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodos_Proyecto
{
    class Codificacion_Aritmetica
    {
        private decimal Largo_Cadena;
        private string Cadena_Sin_Codificar;
        private decimal Cadena_Codificada;

        private List<char> Tabla_Simbolos;
        public List<decimal[]> Tabla_Rangos;

        public Codificacion_Aritmetica(string Cadena)
        {
            Cadena_Sin_Codificar = Cadena;
            Largo_Cadena = Cadena.Length;
            Cadena_Codificada = Get_Codificado();
        }
        public Codificacion_Aritmetica(decimal Codificado, List<decimal[]> Tabla, List<char> Simbolos)
        {
            Cadena_Codificada = Codificado;
            Tabla_Rangos = Tabla;
            Tabla_Simbolos = Simbolos;
        }

        public decimal Get_Codificado()
        {
            if (Cadena_Codificada == 0 || Cadena_Codificada == null)
            {
                List<decimal[]> Tabla_Frecuencias = GET_TABLE();
                List<decimal[]> Tabla_Codificacion_I_S = new List<decimal[]>();

                List<char> Simbolos = new List<char>();

                for (int i = 0; i < Largo_Cadena; i++)
                {
                    if (Simbolos == null)
                        Simbolos.Add(Cadena_Sin_Codificar[i]);
                    else if (!Simbolos.Contains(Cadena_Sin_Codificar[i]))
                        Simbolos.Add(Cadena_Sin_Codificar[i]); ;
                }

                for (int i = 0; i < Largo_Cadena; i++)
                {
                    int aux = 0;
                    while (Cadena_Sin_Codificar[i] != Simbolos[aux])
                        aux++;

                    if (i == 0)
                    {
                        decimal[] rango_I_S = { 0, (0 + 1 * Tabla_Frecuencias[aux][1]) };
                        Tabla_Codificacion_I_S.Add(rango_I_S);
                    }
                    else
                    {
                        decimal diferencia = (Tabla_Codificacion_I_S[i - 1][1] - Tabla_Codificacion_I_S[i - 1][0]);
                        decimal[] rango_I_S = { (Tabla_Codificacion_I_S[i - 1][0] + diferencia * Tabla_Frecuencias[aux][0]), (Tabla_Codificacion_I_S[i - 1][0] + diferencia * Tabla_Frecuencias[aux][1]) };
                        Tabla_Codificacion_I_S.Add(rango_I_S);
                    }
                }

                Tabla_Simbolos = Simbolos;
                Tabla_Rangos = Tabla_Frecuencias;

                return Tabla_Codificacion_I_S[Tabla_Codificacion_I_S.Count - 1][0];
            }
            else
                return Cadena_Codificada;
        }

        private List<decimal[]> GET_TABLE()
        {
            if(Tabla_Rangos == null)
            {
                List<char> Simbolos = new List<char>();
                List<int> Frecuencias = new List<int>();
                List<decimal> Frecuencias1 = new List<decimal>();
                List<decimal[]> Rangos_I_S = new List<decimal[]>();
                for (int i = 0; i < Largo_Cadena; i++)
                {
                    if (Simbolos == null)
                        Simbolos.Add(Cadena_Sin_Codificar[i]);
                    else if (!Simbolos.Contains(Cadena_Sin_Codificar[i]))
                        Simbolos.Add(Cadena_Sin_Codificar[i]); ;
                }
                for (int i = 0; i < Simbolos.Count; i++)
                {
                    int aux = 0;
                    for (int j = 0; j < Largo_Cadena; j++)
                    {
                        if (Simbolos[i] == Cadena_Sin_Codificar[j]) 
                            aux++;
                    }
                    Frecuencias.Add(aux);
                }
                for (int i = 0; i < Frecuencias.Count; i++)
                {
                    Frecuencias1.Add(Frecuencias[i] / Largo_Cadena);
                    if (i == 0)
                    {
                        decimal[] rango_I_S = { 0, Frecuencias1[i] };
                        Rangos_I_S.Add(rango_I_S);
                    }
                    else
                    {
                        decimal[] rango_I_S = { Rangos_I_S[i-1][1], Frecuencias1[i] + Rangos_I_S[i-1][1] };
                        Rangos_I_S.Add(rango_I_S);
                    }
                }


                return Rangos_I_S;
            }
            else
            {
                return Tabla_Rangos;
            }
        }

        public string Get_Decodificacion(int lon)
        {
            decimal Mensaje_Sucio = Cadena_Codificada;
            string Mensaje_limpio = "";
            int aux = 0;
            while(Mensaje_Sucio != 0 && Mensaje_limpio.Length < lon)
            {
                decimal diferencia = Tabla_Rangos[aux][1] - Tabla_Rangos[aux][0];
                if (Math.Round(Mensaje_Sucio, 17) == Math.Round(Tabla_Rangos[aux][1], 17) && Mensaje_Sucio < Tabla_Rangos[aux][1])
                    Mensaje_Sucio = Tabla_Rangos[aux][1] + 0.000005M;
                if (Mensaje_Sucio >= Tabla_Rangos[aux][0] && Mensaje_Sucio < Tabla_Rangos[aux][1])
                {
                    Mensaje_limpio += Tabla_Simbolos[aux];
                    Mensaje_Sucio = (Mensaje_Sucio - Tabla_Rangos[aux][0]) / (diferencia);
                    if(Math.Round(Mensaje_Sucio, 10) == 0)
                        Mensaje_Sucio = Math.Round(Mensaje_Sucio, 10);
                    
                    aux = 0;
                    continue;
                }
                else
                {
                    aux++;
                    continue;
                }
            }

            return Mensaje_limpio;
        }

    }
}
