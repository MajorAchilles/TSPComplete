using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TSPTest
{
    public class TSPGenerator
    {
        List<CityNode> cities { get; set; }
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

        public List<CityNode> GenerateCities()
        {
            cities = new List<CityNode>(MaxCities);
            Random random = new Random();

            for (int i = 0; i < MaxCities; i++)
            {
                CityNode city = new CityNode();
                int x = random.Next(0+BorderSize, LandHorizontal-BorderSize-BorderSize);
                int y = random.Next(0+BorderSize, LandVertical-BorderSize-BorderSize);
                city.Coordinates = new Point(x, y);
                cities.Add(city);
            }
            return cities;
        }
    }
}
