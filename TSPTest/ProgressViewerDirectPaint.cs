using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace TSPTest
{
    public partial class ProgressViewerDirectPaint : Form
    {
        double bestDistance = 99999;
        double worstDistance = -100;
        TSPGeneticAlgorithm ga;
        BackgroundWorker bwAlgorithm;
        bool drawing = false;
        int eliteCount;
        int mutationChance;
        int maxGenerations;
        String data = null;

        private Organism[] population;
        private Bitmap[] images;

        public ProgressViewerDirectPaint(Organism[] population, int maxGenerations, int mutationChance, int eliteCount)
        {
            this.mutationChance = mutationChance;
            this.maxGenerations = maxGenerations;
            this.eliteCount = eliteCount;
            InitializeComponent();
            this.population = population;
            images = new Bitmap[population.Count()];

            bwAlgorithm = new BackgroundWorker();
            bwAlgorithm.WorkerReportsProgress = true;
            bwAlgorithm.WorkerSupportsCancellation = true;
            bwAlgorithm.DoWork += BwAlgorithm_DoWork;
            bwAlgorithm.ProgressChanged += BwAlgorithm_ProgressChanged;

            ga = new TSPGeneticAlgorithm(population, population.Count(), mutationChance, eliteCount);
        }

        private void ProgressViewer_Load(object sender, EventArgs e)
        {
            bwAlgorithm.RunWorkerAsync();
            canvas.Paint += Canvas_Paint;
        }

        private void BwAlgorithm_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            drawing = true;

            data = "Generation " + e.ProgressPercentage + Environment.NewLine;
            data += "Best distance: " + bestDistance + Environment.NewLine;
            data += "Worst distance: " + worstDistance + Environment.NewLine;
            data += "Average distance: " + (bestDistance + worstDistance) / 2;
            this.SuspendLayout();

            bestDistance = population[0].Fitness;
            worstDistance = population[population.Count() - 1].Fitness;

            for (int i = 0; i < population.Count(); i++)
            {
                images[i] = population[i].Tour.DrawTour();
            }

            canvas.Invalidate();

            this.ResumeLayout();
            drawing = false;
        }

        private void BwAlgorithm_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            while (ga.GenerationNo <= maxGenerations)
            {
                worker.ReportProgress(ga.GenerationNo);
                Thread.Sleep(150); //100 miliseconds for creating image. 50 for drawing.
                while (drawing)
                {
                }

                population = ga.GetNextGeneration();
                if (worker.CancellationPending)
                    break;
            }
        }

        private void ProgressViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Quit?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }
        
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Rectangle[] regions = GetRegions();

            Graphics g = e.Graphics;
            g.Clear(Color.White);

            for (int i = 0; i < regions.Count(); i++)
            {
                Rectangle region = regions[i];
                if (i == 0)
                    g.FillRectangle(Brushes.LightGreen, new Rectangle(region.X+1, region.Y+1, region.Width-1, region.Height-1));
                else
                    if (i == 15)
                    g.FillRectangle(Brushes.LightPink, new Rectangle(region.X + 1, region.Y + 1, region.Width - 1, region.Height - 1));

               g.DrawRectangle(Pens.Black, new Rectangle(region.X + 1, region.Y + 1, region.Width - 1, region.Height - 1));

                int size = 0;
                if (region.Width > region.Height)
                    size = region.Height-4;
                else
                    size = region.Width-4;

                int x = region.Left + ((region.Width - size) / 2); //x y adjusted relative to each region
                int y = region.Top + ((region.Height - size) / 2);
                string distanceString = "Distance: " + Environment.NewLine + Math.Round(population[i].Fitness, 2);
                g.DrawString(distanceString, this.Font, Brushes.Black, new Point(region.X + 10, region.Y + 10));
                Rectangle imageRect = new Rectangle(new Point(x+1, y+1), new Size(size, size));

                if (images[i] != null)
                    g.DrawImage(images[i], imageRect);
            }

            g.DrawString(data, this.Font, Brushes.Black, new Point(10, canvas.Bottom - 100));
        }

        private void canvas_Click(object sender, EventArgs e)
        {
            Point position = canvas.PointToClient(Cursor.Position);
            Rectangle[] regions = GetRegions();
            int index = -1;
            for (int i = 0; i < regions.Count(); i++)
            {
                if (position.X >= regions[i].Left && position.X <= regions[i].Right && position.Y >= regions[i].Top && position.Y <= regions[i].Bottom)
                {
                    index = i;
                    break;
                }
            }

            if (index >= 0)
                new SolutionViewer(population[index]).Show();
        }

        private Rectangle[] GetRegions()
        {
            Rectangle[] regions = new Rectangle[16];
            int widths = canvas.Width / 4;
            int heights = (canvas.Height - 100) / 4;
            int x = 0;
            int y = 0;
            int counter = 0;
            for (int i = 0; i < 4; i++)
            {
                x = 0;
                for (int j = 0; j < 4; j++)
                {
                    Rectangle region = new Rectangle(x+1, y+1, widths-1, heights-1);
                    regions[counter++] = region;
                    x += widths;
                }
                y += heights;
            }
            return regions;
        }

        private void ProgressViewerDirectPaint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }

    class Canvas:Panel
    {
        public Canvas():base()
        {
            this.DoubleBuffered = true;
        }
    }
}
