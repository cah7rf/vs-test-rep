using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDTree;

namespace CutFillBalanceCH.Model
{
    public class Pair
    {
        public Pair(InputLine cut, InputLine fill)
        {
            this.Cut = cut;
            this.Fill = fill;
            double dX = cut.X - fill.X;
            double dY = cut.Y - fill.Y;
            double dZ = cut.Z - fill.Z;

            this.DistanceSquared = ((dX * dX) + (dY * dY) + (dZ * dZ));

        }
        public override string ToString()
        {
            return string.Format("Cut=[{0}], Fill=[{1}]", this.Cut, this.Fill);
        }
        public InputLine Cut { get; private set; }

        public double DistanceSquared { get; private set; }

        public InputLine Fill { get; private set; }
    }
}
