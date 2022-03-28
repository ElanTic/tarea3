using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduccion.Figuras
{
    internal class Cuadrado : Figura

    {
        private const int lados = 4;
        public Cuadrado()
        {
            this.incognitas = new string[] { "lado" };
        }
        //private int longitud;
        override public double obtenArea(int[] incognita) { 
            if(esFigValida(incognita)) return incognita[0] * incognita[0];
            return -1;
        }
        override public double obtenPerimetro(int[] incognita) { 
            if(esFigValida(incognita)) return incognita[0]*lados;
            return -1;
        }
        //public string[] getIncognitas{ get { return incognitas;} }

    }
}
