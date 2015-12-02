using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace TSPTest
{
    public partial class ProgressViewerElite : Form
    {
        double bestDistance = 99999;
        double worstDistance = -100;
        TSPGeneticAlgorithm ga;
        BackgroundWorker bwAlgorithm;
        volatile bool drawing = false;
        TSPOptions options;
        string data = null;
        int sleepTime;

        private Organism[] population;
        private Bitmap image;

        public ProgressViewerElite(TSPOptions options)
        {
            this.options = options;
            this.population = options.population;
            this.sleepTime = options.geneLength/2;
            InitializeComponent();

            bwAlgorithm = new BackgroundWorker();
            bwAlgorithm.WorkerReportsProgress = true;
            bwAlgorithm.WorkerSupportsCancellation = true;
            bwAlgorithm.DoWork += BwAlgorithm_DoWork;
            bwAlgorithm.ProgressChanged += BwAlgorithm_ProgressChanged;

            ga = new TSPGeneticAlgorithm(options);
        }

        private void ProgressViewer_Load(object sender, EventArgs e)
        {
            bwAlgorithm.RunWorkerAsync();
            canvas.Paint += Canvas_Paint;
        }

        private void BwAlgorithm_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            drawing = true;
            bestDistance = population[0].Fitness;
            worstDistance = population[population.Count() - 1].Fitness;

            data = "Generation " + e.ProgressPercentage + Environment.NewLine;
            data += "Best distance: " + bestDistance + Environment.NewLine;
            data += "Worst distance: " + worstDistance + Environment.NewLine;
            data += "Average distance: " + (bestDistance + worstDistance) / 2;
            this.SuspendLayout();

            image = population[0].Tour.DrawTour();
            canvas.Invalidate();

            this.ResumeLayout();
            drawing = false;
        }

        private void BwAlgorithm_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            while (ga.GenerationNo <= options.maxGenerations)
            {
                worker.ReportProgress(ga.GenerationNo);
                Thread.Sleep(sleepTime); //100 miliseconds for creating image. 50 for drawing.
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
            {
                if (bwAlgorithm != null)
                {
                    bwAlgorithm.CancelAsync();
                    bwAlgorithm.Dispose();
                }
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }
        
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            if (image != null)
                g.DrawImage(image, GetRegion());
            g.DrawString(data, this.Font, Brushes.Black, new Point(10, canvas.Bottom - 100));
        }

        private Rectangle GetRegion()
        {
            int width = canvas.Width - 10;
            int height = canvas.Height - 110;

            if (height < width)
                width = height;
            else
                height = width;

            return new Rectangle((canvas.Width - width)/2, 10, width, height);
        }

        private void ProgressViewerDirectPaint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void canvas_Click(object sender, EventArgs e)
        {
            new SolutionViewer(this.population[0]).Show();
        }
    }
}
