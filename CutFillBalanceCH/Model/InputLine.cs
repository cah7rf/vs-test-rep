using System;

namespace CutFillBalanceCH.Model
{
    public class InputLine : IEquatable<InputLine>
    {
        public int PID {get; private set;}
        public double TotalVolume { get; private set; }
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            InputLine objAsInputLine = obj as InputLine;
            if (objAsInputLine == null) return false;
            else return Equals(objAsInputLine);
        }
        public bool Equals(InputLine other)
        {
            if (other == null) return false;
            return (this.PID.Equals(other.PID));
        }
        public override int GetHashCode()
        {
            return PID;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, ({2}, {3}, {4})", new object[] 
                {
                    this.PID, 
                    this.TotalVolume, 
                    this.X, 
                    this.Y, 
                    this.Z 
                }                );
        }
        public void Add(string fileLine)
        {

            this.Add(fileLine, ',');

        }

        public void Add(string fileLine, char fileDelimiter)
        {
            String[] values = fileLine.Split(fileDelimiter);
            this.PID = Int32.Parse(values[0]);
            this.TotalVolume = Convert.ToDouble(values[1]);
            this.X = Convert.ToDouble(values[2]);
            this.Y = Convert.ToDouble(values[3]);
            this.Z = Convert.ToDouble(values[4]);

        }
        public double Distance(InputLine lineTo)
        {
            double dX = this.X - lineTo.X;
            double dY = this.Y - lineTo.Y;
            double dZ = this.Z - lineTo.Z;

           double pDistance = ((dX * dX) + (dY * dY) + (dZ * dZ));
            
            return pDistance;
        }

    }
}
