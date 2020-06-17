using System;
using System.Collections.Generic;

namespace AlgorytmEwolucyjny
{
    public class AlgorytmEwolucyjny
    {
        private TSP problem;

        private TSPGenotype[] population;
        private TSPGenotype[] newPopulation;
        private TSPGenotype[] temp;


        private TSPGenotype bestGenotype;
        private float bestFitness = Single.MaxValue;

        private float[] bestFitnessGen;
        private float[] worstFitnessGen;
        private float[] avgFitnessGen;
        float fitnessSum = 0;


        private double crossoverProb = 0.7;
        private double mutationProb = 0.4;
        private int numOfGenerations;
        private int populationSize;
        private int tournamentSize;

        private string selectionType;
        private float[] rouletteBoard;
        private float maxRoulette;

        public int TournamentSize { get => tournamentSize; set => tournamentSize = value; }
        public double CrossoverProb { get => crossoverProb; set => crossoverProb = value; }
        public double MutationProb { get => mutationProb; set => mutationProb = value; }
        public float[] BestFitnessGen { get => bestFitnessGen; set => bestFitnessGen = value; }
        public float[] WorstFitnessGen { get => worstFitnessGen; set => worstFitnessGen = value; }
        public float[] AvgFitnessGen { get => avgFitnessGen; set => avgFitnessGen = value; }

        public AlgorytmEwolucyjny(TSP problem, int populationSize, int numOfGenerations, string selectionType)
        {
            this.problem = problem;
            this.populationSize = populationSize;
            this.numOfGenerations = numOfGenerations;
            if (selectionType == "TNM") this.selectionType = "TNM";
            else this.selectionType = "ROU";
            TournamentSize = 25;
            rouletteBoard = new float[populationSize];

            bestFitnessGen = new float[numOfGenerations];
            worstFitnessGen = new float[numOfGenerations];
            avgFitnessGen = new float[numOfGenerations];

        }


        public TSPGenotype runAlgorithm()
        {
            initialise();

            Random r = new Random();
            Double randomDouble;
            float fitness;
            
            TSPGenotype p1 = null;
            TSPGenotype p2 = null;
            

            for (int i = 0; i<numOfGenerations; i++)
            {
                if (selectionType == "ROU") prepareRoulette();
                for (int j = 0; j < populationSize; j++) {

                    //selekcja
                    if (selectionType == "TNM")
                    {
                        p1 = selectTournament();
                        p2 = selectTournament();
                    }
                    if (selectionType == "ROU")
                    {
                        p1 = selectRoulette();
                        p2 = selectRoulette();
                    }


                    //krzyżowanie
                    randomDouble = r.NextDouble();
                    if (randomDouble < CrossoverProb)
                        newPopulation[j] = TSPGenotype.crossover(p1, p2);
                    else
                        newPopulation[j] = new TSPGenotype(p1);

                    //mutacja
                    randomDouble = r.NextDouble();
                    if (randomDouble<MutationProb)
                    {
                        newPopulation[j].mutateReverse();
                    }
                    fitness = newPopulation[j].fitness();

                    //sprawdzenie, czy najlepszy
                    if (fitness < bestFitness)
                    {
                        bestFitness = fitness;
                        bestGenotype = newPopulation[j];
                    }



                }
                temp = population;
                population = newPopulation;
                newPopulation = temp; ;
            }
            return bestGenotype;
        }

        public TSPGenotype runAlgorithmWithGreedy()
        {
            initialiseWithGreedy();

            Random r = new Random();
            Double randomDouble;
            float fitness;

            TSPGenotype p1 = null;
            TSPGenotype p2 = null;


            for (int i = 0; i < numOfGenerations; i++)
            {
                if (selectionType == "ROU") prepareRoulette();
                for (int j = 0; j < populationSize; j++)
                {

                    //selekcja
                    if (selectionType == "TNM")
                    {
                        p1 = selectTournament();
                        p2 = selectTournament();
                    }
                    if (selectionType == "ROU")
                    {
                        p1 = selectRoulette();
                        p2 = selectRoulette();
                    }


                    //krzyżowanie
                    randomDouble = r.NextDouble();
                    if (randomDouble < CrossoverProb)
                        newPopulation[j] = TSPGenotype.crossover(p1, p2);
                    else
                        newPopulation[j] = new TSPGenotype(p1);

                    //mutacja
                    randomDouble = r.NextDouble();
                    if (randomDouble < MutationProb)
                    {
                        newPopulation[j].mutateReverse();
                    }
                    fitness = newPopulation[j].fitness();

                    //sprawdzenie, czy najlepszy
                    if (fitness < bestFitness)
                    {
                        bestFitness = fitness;
                        bestGenotype = newPopulation[j];
                    }



                }
                Console.WriteLine(bestFitness);
                temp = population;
                population = newPopulation;
                newPopulation = temp; ;
            }
            return bestGenotype;
        }


