using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BinPackingComparison.Algorithms;

namespace BinPackingComparison
{
	class Program
	{
		static int[] GenerateRandomArray(int minVal, int maxVal, int numberOfItems)
		{
			var randomArray = new int[numberOfItems];
			for (int i = 0; i < numberOfItems; i++)
			{
				randomArray[i] = new Random().Next(minVal, maxVal);
			}

			return randomArray;
		}

        static void Main(string[] args)
		{
			var numberOfItems = 32000;
			var binCapacity = 10;
            var M = 4;
            ReadValuesFromKeyboard(ref numberOfItems, ref binCapacity, ref M);


            Console.WriteLine("\nExecutare algoritmi: \n");


            //BinPackingAlgorithm<double> harmonick = new HarmonicK(new double[] { .5, .7, .5, .2, .4, .2, .5, .1, .6 }, 9, 1.0, 4);
            //harmonick.SimulateBinPackingProblem();

			var randomArray = GenerateRandomArray(1, 7, numberOfItems);
            var taskArray = (new List<BinPackingAlgorithm<int>>
            {
                new FirstFit(randomArray, numberOfItems, binCapacity),
                new NextFit(randomArray, numberOfItems, binCapacity),
                new BestFit(randomArray, numberOfItems, binCapacity),
                new WorstFit(randomArray, numberOfItems, binCapacity)

            }).Select(algorithm => Task.Run(() => algorithm.SimulateBinPackingProblem())).ToList();

            taskArray.Add(Task.Run(
                () => (new HarmonicK(randomArray.Select(val => val / 10.0).ToArray(), numberOfItems, binCapacity / 10.0, M)).SimulateBinPackingProblem()
                )
            );

            Task.WaitAll(taskArray.ToArray());

            Console.WriteLine("\nApasa <Enter>");
			Console.ReadLine();
		}

		private static void ReadValuesFromKeyboard(ref int numberOfItems, ref int binCapacity, ref int M)
		{
			try
			{
				Console.Write("Numarul de obiecte: ");
				numberOfItems = Convert.ToInt32(Console.ReadLine());
			}
			catch
			{
				Console.WriteLine("Valoare gresita, se foloseste valoarea default, 32000");
			}

			try
			{
				Console.Write("Capacitatea unui container: ");
				binCapacity = Convert.ToInt32(Console.ReadLine());
			}
			catch
			{
				Console.WriteLine("Valoare gresita, se foloseste valoarea default, 10");
			}

            try
            {
                Console.Write("Valoarea M, pentru Harmonic-K: ");
                M = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Valoare gresita, se foloseste valoarea default, 4");
            }
        }
	}
}
