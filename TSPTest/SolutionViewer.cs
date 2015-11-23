using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TSPTest
{
    public partial class SolutionViewer : Form
    {
        public SolutionViewer(List<CityNode> cities)
        {
            InitializeComponent();

            RandomSolution randomSolution = new RandomSolution(cities);
            randomSolution.CreateRandomSolution();
            double distance = 0D;
            this.pictureBox1.Image = randomSolution.DrawSolution(ref distance);
            this.Text = "Distance: " + distance;
        }
    }
}
