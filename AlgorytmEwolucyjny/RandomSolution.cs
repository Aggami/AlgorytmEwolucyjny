using System;
using System.Collections.Generic;

namespace AlgorytmEwolucyjny
{
    public class RandomSolution
    {
        float best;
        float worst;
        float avg=0;
        float dev;


        public RandomSolution()
        {
        }

        public float Best { get => best; set => best = value; }
        public float Worst { get => worst; set => worst = value; }
        public float Avg { get => avg; set => avg = value; }
        public float Dev { get => dev; set => dev = value; }

        public string run(int numberOfRandomSolutions, TSP problem)
        {
            float bestScore = Single.MaxValue;
            string bestSolution = "";

            string currentSolution;
            float score;

            float[] solutionsScores = new float[numberOfRandomSolutions]; 

            Avg = 0;
            Best = Single.MaxValue;
            Worst = 0;
            Dev = 0;

            for (int i = 0; i < numberOfRandomSolutions; i++)
            {
                
                currentSolution = problem.randomSolution();
                score = problem.pathlength(currentSolution);
                Avg += score;
                solutionsScores[i] = score;
                if (score < bestScore)
                {
                    bestScore = score;
                    Best = score;
                    bestSolution = currentSolution;
                }
                if (score > worst) worst = score; 

            }

            Avg = Avg / numberOfRandomSolutions;

            for (int i = 0; i < numberOfRandomSolutions; i++)
            {
                Dev += (solutionsScores[i] - Avg) * (solutionsScores[i] - Avg);
            }
            Dev = Convert.ToSingle(Math.Sqrt( Dev / numberOfRandomSolutions));
            return bestSolution;
        }
    }
}
