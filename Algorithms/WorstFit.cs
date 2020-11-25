using System;
using System.Collections.Generic;
using System.Text;

namespace BinPackingComparison.Algorithms
{
	class WorstFit: BinPackingAlgorithm<int>
	{
		public WorstFit(int[] itemsArray, int numberOfItems, int binCapacity) : base(itemsArray, numberOfItems, binCapacity)
		{
			AlgorithmDescription = "Worst Fit, O(n²)";
		}

		public override int ComputeNumberOfBins()
		{
			int res = 0;

			int[] bin_rem = new int[NumberOfItems];

			for (int i = 0; i < NumberOfItems; i++)
			{
				int j;

				int mx = -1, wi = 0;

				for (j = 0; j < res; j++)
				{
					if (bin_rem[j] >= ItemsArray[i] && bin_rem[j] - ItemsArray[i] > mx)
					{
						wi = j;
						mx = bin_rem[j] - ItemsArray[i];
					}
				}

                if (mx == -1)
                {
                    bin_rem[res] = BinCapacity - ItemsArray[i];
                    res++;
                }
                else
                {
                    bin_rem[wi] -= ItemsArray[i];
                }
			}
			return res;
        }
	}
}