        public TSPGenotype runAlgorithmWithHistory()
        {
            initialise();

            Random r = new Random();
            Double randomDouble;
            float fitness;

            TSPGenotype p1 = null;
            TSPGenotype p2 = null;


            for (int i = 0; i < numOfGenerations; i++)
            {
                fitnessSum = 0;
                WorstFitnessGen[i] = 0;
                BestFitnessGen[i] = Single.MaxValue;
                
 
                if (selectionType == "ROU") prepareRoulette();
                for (int j = 0; j < populationSize; j++)
                {

                    //selekcja
                    if (selectionType == "TNM")
                    {
                        p1 = selectTournament();
                        p2 = selectTournament();
                    }
                    if (selectionType == "ROU")
                    {
                        p1 = selectRoulette();
                        p2 = selectRoulette();
                    }


                    //krzyżowanie
                    randomDouble = r.NextDouble();
                    if (randomDouble < CrossoverProb)
                        newPopulation[j] = TSPGenotype.crossover(p1, p2);
                    else
                        newPopulation[j] = new TSPGenotype(p1);

                    //mutacja
                    randomDouble = r.NextDouble();
                    if (randomDouble < MutationProb)
                    {
                        newPopulation[j].mutateReverse();
                    }
                    fitness = newPopulation[j].fitness();

                    //sprawdzenie, czy najlepszy
                    if (fitness < bestFitness)
                    {
                        bestFitness = fitness;
                        bestGenotype = newPopulation[j];
                    }

                    if (fitness > WorstFitnessGen[i])
                    {
                        WorstFitnessGen[i] = fitness;
                    }

                    if (fitness < BestFitnessGen[i])
                    {
                        BestFitnessGen[i] = fitness;
                    }

                    fitnessSum += fitness;

                }

                AvgFitnessGen[i] = fitnessSum / numOfGenerations;
                temp = population;
                population = newPopulation;
                newPopulation = temp; ;
            }
            return bestGenotype;
        }


        private void initialise()
        {
            population = new TSPGenotype[populationSize];
            newPopulation = new TSPGenotype[populationSize];
            for (int i= 0; i<populationSize; i++)
            {
                population[i] = TSPGenotype.randomGenotype(problem);
            }
            
        }

        private void initialiseWithGreedy()
        {
            double greedyProb = 0.1;

            List<TSPGenotype> greedySolutions = new List<TSPGenotype>();
            for (int i = 1; i<problem.Dimention+1; i++)
            {
                greedySolutions.Add(new TSPGenotype(TSPGenotype.solutionToGenotype(GreedyAlgorithm.solveGreedy(problem, i)), problem));
                    
            }

          

            population = new TSPGenotype[populationSize];
            newPopulation = new TSPGenotype[populationSize];

            Random r = new Random();
            
            for (int i = 0; i < populationSize; i++)
            {
                if ((r.NextDouble() < greedyProb)&&greedySolutions.Count>0 )
                {
                    int randInt = r.Next(greedySolutions.Count);
                    population[i] = greedySolutions[randInt];
                    greedySolutions.RemoveAt(randInt);
                }
                else
                    population[i] = TSPGenotype.randomGenotype(problem);
                
            }

            


        }


        private TSPGenotype selectTournament()
        {
            Random r = new Random();
            float minFitness = Single.MaxValue;
            TSPGenotype bestGenotype = null;
            int randomPick;

            for (int i = 0; i < TournamentSize; i++)
            {
                randomPick = r.Next(populationSize);
                if (population[randomPick].fitness() < minFitness)
                {
                    minFitness = population[randomPick].fitness();
                    bestGenotype = population[randomPick];
                }
            }
            return bestGenotype;
        }


        private TSPGenotype selectRoulette()
        {
            Random r = new Random();
            int i = 0;
            float randV = Convert.ToSingle(r.NextDouble()*maxRoulette);

            while ((randV > rouletteBoard[i])&&i<populationSize)
            {
                i++;
            }

            return population[i];
        }

        

        private void prepareRoulette()
        {
            float max = 0;
            float e = 0.01F;
            float avg = 0;

            for (int i = 0; i < populationSize; i++)
            {
                if (population[i].fitness() > max) max = population[i].fitness();
                avg += population[i].fitness();
            }

            avg = avg / populationSize;

            float nextProb = 0F;

            for (int i = 0; i < populationSize; i++)
            {
                rouletteBoard[i] = (max - population[i].fitness() + e+nextProb) * avg/ population[i].fitness();
                nextProb = rouletteBoard[i];
            }

            maxRoulette = rouletteBoard[populationSize-1];


        }

        public string toString()
        {
            string s = "Rozmiar populacji: "+populationSize+"Liczba generacji: "+numOfGenerations+"Rozmiar turnieju: "+tournamentSize+"Prawdopodob. krzyżowania: "+crossoverProb+"Pradopodob. mutacji: "+ mutationProb;
            return s;
        }

        

        
    }
}
