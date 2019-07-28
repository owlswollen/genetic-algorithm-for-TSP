using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GAforTSP
{
    class GA
    {
        public static int popSize, chromLen;
        public List<Chromosome> population, offsPopulation;
        public static TSP tSP;
        public Chromosome bestOfBest;
        public struct Chromosome
        {
            public int[] path;

            public Chromosome(int x)
            {
                path = new int[chromLen];
            }
            public Chromosome(int[] p)
            {
                path = p;
            }
            public double Distance()
            {
                double sum = 0;
                for (int i = 0; i < chromLen - 1; i++)
                    sum += tSP.distMatrix[path[i], path[i + 1]];
                sum += tSP.distMatrix[path[chromLen - 1], path[0]];
                return sum;
            }
            public string Print()
            {
                string s = "";
                for (int i = 0; i < chromLen - 1; i++)
                {
                    s += path[i] + " ";
                }
                s += path[chromLen - 1];
                return s;
            }
        }
        public GA()
        {
            offsPopulation = new List<Chromosome>();
        }

        public void CreatePopulation(bool greedy)
        {
            double min;
            int mini = 0;
            int nodeIndex, num;
            int i = 0;
            Random rand = new Random();
            population = new List<Chromosome>();
            int[] chromosome = new int[chromLen];
            int[] visited;

            int count = popSize;
            if (greedy)
            {
                // Baslangic populasyonu icin greedy yontem
                for (int j = 0; j < Math.Min(chromLen, popSize); j++)
                {
                    chromosome[0] = j;
                    visited = new int[chromLen];
                    visited[j] = 1;
                    for (int k = 1; k < chromLen; k++)
                    {
                        min = double.MaxValue;
                        for (int l = 0; l < chromLen; l++)
                        {
                            if (visited[l] == 0 && l != chromosome[k - 1] && min > tSP.distMatrix[l, chromosome[k - 1]])
                            {
                                min = tSP.distMatrix[l, chromosome[k - 1]];
                                mini = l;
                            }
                        }
                        chromosome[k] = mini;
                        visited[mini] = 1;
                    }
                    Chromosome temp = new Chromosome(chromosome);
                    population.Add(temp);
                }

                count = popSize - chromLen;
            }

            while (i < count)
            {
                chromosome = new int[chromLen];
                nodeIndex = 0;
                // Random kromozomlarin olusturulmasi, populasyona eklenmesi ve populasyonun iyiden kotuye siralanmasi
                do
                {
                    num = rand.Next(0, chromLen);
                    if (chromosome[num] == 0)
                    {
                        chromosome[num] = nodeIndex++;
                    }
                } while (nodeIndex < chromLen);
                Chromosome temp = new Chromosome(chromosome);
                population.Add(temp);
                i++;
            }
            population = population.OrderBy(x => x.Distance()).ToList();
        }

        // Rank selection
        public List<Chromosome> Selection()
        {
            Random r = new Random();
            int i1 = r.Next((popSize + 1) * popSize / 2);
            int i2 = r.Next((popSize + 1) * popSize / 2);
            int index1 = Convert.ToInt32(Math.Ceiling((-1.0 + Math.Sqrt(1.0 + 8.0 * i1)) / 2.0));
            int index2 = Convert.ToInt32(Math.Ceiling((-1.0 + Math.Sqrt(1.0 + 8.0 * i2)) / 2.0));
            while (index1 == index2)
            {
                i2 = r.Next((popSize + 1) * popSize / 2);
                index2 = Convert.ToInt32(Math.Ceiling((-1.0 + Math.Sqrt(1.0 + 8.0 * i2)) / 2.0));
            }
            List < Chromosome > parents = new List<Chromosome>();
            parents.Add(population[Convert.ToInt32(Math.Sqrt(Math.Sqrt(popSize - index1)))]);
            parents.Add(population[Convert.ToInt32(Math.Sqrt(Math.Sqrt(popSize - index2)))]);
            return parents;
        }

        public void Mutation(double prob)
        {
            Random rand = new Random();
            double randNum;
            int i, j;
            for (int k = 0; k < popSize; k++)
            {
                randNum = rand.NextDouble();
                while (randNum < prob)
                {
                    i = rand.Next(0, chromLen);
                    do
                    {
                        j = rand.Next(0, chromLen);
                    } while (i == j);
                    int temp = population[k].path[i];
                    population[k].path[i] = population[k].path[j];
                    population[k].path[j] = temp;
                    randNum = rand.NextDouble();
                }
            }
        }

        public List<Chromosome> OnePointCO(Chromosome parent1, Chromosome parent2)
        {
            bool[,] signs = new bool[2, chromLen];
            List<Chromosome> offsprings = new List<Chromosome>();
            Chromosome offs1 = new Chromosome(0);
            Chromosome offs2 = new Chromosome(0);

            Random rand = new Random();
            int point = rand.Next(1, chromLen - 1);  //
            for (int i = 0; i < point; i++)
            {
                offs1.path[i] = parent1.path[i];
                offs2.path[i] = parent2.path[i];
                signs[0, parent1.path[i]] = true;
                signs[1, parent2.path[i]] = true;
            }
            int k = 0, l = 0;
            for (int i = 0; i < chromLen; i++)
            {
                if (!signs[0, parent2.path[i]])
                    offs1.path[point + k++] = parent2.path[i];
                if (!signs[1, parent1.path[i]])
                    offs2.path[point + l++] = parent1.path[i];
            }
            offsprings.Add(offs1);
            offsprings.Add(offs2);
            return offsprings;
        }

        public List<Chromosome> TwoPointCO(Chromosome parent1, Chromosome parent2)
        {
            bool[,] signs = new bool[2, chromLen];
            List<Chromosome> offsprings = new List<Chromosome>();
            Chromosome offs1 = new Chromosome(0);
            Chromosome offs2 = new Chromosome(0);

            Random rand = new Random();
            int point1 = rand.Next(1, chromLen / 2);
            int point2 = rand.Next(chromLen / 2, chromLen - 1);

            // Iki nokta arasinda kalan bolumun yerlestirilmesi
            for (int i = point1; i < point2; i++)
            {
                offs1.path[i] = parent2.path[i];
                offs2.path[i] = parent1.path[i];
                signs[0, parent2.path[i]] = true;
                signs[1, parent1.path[i]] = true;
            }

            // Ilk noktaya kadar olan bolum
            List<int> temp = new List<int>();
            List<int> temp2 = new List<int>();
            for (int i = 0; i < point1; i++)
            {
                if (!signs[0, parent1.path[i]])
                {
                    offs1.path[i] = parent1.path[i];
                    signs[0, parent1.path[i]] = true;
                }
                else
                    temp.Add(i);
                if (!signs[1, parent2.path[i]])
                {
                    offs2.path[i] = parent2.path[i];
                    signs[1, parent2.path[i]] = true;
                }
                else
                    temp2.Add(i);
            }

            // Ikinci noktadan sontaki bolum
            for (int i = point2; i < chromLen; i++)
            {
                if (!signs[0, parent1.path[i]])
                {
                    offs1.path[i] = parent1.path[i];
                    signs[0, parent1.path[i]] = true;
                }
                else
                    temp.Add(i);
                if (!signs[1, parent2.path[i]])
                {
                    offs2.path[i] = parent2.path[i];
                    signs[1, parent2.path[i]] = true;
                }
                else
                    temp2.Add(i);
            }

            // Kullanilmamis node'larin yerlestirilmesi
            int k = 0, l = 0;
            for (int i = 0; i < chromLen; i++)
            {
                if (!signs[0, i])
                    offs1.path[temp[k++]] = i;
                if (!signs[1, i])
                    offs2.path[temp2[l++]] = i;
            }
            offsprings.Add(offs1);
            offsprings.Add(offs2);
            return offsprings;
        }

        Chromosome offspring;
        List<int> offsUnused;
        int offsIndex;

        // Alternating Edges Crossover
        public List<Chromosome> AlternatingEdgesCO(Chromosome parent1, Chromosome parent2)
        {
            List<Chromosome> tempList = new List<Chromosome>();
            offspring = new Chromosome(0);
            offsUnused = new List<int>();
            for (int i = 2; i < chromLen; i++)
            {
                offsUnused.Add(parent1.path[i]);
            }
            offspring.path[0] = parent1.path[0];
            offspring.path[1] = parent1.path[1];
            offsIndex = 2;
            while (offsIndex < chromLen)
            {
                ChooseEdge(parent2);
                if (offsIndex < chromLen)
                {
                    ChooseEdge(parent1);
                }
            }
            tempList.Add(offspring);
            return tempList;
        }

        // Bir parent'in bitisindeki elemanin diger parent'ta bulunmasi
        public void ChooseEdge(Chromosome parent)
        {
            bool infeasible = false;
            for (int i = 0; i < chromLen; i++)
            {
                if (parent.path[i] == offspring.path[offsIndex - 1])
                {
                    if (i + 1 == chromLen)
                    {
                        infeasible = true;
                    }
                    if (!infeasible)
                    {
                        for (int j = 0; j < offsIndex; j++)
                        {
                            if (offspring.path[j] == parent.path[i + 1])
                            {
                                infeasible = true;
                                break;
                            }
                        }
                    }
                    if (!infeasible)
                    {
                        offspring.path[offsIndex] = parent.path[i + 1];
                        offsUnused.Remove(parent.path[i + 1]);
                        offsIndex++;
                        break;
                    }
                    else
                    {
                        Random rand = new Random();
                        int randIndex = rand.Next(0, offsUnused.Count);
                        offspring.path[offsIndex] = offsUnused[randIndex];
                        offsUnused.Remove(offsUnused[randIndex]);
                        offsIndex++;
                        break;
                    }
                }
            }
        }

        public void Elitism(double elitismRate)
        {
            for (int i = 0; i <= popSize * elitismRate; i++)
                offsPopulation.Add(population[i]);
        }

        public double Average()
        {
            double sum = 0;
            foreach (Chromosome chrom in population)
            {
                sum += chrom.Distance();
            }
            return sum / popSize;
        }

        public void ChangePopulation()
        {
            population.Clear();
            foreach (Chromosome chrom in offsPopulation)
                population.Add(chrom);
            offsPopulation.Clear();
            population = population.OrderBy(x => x.Distance()).ToList();
        }
    }
}
