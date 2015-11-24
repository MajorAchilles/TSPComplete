using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Axiard.Utilities.Extensions;

namespace TSPTest
{
    public partial class ProgressViewer : Form
    {
        int bestCounter = 0;
        double bestDistance = 99999;
        int worstCounter = 0;
        double worstDistance = -100;
        TSPGeneticAlgorithm ga;

        private RandomSolution[] population;

        public ProgressViewer()
        {
            InitializeComponent();
        }

        public ProgressViewer(RandomSolution[] population)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.population = population;
            ga = new TSPGeneticAlgorithm(population, 4, 1, 20);
        }

        private void DrawPopulation()
        {
            bestCounter = 0;
            bestDistance = 99999;
            worstCounter = 0;
            worstDistance = -100;

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                PictureBox pB = (PictureBox)tableLayoutPanel1.Controls[i];
                pB.BackColor = SystemColors.Control;
                double distance = population[i].TourDistance;
                pB.Image = population[i].DrawSolution();
                if (distance < bestDistance)
                {
                    bestDistance = distance;
                    bestCounter = i;
                }

                if (distance > worstDistance)
                {
                    worstDistance = distance;
                    worstCounter = i;
                }

                pB.Tag = i;
            }

            PictureBox pbColor = (PictureBox)tableLayoutPanel1.Controls[bestCounter];
            pbColor.BackColor = Color.LightGreen;
            pbColor = (PictureBox)tableLayoutPanel1.Controls[worstCounter];
            pbColor.BackColor = Color.LightPink;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox pB = (PictureBox)sender;
            new SolutionViewer(population[(int)pB.Tag]).ShowDialog();
        }

        private void ProgressViewer_Load(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.DoWork += Bw_DoWork;
            bw.ProgressChanged += Bw_ProgressChanged;
            bw.RunWorkerAsync();
        }

        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            DrawPopulation();
            textBox1.Text += "Generation " + ga.GenerationNo + Environment.NewLine;
            textBox1.Text += "Best distance: " + bestDistance + Environment.NewLine;
            textBox1.Text += "Worst distance: " + worstDistance + Environment.NewLine;
            textBox1.ScrollTextBoxToBottom();
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            while (ga.GenerationNo < 30)
            {
                worker.ReportProgress(0);
                population = ga.GetNextGeneration();
            }
        }
    }
}
