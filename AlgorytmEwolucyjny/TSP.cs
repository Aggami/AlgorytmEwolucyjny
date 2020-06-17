using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorytmEwolucyjny
{
    public class TSP
    {
        private string name;
        private float[,] coordinates;
        private float[,] distances;
        private string type;
        private int dimention;

        private const int MAXINFOLINES = 10;

        public float[,] Distances { get => distances; set => distances = value; }
        public int Dimention { get => dimention; set => dimention = value; }
        public string Name { get => name; set => name = value; }

        public TSP()
        {
        }

        public bool importFromFile(string path)
        {
            //open file
            string[] lines = System.IO.File.ReadAllLines(path);

            //read description
            int startdata = readBasicInfo(lines);
            Dimention = lines.Length - startdata - 2;
            coordinates = new float[Dimention+1, 2];

            //read coordinates
            for (int i=startdata;  i<lines.Length-2; i++)
            {
                lines[i] = lines[i].Replace('.', ',');
                lines[i] = lines[i].Replace("    ", " ").TrimStart();
                string[] cityData = lines[i].Split();
                int cityNum = Int32.Parse(cityData[0]);
                float coor1 = Single.Parse(cityData[1]);
                float coor2 = Single.Parse(cityData[2]);
                coordinates[cityNum, 0] = coor1;
                coordinates[cityNum, 1] = coor2;
            }

            calculateDistances();

            return true;
        }

        public float getDistance(int city1, int city2)
        {
            if (Distances == null || Distances.Length < city1 * city2) return -1;
            return Distances[city1, city2];
        }

        private void calculateDistances()
        {
            Distances = new float[Dimention + 1, Dimention + 1];
            for (int i = 1; i<Dimention+1; i++)
            {
                for (int j = 1; j< i; j++)
                {
                    float c1x = coordinates[i, 0];
                    float c1y = coordinates[i, 1];
                    float c2x = coordinates[j, 0];
                    float c2y = coordinates[j, 1];




                    float distance;
                    if (type == "GEO")
                    {
                        distance = distanceGEO(c1x, c1y, c2x, c2y);
                    }
                    else
                    {
                        distance = distanceEUC(c1x, c1y, c2x, c2y);
                    }
                    Distances[i, j] = distance;
                    Distances[j, i] = distance;
                }
            }
        }

        public static float distanceGEO(float c1x, float c1y, float c2x, float c2y)
        {
            if ((c1x == c2x) && (c1y == c2y)) return 0;

            float diffX = Convert.ToSingle((c1x - c2x) *Math.PI/180);

            float diffY = Convert.ToSingle((c1y - c2y) * Math.PI/180);

            float r = 6371F;

            float result = r * Convert.ToSingle(Math.Acos(Math.Cos(diffX) - Math.Cos(diffY)));



            return result;

        }

        public static float distanceEUC(float c1x, float c1y, float c2x, float c2y)
        {
            float diffX = c1x - c2x;

            float diffY = c1y - c2y;

            return Convert.ToSingle(Math.Sqrt(diffX * diffX + diffY * diffY));
        }

        private int readBasicInfo(string[] lines)
        {
            for (int i = 0; i<MAXINFOLINES; i++)
            {
                if (lines[i].Contains("NAME"))
                {
                    this.Name = lines[i].Trim().Remove(0, 5);
                }
                if(lines[i].Contains("EDGE_WEIGHT_TYPE"))
                {
                    if (lines[i].Contains("GEO"))
                    {
                        this.type = "GEO";
                    }
                    else
                    {
                        this.type = "EUC";
                    }
                }
                if (lines[i] == "NODE_COORD_SECTION") return i+1;
            }
            return -1;
        }

        

        public string randomSolution()
        {
            List<int> toVisit = new List<int>();
            string s = "";
            int randRange = Dimention;

            //wypełnienie puli miastami
            for (int i=1; i<Dimention+1; i++)
            {
                toVisit.Add(i);
            }



            Random r = new Random();
            int temp;
            for (int i=0; i<Dimention; i++)
            {
                temp = r.Next(randRange);
                s += toVisit[temp]+" ";
                
                toVisit.RemoveAt(temp);
                randRange = randRange - 1;
                
            }
            return s;
        }

        public int[] randomSolutionInt()
        {
            List<int> toVisit = new List<int>();
            int[] solution= new int[Dimention];
            
            int randRange = Dimention;

            //wypełnienie puli miastami
            for (int i = 1; i < Dimention + 1; i++)
            {
                toVisit.Add(i);
            }



            Random r = new Random();
            int temp;
            for (int i = 0; i < Dimention; i++)
            {
                temp = r.Next(randRange);
                solution[i] = toVisit[temp];

                toVisit.RemoveAt(temp);
                randRange = randRange - 1;

            }
            return solution;
        }


        public string algorithmInfo()
        {
            string s = "";
            s += "Name: " + Name + "\n";
            for (int i = 1; i<Dimention+1; i++)
            {
                s += i + " " + coordinates[i, 0] + " " + coordinates[i, 1] + "\n";
            }
            s += "Odległości \n";

            int arraySize = Dimention;
            if (arraySize > 100) arraySize = 100;

            for (int i = 1; i < arraySize+1; i++)
            {
                for (int j = 1; j < arraySize+ 1; j++)
                {
                    s += Distances[i, j].ToString("N2").PadLeft(10);
                }
                s += "\n";
            }

            return s;
        }

        public float pathlength(string path)
        {
            float pathLength = 0;
            string[] steps = path.Split();
            for (int i=0; i<Dimention-1; i++)
            {
                int c1 = Int32.Parse(steps[i]);
                int c2 = Int32.Parse(steps[i+1]);
                pathLength += Distances[c1, c2];
            }
            int last = Int32.Parse(steps[Dimention-1]);
            int first = Int32.Parse(steps[0]);
            pathLength += Distances[first, last];

            return pathLength; 
        }

        public float pathlength(int[] solution)
        {
            float pathLength = 0;
            
            for (int i = 0; i < Dimention - 1; i++)
            { 
                pathLength += Distances[solution[i], solution[i+1]];
            }
            
            pathLength += Distances[solution[0], solution[Dimention-1]];

            return pathLength;
        }


    }
}
