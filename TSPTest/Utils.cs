using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TSPTest
{
    static class Utils
    {
        public static Random random = new Random();

        public static Bitmap DrawTour(this List<Point> tour)
        {
            if (tour.Count == 0)
                return null;

            Bitmap tspImage = new Bitmap(TSPViewer.HorizontalSize, TSPViewer.VerticalSize);
            Graphics g = Graphics.FromImage(tspImage);
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //Font font = new Font("Arial", 8F);
            g.Clear(Color.White);
            g.DrawRectangle(Pens.BlueViolet, new Rectangle(TSPViewer.Border, TSPViewer.Border, TSPViewer.HorizontalSize - (TSPViewer.Border * 2) - 1, TSPViewer.VerticalSize - (TSPViewer.Border * 2) - 1));

            for (int i = 0; i < tour.Count - 1; i++)
            {
                Point current = tour[i];
                Point next = tour[i + 1];
                g.FillEllipse(Brushes.Black, new Rectangle(current.X - 2, current.Y - 2, 5, 5));
                g.DrawEllipse(Pens.Black, new Rectangle(current.X - 4, current.Y - 4, 9, 9));
                //g.DrawString(i+" - "+current.ToString(), font, Brushes.Black, new Point(current.X + 10, current.Y));
                g.DrawLine(Pens.Red, current, next);
            }

            Point last = tour[tour.Count - 1];
            g.FillEllipse(Brushes.Black, new Rectangle(last.X - 2, last.Y - 2, 5, 5));
            g.DrawEllipse(Pens.Black, new Rectangle(last.X - 4, last.Y - 4, 9, 9));
            g.DrawLine(Pens.Red, last, tour[0]);
            //g.DrawString((tour.Count - 1) + " - " + last.ToString(), font, Brushes.Black, new Point(last.X + 10, last.Y));

            return tspImage;
        }

        public static Bitmap DrawCities(this List<Point> cities)
        {
            Bitmap image = new Bitmap(TSPViewer.HorizontalSize, TSPViewer.VerticalSize);

            Graphics g = Graphics.FromImage(image);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);
            g.DrawRectangle(Pens.BlueViolet, new Rectangle(TSPViewer.Border, TSPViewer.Border, TSPViewer.HorizontalSize - (TSPViewer.Border * 2) - 1, TSPViewer.VerticalSize - (TSPViewer.Border * 2) - 1));

            foreach (Point location in cities)
            {
                g.FillEllipse(Brushes.Black, new Rectangle(location.X - 2, location.Y - 2, 5, 5));
                g.DrawEllipse(Pens.Black, new Rectangle(location.X - 4, location.Y - 4, 9, 9));
            }

            return image;
        }

        public static double GetDistance(this Point point1, Point point2)
        {
            if (point1 == null || point2 == null)
                return 0;
            int xDist = point1.X - point2.X;
            int yDist = point1.Y - point2.Y;

            double distance = Math.Sqrt(Math.Pow(xDist, 2) + Math.Pow(yDist, 2));
            return Math.Round(distance, 3);
        }

        public static int GetDistanceFast(this Point point1, Point point2)
        {
            if (point1 == null || point2 == null)
                return 0;
            int xDist = point1.X - point2.X;
            int yDist = point1.Y - point2.Y;

            return (xDist*xDist) + (yDist*yDist); //FAST. SINCE ONLY COMPARISION MATTERS. NOT ACCURACY.
        }

        public static List<Point> Swap(this List<Point> tour, int index1, int index2)
        {
            Point first = tour[index1];
            Point second = tour[index2];
            tour[index1] = second;
            tour[index2] = first;
            return tour;
        }

        public static double GetTourDistance(this List<Point> tour)
        {
            double tourDistance = 0;
            if (tour.Count > 2)
            {
                for (int i = 0; i < tour.Count - 2; i++)
                {
                    Point city = tour[i];
                    Point next = tour[i + 1];
                    tourDistance += GetDistance(city, next);
                }
                tourDistance += GetDistance(tour[tour.Count - 1], tour[0]);
            }
            return tourDistance;
        }

        public static double GetTourDistanceFast(this List<Point> tour)
        {
            int tourDistance = 0;
            if (tour.Count > 2)
            {
                for (int i = 0; i < tour.Count - 2; i++)
                {
                    Point city = tour[i];
                    Point next = tour[i + 1];
                    tourDistance += GetDistanceFast(city, next);
                }
                tourDistance += GetDistanceFast(tour[tour.Count - 1], tour[0]);
            }
            return tourDistance;
        }

        public static Organism CreateRandomSolution(this List<Point> cities)
        {
            Organism solution = new Organism();
            List<Point> citiesCopy = cities.ToList();

            while (citiesCopy.Count != 0)
            {
                Point city = citiesCopy[random.Next(0, citiesCopy.Count)];
                citiesCopy.Remove(city);
                solution.Tour.Add(city);
            }

            solution.Fitness = solution.Tour.GetTourDistance();

            return solution;
        }

        public static bool IsIntersecting(Point line1start, Point line1end, Point line2start, Point line2end)
        {
            return OnOpposite(line1start, line1end, line2start, line2end) && OnOpposite(line2start, line2end, line1start, line1end);
        }

        private static bool OnOpposite(Point line1start, Point line1end, Point line2start, Point line2end)
        {
            int eqn1 = (line1end.X - line1start.X) * (line2start.Y - line1end.Y) - (line1end.Y - line1start.Y) * (line2start.X - line1end.X);
            int eqn2 = (line1end.X - line1start.X) * (line2end.Y - line1end.Y) - (line1end.Y - line1start.Y) * (line2end.X - line1end.X);

            return (eqn1 ^ eqn2) < 0;
        }
    }
}
