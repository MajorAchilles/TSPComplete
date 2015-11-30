using System;
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
        Greedy,
        Opt2
    }

    public class TSPOptions
    {
        public Organism[] population;
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
                        child = CrossOverSubtour(parent1, parent2);
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
                    if (options.mutationMethod == MutationMethod.Greedy)
                        child = MutateGreedy(child);
                    else
                        child = Mutate2Opt(child);
                }
                else
                {
                    if (random.Next(0, 101) <= options.mutationPopulationPercentage) //MUTATE
                        if (options.mutationMethod == MutationMethod.Greedy)
                            child = MutateGreedy(child);
                        else
                            child = Mutate2Opt(child);
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

            solution.Fitness = solution.Tour.GetTourDistance();

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

            solution.Fitness = solution.Tour.GetTourDistance();
            return solution;
        }

        private Organism CrossOverGreedy(Organism parent1, Organism parent2) // NOT GREEDY ENOUGH. MAKE MORE GREEDY.
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

            solution.Fitness = solution.Tour.GetTourDistance();
            return solution;
        }

        private Organism MutateGreedy(Organism organism)
        {
            if (organism.Tour.Count > 1)
            {
                double current = organism.Fitness;

                int index = random.Next(0, organism.Tour.Count);
                int next;
                if (index == 0) //First
                    if (random.Next(0, 2) == 0) //Next or last
                        next = index + 1;
                    else
                        next = organism.Tour.Count - 1;
                else if (index == organism.Tour.Count - 1) //last
                    if (random.Next(0, 2) == 0) //Previous or first
                        next = index - 1;
                    else
                        next = 0;
                else //All in between
                    if (random.Next(0, 2) == 0) //Previous or next
                    next = index - 1;
                else
                    next = index + 1;

                organism.Tour.Swap(index, next);
                organism.Fitness = organism.Tour.GetTourDistance();

                if (organism.Fitness > current) //If mutation wasn't beneficial
                {
                    organism.Tour.Swap(index, next);
                    organism.Fitness = organism.Tour.GetTourDistance();
                }
            }
            return organism;
        }

        private Organism Mutate2Opt(Organism organism)
        {
            int i = 0;
            double tourLength = organism.Tour.Count;
            double percentage = options.mutationIndividualPercentage;
            tourLength = (int)((percentage / 100D) * tourLength);

            while (i < tourLength)
            {
                if (organism.Tour.Count > 3)
                {
                    int i11 = random.Next(0, organism.Tour.Count);

                    int i12 = i11 + 1;
                    if (i12 == organism.Tour.Count) // if index overflow
                        i12 = 0; //First

                    int i21 = random.Next(0, organism.Tour.Count);
                    while (i21 == i11 || i21 == i12) //If getting existing number
                        i21 = random.Next(0, organism.Tour.Count);

                    int i22 = i21 + 1;
                    if (i22 == organism.Tour.Count)
                        i22 = 0;


                    Point t11 = organism.Tour[i11];
                    Point t12 = organism.Tour[i12];
                    Point t21 = organism.Tour[i21];
                    Point t22 = organism.Tour[i22];

                    double originalDistance = Utils.GetDistance(t11, t12) + Utils.GetDistance(t21, t22);
                    double newDistance = Utils.GetDistance(t11, t22) + Utils.GetDistance(t21, t12);


                    if (newDistance < originalDistance)
                    {
                        Organism mutated = new Organism();
                        mutated.Tour = organism.Tour.ToList();
                        mutated.Tour.Swap(i12, i22);
                        mutated.Fitness = mutated.Tour.GetTourDistance();
                        if (mutated.Fitness < organism.Fitness)
                            organism = mutated;
                    }
                }
                i++;
            }
            return organism;
        }
    }
}