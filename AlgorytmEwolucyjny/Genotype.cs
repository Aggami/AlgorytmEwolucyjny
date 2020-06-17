using System;
using System.Collections.Generic;

namespace AlgorytmEwolucyjny
{
    public class TSPGenotype
    {
        private int[] genotype;
        TSP problem;

        public TSPGenotype()
        {
            
        }

        public TSPGenotype(int[] genotype, TSP problem)
        {
            this.problem = problem;
            this.genotype = genotype;
        }

        public TSPGenotype(TSP problem)
        {
            this.problem = problem;
            this.genotype = problem.randomSolutionInt();
        }

        public TSPGenotype(TSPGenotype parent)
        {
            this.problem = parent.problem;
            this.genotype =(int[])parent.genotype.Clone();
        }

        public static TSPGenotype randomGenotype(TSP problem)
        {
            TSPGenotype g = new TSPGenotype(problem);
            g.genotype = problem.randomSolutionInt();
            return g;
        }

        

        public float fitness()
        {
            return problem.pathlength(genotype);
        }


        

        public static TSPGenotype crossover (TSPGenotype parent1, TSPGenotype parent2)
        {
            Random r = new Random();
            int len = parent1.genotype.Length;

            List<int> genotype2 = new List<int>(parent2.genotype);

            TSPGenotype child = new TSPGenotype(parent1);
            int position1 = r.Next(len);
            int position2 = r.Next(len);

            while (position1 == position2)
            {
                position2 = r.Next(len);
            }



            if (position1 > position2)
            {
                int temp = position1;
                position1 = position2;
                position2 = temp;
            }

            for (int i=position1; i<=position2; i++)
            {
                genotype2.Remove(child.genotype[i]);
            }

        

            for (int i = 0; i < position1; i++)
            {
                child.genotype[i] = genotype2[0];
                genotype2.RemoveAt(0);
            }

            for (int i=position2+1; i<len; i++)
            {
                child.genotype[i] = genotype2[0];
                genotype2.RemoveAt(0);
            }

            return child; 

        }

        public void mutate()
        {
            int len = genotype.Length;
            Random r = new Random();
            int position1 = r.Next(len);
            int position2 = r.Next(len);

            while (position1 == position2)
            {
                position2 = r.Next(len);
            }

            int temp = genotype[position1];
            genotype[position1] = genotype[position2];
            genotype[position2] = temp;

        }

        public void mutateReverse()
        {
            int len = genotype.Length;
            Random r = new Random();
            int position1 = r.Next(len);
            int position2 = r.Next(len);

            while (position1 == position2)
            {
                position2 = r.Next(len);
            }

            while (position1 < position2)
            {
                int temp = genotype[position1];
                genotype[position1] = genotype[position2];
                genotype[position2] = temp;
                position1++;
                position2--;
            }
        }

        public static int[] solutionToGenotype(string solution)
        {
            solution = solution.Trim();
            string[] steps = solution.Split();
            int[] genotype = new int[steps.Length];

            for (int i = 0; i < steps.Length; i++)
            {
                genotype[i] = Int32.Parse(steps[i]);

            }

            return genotype;
        }

        public static string genotypeToSolution(int[] genotype)
        {
            string s = "";
            foreach (int g in genotype)
            {
                s += g + " ";
            }
            s = s.TrimEnd();
            return s;
        }

        public override string ToString()
        {
            string s="";
            for (int i = 0; i<genotype.Length; i++)
            {
                s += genotype[i] + " ";
            }
            s += "Fitness: ";
            s += this.fitness();
            return s;
        }
    }
}
