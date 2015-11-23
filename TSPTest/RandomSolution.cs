using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TSPTest
{
    class RandomSolution
    {
        List<CityNode> tour;
        public List<CityNode> Tour
        {
            get
            {
                return tour;
            }
        }

        List<CityNode> cities;
        
        public RandomSolution(List<CityNode> cities)
        {
            this.cities = cities.ToList();
        }

        public List<CityNode> CreateRandomSolution()
        {
            tour = new List<CityNode>();
            Random random = new Random();

            CityNode city = null;
            while (cities.Count != 0)
            {
                city = cities[random.Next(0, cities.Count)];
                cities.Remove(city);
                Tour.Add(city);
            }

            return tour;
        }

        public Bitmap DrawSolution(ref double distance)
        {
            distance = 0;
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
                distance += GetDistance(location, nextLocation);
            }

            if (tour.Count > 1)
            {
                CityNode city = tour[tour.Count - 1];
                Point location = city.Coordinates;
                g.FillEllipse(Brushes.Black, new Rectangle(location.X - 2, location.Y - 2, 5, 5));
                g.DrawEllipse(Pens.Black, new Rectangle(location.X - 4, location.Y - 4, 9, 9));
                //g.DrawString(city.Name, this.Font, Brushes.CadetBlue, location.X + 7, location.Y - 7);
            }
            distance = Math.Round(distance, 2);
            return tspImage;
        }

        private double GetDistance(Point point1, Point point2)
        {
            int xDist = point1.X - point2.X;
            int yDist = point1.Y - point2.Y;

            double distance = Math.Sqrt(Math.Pow(xDist, 2) + Math.Pow(yDist, 2));
            return Math.Round(distance, 3);
        }
    }
}
