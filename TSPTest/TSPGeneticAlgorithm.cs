﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TSPTest
{
    public enum CrossOverMethod
    {
        Random,
        Greedy,
        SubTour
    }

    public enum MutationMethod
    {
        SwapNeighbour,
        Opt2
    }

    public class TSPOptions
    {
        public Organism[] population;
        public int geneLength;
        public int populationSize;
        public int maxGenerations;
        public int mutationPopulationPercentage;
        public int mutationIndividualPercentage;
        public int elitePercentage;
        public CrossOverMethod crossOverMethod;
        public MutationMethod mutationMethod;
    }

    class TSPGeneticAlgorithm
    {
        Organism[] population;
        Organism[] elitePopulation;
        static Random random = new Random();
        TSPOptions options;
        int generationCount;

        public int GenerationNo
        {
            get
            {
                return generationCount;
            }
        }

        public TSPGeneticAlgorithm(TSPOptions options)
        {
            this.options = options;
            this.population = options.population;
            generationCount = 1;
            elitePopulation = new Organism[options.elitePercentage];
        }

        public Organism[] GetNextGeneration()
        {
            List<Organism> populationList = population.ToList();
            populationList = Selection(populationList);
            population = populationList.ToArray();
            generationCount++;
            return population;
        }

        private List<Organism> Selection(List<Organism> populationList)
        {
            if (generationCount == 1) //This is an initial population. 
                populationList.Sort(); //We need to sort by fitness so that good solutions don't die.

            if (options.elitePercentage != 100) //Cull and generate new population
            {
                List<Organism> newList = new List<Organism>();
                newList = populationList.ToList();

                double popCount = populationList.Count;
                double percentage = options.elitePercentage;
                int num = (int)((percentage / 100D) * popCount);
                if (num == 0)
                    num = 1;
                num = (int)popCount - num;
                newList.RemoveRange(newList.Count - num, num);

                while (newList.Count < options.populationSize)
                {
                    Organism child = null;
                    Organism parent1 = newList[random.Next(0, newList.Count)];
                    Organism parent2 = newList[random.Next(0, newList.Count)];
                    //Organism parent1 = populationList[random.Next(0, populationList.Count)];
                    //Organism parent2 = populationList[random.Next(0, populationList.Count)];

                    if (options.crossOverMethod == CrossOverMethod.Random)  //CROSSOVER
                        child = CrossOverRandom(parent1, parent2);
                    else if (options.crossOverMethod == CrossOverMethod.Greedy)
                        child = CrossOverGreedy(parent1, parent2);
                    else
                        child = CrossOverSubtourVersion2(parent1, parent2);
                    newList.Add(child);
                }

                newList.Sort();
                populationList = newList;
            }

            for (int i = 0; i < populationList.Count; i++)
            {
                Organism child = populationList[i];

                if (i == 0) //Always mutate elite.
                {
                    child = MutateTwoOptNew(child);
                    child = MutateSwapNeighbour(child);
                    //if (options.mutationMethod == MutationMethod.SwapNeighbour)
                    //    child = MutateSwapNeighbour(child);
                    //else
                    //{
                    //    child = MutateTwoOpt(child);
                    //    child = MutateSwapNeighbour(child);
                    //}
                }
                else
                {
                    if (random.Next(0, 101) <= options.mutationPopulationPercentage) //MUTATE
                    {
                        child = MutateTwoOptNew(child);
                        child = MutateSwapNeighbour(child);
                    }
                    //if (options.mutationMethod == MutationMethod.SwapNeighbour)
                    //    child = MutateSwapNeighbour(child);
                    //else
                    //{
                    //    child = MutateTwoOpt(child);
                    //    child = MutateSwapNeighbour(child);
                    //}
                }
                populationList[i] = child;
            }

            populationList.Sort(); //Sort after creation of population, by decreasing fitness and increasing distance
            return populationList;
        }

        private Organism CrossOverSubtour(Organism parent1, Organism parent2)
        {
            bool f1 = true;
            bool f2 = true;
            int n = parent1.Tour.Count;
            Organism solution = new Organism();
            int i = random.Next(0, n);
            Point town = parent1.Tour[i];
            List<Point> tour1 = parent1.Tour.ToList();

            int x = i;
            int y = parent2.Tour.IndexOf(town);

            solution.Tour.Add(town);
            tour1.Remove(town);

            while (f1 || f2)
            {
                x = (x - 1) % n;

                if (x < 0)
                    x = 0;

                y = (y + 1) % n;

                if (f1)
                {
                    if (!solution.Tour.Contains(parent1.Tour[x]))
                    {
                        solution.Tour.Add(parent1.Tour[x]);
                        tour1.Remove(parent1.Tour[x]);
                    }
                    else
                        f1 = false;
                }

                if (f2)
                {
                    if (!solution.Tour.Contains(parent2.Tour[y]))
                    {
                        solution.Tour.Add(parent2.Tour[y]);
                        tour1.Remove(parent2.Tour[y]);
                    }
                    else
                        f2 = false;
                }

                while (solution.Tour.Count < parent1.Tour.Count)
                {
                    int index = random.Next(0, tour1.Count);
                    solution.Tour.Add(tour1[index]);
                    tour1.RemoveAt(index);
                }
            }

            solution.Fitness = solution.Tour.GetTourDistanceFast();

            return solution;
        }

        private Organism CrossOverSubtourVersion2(Organism parent1, Organism parent2)
        {
            int n = parent1.Tour.Count;
            int start = random.Next(0, n);
            int end = 0;
            while (end < start)
                end = random.Next(0, n);

            Organism solution = new Organism();

            for(int i = start; i<=end; i++)
            {
                solution.Tour.Add(parent1.Tour[i]);
            }

            for(int j = 0; j< n;j++)
            {
                if (!solution.Tour.Contains(parent2.Tour[j]))
                    solution.Tour.Add(parent2.Tour[j]);
            }
            solution.Fitness = solution.Tour.GetTourDistanceFast();
            return solution;
        }

        private Organism CrossOverRandom(Organism parent1, Organism parent2)
        {
            Organism solution = new Organism();
            while (solution.Tour.Count != parent1.Tour.Count)
            {
                if (random.Next(0, 2) == 1) //Pick a city from parent1
                    while (true)
                    {
                        Point city = parent1.Tour[random.Next(parent1.Tour.Count)];
                        if (!solution.Tour.Contains(city))        //Already have this city, pick another
                        {
                            solution.Tour.Add(city);
                            break;
                        }
                    }
                else                    //Pick a city from parent 2
                    while (true)
                    {
                        Point city = parent2.Tour[random.Next(parent1.Tour.Count)];
                        if (!solution.Tour.Contains(city))        //Already have this city, pick another
                        {
                            solution.Tour.Add(city);
                            break;
                        }
                    }
            }


            solution.Fitness = solution.Tour.GetTourDistanceFast();
            return solution;
        }

        // NOT GREEDY ENOUGH. MAKE MORE GREEDY.
        private Organism CrossOverGreedy(Organism parent1, Organism parent2)
        {
            //The swapping here deals with only two nodes. Which may not always lead to a 
            //optimal local solution. Need to come up with a way to work globally.
            int tourCount = parent1.Tour.Count;
            List<Point> parent1Cities = parent1.Tour.ToList();
            List<Point> parent2Cities = parent2.Tour.ToList();

            Organism solution = new Organism();

            while (solution.Tour.Count < tourCount)
            {
                if (parent1Cities.Count > 1 && parent2Cities.Count > 1)
                {
                    int i = random.Next(0, parent1Cities.Count);
                    Point city = parent1Cities[i];

                    Point next1 = parent1Cities[0];
                    if (i < parent1Cities.Count - 1)
                        next1 = parent1Cities[i + 1];

                    int indexNext2 = parent2Cities.IndexOf(city) + 1;
                    if (indexNext2 == parent2Cities.Count)
                        indexNext2 = 0;
                    Point next2 = parent2Cities[indexNext2];
                    double distance1 = city.GetDistance(next1);
                    double distance2 = city.GetDistance(next2);

                    solution.Tour.Add(city);
                    parent1Cities.Remove(city);
                    parent2Cities.Remove(city);

                    if (distance1 < distance2) //parent 1 tour is closer
                    {
                        solution.Tour.Add(next1);
                        parent1Cities.Remove(next1);
                        parent2Cities.Remove(next1);
                    }
                    else                    //parent 2 tour is closer
                    {
                        solution.Tour.Add(next2);
                        parent1Cities.Remove(next2);
                        parent2Cities.Remove(next2);
                    }
                }

                if (parent1Cities.Count > 1)
                {
                    int i = random.Next(0, parent1Cities.Count);
                    Point city = parent1Cities[i];
                    Point next = parent1Cities[0];
                    if (i < parent1Cities.Count - 1)
                        next = parent1Cities[i + 1];

                    solution.Tour.Add(city);
                    parent1Cities.Remove(city);
                    parent2Cities.Remove(city);

                    solution.Tour.Add(next);
                    parent1Cities.Remove(next);
                    parent2Cities.Remove(next);
                }

                if (parent2Cities.Count > 1)
                {
                    int i = random.Next(0, parent2Cities.Count);
                    Point city = parent2Cities[i];

                    Point next = parent2Cities[0];
                    if (i < parent2Cities.Count - 1)
                        next = parent2Cities[i + 1];

                    solution.Tour.Add(city);
                    parent1Cities.Remove(city);
                    parent2Cities.Remove(city);
                    solution.Tour.Add(next);
                    parent1Cities.Remove(next);
                    parent2Cities.Remove(next);
                }

                if (parent1Cities.Count == 1)
                {
                    Point city = parent1Cities[0];
                    solution.Tour.Add(city);
                    parent1Cities.Remove(city);
                    parent2Cities.Remove(city);
                }

                if (parent2Cities.Count == 1)
                {
                    Point city = parent2Cities[0];
                    solution.Tour.Add(city);
                    parent1Cities.Remove(city);
                    parent2Cities.Remove(city);
                }
            }

            solution.Fitness = solution.Tour.GetTourDistanceFast();
            return solution;
        }

        private Organism MutateSwapNeighbour(Organism organism)
        {
            if (organism.Tour.Count > 1)
            {
                double current = organism.Fitness;

                int index = 0;
                while (index < organism.Tour.Count)
                {
                    int first = index - 1;
                    if (first < 0)
                        first = organism.Tour.Count - 1;

                    int next = index + 1;
                    if (next == organism.Tour.Count)
                        next = 0;

                    int last = next + 1;
                    if (last == organism.Tour.Count)
                        last = 0;

                    int firstToIndex = organism.Tour[first].GetDistanceFast(organism.Tour[index]);
                    int indexToNext = organism.Tour[index].GetDistanceFast(organism.Tour[next]);
                    int nextToLast = organism.Tour[next].GetDistanceFast(organism.Tour[last]);
                    int firstToNext = organism.Tour[first].GetDistanceFast(organism.Tour[next]);
                    int indexToLast = organism.Tour[index].GetDistanceFast(organism.Tour[last]);

                    int curDistance = firstToIndex + indexToNext + nextToLast;
                    int swappedDistance = firstToNext + indexToNext + indexToLast;

                    if(curDistance>swappedDistance)
                        organism.Swap(index, next);

                    //if (organism.Fitness >= current) //If mutation wasn't beneficial
                    //    organism.Swap(index, next);

                    index++;
                }
            }
            return organism;
        }

        private Organism MutateTwoOpt(Organism organism)
        {
            int i = 0;
            double tourLength = organism.Tour.Count;
            double percentage = options.mutationIndividualPercentage;
            tourLength = (int)((percentage / 100D) * tourLength);

            while (i < tourLength)
            {
                if (organism.Tour.Count > 3)
                {
                    int A = random.Next(0, organism.Tour.Count);

                    int B = A + 1;
                    if (B == organism.Tour.Count) // if index overflow
                        B = 0; //First

                    int C = random.Next(0, organism.Tour.Count);
                    while (C == A || C == B) //If getting existing number
                        C = random.Next(0, organism.Tour.Count);

                    int D = C + 1;
                    if (D == organism.Tour.Count)
                        D = 0;


                    Point line1Start = organism.Tour[A];
                    Point line1End = organism.Tour[B];
                    Point line2Start = organism.Tour[C];
                    Point line2End = organism.Tour[D];

                    double originalDistance = Utils.GetDistance(line1Start, line1End) + Utils.GetDistance(line2Start, line2End);
                    double newDistanceHorizontal = Utils.GetDistance(line1Start, line2End) + Utils.GetDistance(line2Start, line1End); //swap 12, 22
                    double newDistanceVertical = Utils.GetDistance(line1Start, line2Start) + Utils.GetDistance(line2End, line1End); //swap 12, 21

                    if (newDistanceHorizontal < originalDistance || newDistanceVertical < originalDistance)
                        if (newDistanceHorizontal < newDistanceVertical)
                        {
                            Organism mutated = organism.Clone();
                            mutated.Swap(B, D);
                            if (mutated.Fitness < organism.Fitness)
                                organism = mutated;
                        }
                        else
                        {
                            Organism mutated = organism.Clone();
                            mutated.Swap(B, C);
                            if (mutated.Fitness < organism.Fitness)
                                organism = mutated;
                        }
                }
                i++;
            }
            return organism;
        }

        private Organism MutateTwoOptNew(Organism organism)
        {
            //double tourLength = organism.Tour.Count;
            //double percentage = options.mutationIndividualPercentage;
            //tourLength = (int)((percentage / 100D) * tourLength);

            if (organism.Tour.Count < 3)
                return organism;

            for (int A = 0; A < organism.Tour.Count - 2; A++)
            {
                int B = A + 1;
                if (B == organism.Tour.Count)
                    B = 0;

                for (int C = B + 1; C < organism.Tour.Count; C++)
                {
                    int D = C + 1;
                    if (D == organism.Tour.Count)
                        D = 0;

                    //Console.WriteLine("Line1: {0},{1} Line2: {2},{3}", A, B, C, D);
                    if(A!=D)
                    {
                        if(random.Next(0,2)==1)
                        {
                            int temp = A;
                            A = B;
                            B = temp;
                            temp = C;
                            C = D;
                            D = temp;
                        }

                        Point line1Start = organism.Tour[A];
                        Point line1End = organism.Tour[B];
                        Point line2Start = organism.Tour[C];
                        Point line2End = organism.Tour[D];

                        if (Utils.IsIntersecting(line1Start, line1End, line2Start, line2End))
                        {
                            #region TRIAL
                            //Organism mutateAB = organism.Clone();
                            //mutateAB.OptimizingSwap(A, B);

                            //Organism mutateAC = organism.Clone();
                            //mutateAB.OptimizingSwap(A, C);

                            //Organism mutateAD = organism.Clone();
                            //mutateAB.OptimizingSwap(A, D);

                            //Organism mutateBC = organism.Clone();
                            //mutateAB.OptimizingSwap(B, C);

                            //Organism mutateBD = organism.Clone();
                            //mutateAB.OptimizingSwap(B, D);

                            //Organism mutateCD = organism.Clone();
                            //mutateAB.OptimizingSwap(C, D);

                            ////REVERSE
                            //Organism mutateBA = organism.Clone();
                            //mutateAB.OptimizingSwap(B, A);

                            //Organism mutateCA = organism.Clone();
                            //mutateAB.OptimizingSwap(C, A);

                            //Organism mutateDA = organism.Clone();
                            //mutateAB.OptimizingSwap(D, A);

                            //Organism mutateCB = organism.Clone();
                            //mutateAB.OptimizingSwap(C, B);

                            //Organism mutateDB = organism.Clone();
                            //mutateAB.OptimizingSwap(D, B);

                            //Organism mutateDC = organism.Clone();
                            //mutateAB.OptimizingSwap(D, C);



                            //if (mutateAB.Fitness < organism.Fitness)
                            //    organism = mutateAB;

                            //if (mutateAC.Fitness < organism.Fitness)
                            //    organism = mutateAC;

                            //if (mutateAD.Fitness < organism.Fitness)
                            //    organism = mutateAD;

                            //if (mutateBC.Fitness < organism.Fitness)
                            //    organism = mutateBC;

                            //if (mutateBD.Fitness < organism.Fitness)
                            //    organism = mutateBD;

                            //if (mutateCD.Fitness < organism.Fitness)
                            //    organism = mutateCD;


                            //REVERSE

                            //if (mutateBA.Fitness < organism.Fitness)
                            //    organism = mutateBA;

                            //if (mutateCA.Fitness < organism.Fitness)
                            //    organism = mutateCA;

                            //if (mutateDA.Fitness < organism.Fitness)
                            //    organism = mutateDA;

                            //if (mutateCB.Fitness < organism.Fitness)
                            //    organism = mutateCB;

                            //if (mutateDB.Fitness < organism.Fitness)
                            //    organism = mutateDB;

                            //if (mutateDC.Fitness < organism.Fitness)
                            //    organism = mutateDC;
                            #endregion

                            Organism mutateHorizontal = organism.Clone();
                            mutateHorizontal.OptimizingSwap(B, D);

                            Organism mutateHorizontal2 = organism.Clone();
                            mutateHorizontal.OptimizingSwap(D, B);

                            Organism mutateVertical = organism.Clone();
                            mutateVertical.OptimizingSwap(B, C);

                            Organism mutateVertical2 = organism.Clone();
                            mutateVertical.OptimizingSwap(C, B);

                            if (mutateHorizontal.Fitness <= organism.Fitness)
                                organism = mutateHorizontal;

                            if (mutateHorizontal2.Fitness <= organism.Fitness)
                                organism = mutateHorizontal2;

                            if (mutateVertical.Fitness <= organism.Fitness)
                                organism = mutateVertical;

                            if (mutateVertical2.Fitness <= organism.Fitness)
                                organism = mutateVertical2;

                            #region OLD CODE
                            //Organism mutateHorizontal = organism.Clone();
                            //mutateHorizontal.OptimizingSwap(B, D);

                            //Organism mutateHorizontal2 = organism.Clone();
                            //mutateHorizontal.OptimizingSwap(D, B);

                            //Organism mutateVertical = organism.Clone();
                            //mutateVertical.OptimizingSwap(B, C);

                            //Organism mutateVertical2 = organism.Clone();
                            //mutateVertical.OptimizingSwap(C, B);
                            #endregion
                        }
                    }
                }
            }
            return organism;
        }
    }
}