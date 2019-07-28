using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace GAforTSP
{
    public partial class Form1 : Form
    {
        File file;
        GA geneticAlgorithm;
        TSP tSP;
        double crossoverProb, mutationProb, elitismRate;
        int generationNum, popSize;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            try
            {
                crossoverProb = Convert.ToDouble(textBoxPc.Text);
                mutationProb = Convert.ToDouble(textBoxPm.Text);
                elitismRate = Convert.ToDouble(textBoxRe.Text);
                generationNum = Convert.ToInt32(textBoxGenNum.Text);
                popSize = Convert.ToInt32(textBoxPopSize.Text);
                progressBar1.Maximum = generationNum + 1;
                progressBar1.Minimum = 0;
                progressBar1.Value = 0;

                if (crossoverProb > 1 || crossoverProb < 0)
                {
                    textBoxPc.Clear();
                    MessageBox.Show("Pc must be in the interval [0, 1].");
                }
                if (mutationProb > 1 || mutationProb < 0)
                {
                    textBoxPm.Clear();
                    MessageBox.Show("Pm must be in the interval [0, 1].");
                }
                if (elitismRate > 1 || elitismRate < 0)
                {
                    textBoxRe.Clear();
                    MessageBox.Show("Re must be in the interval [0, 1].");
                    elitismRate = Convert.ToDouble(textBoxRe.Text);
                }
                if (generationNum < 0)
                {
                    textBoxGenNum.Clear();
                    MessageBox.Show("Number of generationNums must be positive.");
                }
                if (popSize < 0)
                {
                    textBoxPopSize.Clear();
                    MessageBox.Show("Population size must be positive.");
                }
            }
            catch
            {
                MessageBox.Show("Invalid parameters!");
            }
            try
            {
                switch (file.edgeWeightType)
                {
                    case "EUC_2D":
                        tSP = new TSP(file.nodeCoords, file.dimension, TSP.EdgeWeightType.EUC_2D);
                        break;
                    case "MAN_2D":
                        tSP = new TSP(file.nodeCoords, file.dimension, TSP.EdgeWeightType.MAN_2D);
                        break;
                    case "MAX_2D":
                        tSP = new TSP(file.nodeCoords, file.dimension, TSP.EdgeWeightType.MAX_2D);
                        break;
                    case "CEIL_2D":
                        tSP = new TSP(file.nodeCoords, file.dimension, TSP.EdgeWeightType.CEIL_2D);
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Please select a file.");
            }
            try
            {
                GA.chromLen = file.dimension;
                GA.popSize = popSize;
                GA.tSP = tSP;
                geneticAlgorithm = new GA();
                if (radioButtonAlterEdges.Checked)
                    Run(geneticAlgorithm.AlternatingEdgesCO);
                else if (radioButtonOnePoint.Checked)
                    Run(geneticAlgorithm.OnePointCO);
                else if (radioButtonTwoPoint.Checked)
                    Run(geneticAlgorithm.TwoPointCO);

                richTextBox1.Text = "Best Distance: " + geneticAlgorithm.bestOfBest.Distance() + "\n";
                richTextBox1.Text += "Best Path:\n" + geneticAlgorithm.bestOfBest.Print() + "\n";

                file.WriteToFile(geneticAlgorithm.bestOfBest.Print(), geneticAlgorithm.bestOfBest.Distance());
            }
            catch
            {
                //MessageBox.Show("");
            }
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            file = new File();
            richTextBox.Text = "";
            string message = file.Operate();
            if (!message.Equals(""))
                MessageBox.Show(message);
            else
            {
                file.ReadCoords();
                richTextBox.Text += "Name: " + file.name + "\n";
                richTextBox.Text += "Type: " + file.type + "\n";
                richTextBox.Text += "Comment: " + file.comment + "\n";
                richTextBox.Text += "Dimension: " + file.dimension + "\n";
                richTextBox.Text += "Edge weight type: " + file.edgeWeightType + "\n";
            }
        }

        private void Run(Func<GA.Chromosome, GA.Chromosome, List<GA.Chromosome>> Crossover)
        {
            chart.Series.Clear();
            Series bestSeries = new Series();
            Series averageSeries = new Series();
            Series bestOfSeries = new Series();
            //bestSeries.ChartType = SeriesChartType.Line;
            bestOfSeries.ChartType = SeriesChartType.Line;
            averageSeries.ChartType = SeriesChartType.Line;
            //bestSeries.Name = "Best";
            bestOfSeries.Name = "Best";
            averageSeries.Name = "Average";
            bool greedy = false;
            if (checkBox1.Checked)
                greedy = true;
            geneticAlgorithm.CreatePopulation(greedy);
            Random r = new Random();
            for (int i = 0; i < generationNum; i++)
            {
                progressBar1.Value++;
                geneticAlgorithm.Elitism(elitismRate);
                while (geneticAlgorithm.offsPopulation.Count < popSize)
                {
                    List<GA.Chromosome> parents = new List<GA.Chromosome>();
                    foreach (GA.Chromosome parent in geneticAlgorithm.Selection())
                        parents.Add(parent);
                    double randNum = r.NextDouble();
                    if (randNum <= crossoverProb)
                    {
                        List<GA.Chromosome> offsprings = new List<GA.Chromosome>();
                        foreach (GA.Chromosome offs in Crossover(parents[0], parents[1]))
                            offsprings.Add(offs);
                        foreach (GA.Chromosome offs in offsprings)
                            geneticAlgorithm.offsPopulation.Add(offs);
                    }
                    else
                    {
                        geneticAlgorithm.offsPopulation.Add(parents[0]);
                        if (geneticAlgorithm.offsPopulation.Count < popSize)
                            geneticAlgorithm.offsPopulation.Add(parents[1]);
                    }
                }
                geneticAlgorithm.Mutation(mutationProb);
                geneticAlgorithm.ChangePopulation();
                if (i == 0 || geneticAlgorithm.population[0].Distance() < geneticAlgorithm.bestOfBest.Distance())
                {
                    geneticAlgorithm.bestOfBest = geneticAlgorithm.population[0];
                }
                //bestSeries.Points.AddXY(i, geneticAlgorithm.population[0].Distance());
                bestOfSeries.Points.AddXY(i, geneticAlgorithm.bestOfBest.Distance());
                averageSeries.Points.AddXY(i, geneticAlgorithm.Average());
            }
            chart.ChartAreas[0].AxisX.Maximum = generationNum;
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisY.Maximum = Math.Max(2 * geneticAlgorithm.bestOfBest.Distance(), 2 * geneticAlgorithm.Average());
            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart.MouseWheel += chart1_MouseWheel;
            //chart.Series.Add(bestSeries);
            chart.Series.Add(averageSeries);
            chart.Series.Add(bestOfSeries);
        }

        // https://stackoverflow.com/a/14542854/5589417
        private void chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            var chart = (Chart)sender;
            var xAxis = chart.ChartAreas[0].AxisX;
            var yAxis = chart.ChartAreas[0].AxisY;

            try
            {
                if (e.Delta < 0)
                {
                    xAxis.ScaleView.ZoomReset();
                    yAxis.ScaleView.ZoomReset();
                }
                else if (e.Delta > 0)
                {
                    var xMin = xAxis.ScaleView.ViewMinimum;
                    var xMax = xAxis.ScaleView.ViewMaximum;
                    var yMin = yAxis.ScaleView.ViewMinimum;
                    var yMax = yAxis.ScaleView.ViewMaximum;

                    var posXStart = xAxis.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                    var posXFinish = xAxis.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
                    var posYStart = yAxis.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
                    var posYFinish = yAxis.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;

                    xAxis.ScaleView.Zoom(posXStart, posXFinish);
                    yAxis.ScaleView.Zoom(posYStart, posYFinish);
                }
            }
            catch { }
        }
    }
}
