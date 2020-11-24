using System;
using System.Collections.Generic;
using System.Text;

namespace BinPackingComparison.Algorithms
{
	class FirstFit: BinPackingAlgorithm<int>
	{
		public FirstFit(int[] itemsArray, int numberOfItems, int binCapacity) : base(itemsArray, numberOfItems, binCapacity)
		{
			AlgorithmDescription = "First Fit, O(n²)";
		}

		public override int ComputeNumberOfBins()
		{
			// Initialize result (Count of bins) 
			int res = 0;

			// Create an array to store remaining space in bins 
			// there can be at most n bins 
			int[] bin_rem = new int[NumberOfItems];

			// Place items one by one 
			for (int i = 0; i < NumberOfItems; i++)
			{
				// Find the first bin that can accommodate 
				// weight[i] 
				int j;
				for (j = 0; j < res; j++)
				{
					if (bin_rem[j] >= ItemsArray[i])
					{
						bin_rem[j] = bin_rem[j] - ItemsArray[i];
						break;
					}
				}

				// If no bin could accommodate weight[i] 
				if (j == res)
				{
					bin_rem[res] = BinCapacity - ItemsArray[i];
					res++;
				}
			}
			return res;
        }
	}
}
