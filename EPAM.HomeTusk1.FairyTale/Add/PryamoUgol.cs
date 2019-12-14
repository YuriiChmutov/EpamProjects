using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add
{
    class PryamoUgol: Figure
    {
        public PryamoUgol()
        {
            Name = "Pryamougolnick";
            Width = 4;
            Height = 5;
        }

        public override double Square(double w, double h)
        {
            return w * h;
        }

        public override double Perimetr(double w, double h) => (w + h) * 2;
    }
}
