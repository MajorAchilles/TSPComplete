using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TSPTest
{
    public class RandomSolution: IComparable
    {
        List<CityNode> tour;
        double tourDistance = 0D;
        static Random random = new Random();

        public List<CityNode> Tour
        {
            get
            {
                return tour;
            }
        }

        public double TourDistance
        {
            get
            {
                return tourDistance;
            }
        }

        List<CityNode> cities;
        
        public RandomSolution(List<CityNode> cities)
        {
            this.cities = cities.ToList();
        }

        public RandomSolution()
        {
            tour = new List<CityNode>();
        }

        public List<CityNode> CreateRandomSolution()
        {
            tour = new List<CityNode>();

            CityNode city = null;
            while (cities.Count != 0)
            {
                city = cities[random.Next(0, cities.Count)];
                cities.Remove(city);
                Tour.Add(city);
            }

            CalculateTourDistance();

            return tour;
        }

        public double CalculateTourDistance()
        {
            tourDistance = 0;
            if (tour.Count > 2)
            {
                for (int i = 0; i < Tour.Count - 2; i++)
                {
                    CityNode city = tour[i];
                    CityNode next = tour[i + 1];
                    tourDistance += GetDistance(city.Coordinates, next.Coordinates);
                }
            }
            return tourDistance;
        }

        public List<CityNode> SwapCities(int index1, int index2)
        {
            CityNode first = tour[index1];
            CityNode second = tour[index2];
            tour[index1] = second;
            tour[index2] = first;
            CalculateTourDistance();
            return tour;
        }

        public Bitmap DrawSolution()
        {
            Bitmap tspImage = new Bitmap(TSPViewer.HorizontalSize, TSPViewer.VerticalSize);

            Graphics g = Graphics.FromImage(tspImage);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);
            g.DrawRectangle(Pens.BlueViolet, new Rectangle(TSPViewer.Border, TSPViewer.Border, TSPViewer.HorizontalSize - (TSPViewer.Border * 2) - 1, TSPViewer.VerticalSize - (TSPViewer.Border * 2) - 1));

            for (int i = 0; i < tour.Count - 1; i++)
            {
                CityNode city = tour[i];
                Point location = city.Coordinates;
                Point nextLocation = tour[i + 1].Coordinates;
                g.FillEllipse(Brushes.Black, new Rectangle(location.X - 2, location.Y - 2, 5, 5));
                g.DrawEllipse(Pens.Black, new Rectangle(location.X - 4, location.Y - 4, 9, 9));
                g.DrawLine(Pens.Red, location, nextLocation);
            }

            if (tour.Count > 1)
            {
                CityNode city = tour[tour.Count - 1];
                Point location = city.Coordinates;
                g.FillEllipse(Brushes.Black, new Rectangle(location.X - 2, location.Y - 2, 5, 5));
                g.DrawEllipse(Pens.Black, new Rectangle(location.X - 4, location.Y - 4, 9, 9));
                //g.DrawString(city.Name, this.Font, Brushes.CadetBlue, location.X + 7, location.Y - 7);
            }
            return tspImage;
        }

        public double GetDistance(Point point1, Point point2)
        {
            if (point1 == null || point2 == null)
                return 0;
            int xDist = point1.X - point2.X;
            int yDist = point1.Y - point2.Y;

            double distance = Math.Sqrt(Math.Pow(xDist, 2) + Math.Pow(yDist, 2));
            return Math.Round(distance, 3);
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            RandomSolution other = obj as RandomSolution;

            if (other != null)
                return this.tourDistance.CompareTo(other.tourDistance);
            else
                throw new ArgumentException("Object is not a RandomSolution");
        }

        public override string ToString()
        {
            return this.tourDistance.ToString();
        }
    }
}
