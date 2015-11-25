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
        public int eliteCount;
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
            elitePopulation = new Organism[options.eliteCount];
        }

        public Organism[] GetNextGeneration()
        {
            generationCount++;
            List<Organism> populationList = population.ToList();
            populationList.Sort();

            for(int i = 0; i<options.eliteCount; i++)
            {
                elitePopulation[i] = populationList[i];
            }

            populationList = CrossOver(populationList);

            for (int i = 0; i<populationList.Count; i++)
            {
                if(random.Next(0, 101)<options.mutationChance)
                    populationList[i] = Mutate(populationList[i]);
            }

            populationList.Sort();

            int lastIndex = populationList.Count - 1;
            for(int i = 0; i<options.eliteCount; i++)
            {
                populationList[lastIndex - i] = elitePopulation[i];
            }

            populationList.Sort();

            population = populationList.ToArray();
            return population;
        }

        private List<Organism> CrossOver(List<Organism> populationList)
        {
            List<Organism> newList = new List<Organism>();

            while (newList.Count < options.populationSize)
            {
                Organism parent1 = populationList[random.Next(0, populationList.Count)];
                Organism parent2 = populationList[random.Next(0, populationList.Count)];
                if (options.crossOverMethod == CrossOverMethod.Random)
                    newList.Add(RandomCrossOver(parent1, parent2));
                else
                    newList.Add(GreedyCrossOver(parent1, parent2));
            }
            return newList;
        }

        private Organism RandomCrossOver(Organism parent1, Organism parent2)
        {
            Organism randomSolution = new Organism();
            while (randomSolution.Tour.Count != parent1.Tour.Count)
            {
                if (random.Next(0, 2) == 1)
                {
                    while (true)
                    {
                        Point city = parent1.Tour[random.Next(parent1.Tour.Count)];
                        if (!randomSolution.Tour.Contains(city))
                        {
                            randomSolution.Tour.Add(city);
                            break;
                        }
                    }
                }
                else
                {
                    while (true)
                    {
                        Point city = parent2.Tour[random.Next(parent1.Tour.Count)];
                        if (!randomSolution.Tour.Contains(city))
                        {
                            randomSolution.Tour.Add(city);
                            break;
                        }
                    }
                }
            }

            randomSolution.Fitness = randomSolution.Tour.GetTourDistance();
            return randomSolution;
        }

        private Organism GreedyCrossOver(Organism parent1, Organism parent2)
        {
            List<Point> parent1Chromosome = parent1.Tour.ToList();
            List<Point> parent2Chromosome = parent2.Tour.ToList();
            Organism randomSolution = new Organism();

            while (parent1Chromosome.Count > 0 && parent2Chromosome.Count > 0)
            {
                if (random.Next(0, 2) > 0)
                {
                    int index = random.Next(0, parent2Chromosome.Count);
                    Point city = parent2Chromosome[index];
                    randomSolution.Tour.Add(city);
                    parent2Chromosome.Remove(city);
                }
                else
                {
                    int index = random.Next(0, parent1Chromosome.Count);
                    Point city = parent1Chromosome[index];
                    randomSolution.Tour.Add(city);
                    parent1Chromosome.Remove(city);
                }
            }

            while (parent1Chromosome.Count > 0)
            {
                int index = random.Next(0, parent1Chromosome.Count);
                Point city = parent1Chromosome[index];
                randomSolution.Tour.Add(city);
                parent1Chromosome.Remove(city);
            }

            while (parent2Chromosome.Count > 0)
            {
                int index = random.Next(0, parent2Chromosome.Count);
                Point city = parent2Chromosome[index];
                randomSolution.Tour.Add(city);
                parent2Chromosome.Remove(city);
            }


            return randomSolution;
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
