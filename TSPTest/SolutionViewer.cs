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
        public SolutionViewer(Organism solution)
        {
            InitializeComponent();

            this.pictureBox1.Image = solution.Tour.DrawTour();
            this.Text = "Distance: " + solution.Fitness;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "Solution";
            sfd.DefaultExt = ".bmp";
            sfd.Filter ="Bitmap File (*.bmp)| *.bmp";
            sfd.FilterIndex = 0;
            sfd.RestoreDirectory = true;
            sfd.SupportMultiDottedExtensions = true;
            sfd.OverwritePrompt = true;
            sfd.Title = "Save solution image";
            if(sfd.ShowDialog()== DialogResult.OK)
            {
                Bitmap bmp = (Bitmap) this.pictureBox1.Image;
                bmp.Save(sfd.FileName);
            }
        }
    }
}
