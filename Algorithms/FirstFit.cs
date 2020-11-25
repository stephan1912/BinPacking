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
			int res = 0;

			int[] bin_rem = new int[NumberOfItems];

			for (int i = 0; i < NumberOfItems; i++)
			{
				int j;
				for (j = 0; j < res; j++)
				{
					if (bin_rem[j] >= ItemsArray[i])
					{
						bin_rem[j] = bin_rem[j] - ItemsArray[i];
						break;
					}
				}

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
