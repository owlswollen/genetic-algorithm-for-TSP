using System;
using System.Collections.Generic;

namespace GAforTSP
{
    class TSP
    {
        public double[,] distMatrix;
        public enum EdgeWeightType { EUC_2D, MAX_2D, MAN_2D, CEIL_2D }

        public TSP(List<double[]> nodeCoords, int size, EdgeWeightType edgeWeightType)
        {
            distMatrix = new double[size, size];
            switch (edgeWeightType)
            {
                case EdgeWeightType.EUC_2D:
                    CreateDistMatrix(nodeCoords, EUC_2D);
                    break;
                case EdgeWeightType.MAX_2D:
                    CreateDistMatrix(nodeCoords, MAX_2D);
                    break;
                case EdgeWeightType.MAN_2D:
                    CreateDistMatrix(nodeCoords, MAN_2D);
                    break;
                case EdgeWeightType.CEIL_2D:
                    CreateDistMatrix(nodeCoords, CEIL_2D);
                    break;
            }
        }
        public void CreateDistMatrix(List<double[]> nodeCoords, Func<double, double, double, double, double> DistFunc)
        {
            int nodeCount = nodeCoords.Count;
            for(int i = 0; i < nodeCount; i++)
            {
                for(int j = 0; j < nodeCount; j++)
                {
                    if (j >= i + 1)
                        distMatrix[i, j] = DistFunc(nodeCoords[i][0], nodeCoords[i][1], nodeCoords[j][0], nodeCoords[j][1]);
                    else
                        distMatrix[i, j] = distMatrix[j, i];
                }
            }

        }
        public double CalcCost(int[] path)
        {
            double cost = 0;
            for (int i = 0; i < path.Length - 1; i++)
                cost += distMatrix[path[i], path[i + 1]];
            cost += distMatrix[path[path.Length - 1], path[0]];
            return cost;
        }

        public double EUC_2D(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }
        public double MAX_2D(double x1, double y1, double x2, double y2)
        {
            return Math.Max(Math.Abs(x1 - x2), Math.Abs(y1 - y2));
        }
        public double MAN_2D(double x1, double y1, double x2, double y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }
        public double CEIL_2D(double x1, double y1, double x2, double y2)
        {
            return Math.Ceiling(EUC_2D(x1, x2, y1, y2));
        }
    }
}
