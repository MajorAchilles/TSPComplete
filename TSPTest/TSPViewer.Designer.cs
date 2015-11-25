namespace TSPTest
{
    partial class TSPViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBoxViewPort = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonManual = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownPopulationSize = new System.Windows.Forms.NumericUpDown();
            this.comboBoxCrossOverMethod = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownEliteCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownMaxGenerations = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownMutationChance = new System.Windows.Forms.NumericUpDown();
            this.buttonStart = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDownCityCount = new System.Windows.Forms.NumericUpDown();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxViewPort)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopulationSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEliteCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxGenerations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMutationChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCityCount)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBoxViewPort);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonManual);
            this.splitContainer1.Panel2.Controls.Add(this.buttonLoad);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSave);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.numericUpDownPopulationSize);
            this.splitContainer1.Panel2.Controls.Add(this.comboBoxCrossOverMethod);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.numericUpDownEliteCount);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.numericUpDownMaxGenerations);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.numericUpDownMutationChance);
            this.splitContainer1.Panel2.Controls.Add(this.buttonStart);
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.numericUpDownCityCount);
            this.splitContainer1.Size = new System.Drawing.Size(1003, 684);
            this.splitContainer1.SplitterDistance = 790;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBoxViewPort
            // 
            this.pictureBoxViewPort.ContextMenuStrip = this.contextMenuStrip;
            this.pictureBoxViewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxViewPort.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxViewPort.Name = "pictureBoxViewPort";
            this.pictureBoxViewPort.Size = new System.Drawing.Size(790, 684);
            this.pictureBoxViewPort.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxViewPort.TabIndex = 0;
            this.pictureBoxViewPort.TabStop = false;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(101, 48);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.Load_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.Save_Click);
            // 
            // buttonManual
            // 
            this.buttonManual.Location = new System.Drawing.Point(30, 12);
            this.buttonManual.Name = "buttonManual";
            this.buttonManual.Size = new System.Drawing.Size(149, 33);
            this.buttonManual.TabIndex = 0;
            this.buttonManual.Text = "Manual";
            this.buttonManual.UseVisualStyleBackColor = true;
            this.buttonManual.Click += new System.EventHandler(this.ButtonManual_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(30, 532);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(149, 41);
            this.buttonLoad.TabIndex = 10;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.Load_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(30, 593);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(149, 41);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Population Size";
            // 
            // numericUpDownPopulationSize
            // 
            this.numericUpDownPopulationSize.Location = new System.Drawing.Point(128, 203);
            this.numericUpDownPopulationSize.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownPopulationSize.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDownPopulationSize.Name = "numericUpDownPopulationSize";
            this.numericUpDownPopulationSize.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownPopulationSize.TabIndex = 3;
            this.numericUpDownPopulationSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // comboBoxCrossOverMethod
            // 
            this.comboBoxCrossOverMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCrossOverMethod.FormattingEnabled = true;
            this.comboBoxCrossOverMethod.Items.AddRange(new object[] {
            "Random",
            "Greedy"});
            this.comboBoxCrossOverMethod.Location = new System.Drawing.Point(91, 307);
            this.comboBoxCrossOverMethod.Name = "comboBoxCrossOverMethod";
            this.comboBoxCrossOverMethod.Size = new System.Drawing.Size(88, 21);
            this.comboBoxCrossOverMethod.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Crossover:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Elite Percentage:";
            // 
            // numericUpDownEliteCount
            // 
            this.numericUpDownEliteCount.Location = new System.Drawing.Point(128, 281);
            this.numericUpDownEliteCount.Name = "numericUpDownEliteCount";
            this.numericUpDownEliteCount.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownEliteCount.TabIndex = 6;
            this.numericUpDownEliteCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Generations: ";
            // 
            // numericUpDownMaxGenerations
            // 
            this.numericUpDownMaxGenerations.Location = new System.Drawing.Point(128, 255);
            this.numericUpDownMaxGenerations.Maximum = new decimal(new int[] {
            16000,
            0,
            0,
            0});
            this.numericUpDownMaxGenerations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMaxGenerations.Name = "numericUpDownMaxGenerations";
            this.numericUpDownMaxGenerations.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownMaxGenerations.TabIndex = 5;
            this.numericUpDownMaxGenerations.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Mutation Chance:";
            // 
            // numericUpDownMutationChance
            // 
            this.numericUpDownMutationChance.Location = new System.Drawing.Point(128, 229);
            this.numericUpDownMutationChance.Name = "numericUpDownMutationChance";
            this.numericUpDownMutationChance.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownMutationChance.TabIndex = 4;
            this.numericUpDownMutationChance.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(30, 341);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(149, 40);
            this.buttonStart.TabIndex = 8;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(30, 396);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 40);
            this.button2.TabIndex = 9;
            this.button2.Text = "View A Solution";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ButtonViewSolution_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "City Count:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Regenerate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ButtonRegenerate_Click);
            // 
            // numericUpDownCityCount
            // 
            this.numericUpDownCityCount.Location = new System.Drawing.Point(128, 62);
            this.numericUpDownCityCount.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownCityCount.Name = "numericUpDownCityCount";
            this.numericUpDownCityCount.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownCityCount.TabIndex = 1;
            this.numericUpDownCityCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownCityCount.ValueChanged += new System.EventHandler(this.NumericUpDownCities_ValueChanged);
            // 
            // TSPViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 684);
            this.Controls.Add(this.splitContainer1);
            this.Name = "TSPViewer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxViewPort)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopulationSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEliteCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxGenerations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMutationChance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCityCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBoxViewPort;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownMutationChance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxGenerations;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown numericUpDownCityCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownEliteCount;
        private System.Windows.Forms.ComboBox comboBoxCrossOverMethod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownPopulationSize;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.Button buttonManual;
    }
}

