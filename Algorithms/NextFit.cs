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
			int res = 1, bin_rem = BinCapacity;

			for (int i = 0; i < NumberOfItems; i++)
			{
				if (ItemsArray[i] > bin_rem)
				{
					res++; 
					bin_rem = BinCapacity - ItemsArray[i];
				}
				else
					bin_rem -= ItemsArray[i];
			}
			return res;
        }
	}
}
