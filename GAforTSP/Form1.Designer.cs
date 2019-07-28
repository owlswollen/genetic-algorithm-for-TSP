namespace GAforTSP
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.radioButtonOnePoint = new System.Windows.Forms.RadioButton();
            this.radioButtonTwoPoint = new System.Windows.Forms.RadioButton();
            this.radioButtonAlterEdges = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxPc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxRe = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxGenNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPopSize = new System.Windows.Forms.TextBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(25, 516);
            this.buttonRun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(232, 32);
            this.buttonRun.TabIndex = 0;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(23, 30);
            this.buttonOpenFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(232, 34);
            this.buttonOpenFile.TabIndex = 1;
            this.buttonOpenFile.Text = "Open File";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(15, 15);
            this.richTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(297, 86);
            this.richTextBox.TabIndex = 2;
            this.richTextBox.Text = "";
            // 
            // radioButtonOnePoint
            // 
            this.radioButtonOnePoint.AutoSize = true;
            this.radioButtonOnePoint.Location = new System.Drawing.Point(8, 26);
            this.radioButtonOnePoint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonOnePoint.Name = "radioButtonOnePoint";
            this.radioButtonOnePoint.Size = new System.Drawing.Size(97, 21);
            this.radioButtonOnePoint.TabIndex = 3;
            this.radioButtonOnePoint.Text = "One-Point ";
            this.radioButtonOnePoint.UseVisualStyleBackColor = true;
            // 
            // radioButtonTwoPoint
            // 
            this.radioButtonTwoPoint.AutoSize = true;
            this.radioButtonTwoPoint.Location = new System.Drawing.Point(8, 55);
            this.radioButtonTwoPoint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonTwoPoint.Name = "radioButtonTwoPoint";
            this.radioButtonTwoPoint.Size = new System.Drawing.Size(92, 21);
            this.radioButtonTwoPoint.TabIndex = 4;
            this.radioButtonTwoPoint.Text = "Two-Point";
            this.radioButtonTwoPoint.UseVisualStyleBackColor = true;
            // 
            // radioButtonAlterEdges
            // 
            this.radioButtonAlterEdges.AutoSize = true;
            this.radioButtonAlterEdges.Checked = true;
            this.radioButtonAlterEdges.Location = new System.Drawing.Point(8, 84);
            this.radioButtonAlterEdges.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonAlterEdges.Name = "radioButtonAlterEdges";
            this.radioButtonAlterEdges.Size = new System.Drawing.Size(141, 21);
            this.radioButtonAlterEdges.TabIndex = 5;
            this.radioButtonAlterEdges.TabStop = true;
            this.radioButtonAlterEdges.Text = "Alternating Edges";
            this.radioButtonAlterEdges.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonTwoPoint);
            this.groupBox1.Controls.Add(this.radioButtonAlterEdges);
            this.groupBox1.Controls.Add(this.radioButtonOnePoint);
            this.groupBox1.Location = new System.Drawing.Point(23, 79);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(232, 117);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crossover";
            // 
            // textBoxPc
            // 
            this.textBoxPc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxPc.Location = new System.Drawing.Point(176, 16);
            this.textBoxPc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPc.Name = "textBoxPc";
            this.textBoxPc.Size = new System.Drawing.Size(41, 22);
            this.textBoxPc.TabIndex = 7;
            this.textBoxPc.Text = "0.7";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Crossover Probability:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "Mutation Probability:";
            // 
            // textBoxPm
            // 
            this.textBoxPm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxPm.Location = new System.Drawing.Point(176, 57);
            this.textBoxPm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPm.Name = "textBoxPm";
            this.textBoxPm.Size = new System.Drawing.Size(41, 22);
            this.textBoxPm.TabIndex = 9;
            this.textBoxPm.Text = "0.05";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Elitism Rate:";
            // 
            // textBoxRe
            // 
            this.textBoxRe.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxRe.Location = new System.Drawing.Point(177, 94);
            this.textBoxRe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRe.Name = "textBoxRe";
            this.textBoxRe.Size = new System.Drawing.Size(41, 22);
            this.textBoxRe.TabIndex = 11;
            this.textBoxRe.Text = "0.2";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 23);
            this.label4.TabIndex = 15;
            this.label4.Text = "Number of Generations:";
            // 
            // textBoxGenNum
            // 
            this.textBoxGenNum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxGenNum.Location = new System.Drawing.Point(177, 16);
            this.textBoxGenNum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxGenNum.Name = "textBoxGenNum";
            this.textBoxGenNum.Size = new System.Drawing.Size(41, 22);
            this.textBoxGenNum.TabIndex = 14;
            this.textBoxGenNum.Text = "1000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 59);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Population Size:";
            // 
            // textBoxPopSize
            // 
            this.textBoxPopSize.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxPopSize.Location = new System.Drawing.Point(177, 55);
            this.textBoxPopSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPopSize.Name = "textBoxPopSize";
            this.textBoxPopSize.Size = new System.Drawing.Size(41, 22);
            this.textBoxPopSize.TabIndex = 16;
            this.textBoxPopSize.Text = "500";
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(16, 108);
            this.chart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(913, 446);
            this.chart.TabIndex = 13;
            this.chart.Text = "chart1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 560);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(913, 23);
            this.progressBar1.TabIndex = 18;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(319, 14);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(609, 86);
            this.richTextBox1.TabIndex = 19;
            this.richTextBox1.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxPc);
            this.groupBox2.Controls.Add(this.textBoxPm);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxRe);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(23, 204);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(232, 133);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBoxGenNum);
            this.groupBox3.Controls.Add(this.textBoxPopSize);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(23, 345);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(232, 97);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Controls.Add(this.buttonRun);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.buttonOpenFile);
            this.groupBox4.Location = new System.Drawing.Point(937, 6);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(279, 577);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(25, 449);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(230, 53);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "Generate initial population by greedy approach";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 614);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.richTextBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.RadioButton radioButtonOnePoint;
        private System.Windows.Forms.RadioButton radioButtonTwoPoint;
        private System.Windows.Forms.RadioButton radioButtonAlterEdges;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxPc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxRe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxGenNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPopSize;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.CheckBox checkBox1;
    }
}

