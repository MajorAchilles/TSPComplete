﻿using System;
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
            this.DoubleBuffered = true;
            this.population = population;
            bwAlgorithm = new BackgroundWorker();
            bwAlgorithm.WorkerReportsProgress = true;
            bwAlgorithm.WorkerSupportsCancellation = true;
            bwAlgorithm.DoWork += BwAlgorithm_DoWork;
            bwAlgorithm.ProgressChanged += BwAlgorithm_ProgressChanged;
            images = new Bitmap[16];

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
                if (i == 0)
                    g.FillRectangle(Brushes.LightGreen, regions[i]);
                else
                    if (i == 15)
                    g.FillRectangle(Brushes.LightPink, regions[i]);
                else
                    g.DrawRectangle(Pens.Black, regions[i]);

                int size = 0;
                if (regions[i].Width > regions[0].Height)
                    size = regions[i].Height;
                else
                    size = regions[i].Width;
                int x = regions[i].Left + ((regions[i].Width - size) / 2); //x y adjusted relative to each region
                int y = regions[i].Top + ((regions[i].Height - size) / 2);
                Rectangle imageRect = new Rectangle(new Point(x, y), new Size(size, size));

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
                    Rectangle region = new Rectangle(x, y, widths, heights);
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