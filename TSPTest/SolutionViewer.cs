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
        public SolutionViewer(RandomSolution randomSolution)
        {
            InitializeComponent();

            this.pictureBox1.Image = randomSolution.DrawSolution();
            this.Text = "Distance: " + randomSolution.TourDistance;
        }
    }
}
