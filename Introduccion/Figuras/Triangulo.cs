using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduccion.Figuras
{
    internal class Triangulo : Figura
    {
        private const int lados = 3;
        public Triangulo() { 
            incognitas = new string[] { "lado 1", "lado 2", "lado 3" }; 
        }
        //private int longitud;
        override public double obtenArea(int[] incognita)
        {
            if (esTriangulo(incognita))
            {
                //formula encontrada en el interneis.
                double perimetro = obtenPerimetro(incognita)/2;
                return Math.Sqrt(
                    perimetro * (perimetro - incognita[0])
                     * (perimetro - incognita[1])
                     * (perimetro - incognita[2])
                    );
            }
            return -1;
        }
        override public double obtenPerimetro(int[] incognita)
        {
            if (esTriangulo(incognita))
            {
                return incognita[0] + incognita[1] + incognita[2];
            }
            return -1;
        }
        public bool esTriangulo(int[] valores) {
            
            return esFigValida(valores) && ((valores[0] + valores[1]) > valores[2]) &&
                ((valores[0] + valores[2]) > valores[1]) &&
                ((valores[1] + valores[2]) > valores[0]);
        }
    }
}
