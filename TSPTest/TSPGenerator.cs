using System.Collections.Generic;
using System.Drawing;

namespace TSPTest
{
    public class TSPGenerator
    {
        List<Point> cities { get; set; }
        public int LandHorizontal { get; set; }
        public int LandVertical { get; set; }
        public int BorderSize { get; set; }
        public int MaxCities { get; set; }


        public TSPGenerator(int maxCities, int landHorizontal, int landVertical, int borderSize)
        {
            this.MaxCities = maxCities;
            this.LandHorizontal = landHorizontal;
            this.LandVertical = landVertical;
            this.BorderSize = borderSize;
        }

        public List<Point> GenerateCities()
        {
            cities = new List<Point>(MaxCities);
            for (int i = 0; i < MaxCities; i++)
            {

                int x = Utils.random.Next(0+BorderSize, LandHorizontal-BorderSize-BorderSize);
                int y = Utils.random.Next(0+BorderSize, LandVertical-BorderSize-BorderSize);
                Point city = new Point(x, y);
                cities.Add(city);
            }
            return cities;
        }
    }
}
