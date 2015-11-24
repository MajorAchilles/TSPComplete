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
            if (tspImage != null)
                tspImage.Dispose();
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDownCityCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownMutationChance = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownMaxGenerations = new System.Windows.Forms.NumericUpDown();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownEliteCount = new System.Windows.Forms.NumericUpDown();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxViewPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCityCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMutationChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxGenerations)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEliteCount)).BeginInit();
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
            this.pictureBoxViewPort.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBoxViewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxViewPort.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxViewPort.Name = "pictureBoxViewPort";
            this.pictureBoxViewPort.Size = new System.Drawing.Size(790, 684);
            this.pictureBoxViewPort.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxViewPort.TabIndex = 0;
            this.pictureBoxViewPort.TabStop = false;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(30, 341);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(149, 40);
            this.buttonStart.TabIndex = 7;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(30, 108);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 40);
            this.button2.TabIndex = 6;
            this.button2.Text = "View A Solution";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.button1.Location = new System.Drawing.Point(30, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "Regenerate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.numericUpDownCityCount.TabIndex = 2;
            this.numericUpDownCityCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownCityCount.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Mutation Chance:";
            // 
            // numericUpDownMutationChance
            // 
            this.numericUpDownMutationChance.Location = new System.Drawing.Point(128, 239);
            this.numericUpDownMutationChance.Name = "numericUpDownMutationChance";
            this.numericUpDownMutationChance.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownMutationChance.TabIndex = 8;
            this.numericUpDownMutationChance.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Generations: ";
            // 
            // numericUpDownMaxGenerations
            // 
            this.numericUpDownMaxGenerations.Location = new System.Drawing.Point(128, 270);
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
            this.numericUpDownMaxGenerations.TabIndex = 10;
            this.numericUpDownMaxGenerations.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 26);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Elite Count:";
            // 
            // numericUpDownEliteCount
            // 
            this.numericUpDownEliteCount.Location = new System.Drawing.Point(128, 305);
            this.numericUpDownEliteCount.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownEliteCount.Name = "numericUpDownEliteCount";
            this.numericUpDownEliteCount.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownEliteCount.TabIndex = 12;
            this.numericUpDownEliteCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCityCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMutationChance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxGenerations)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEliteCount)).EndInit();
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown numericUpDownCityCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownEliteCount;
    }
}

