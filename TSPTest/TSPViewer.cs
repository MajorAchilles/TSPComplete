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
    public partial class TSPViewer : Form
    {
        int cityCount = 100;
        List<Point> cities;
        TSPGenerator tspGenerator;
        Bitmap tspImage;
        const int horizontalSize = 700;
        const int verticalSize = 700;
        const int border = 0;

        public static int HorizontalSize
        {
            get
            {
                return horizontalSize;
            }
        }

        public static int VerticalSize
        {
            get
            {
                return verticalSize;
            }
        }

        public static int Border
        {
            get
            {
                return border;
            }
        }

        public TSPViewer()
        {
            InitializeComponent();
            tspGenerator = new TSPGenerator(cityCount, HorizontalSize, VerticalSize, Border);
            FillCities();
        }

        private void FillCities()
        {
            cities = tspGenerator.GenerateCities();
            tspImage = new Bitmap(HorizontalSize, VerticalSize);

            Graphics g = Graphics.FromImage(tspImage);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);
            g.DrawRectangle(Pens.BlueViolet, new Rectangle(Border, Border, HorizontalSize - (Border * 2) - 1, VerticalSize - (Border * 2) - 1));

            foreach (Point location in cities)
            {
                g.FillEllipse(Brushes.Black, new Rectangle(location.X - 2, location.Y - 2, 5, 5));
                g.DrawEllipse(Pens.Black, new Rectangle(location.X - 4, location.Y - 4, 9, 9));
            }

            pictureBoxViewPort.Image = tspImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillCities();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            tspGenerator.MaxCities = this.cityCount = (int)numericUpDownCityCount.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Organism randomSolution = cities.CreateRandomSolution();
            new SolutionViewer(randomSolution).Show();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Organism[] population = new Organism[16];
            for (int i = 0; i < population.Count(); i++)
            {
                Organism solution = cities.CreateRandomSolution();
                population[i] = solution;
            }

            new ProgressViewerDirectPaint(population, (int) numericUpDownMaxGenerations.Value, (int) numericUpDownMutationChance.Value, (int) numericUpDownEliteCount.Value).ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "Problem";
            sfd.DefaultExt = ".bmp";
            sfd.Filter = "Bitmap File (*.bmp)| *.bmp";
            sfd.FilterIndex = 0;
            sfd.RestoreDirectory = true;
            sfd.SupportMultiDottedExtensions = true;
            sfd.OverwritePrompt = true;
            sfd.Title = "Save problem image";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = (Bitmap)pictureBoxViewPort.Image;
                bmp.Save(sfd.FileName);
            }
        }
    }
}
