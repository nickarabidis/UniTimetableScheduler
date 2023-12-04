using System.Collections.Generic;

namespace Scheduler.Model
{
    public interface Chromosome<T> where T : Chromosome<T>
    {
        public T MakeNewFromPrototype(List<float> positions = null);
		
        public float Fitness { get; }

        public Configuration Configuration { get; }

        public T Crossover(T mother, int numberOfCrossoverPoints, float crossoverProbability);
		

        public void Mutation(int mutationSize, float mutationProbability);
		
		public double[] Objectives { get; }

    }
}
