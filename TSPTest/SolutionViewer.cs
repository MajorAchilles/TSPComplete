﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace TSPTest
{
    public partial class SolutionViewer : Form
    {
        Organism solution;
        bool updateConstant = false;

        public bool UpdateConstant
        {
            get
            {
                return updateConstant;
            }

            set
            {
                updateConstant = value;
            }
        }

        public Organism Solution
        {
            get
            {
                return solution;
            }

            set
            {
                solution = value;
                if (updateConstant)
                    this.pictureBox.Image = solution.Tour.DrawTour();
            }
        }

        public SolutionViewer(Organism solution)
        {
            InitializeComponent();

            this.Solution = solution;
            this.pictureBox.Image = solution.Tour.DrawTour();
            this.Text = "Distance: " + solution.Fitness;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "Problem";
            sfd.Filter = "Bitmap File (*.bmp)|*.bmp|XML File (*.xml)|*.xml";
            sfd.FilterIndex = 0;
            sfd.RestoreDirectory = true;
            sfd.OverwritePrompt = true;
            sfd.SupportMultiDottedExtensions = false;
            sfd.Title = "Save problem image";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (sfd.FilterIndex == 1)
                {
                    Bitmap bmp = (Bitmap)pictureBox.Image;
                    bmp.Save(sfd.FileName);
                }
                else
                {
                    SaveAsXML(sfd.FileName);
                }
            }
        }

        private void SaveAsXML(string fileName)
        {
            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load(ProgramSettings.Paths.ProgramDataConfigPath + "Settings.xml");
            //XmlNode documentRoot = xmlDoc.DocumentElement;
            //XmlNode databaseConnectionString = documentRoot.ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes[0];
            //databaseConnectionString.Value = GetCryptography().Encrypt(connectionString);
            //xmlDoc.Save(ProgramSettings.Paths.ProgramDataConfigPath + "Settings.xml");
            //success = true;

            XmlDocument document = new XmlDocument();
            XmlNode problem = document.CreateElement("solution");
            XmlAttribute attr = document.CreateAttribute("count");
            attr.Value = Solution.Tour.Count.ToString();
            problem.Attributes.Append(attr);

            foreach (Point point in Solution.Tour)
            {
                XmlNode pointNode = document.CreateElement("point");
                XmlAttribute x = document.CreateAttribute("x");
                x.Value = point.X.ToString();
                XmlAttribute y = document.CreateAttribute("y");
                y.Value = point.Y.ToString();
                pointNode.Attributes.Append(x);
                pointNode.Attributes.Append(y);
                problem.AppendChild(pointNode);
            }

            document.AppendChild(problem);
            document.Save(fileName);
        }

        private void Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "Problem";
            ofd.Filter = "XML File (*.xml)|*.xml";
            ofd.FilterIndex = 0;
            ofd.RestoreDirectory = true;
            ofd.SupportMultiDottedExtensions = false;
            ofd.Title = "Open problem file...";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadXML(ofd.FileName);
            }
        }

        private void LoadXML(string fileName)
        {

            if (File.Exists(fileName))
            {
                try
                {
                    List<Point> xmlCities = new List<Point>();
                    XmlDocument document = new XmlDocument();
                    document.Load(fileName);

                    foreach (XmlNode point in document.DocumentElement.ChildNodes)
                    {
                        int x = Convert.ToInt32(point.Attributes[0].Value);
                        int y = Convert.ToInt32(point.Attributes[1].Value);
                        Point city = new Point(x, y);
                        xmlCities.Add(city);
                    }
                    Solution.Tour = xmlCities.ToList();

                    //DrawCities();
                }
                catch
                {
                    MessageBox.Show("Invalid XML file!!!");
                }
            }
            else
                MessageBox.Show("File not found!");
        }
    }
}
