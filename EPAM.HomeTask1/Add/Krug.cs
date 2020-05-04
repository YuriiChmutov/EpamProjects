using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add
{
    class Krug: Figure
    {
         double pi = 3.14;
        double radius { get; set; }
        public Krug()
        {
            Name = "Krug";           
            
        }

        public override  double Square(double w, double radius)
        {
            return 2 * pi * radius;
        }
    }
}
