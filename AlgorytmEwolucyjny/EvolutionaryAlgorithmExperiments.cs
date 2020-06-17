using System;
namespace AlgorytmEwolucyjny
{
    public static class EvolutionaryAlgorithmExperiments
    {
        public static void testPopulationSize(TSP problem, int[] populationSizes, int numOfGenerations)
        {
            string line;
            TSPGenotype genotype;
            var file = new System.IO.StreamWriter(@"/Users/aggami/Library/Mobile Documents/com~apple~CloudDocs/Studia/Semestr 6/SIiIW/" + problem.Name + "testPopulacjiGen=" + numOfGenerations + ".txt");
            file.AutoFlush = true;

            AlgorytmEwolucyjny algorytmProb = new AlgorytmEwolucyjny(problem, populationSizes[0], numOfGenerations, "TNM");
            string infoLine = algorytmProb.ToString();

            string startLine = "Popsize; Avg; Min; Max; Stand.dev; AvgTime; ";
            file.WriteLine(startLine);



            foreach (int ps in populationSizes)
            {
                Console.WriteLine("Start for value: " + ps);
                float[] results = new float[10];
                float min = Single.MaxValue;
                float max = 0;
                float sum = 0;
                float avg = 0;
                float dev = 0;
                float temp;

                var watch = System.Diagnostics.Stopwatch.StartNew();

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Run " + i);

                    AlgorytmEwolucyjny algorytmT = new AlgorytmEwolucyjny(problem, ps, numOfGenerations, "TNM");
                    genotype = algorytmT.runAlgorithm();
                    temp = genotype.fitness();
                    sum += temp;

                    results[i] = genotype.fitness();
                    if (temp > max) max = temp;
                    if (temp < min) min = temp;
                }

                watch.Stop();
                avg = sum / 10;

                for (int i = 0; i < 10; i++)
                {
                    dev += (results[i] - avg) * (results[i] - avg);
                }

                dev = Convert.ToSingle(Math.Sqrt(dev / 10));

                var elapsedTime = watch.ElapsedMilliseconds;
                elapsedTime = elapsedTime / 10000;


                line = ps + "; " + avg + "; " + min + "; " + max + "; " + dev + "; " + elapsedTime + ";";
                file.WriteLine(line);

            }

            file.Close();
        }

        public static void testGenerations(TSP problem, int populationSize, int[] numOfGenerations)
        {
            string line;
            TSPGenotype genotype;
            var file = new System.IO.StreamWriter(@"/Users/aggami/Library/Mobile Documents/com~apple~CloudDocs/Studia/Semestr 6/SIiIW/" + problem.Name + "testGeneracjiPop=" + populationSize + ".txt");
            file.AutoFlush = true;

            string startLine = "Popsize; Avg; Min; Max; Stand.dev; AvgTime; ";





            foreach (int ng in numOfGenerations)
            {
                Console.WriteLine("Start for value: " + ng);
                float[] results = new float[10];
                float min = Single.MaxValue;
                float max = 0;
                float sum = 0;
                float avg = 0;
                float dev = 0;
                float temp;

                var watch = System.Diagnostics.Stopwatch.StartNew();


                line = ng.ToString() + "; ";
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Run " + i);


                    AlgorytmEwolucyjny algorytmT = new AlgorytmEwolucyjny(problem, populationSize, ng, "TNM");

                    if (i == 0)
                    {
                        file.WriteLine(algorytmT.toString());
                        file.WriteLine(startLine);

                    }
                    genotype = algorytmT.runAlgorithm();
                    temp = genotype.fitness();
                    sum += temp;

                    results[i] = genotype.fitness();
                    if (temp > max) max = temp;
                    if (temp < min) min = temp;
                }

                watch.Stop();
                avg = sum / 10;

                for (int i = 0; i < 10; i++)
                {
                    dev += (results[i] - avg) * (results[i] - avg);
                }

                dev = Convert.ToSingle(Math.Sqrt(dev / 10));

                var elapsedTime = watch.ElapsedMilliseconds;
                elapsedTime = elapsedTime / 10000;


                line = ng + "; " + avg + "; " + min + "; " + max + "; " + dev + "; " + elapsedTime + ";";
                file.WriteLine(line);

            }

