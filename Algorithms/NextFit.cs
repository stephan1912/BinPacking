using System;
using System.Collections.Generic;
using System.Text;

namespace BinPackingComparison.Algorithms
{
	public class NextFit: BinPackingAlgorithm<int>
	{
		public NextFit(int[] itemsArray, int numberOfItems, int binCapacity) : base(itemsArray, numberOfItems, binCapacity)
		{
			AlgorithmDescription = "Next Fit, O(n)";
		}

		public override int ComputeNumberOfBins()
		{
			// Initialize result (Count of bins) and remaining 
			// capacity in current bin. 
			int res = 1, bin_rem = BinCapacity;

			// Place items one by one 
			for (int i = 0; i < NumberOfItems; i++)
			{
				// If this item can't fit in current bin 
				if (ItemsArray[i] > bin_rem)
				{
					res++; // Use a new bin 
					bin_rem = BinCapacity - ItemsArray[i];
				}
				else
					bin_rem -= ItemsArray[i];
			}
			return res;
        }
	}
}
