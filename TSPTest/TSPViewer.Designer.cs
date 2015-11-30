﻿namespace TSPTest
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownMutationIndividual = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxMutationMethod = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownMutationPopulation = new System.Windows.Forms.NumericUpDown();
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDownCityCount = new System.Windows.Forms.NumericUpDown();
            this.checkBoxEliteOnly = new System.Windows.Forms.CheckBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxViewPort)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMutationIndividual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMutationPopulation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopulationSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEliteCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxGenerations)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxEliteOnly);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.numericUpDownMutationIndividual);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboBoxMutationMethod);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDownMutationPopulation);
            this.groupBox1.Location = new System.Drawing.Point(11, 277);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 103);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mutation:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Individual %";
            // 
            // numericUpDownMutationIndividual
            // 
            this.numericUpDownMutationIndividual.Location = new System.Drawing.Point(117, 75);
            this.numericUpDownMutationIndividual.Name = "numericUpDownMutationIndividual";
            this.numericUpDownMutationIndividual.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownMutationIndividual.TabIndex = 20;
            this.numericUpDownMutationIndividual.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Mutation:";
            // 
            // comboBoxMutationMethod
            // 
            this.comboBoxMutationMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMutationMethod.FormattingEnabled = true;
            this.comboBoxMutationMethod.Items.AddRange(new object[] {
            "Greedy",
            "2opt"});
            this.comboBoxMutationMethod.Location = new System.Drawing.Point(80, 13);
            this.comboBoxMutationMethod.Name = "comboBoxMutationMethod";
            this.comboBoxMutationMethod.Size = new System.Drawing.Size(88, 21);
            this.comboBoxMutationMethod.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Population %";
            // 
            // numericUpDownMutationPopulation
            // 
            this.numericUpDownMutationPopulation.Location = new System.Drawing.Point(117, 46);
            this.numericUpDownMutationPopulation.Name = "numericUpDownMutationPopulation";
            this.numericUpDownMutationPopulation.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownMutationPopulation.TabIndex = 4;
            this.numericUpDownMutationPopulation.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
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
            this.buttonLoad.Location = new System.Drawing.Point(30, 574);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(149, 41);
            this.buttonLoad.TabIndex = 10;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.Load_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(30, 635);
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
            this.label6.Location = new System.Drawing.Point(27, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Population Size";
            // 
            // numericUpDownPopulationSize
            // 
            this.numericUpDownPopulationSize.Location = new System.Drawing.Point(128, 173);
            this.numericUpDownPopulationSize.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownPopulationSize.Minimum = new decimal(new int[] {
            1,
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
            "Greedy",
            "Subtour"});
            this.comboBoxCrossOverMethod.Location = new System.Drawing.Point(91, 250);
            this.comboBoxCrossOverMethod.Name = "comboBoxCrossOverMethod";
            this.comboBoxCrossOverMethod.Size = new System.Drawing.Size(88, 21);
            this.comboBoxCrossOverMethod.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Crossover:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Elite Percentage:";
            // 
            // numericUpDownEliteCount
            // 
            this.numericUpDownEliteCount.Location = new System.Drawing.Point(128, 224);
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
            this.label3.Location = new System.Drawing.Point(27, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Generations: ";
            // 
            // numericUpDownMaxGenerations
            // 
            this.numericUpDownMaxGenerations.Location = new System.Drawing.Point(128, 198);
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
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(30, 427);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(149, 40);
            this.buttonStart.TabIndex = 8;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(30, 482);
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
            // checkBoxEliteOnly
            // 
            this.checkBoxEliteOnly.AutoSize = true;
            this.checkBoxEliteOnly.Checked = true;
            this.checkBoxEliteOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEliteOnly.Location = new System.Drawing.Point(30, 404);
            this.checkBoxEliteOnly.Name = "checkBoxEliteOnly";
            this.checkBoxEliteOnly.Size = new System.Drawing.Size(96, 17);
            this.checkBoxEliteOnly.TabIndex = 21;
            this.checkBoxEliteOnly.Text = "View Elite Only";
            this.checkBoxEliteOnly.UseVisualStyleBackColor = true;
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMutationIndividual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMutationPopulation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopulationSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEliteCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxGenerations)).EndInit();
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
        private System.Windows.Forms.NumericUpDown numericUpDownMutationPopulation;
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
        private System.Windows.Forms.ComboBox comboBoxMutationMethod;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownMutationIndividual;
        private System.Windows.Forms.CheckBox checkBoxEliteOnly;
    }
}

