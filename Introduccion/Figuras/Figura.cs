using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduccion
{
    internal abstract class Figura
    {
        protected string[] incognitas;
        //private int lados;
        abstract public double obtenPerimetro(int[] incognitas);
        abstract public double obtenArea(int[] incognitas);
        public string[] getIncognitas{ get { return incognitas; } }

        // no debe haber longitudes negativas.
        public bool esFigValida(int[] incognitas) 
        {
            if(incognitas.Length != this.incognitas.Length) return false;
            foreach (int incognita in incognitas)
            {
                if (incognita <= 0) { return false; }
            }
            return true;
        
        }
        //public string nombre { get; }
    }
}
