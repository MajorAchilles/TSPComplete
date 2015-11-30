using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace TSPTest
{
    public partial class TSPViewer : Form
    {
        int cityCount = 30;
        List<Point> cities;
        TSPGenerator tspGenerator;
        const int horizontalSize = 900;
        const int verticalSize = 900;
        const int border = 10;

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
            comboBoxCrossOverMethod.SelectedIndex = comboBoxMutationMethod.SelectedIndex = 0;

            tspGenerator = new TSPGenerator(cityCount, HorizontalSize, VerticalSize, Border);
            cities = tspGenerator.GenerateCities();
            pictureBoxViewPort.Image = cities.DrawCities();
        }

        private void ButtonRegenerate_Click(object sender, EventArgs e)
        {
            cities = tspGenerator.GenerateCities();
            pictureBoxViewPort.Image = cities.DrawCities();
        }

        private void NumericUpDownCities_ValueChanged(object sender, EventArgs e)
        {
            tspGenerator.MaxCities = this.cityCount = (int)numericUpDownCityCount.Value;
        }

        private void ButtonViewSolution_Click(object sender, EventArgs e)
        {
            Organism randomSolution = cities.CreateRandomSolution();
            new SolutionViewer(randomSolution).Show();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Organism[] population = new Organism[(int)numericUpDownPopulationSize.Value];
            for (int i = 0; i < population.Count(); i++)
            {
                Organism solution = cities.CreateRandomSolution();
                population[i] = solution;
            }

            TSPOptions options = new TSPOptions();
            options.population = population;
            options.populationSize = (int)numericUpDownPopulationSize.Value;
            options.maxGenerations = (int)numericUpDownMaxGenerations.Value;
            options.mutationPopulationPercentage = (int)numericUpDownMutationPopulation.Value;
            options.mutationIndividualPercentage = (int)numericUpDownMutationIndividual.Value;
            options.elitePercentage = (int)numericUpDownEliteCount.Value;
            options.crossOverMethod = (CrossOverMethod)comboBoxCrossOverMethod.SelectedIndex;
            options.mutationMethod = (MutationMethod)comboBoxMutationMethod.SelectedIndex;

            if (checkBoxEliteOnly.Checked)
                new ProgressViewerElite(options).ShowDialog();
            else
                new ProgressViewerDirectPaint(options).ShowDialog();
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
                    Bitmap bmp = (Bitmap)pictureBoxViewPort.Image;
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

            TSPOptions options = new TSPOptions();
            options.populationSize = (int)numericUpDownPopulationSize.Value;
            options.maxGenerations = (int)numericUpDownMaxGenerations.Value;
            options.mutationPopulationPercentage = (int)numericUpDownMutationPopulation.Value;
            options.mutationIndividualPercentage = (int)numericUpDownMutationIndividual.Value;
            options.elitePercentage = (int)numericUpDownEliteCount.Value;
            options.crossOverMethod = (CrossOverMethod)comboBoxCrossOverMethod.SelectedIndex;
            options.mutationMethod = (MutationMethod)comboBoxMutationMethod.SelectedIndex;

            XmlDocument document = new XmlDocument();
            XmlNode problem = document.CreateElement("problem");
            XmlAttribute attr = document.CreateAttribute("count");
            attr.Value = cityCount.ToString();
            problem.Attributes.Append(attr);
            foreach (Point point in cities)
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
                    cities = xmlCities.ToList();

                    this.pictureBoxViewPort.Image = cities.DrawCities();
                }
                catch
                {
                    MessageBox.Show("Invalid XML file!!!");
                }
            }
            else
                MessageBox.Show("File not found!");
        }

        private void ButtonManual_Click(object sender, EventArgs e)
        {
            new TSPManualCreator().ShowDialog();
        }
    }
}
