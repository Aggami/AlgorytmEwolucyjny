using System;

namespace AlgorytmEwolucyjny
{
    class Program
    {
        static void Main(string[] args)
        {

            TSP problem0 = new TSP();
            TSP problem1 = new TSP();
            TSP problem2= new TSP();
            TSP problem3 = new TSP();
            TSP problem4 = new TSP();
            TSP problem5 = new TSP();


            //Uwaga: należy wprowadzić prawidłową ścieżkę do pliku
            problem0.importFromFile(@"/Users/aggami/Downloads/TSP/berlin11_modified.tsp");
            problem1.importFromFile(@"/Users/aggami/Downloads/TSP/berlin52.tsp");
            problem2.importFromFile(@"/Users/aggami/Downloads/TSP/kroA100.tsp");
            problem3.importFromFile(@"/Users/aggami/Downloads/TSP/kroA150.tsp");
            problem4.importFromFile(@"/Users/aggami/Downloads/TSP/kroA200.tsp");
            problem5.importFromFile(@"/Users/aggami/Downloads/TSP/fl417.tsp");

            //AlgorytmEwolucyjny algorytm = new AlgorytmEwolucyjny(problem2, 500, 300, "TNM");
            EvolutionaryAlgorithmExperiments.testHistoryGenerations(problem2, 500, 300);

            //EvolutionaryAlgorithmExperiments.finalTestAfter(new TSP[] { problem1, problem2, problem3, problem4, problem5 }, new int[] { 250, 500, 700, 850, 1000 }, new int[] { 250, 500, 700, 850, 1000 });

            //EvolutionaryAlgorithmExperiments.testMutationProbs(problem1, 200, 200, 20, new double[] { 0.1, 0.15, 0.2, 0.25, 0.3, 0.35, 0.4, 0.45, 0.5, 0.6, 0.7, 0.8, 0.9 });
            //EvolutionaryAlgorithmExperiments.testMutationProbs(problem2, 450, 450, 20, new double[] { 0.1, 0.2, 0.25, 0.3, 0.35, 0.4, 0.45, 0.5, 0.6, 0.7, 0.8, 0.9 });


            //EvolutionaryAlgorithmExperiments.testSelectionMethods(problem1, 150, 150);
            //EvolutionaryAlgorithmExperiments.testSelectionMethods(problem2, 300, 300);
            //EvolutionaryAlgorithmExperiments.testSelectionMethods(problem3, 500, 500);
            //EvolutionaryAlgorithmExperiments.testSelectionMethods(problem4, 550, 550);
            //EvolutionaryAlgorithmExperiments.testSelectionMethods(problem5, 700, 700);

            //EvolutionaryAlgorithmExperiments.testRoulette(problem2, 500, 500);
            //EvolutionaryAlgorithmExperiments.testRoulette(problem3, 700, 700);

            //EvolutionaryAlgorithmExperiments.testRoulette(problem4, 800, 800);
            //EvolutionaryAlgorithmExperiments.testRoulette(problem5, 1100, 1100);

            //EvolutionaryAlgorithmExperiments.testHistoryGenerations(problem2, 500, 300);
            //EvolutionaryAlgorithmExperiments.testHistoryGenerations(problem2, 300, 500);
            //EvolutionaryAlgorithmExperiments.testHistoryGenerations(problem2, 500, 500);

            //EvolutionaryAlgorithmExperiments.testHistoryGenerations(problem3, 700, 500);
            //EvolutionaryAlgorithmExperiments.testHistoryGenerationsRou(problem3, 500, 700);
            //EvolutionaryAlgorithmExperiments.testHistoryGenerations(problem3, 700, 700);

            //EvolutionaryAlgorithmExperiments.testDifferentAlgorithms(new TSP[] { problem1, problem2, problem3, problem4, problem5 }, 700, 700);

            //EvolutionaryAlgorithmExperiments.testCrossoverProbs(problem2, 500, 500, 20, new double[] { 0.1, 0.2, 0.3, 0.5, 0.7, 0.8,0.85, 0.9, 1 });
            //EvolutionaryAlgorithmExperiments.testCrossoverProbs(problem3, 700, 700, 20, new double[] { 0.1, 0.2, 0.3, 0.5, 0.7, 0.8, 0.85, 0.9, 1 });
            //EvolutionaryAlgorithmExperiments.testCrossoverProbs(problem4, 700, 700, 20, new double[] { 0.1, 0.2, 0.3, 0.5, 0.7, 0.8, 0.85, 0.9, 1 });


            //EvolutionaryAlgorithmExperiments.testGenerations(problem2, 500, new int[] { 100, 250, 300, 500, 700 });
            //EvolutionaryAlgorithmExperiments.testGenerations(problem3, 700, new int[] { 250, 300, 400, 500, 700, 900 });
            //EvolutionaryAlgorithmExperiments.testGenerations(problem4, 700, new int[] { 250, 400, 500, 700, 900 });
            //EvolutionaryAlgorithmExperiments.testGenerations(problem5, 700, new int[] { 500, 700, 1000, 1100});




            //EvolutionaryAlgorithmExperiments.testRoulette(problem2, 750, 750);
            //EvolutionaryAlgorithmExperiments.testRoulette(problem3, 1000, 1000);

            //EvolutionaryAlgorithmExperiments.testRoulette(problem4, 1300, 1300);
            //EvolutionaryAlgorithmExperiments.testRoulette(problem5, 1300, 1300);



            //EvolutionaryAlgorithmExperiments.testRoulette(problem1, 300, 300);

            //EvolutionaryAlgorithmExperiments.testTournamentSize(problem1, 200, 200, new int[] {10 });

            //EvolutionaryAlgorithmExperiments.testDifferentAlgorithms(new TSP[] { problem1, problem2, problem3 , problem4 , problem5 }, 300, 300);

            //EvolutionaryAlgorithmExperiments.testPopulationSize(problem, new int[] { 100, 250, 400, 550, 700, 900}, 500);
            //EvolutionaryAlgorithmExperiments.testTournamentSize(problem, 300, 300, new int[] { 2, 5, 10, 25, 50});
            //EvolutionaryAlgorithmExperiments.testCrossoverProbs(problem, 250, 250, 20, new double[] { 0, 0.2, 0.4, 0.5, 0.7, 0.8, 0.9 });
            //EvolutionaryAlgorithmExperiments.testMutationProbs(problem, 250, 250, 20, new double[] { 0.07, 0.1, 0.15, 0.2, 0.3, 0.4 });

            //EvolutionaryAlgorithmExperiments.testTournamentSize(problem3, 250, 250, new int[] { 5, 10, 15, 20, 30 });
            //EvolutionaryAlgorithmExperiments.testTournamentSize(problem4, 300, 300, new int[] { 5, 10, 15, 20, 30 });
            //EvolutionaryAlgorithmExperiments.testTournamentSize(problem5, 300, 300, new int[] { 5, 10, 15, 20, 30 });

            //EvolutionaryAlgorithmExperiments.testCrossoverProbs(problem3, 250, 250, 20, new double[] { 0.2, 0.5, 0.7, 0.8, 0.9 });
            //EvolutionaryAlgorithmExperiments.testCrossoverProbs(problem4, 300, 300, 25, new double[] { 0.2, 0.5, 0.7, 0.8, 0.9 });
            //EvolutionaryAlgorithmExperiments.testCrossoverProbs(problem5, 300, 300, 25, new double[] { 0.2, 0.5, 0.7, 0.8, 0.9 });



            


            //EvolutionaryAlgorithmExperiments.testRoulette(problem5, 1000, 1000);



            //EvolutionaryAlgorithmExperiments.testMutationProbs(problem1, 200, 200, 20, new double[] { 0.07, 0.1, 0.15, 0.2, 0.3, 0.4, 0.5, 0.7, 0.8, 0.9 });
            //EvolutionaryAlgorithmExperiments.testMutationProbs(problem3, 400, 400, 20, new double[] { 0.1, 0.15, 0.2, 0.3, 0.4, 0.5, 0.7, 0.8, 0.9 });

            //EvolutionaryAlgorithmExperiments.testMutationProbs(problem4, 300, 300, 25, new double[] { 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7 });
            // EvolutionaryAlgorithmExperiments.testMutationProbs(problem5, 300, 300, 25, new double[] { 0.1, 0.2, 0.3, 0.4, 0.5, 0.6 });

            //EvolutionaryAlgorithmExperiments.testGenerations(problem4, 300, new int[] { 100, 200, 500, 700 });
            //EvolutionaryAlgorithmExperiments.testGenerations(problem5, 400, new int[] { 100, 200, 500, 700 });

            //TSP problem2 = new TSP();

            ////Uwaga: należy wprowadzić prawidłową ścieżkę do pliku 
            //problem2.importFromFile(@"/Users/aggami/Downloads/TSP/kroA100.tsp");
            ////EvolutionaryAlgorithmExperiments.testTournamentSize(problem2, 450, 450, new int[] { 2, 5, 10, 25, 50, 100, 200 });
            //EvolutionaryAlgorithmExperiments.testCrossoverProbs(problem2, 450, 450, 25, new double[] {0, 0.2, 0.4, 0.5, 0.7, 0.8, 0.9 });
            //EvolutionaryAlgorithmExperiments.testMutationProbs(problem2, 450, 450, 25, new double[] { 0.07, 0.1, 0.15, 0.2, 0.3, 0.4 });



            //TSP problem = new TSP();

            //////Uwaga: należy wprowadzić prawidłową ścieżkę do pliku 
            //problem.importFromFile(@"/Users/aggami/Downloads/TSP/fl417.tsp");

            //EvolutionaryAlgorithmExperiments.testPopulationSize(problem, new int[] { 100, 450, 700, 1000, 1500 }, 1000);
            //EvolutionaryAlgorithmExperiments.testGenerations(problem, 750, new int[] { 100, 400, 700, 1000, 1500 });
            //EvolutionaryAlgorithmExperiments.testGenerationsAndPopulations(problem, new int[] { 100, 500, 1000 }, new int[] { 100, 500, 1000 });
            //EvolutionaryAlgorithmExperiments.testTournamentSize(problem, 600, 600, new int[]{ 2, 5, 10, 25, 35, 50, 70, 100});
            //EvolutionaryAlgorithmExperiments.testCrossoverProbs(problem2, 600, 600, 25, new double[] { 0, 0.2,0.5, 0.7, 0.9 });
            //EvolutionaryAlgorithmExperiments.testMutationProbs(problem2, 600, 600, 25, new double[] { 0.07, 0.1, 0.2, 0.3});

            //////algorytm z selekcją turniejową
            ////AlgorytmEwolucyjny algorytmT = new AlgorytmEwolucyjny(problem, 100, 100, "TNM");
            ////TSPGenotype gT = algorytmT.runAlgorithm();
            ////Console.WriteLine("Algorytm: ");
            ////Console.WriteLine(gT);

            //////algorytm z selekcją ruletki
            ////AlgorytmEwolucyjny algorytmR = new AlgorytmEwolucyjny(problem, 200, 100, "ROU");
            ////TSPGenotype gR = algorytmR.runAlgorithm();
            ////Console.WriteLine("Algorytm: ");
            ////Console.WriteLine(gR);





            ////algorytm z selekcją turniejową
            //AlgorytmEwolucyjny algorytmT2 = new AlgorytmEwolucyjny(problem2, 1000, 700, "TNM");
            //TSPGenotype gT2 = algorytmT2.runAlgorithm();
            //Console.WriteLine("Algorytm: ");
            //Console.WriteLine(gT2);

            ////algorytm z selekcją ruletki
            //AlgorytmEwolucyjny algorytmR2 = new AlgorytmEwolucyjny(problem2, 2000, 700, "ROU");
            //TSPGenotype gR2 = algorytmR2.runAlgorithm();
            //Console.WriteLine("Algorytm: ");
            //Console.WriteLine(gR2);








            /*
            //Console.WriteLine(problem.randomSolution());

            string randomAlgSolution = RandomSolution.run(10000, problem);
            Console.WriteLine("Najlepsze rozwiązanie: "+randomAlgSolution+ " Wynik: "+problem.pathlength(randomAlgSolution));


            
            Console.WriteLine("Rozwiązanie zachłanne dla 2: "+GreedyAlgorithm.solveGreedy(problem, 2));
            */



            //TSP problem2 = new TSP();
            //problem2.importFromFile(@"/Users/aggami/Downloads/TSP/berlin52.tsp");
            ////Console.WriteLine(problem2.algorithmInfo());

            //AlgorytmEwolucyjny algorytm2 = new AlgorytmEwolucyjny(problem2, 1000, 1000, "ROU");
            //TSPGenotype g2 = algorytm2.runAlgorithm();
            //Console.WriteLine("Algorytm2 : ");
            //Console.WriteLine(g2);



            //for (int i = 0; i < 10; i++)
            //{
            //    TSP problem4 = new TSP();
            //    problem4.importFromFile(@"/Users/aggami/Downloads/TSP/kroA100.tsp");
            //    //Console.WriteLine(problem4.algorithmInfo());
            //    AlgorytmEwolucyjny algorytm4 = new AlgorytmEwolucyjny(problem4, 1000, 1000, "ROU");
            //    TSPGenotype g4 = algorytm4.runAlgorithm();
            //    Console.WriteLine("Algorytm4 : ");
            //    Console.WriteLine(g4);
            //}


            /*
            TSP problem5 = new TSP();
            problem5.importFromFile(@"/Users/aggami/Downloads/TSP/gr666.tsp");
            Console.WriteLine(problem5.algorithmInfo());
            Console.WriteLine("Rozwiązanie zachłanne dla 3: " + problem5.solveGreedy(3));
            */

            /*
            TSP problem3 = new TSP();
            problem3.importFromFile(@"/Users/aggami/Downloads/TSP/nrw1379.tsp");
            //Console.WriteLine(problem3.algorithmInfo());
            Console.WriteLine("Rozwiązanie zachłanne dla 3: " + problem3.solveGreedy(3));


            */

        }
    }
}
