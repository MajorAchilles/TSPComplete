using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TSPTest
{
    public enum CrossOverMethod
    {
        Random,
        Greedy
    }

    public class TSPOptions
    {
        public Organism[] population;
        public int populationSize;
        public int maxGenerations;
        public int mutationChance;
        public int elitePercentage;
        public CrossOverMethod crossOverMethod;
    }

    class TSPGeneticAlgorithm
    {
        Organism[] population;
        Organism[] elitePopulation;
        Random random = new Random();
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
            generationCount++;
            List<Organism> populationList = population.ToList();
            CrossOver(populationList);

            for (int i = 0; i<populationList.Count; i++)
            {
                if(random.Next(0, 101)<options.mutationChance)
                    populationList[i] = Mutate(populationList[i]);
            }

            population = populationList.ToArray();
            return population;
        }

        private void CrossOver(List<Organism> populationList)
        {
            populationList.Sort();

            if (options.elitePercentage != 100)
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
                    Organism parent1 = populationList[random.Next(0, populationList.Count)];
                    Organism parent2 = populationList[random.Next(0, populationList.Count)];
                    if (options.crossOverMethod == CrossOverMethod.Random)
                        newList.Add(CrossOverRandom(parent1, parent2));
                    else
                        newList.Add(CrossOverGreedy(parent1, parent2));
                }
                populationList = newList;

            }
            populationList.Sort();
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

        private Organism CrossOverGreedy(Organism parent1, Organism parent2)
        {
            int tourCount = parent1.Tour.Count;
            List<Point> parent1Cities = parent1.Tour.ToList();
            List<Point> parent2Cities = parent2.Tour.ToList();

            Organism solution = new Organism();

            while (solution.Tour.Count < tourCount)
            {
                if(parent1Cities.Count>1 && parent2Cities.Count>1)
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

        private Organism Mutate(Organism organism)
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
    }
}
