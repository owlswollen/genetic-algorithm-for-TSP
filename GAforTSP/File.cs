using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace GAforTSP
{
    class File
    {
        public string name = "";
        public string type = "";
        public string comment = "";
        public int dimension = 0;
        public string edgeWeightType = "";
        public List<double[]> nodeCoords = new List<double[]>();
        public bool fileSelected = false;

        public string Operate()
        {
            OpenFile();
            ReadFile();
            string message = Control();
            return message;
        }

        List<string> lines = new List<string>();
        public void OpenFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "TSPLIB Files | *.tsp";
            fileDialog.Title = "Choose File";
            DialogResult result = fileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    using (StreamReader reader = new StreamReader(fileDialog.FileName))
                    {
                        fileSelected = true;
                        string line;
                        while ((line = reader.ReadLine()) != null)
                            lines.Add(line);
                    }
                }
                catch
                {
                    fileSelected = false;
                }
            }
        }

        int coordStartIndex = 0;
        int i = 0;
        public void ReadFile()
        {
            foreach (string line in lines)
            {
                string firstPart = line.Split(':')[0];
                int len = line.Split(' ').Length;
                string secondPart = line.Split(' ')[len - 1];
                switch (firstPart)
                {
                    case "NAME ":
                    case "NAME":
                        name = secondPart;
                        break;
                    case "TYPE ":
                    case "TYPE":
                        type = secondPart;
                        break;
                    case "COMMENT ":
                    case "COMMENT":
                        comment = "";
                        string tempString = line.Split(':')[1];
                        for (int i = 1; i < len - 1; i++)
                            comment += tempString.Split(' ')[i] + " ";
                        break;
                    case "DIMENSION ":
                    case "DIMENSION":
                        dimension = Convert.ToInt32(secondPart);
                        break;
                    case "EDGE_WEIGHT_TYPE ":
                    case "EDGE_WEIGHT_TYPE":
                        edgeWeightType = secondPart;
                        break;
                    case "NODE_COORD_SECTION":
                        coordStartIndex = i + 1;
                        break;
                    default:
                        break;
                }
                i++;
            }
        }

        public string Control()
        {
            string message = "";
            if (!fileSelected)
                message = "";
            else
            {
                if (!type.Equals("TSP"))
                    message = "Type must be TSP.";
                if (!(edgeWeightType.Equals("EUC_2D") || edgeWeightType.Equals("MAX_2D") || edgeWeightType.Equals("MAN_2D") || edgeWeightType.Equals("CEIL_2D")))
                    message = "Edge weight type must be EUC_2D, MAX_2D, MAN_2D or CEIL_2D.";
            }
            return message;
        }

        public void ReadCoords()
        {
            int fileLen = dimension + coordStartIndex;
            for (int i = coordStartIndex; i < fileLen; i++)
            {
                double[] tempCoords = new double[2];
                int len = lines[i].Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
                Array arr = lines[i].Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
                tempCoords[0] = Convert.ToDouble(lines[i].Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries)[len - 2]);
                tempCoords[1] = Convert.ToDouble(lines[i].Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries)[len - 1]);
                nodeCoords.Add(tempCoords);
            }
        }

        public void WriteToFile(string tour, double cost)
        {
            List<string> output = new List<string>();
            output.Add("NAME : " + name);
            output.Add("TYPE : TOUR");
            output.Add("COMMENT : Optimal solution for " + name + " " + "(" + cost + ")");
            output.Add("DIMENSION : " + dimension);
            output.Add("TOUR_SECTION");
            string[] nodes = tour.Split(' ');
            int nodesLength = nodes.Length;
            for (int i = 0; i < nodesLength; i++)
            {
                output.Add(nodes[i]);
            }
            output.Add("-1");
            output.Add("EOF");

            string filePath = AppDomain.CurrentDomain.BaseDirectory;
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(filePath, name + ".opt.tour")))
            {
                foreach (string line in output)
                    outputFile.WriteLine(line);
            }
        }
    }
}