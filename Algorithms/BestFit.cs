using System;
using System.Collections.Generic;
using System.Text;

namespace BinPackingComparison.Algorithms
{
	class BestFit: BinPackingAlgorithm<int>
	{
		public BestFit(int[] itemsArray, int numberOfItems, int binCapacity) : base(itemsArray, numberOfItems, binCapacity)
		{
			AlgorithmDescription = "Best Fit, O(n²)";
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
				// Find the best bin that ca\n accomodate 
				// weight[i] 
				int j;

				// Initialize minimum space left and index 
				// of best bin 
				int min = BinCapacity + 1, bi = 0;

				for (j = 0; j < res; j++)
				{
					if (bin_rem[j] >= ItemsArray[i] && bin_rem[j] - ItemsArray[i] < min)
					{
						bi = j;
						min = bin_rem[j] - ItemsArray[i];
					}
				}
				// If no bin could accommodate weight[i], 
				// create a new bin 
				if (min == BinCapacity + 1)
				{
					bin_rem[res] = BinCapacity - ItemsArray[i];
					res++;
				}
				else // Assign the item to best bin 
					bin_rem[bi] -= ItemsArray[i];
			}
			return res;
        }
	}
}