            file.Close();
        }

        public static void testTournamentSize(TSP problem, int populationSize, int numOfGenerations, int[] tournamentSize)
        {
            string line;
            TSPGenotype genotype;
            var file = new System.IO.StreamWriter(@"/Users/aggami/Library/Mobile Documents/com~apple~CloudDocs/Studia/Semestr 6/SIiIW/" + problem.Name + "testTurnieju(ps-gs)=(" + populationSize + "-" + numOfGenerations + ".txt");
            file.AutoFlush = true;

            string startLine = "TournamentSize; Avg; Min; Max; Stand.dev; AvgTime; ";
            file.WriteLine(startLine);

            foreach (int ts in tournamentSize)
            {

                Console.WriteLine("Start for value: " + ts);
                float[] results = new float[10];
                float min = Single.MaxValue;
                float max = 0;
                float sum = 0;
                float avg = 0;
                float dev = 0;
                float temp;

                var watch = System.Diagnostics.Stopwatch.StartNew();


                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Run " + i);

                    AlgorytmEwolucyjny algorytmT = new AlgorytmEwolucyjny(problem, populationSize, numOfGenerations, "TNM");
                    algorytmT.TournamentSize = ts;
                    genotype = algorytmT.runAlgorithm();
                    temp = genotype.fitness();
                    sum += temp;

                    results[i] = genotype.fitness();
                    if (temp > max) max = temp;
                    if (temp < min) min = temp;
                }

                watch.Stop();
                avg = sum / 10;

                for (int i = 0; i < 10; i++)
                {
                    dev += (results[i] - avg) * (results[i] - avg);
                }

                dev = Convert.ToSingle(Math.Sqrt(dev / 10));

                var elapsedTime = watch.ElapsedMilliseconds;
                elapsedTime = elapsedTime / 10000;


                line = ts + "; " + avg + "; " + min + "; " + max + "; " + dev + "; " + elapsedTime + ";";
                file.WriteLine(line);

            }

            file.Close();
        }

        public static void testCrossoverProbs(TSP problem, int populationSize, int numOfGenerations, int ts, double[] crossoverProbs)
        {
            string line;
            TSPGenotype genotype;
            var file = new System.IO.StreamWriter(@"/Users/aggami/Library/Mobile Documents/com~apple~CloudDocs/Studia/Semestr 6/SIiIW/" + problem.Name + "testKrzyzowania.txt");
            file.AutoFlush = true;

            string startLine = "CrossProb; Avg; Min; Max; Stand.dev; AvgTime; ";
            file.WriteLine(startLine);



            var watch = System.Diagnostics.Stopwatch.StartNew();


            foreach (double cp in crossoverProbs)
            {


                Console.WriteLine("Start for value: " + cp);
                float[] results = new float[10];
                float min = Single.MaxValue;
                float max = 0;
                float sum = 0;
                float avg = 0;
                float dev = 0;
                float temp;



                for (int i = 0; i < 10; i++)
                {

                    Console.WriteLine("Run " + i);

                    AlgorytmEwolucyjny algorytmT = new AlgorytmEwolucyjny(problem, populationSize, numOfGenerations, "TNM");
                    algorytmT.TournamentSize = ts;
                    algorytmT.MutationProb = 0.4;
                    algorytmT.CrossoverProb = cp;
                    if (i == 0)
                    {
                        file.WriteLine(algorytmT.toString());
                        file.WriteLine(startLine);

                    }
                    genotype = algorytmT.runAlgorithm();
                    temp = genotype.fitness();
                    sum += temp;

                    results[i] = genotype.fitness();
                    if (temp > max) max = temp;
                    if (temp < min) min = temp;
                }

                watch.Stop();
                avg = sum / 10;

                for (int i = 0; i < 10; i++)
                {
                    dev += (results[i] - avg) * (results[i] - avg);
                }

                dev = Convert.ToSingle(Math.Sqrt(dev / 10));

                var elapsedTime = watch.ElapsedMilliseconds;
                elapsedTime = elapsedTime / 10000;


                line = cp + "; " + avg + "; " + min + "; " + max + "; " + dev + "; " + elapsedTime + ";";
                file.WriteLine(line);

            }

            file.Close();
        }

        public static void testMutationProbs(TSP problem, int populationSize, int numOfGenerations, int ts, double[] mutationProbs)
        {
            string line;
            TSPGenotype genotype;
            var file = new System.IO.StreamWriter(@"/Users/aggami/Library/Mobile Documents/com~apple~CloudDocs/Studia/Semestr 6/SIiIW/" + problem.Name + "testMutacji.txt");
            file.AutoFlush = true;

            string startLine = "MutProb; Avg; Min; Max; Stand.dev; AvgTime; ";



            var watch = System.Diagnostics.Stopwatch.StartNew();

            foreach (double mp in mutationProbs)
            {
                Console.WriteLine("Start for value: " + mp);
                float[] results = new float[10];
                float min = Single.MaxValue;
                float max = 0;
                float sum = 0;
                float avg = 0;
                float dev = 0;
                float temp;

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Run " + i);
                    AlgorytmEwolucyjny algorytmT = new AlgorytmEwolucyjny(problem, populationSize, numOfGenerations, "TNM");
                    algorytmT.TournamentSize = ts;
                    algorytmT.CrossoverProb = 0.85;
                    algorytmT.MutationProb = mp;
                    if (i == 0)
                    {
                        file.WriteLine(algorytmT.toString());
                        file.WriteLine(startLine);

                    }
                    genotype = algorytmT.runAlgorithm();
                    temp = genotype.fitness();
                    sum += temp;

                    results[i] = genotype.fitness();
                    if (temp > max) max = temp;
                    if (temp < min) min = temp;
                }

                watch.Stop();
                avg = sum / 10;

                for (int i = 0; i < 10; i++)
                {
                    dev += (results[i] - avg) * (results[i] - avg);
                }

                dev = Convert.ToSingle(Math.Sqrt(dev / 10));

                var elapsedTime = watch.ElapsedMilliseconds;
                elapsedTime = elapsedTime / 10000;


                line = mp + "; " + avg + "; " + min + "; " + max + "; " + dev + "; " + elapsedTime + ";";
                file.WriteLine(line);

            }

            file.Close();
        }


        public static void testGenerationsAndPopulations(TSP problem, int[] populationSize, int[] numOfGenerations)
        {
            string line;
            TSPGenotype genotype;
            var file = new System.IO.StreamWriter(@"/Users/aggami/Library/Mobile Documents/com~apple~CloudDocs/Studia/Semestr 6/SIiIW/" + problem.Name + "testGeneracjiIPopulacji.txt");

            string startLine = "Popsize; Avg; Min; Max; Stand.dev; AvgTime; ";
            file.WriteLine(startLine);



            foreach (int ps in populationSize)
            {
                Console.WriteLine("Start for value: " + ps);
                float[] results = new float[10];
                float min = Single.MaxValue;
                float max = 0;
                float sum = 0;
                float avg = 0;
                float dev = 0;
                float temp;

                var watch = System.Diagnostics.Stopwatch.StartNew();

                foreach (int ng in numOfGenerations)
                {


                    line = ps.ToString() + "; " + ng.ToString() + "; ";

                    for (int i = 0; i < 10; i++)
                    {
                        AlgorytmEwolucyjny algorytmT = new AlgorytmEwolucyjny(problem, ps, ng, "TNM");
                        genotype = algorytmT.runAlgorithm();
                        temp = genotype.fitness();
                        sum += temp;

                        results[i] = genotype.fitness();
                        if (temp > max) max = temp;
                        if (temp < min) min = temp;
                    }

                    watch.Stop();
                    avg = sum / 10;

                    for (int i = 0; i < 10; i++)
                    {
                        dev += (results[i] - avg) * (results[i] - avg);
                    }

                    dev = Convert.ToSingle(Math.Sqrt(dev / 10));

                    var elapsedTime = watch.ElapsedMilliseconds;
                    elapsedTime = elapsedTime / 10000;


                    line = ps + "; " + avg + "; " + min + "; " + max + "; " + dev + "; " + elapsedTime + ";";
                    file.WriteLine(line);

                }
            }

            file.Close();
        }



        public static void testHistoryGenerations(TSP problem, int populationSize, int numOfGenerations)
        {
            string line;
            TSPGenotype genotype;
            var file = new System.IO.StreamWriter(@"/Users/aggami/Library/Mobile Documents/com~apple~CloudDocs/Studia/Semestr 6/SIiIW/" + "AAAA"+problem.Name + "testHistoriiGeneracjiPs=" + populationSize + ".txt");
            file.AutoFlush = true;

            string startLine = "Generation; Avg; Min; Max;";

            AlgorytmEwolucyjny algorytmT = new AlgorytmEwolucyjny(problem, populationSize, numOfGenerations, "TNM");
            algorytmT.CrossoverProb = 0.7;
            algorytmT.MutationProb = 0.4;
            algorytmT.TournamentSize = 20;
            file.WriteLine(algorytmT.toString());
            file.WriteLine(startLine);

            genotype = algorytmT.runAlgorithmWithHistory();

            for (int i = 0; i < numOfGenerations; i++)
            {
                line = i + "; " + algorytmT.AvgFitnessGen[i] + "; " + algorytmT.BestFitnessGen[i] + "; " + algorytmT.WorstFitnessGen[i];
                file.WriteLine(line);
            }

            file.Close();
        }

        public static void testHistoryGenerationsRou(TSP problem, int populationSize, int numOfGenerations)
        {
            string line;
            TSPGenotype genotype;
            var file = new System.IO.StreamWriter(@"/Users/aggami/Library/Mobile Documents/com~apple~CloudDocs/Studia/Semestr 6/SIiIW/" + problem.Name + "testHistoriiGeneracjiPs=" + populationSize + ".txt");
            file.AutoFlush = true;

            string startLine = "Generation; Avg; Min; Max;";

            AlgorytmEwolucyjny algorytmT = new AlgorytmEwolucyjny(problem, populationSize, numOfGenerations, "ROU");
            algorytmT.CrossoverProb = 0.9;
            algorytmT.MutationProb = 0.4;
            file.WriteLine(algorytmT.toString());
            file.WriteLine(startLine);

            genotype = algorytmT.runAlgorithmWithHistory();

            for (int i = 0; i < numOfGenerations; i++)
            {
                line = i + "; " + algorytmT.AvgFitnessGen[i] + "; " + algorytmT.BestFitnessGen[i] + "; " + algorytmT.WorstFitnessGen[i];
                file.WriteLine(line);
            }

            file.Close();
        }

        public static void testSelectionMethods(TSP problem, int populationSize, int generationNum)
        {
            string line;
            TSPGenotype genotype;
            var file = new System.IO.StreamWriter(@"/Users/aggami/Library/Mobile Documents/com~apple~CloudDocs/Studia/Semestr 6/SIiIW/" + problem.Name + "testSelekcji pop=" + populationSize + " gen=" + generationNum + ".txt");

            AlgorytmEwolucyjny algorytmProb = new AlgorytmEwolucyjny(problem, populationSize, generationNum, "TNM");
            algorytmProb.CrossoverProb = 0.9;
            algorytmProb.MutationProb = 0.4;
            string infoLine = algorytmProb.ToString();
            file.WriteLine(infoLine);

            string startLine = "Method; Avg; Min; Max; Stand.dev; AvgTime; ";
            file.WriteLine(startLine);




            Console.WriteLine("Start TNM");

            float[] results = new float[10];
            float min = Single.MaxValue;
            float max = 0;
            float sum = 0;
            float avg = 0;
            float dev = 0;
            float temp;

            var watch = System.Diagnostics.Stopwatch.StartNew();



            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Run " + i);
                AlgorytmEwolucyjny algorytmT = new AlgorytmEwolucyjny(problem, populationSize, generationNum, "TNM");
                algorytmT.CrossoverProb = 0.9;
                algorytmT.MutationProb = 0.4;

                genotype = algorytmT.runAlgorithm();
                temp = genotype.fitness();
                sum += temp;


                results[i] = genotype.fitness();
                if (temp > max) max = temp;
                if (temp < min) min = temp;
            }

            watch.Stop();
            avg = sum / 10;

            for (int i = 0; i < 10; i++)
            {
                dev += (results[i] - avg) * (results[i] - avg);
            }

            dev = Convert.ToSingle(Math.Sqrt(dev / 10));

            var elapsedTime = watch.ElapsedMilliseconds;
            elapsedTime = elapsedTime / 10000;


            line = "Tournament" + "; " + avg + "; " + min + "; " + max + "; " + dev + "; " + elapsedTime + ";";
            file.WriteLine(line);

            Console.WriteLine("Start ROU");


            min = Single.MaxValue;
            max = 0;
            sum = 0;
            avg = 0;
            dev = 0;

            watch = System.Diagnostics.Stopwatch.StartNew();



            for (int i = 0; i < 10; i++)
            {
                AlgorytmEwolucyjny algorytmT = new AlgorytmEwolucyjny(problem, populationSize, generationNum, "ROU");
                algorytmT.CrossoverProb = 0.9;
                algorytmT.MutationProb = 0.4;
                genotype = algorytmT.runAlgorithm();
                temp = genotype.fitness();
                sum += temp;

                results[i] = genotype.fitness();
                if (temp > max) max = temp;
                if (temp < min) min = temp;
            }

            watch.Stop();
            avg = sum / 10;

            for (int i = 0; i < 10; i++)
            {
                dev += (results[i] - avg) * (results[i] - avg);
            }

            dev = Convert.ToSingle(Math.Sqrt(dev / 10));

            elapsedTime = watch.ElapsedMilliseconds;
            elapsedTime = elapsedTime / 10000;


            line = "Roulette" + "; " + avg + "; " + min + "; " + max + "; " + dev + "; " + elapsedTime + ";";
            file.WriteLine(line);

            file.Close();
        }


        public static void testRoulette(TSP problem, int populationSize, int generationNum)
        {
            string line;
            TSPGenotype genotype;
            var file = new System.IO.StreamWriter(@"/Users/aggami/Library/Mobile Documents/com~apple~CloudDocs/Studia/Semestr 6/SIiIW/" + problem.Name + "testRuletki pop=" + populationSize + " gen=" + generationNum + ".txt");

            AlgorytmEwolucyjny algorytmProb = new AlgorytmEwolucyjny(problem, populationSize, generationNum, "TNM");
            algorytmProb.CrossoverProb = 0.9;
            algorytmProb.MutationProb = 0.4;
            string infoLine = algorytmProb.toString();

            string startLine = "Method; Avg; Min; Max; Stand.dev; AvgTime; ";
            file.WriteLine(startLine);




            Console.WriteLine("Start ROU");

            float[] results = new float[10];
            float min = Single.MaxValue;
            float max = 0;
            float sum = 0;
            float avg = 0;
            float dev = 0;
            float temp;

            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Run " + i);
                AlgorytmEwolucyjny algorytmT = new AlgorytmEwolucyjny(problem, populationSize, generationNum, "ROU");
                algorytmT.CrossoverProb = 0.9;
                algorytmT.MutationProb = 0.4;
                genotype = algorytmT.runAlgorithm();
                temp = genotype.fitness();
                sum += temp;

                results[i] = genotype.fitness();
                if (temp > max) max = temp;
                if (temp < min) min = temp;
            }

            watch.Stop();
            avg = sum / 10;

            for (int i = 0; i < 10; i++)
            {
                dev += (results[i] - avg) * (results[i] - avg);
            }

            dev = Convert.ToSingle(Math.Sqrt(dev / 10));

            var elapsedTime = watch.ElapsedMilliseconds;
            elapsedTime = elapsedTime / 10000;


            line = "Roulette" + "; " + avg + "; " + min + "; " + max + "; " + dev + "; " + elapsedTime + ";";
            file.WriteLine(line);

            file.Close();

        }

        public static void testDifferentAlgorithms(TSP[] problems, int populationSize, int generationNum, int numOfLaunch = 10)
        {
            string line;
            var file = new System.IO.StreamWriter(@"/Users/aggami/Library/Mobile Documents/com~apple~CloudDocs/Studia/Semestr 6/SIiIW/" + "testAlgorytmow.txt");

            file.AutoFlush = true;

            string startLine = "ProblemName; ;Best;Worst;Avg;Std;Best;Worst;Avg;Std;Best;Worst;Avg;Std;";
            file.WriteLine(startLine);
            RandomSolution r = new RandomSolution();


            foreach (TSP problem in problems)
            {

                Console.WriteLine(problem.Name);
                line = problem.Name + "; ;";

                Console.WriteLine("Random");
                r.run(populationSize * generationNum, problem);
                line += r.Best + "; " + r.Worst + "; " + r.Avg + "; " + r.Dev + "; ";

                float best = Single.MaxValue;
                float worst = 0;
                float avg = 0;
                float div = 0;
                float[] solutions = new float[problem.Dimention];

                Console.WriteLine("Greedy");
                for (int i = 0; i < problem.Dimention; i++)
                {
                    float temp = new TSPGenotype(TSPGenotype.solutionToGenotype(GreedyAlgorithm.solveGreedy(problem, i)), problem).fitness();
                    solutions[i] = temp;
                    if (temp > worst) worst = temp;
                    if (temp < best) best = temp;
                    avg += temp;
                }

                avg = avg / problem.Dimention;

                for (int i = 0; i < problem.Dimention; i++)
                {
                    div += (solutions[i] - avg) * (solutions[i] - avg);
                }
                div = div / problem.Dimention;
                div = Convert.ToSingle(Math.Sqrt(div));

                line += best + "; " + worst + "; " + avg + "; " + div + "; ";

                best = Single.MaxValue;
                worst = 0;
                avg = 0;
                div = 0;

                Console.WriteLine("Ewolucyjny");
                for (int i = 0; i < 10; i++)
                {
                    AlgorytmEwolucyjny alg = new AlgorytmEwolucyjny(problem, populationSize, generationNum, "TNM");
                    alg.CrossoverProb = 0.9;
                    alg.MutationProb = 0.4;
                    if (i == 0)
                    {
                        file.WriteLine(alg.toString());

                    }
                    float temp = alg.runAlgorithm().fitness();
                    solutions[i] = temp;
                    if (temp > worst) worst = temp;
                    if (temp < best) best = temp;
                    avg += temp;
                }

                avg = avg / problem.Dimention;

                for (int i = 0; i < problem.Dimention; i++)
                {
                    div += (solutions[i] - avg) * (solutions[i] - avg);
                }
                div = div / problem.Dimention;
                div = Convert.ToSingle(Math.Sqrt(div));

                line += best + "; " + worst + "; " + avg + "; " + div + "; ";


                file.WriteLine(line);
            }



        }

        public static void filesConverter(string[] filePaths)
        {
            foreach (string path in filePaths)
            {
                var file = new System.IO.StreamWriter(path.Replace(".txt", "") + "mod.txt");
                string[] lines = System.IO.File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] nums = line.Split();
                    string newline = "";
                    foreach (string num in nums)
                    {
                        string tempnum = "";
                        if (num.Length > 0) tempnum = num.Remove(num.Length - 1, 1);
                        newline += tempnum + "; ";
                    }
                    file.WriteLine(newline);
                }
                file.Close();

            }

        }

        public static void finalTestBefore(TSP[] problems, int[] populationSizes, int[] generationNums)
        {

            string line;
            var file = new System.IO.StreamWriter(@"/Users/aggami/Library/Mobile Documents/com~apple~CloudDocs/Studia/Semestr 6/SIiIW/" + "finalTestBefore.txt");

            file.AutoFlush = true;

            string startLine = "ProblemName; Popsize; numOfGen; TNMSize; Crossover Prob; Mutation Prob;Best;Worst;Avg;Std;";
            file.WriteLine(startLine);

            for (int i = 0; i < problems.Length; i++)
            {
                Console.WriteLine(problems[i].Name);
                float best = Single.MaxValue;
                float worst = 0;
                float avg = 0;
                float div = 0;
                float[] solutions = new float[10];
                double cp = 0.7;
                double mp = 0.2;
                int ts = 20;

                for (int j = 0; j < 10; j++)
                {

                    Console.WriteLine("Run " + j);
                    AlgorytmEwolucyjny alg = new AlgorytmEwolucyjny(problems[i], populationSizes[i], generationNums[i], "TNM");
                    alg.CrossoverProb = cp;
                    alg.MutationProb = mp;
                    alg.TournamentSize = ts;

                    float temp = alg.runAlgorithm().fitness();
                    solutions[j] = temp;
                    if (temp > worst) worst = temp;
                    if (temp < best) best = temp;
                    avg += temp;
                }
                avg = avg / 10;

                for (int j = 0; j < 10; j++)
                {
                    div += (solutions[i] - avg) * (solutions[j] - avg);
                }
                div = div / 10;
                div = Convert.ToSingle(Math.Sqrt(div));

                line = problems[i].Name + "; " + populationSizes[i] + "; " + generationNums[i] + "; " + ts + "; " + cp + "; " + mp + "; " + best + "; " + worst + "; " + avg + "; " + div + "; ";


                file.WriteLine(line);

            }




        }


        public static void finalTestAfter(TSP[] problems, int[] populationSizes, int[] generationNums)
        {

            string line;
            var file = new System.IO.StreamWriter(@"/Users/aggami/Library/Mobile Documents/com~apple~CloudDocs/Studia/Semestr 6/SIiIW/" + "finalTestAfter2.txt");

            file.AutoFlush = true;

            string startLine = "ProblemName; Popsize; numOfGen; TNMSize; Crossover Prob; Mutation Prob;Best;Worst;Avg;Std;";
            file.WriteLine(startLine);

            for (int i = 0; i < problems.Length; i++)
            {
                Console.WriteLine(problems[i].Name);
                float best = Single.MaxValue;
                float worst = 0;
                float avg = 0;
                float div = 0;
                float[] solutions = new float[10];
                double cp = 0.8;
                double mp = 0.4;
                int ts = 20;

                for (int j = 0; j < 10; j++)
                {

                    Console.WriteLine("Run " + j);
                    AlgorytmEwolucyjny alg = new AlgorytmEwolucyjny(problems[i], populationSizes[i], generationNums[i], "TNM");
                    alg.CrossoverProb = cp;
                    alg.MutationProb = mp;
                    alg.TournamentSize = ts;

                    float temp = alg.runAlgorithmWithGreedy().fitness();
                    solutions[j] = temp;
                    if (temp > worst) worst = temp;
                    if (temp < best) best = temp;
                    avg += temp;
                }
                avg = avg / 10;

                for (int j = 0; j < 10; j++)
                {
                    div += (solutions[i] - avg) * (solutions[j] - avg);
                }
                div = div / 10;
                div = Convert.ToSingle(Math.Sqrt(div));

                line = problems[i].Name + "; " + populationSizes[i] + "; " + generationNums[i] + "; " + ts + "; " + cp + "; " + mp + "; " + best + "; " + worst + "; " + avg + "; " + div + "; ";


                file.WriteLine(line);

            }

        }
    }
}
    


