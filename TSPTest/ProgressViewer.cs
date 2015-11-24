using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Axiard.Utilities.Extensions;
using System.Threading;

namespace TSPTest
{
    public partial class ProgressViewer : Form
    {
        double bestDistance = 99999;
        double worstDistance = -100;
        TSPGeneticAlgorithm ga;
        BackgroundWorker bwAlgorithm;
        //Thread drawingThread;
        bool doneDraw = false;
        int eliteCount;
        int mutationChance;
        int maxGenerations;

        private Organism[] population;

        public ProgressViewer(Organism[] population, int maxGenerations, int mutationChance, int eliteCount)
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

            ga = new TSPGeneticAlgorithm(population, population.Count(), mutationChance, eliteCount);
        }

        private void DrawPopulation()
        {
            doneDraw = false;
            this.SuspendLayout();
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                PictureBox pB = (PictureBox)tableLayoutPanel1.Controls[i];
                pB.BackColor = SystemColors.Control;
                //drawingThread = new Thread(null);
                //drawingThread = new Thread(()=> pB.Image = population[i].Tour.DrawTour());
                //drawingThread.Start();
                //drawingThread.Join();

                
                pB.Image = population[i].Tour.DrawTour(); //Another thread?
                //pB.Image = await DrawImage(population[i].Tour);
                pB.Tag = i;
            }
            //if (ga.GenerationNo % 10 == 0)
            this.ResumeLayout();

            bestDistance = population[0].Fitness;
            worstDistance = population[population.Count() - 1].Fitness;

            PictureBox pbColor = (PictureBox)tableLayoutPanel1.Controls[15];
            pbColor.BackColor = Color.LightPink;
            pbColor = (PictureBox)tableLayoutPanel1.Controls[0];
            pbColor.BackColor = Color.LightGreen;

            doneDraw = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox pB = (PictureBox)sender;
            new SolutionViewer(population[(int)pB.Tag]).ShowDialog();
        }

        private void ProgressViewer_Load(object sender, EventArgs e)
        {
            bwAlgorithm.RunWorkerAsync();
        }

        private void BwAlgorithm_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            DrawPopulation();
            textBox1.Text += "Generation " + e.ProgressPercentage + Environment.NewLine;
            textBox1.Text += "Best distance: " + bestDistance + Environment.NewLine;
            textBox1.Text += "Worst distance: " + worstDistance + Environment.NewLine;
            textBox1.Text += "Average distance: " + (bestDistance+worstDistance)/2 + Environment.NewLine + Environment.NewLine;
            textBox1.ScrollTextBoxToBottom();
        }

        private void BwAlgorithm_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            while (ga.GenerationNo <= maxGenerations)
            {
                worker.ReportProgress(ga.GenerationNo);
                Thread.Sleep(100);
                while (!doneDraw)
                    Thread.Sleep(200);

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
    }
}
