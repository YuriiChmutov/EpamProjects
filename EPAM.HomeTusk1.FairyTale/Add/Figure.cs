using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add
{
    abstract class Figure
    {
        public double Width { get; set; }
        public double Height { get; set; }
        // int Squere { get; set; }
        public string Name { get; set; }

        public virtual double Square(double w, double h)
        {
            return 0;
        }

        public virtual double Perimetr(double w, double h)
        {
            return 0;
        }
    }
}
