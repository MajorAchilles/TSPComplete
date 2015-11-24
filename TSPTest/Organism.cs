using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TSPTest
{
    public class Organism : IComparable
    {
        static Random random = new Random();

        public List<Point> Tour { get; set; }
        public double Fitness { get; set; }

        public Organism()
        {
            Tour = new List<Point>();
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            Organism other = obj as Organism;

            if (other != null)
                return Fitness.CompareTo(other.Fitness);
            else
                throw new ArgumentException("Object is not a RandomSolution");
        }

        public override string ToString()
        {
            return Fitness.ToString();
        }
    }
}
