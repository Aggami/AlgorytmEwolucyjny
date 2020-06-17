using System;
using System.Collections.Generic;

namespace AlgorytmEwolucyjny
{
    public class GreedyAlgorithm
    {

       

        public GreedyAlgorithm()
        {
        }

        

        public static string solveGreedy(TSP problem, int startCity)
        {
            List<int> toVisit = new List<int>();
            for (int i = 1; i < problem.Dimention + 1; i++)
            {
                if (i != startCity) toVisit.Add(i);
            }


            int currentCity = startCity;
            int nextcity = -1;
            string path = startCity + " ";

            for (int i = 0; i < problem.Dimention - 1; i++)
            {
                float curmin = Single.MaxValue;

                foreach (int city in toVisit)
                {
                    if ((problem.Distances[currentCity, city] < curmin))
                    {
                        nextcity = city;
                        curmin = problem.Distances[currentCity, city];
                    }


                }
                toVisit.Remove(nextcity);
                currentCity = nextcity;
                path += currentCity + " ";
            }

            float length = problem.pathlength(path);

            return path;
        }
    }
}
