using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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

        public Organism Clone()
        {
            Organism clone = new Organism();
            clone.Tour = this.Tour.ToList() ;
            clone.Fitness = Fitness;
            return clone;
        }

        public void Swap(int index1, int index2)
        {
            this.Tour.Swap(index1, index2);
            Fitness = this.Tour.GetTourDistanceFast();
        }

        public void OptimizingSwap(int index1, int index2)
        {
            if (index1 == index2)
                return;

            int smaller = index1;
            int larger = index2;

            if (larger == 0)
                larger = Tour.Count - 1;

            Tour.Swap(smaller, larger);

            while (smaller<larger)
            {
                smaller++;
                larger--;
                Tour.Swap(smaller, larger);
            }
            this.Fitness = Tour.GetTourDistanceFast();

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
