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
        private int Decodificacion = new Random().Next(0, 1);
        private string Metodo; 

        public Empresas(string Nombre, string DPI_Decodificado)
        {
            Name = Nombre;
            DPI = DPI_Decodificado;

            if(Decodificacion == 0)
            {
                
            }

        }
    }
}
