using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add
{
    class Kvadrat: PryamoUgol
    {
        public Kvadrat()
        {
            Name = "Kvadrat";
            Width = 4;
            Height = 4;
        }

        
        public override double Perimetr(double w, double h) => (w + h) * 2;
        
    }
}
