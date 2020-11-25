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
			int res = 0;

			int[] bin_rem = new int[NumberOfItems];

			for (int i = 0; i < NumberOfItems; i++)
			{
				int j;

				int min = BinCapacity + 1, bi = 0;

				for (j = 0; j < res; j++)
				{
					if (bin_rem[j] >= ItemsArray[i] && bin_rem[j] - ItemsArray[i] < min)
					{
						bi = j;
						min = bin_rem[j] - ItemsArray[i];
					}
				}
                if (min == BinCapacity + 1)
                {
                    bin_rem[res] = BinCapacity - ItemsArray[i];
                    res++;
                }
                else
                {
                    bin_rem[bi] -= ItemsArray[i];
                }
			}
			return res;
        }
	}
}
