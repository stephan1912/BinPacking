using System;
using System.Diagnostics;
using System.Text;

namespace BinPackingComparison.Algorithms
{
	public abstract class BinPackingAlgorithm<T>
	{
		public T[] ItemsArray { get; set; }
		public int NumberOfItems { get; set; }
		public T BinCapacity { get; set; }
		protected string AlgorithmDescription { get; set; }

		public void SimulateBinPackingProblem()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("-------------------------------------------------------------------------------");
			sb.AppendLine($"Executarea algoritmului {AlgorithmDescription}:");
			var stopWatch = new Stopwatch();
			stopWatch.Start();
			sb.AppendLine($"Numar de containere: {ComputeNumberOfBins()}");
			stopWatch.Stop();
			sb.AppendLine($"Durata de executie: {TimeSpan.FromMilliseconds(stopWatch.ElapsedMilliseconds)}");
			sb.AppendLine("-------------------------------------------------------------------------------");

			Console.WriteLine(sb.ToString());
		}

		public abstract int ComputeNumberOfBins();

		public BinPackingAlgorithm(T[] itemsArray, int numberOfItems, T binCapacity)
		{
			this.ItemsArray = new T[itemsArray.Length];
			Array.Copy(itemsArray, this.ItemsArray, itemsArray.Length);

			this.NumberOfItems = numberOfItems;
			this.BinCapacity = binCapacity;
		}

	}
}