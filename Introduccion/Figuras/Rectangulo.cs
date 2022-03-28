using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduccion.Figuras
{
    internal class Rectangulo: Figura
    {
        private const int lados = 4;
        public Rectangulo()
        {
            incognitas = new string[] { "base", "altura" };
        }
        //private int longitud;
        override public double obtenArea(int[] incognita)
        {
            if (esFigValida(incognita))
            {
                return incognita[0] * incognita[1];
            }
            return -1;
        }
        override public double obtenPerimetro(int[] incognita) {
            if (esFigValida(incognita)) { return (incognita[0] * 2) + (incognita[1] * 2); }
            return -1;
        }
    }
}
