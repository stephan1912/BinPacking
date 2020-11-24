using BinPackingComparison.Algorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinPackingComparison.Algorithms
{
    public class HarmonicK : BinPackingAlgorithm<double>
    {
        public int M { get; set; }
        public HarmonicK(double[] itemsArray, int numberOfItems, double binCapacity, int m) : base(itemsArray, numberOfItems, binCapacity)
        {
            AlgorithmDescription = "Harmonic-K, O(N log M)";
            M = m;
        }

        public override int ComputeNumberOfBins()
        {
            var harmonicData = GenerateHarmonicData();

            for(int i = 0; i < NumberOfItems; i++)
            {
                var index = BinarySearchWithIntervals(0, M, harmonicData, ItemsArray[i]);
                if(index == -1)
                {
                    break;
                }
                harmonicData[index].HandleItemInsertion(ItemsArray[i]);
            }

            #region DescribeResult
            //for(int i = 0; i < harmonicData.Count; i++)
            //{
            //    Console.WriteLine($"Pentru k={i + 1}, avem:");
            //    for(int j = 0; j < harmonicData[i].BinsList.Count; j++)
            //    {
            //        string s = "";
            //        foreach(var value in harmonicData[i].BinsList[j].Values)
            //        {
            //            s += value + ", ";
            //        }
            //        Console.WriteLine($"{harmonicData[i].BinsList[j].Name} cu obiectele {s}");
            //    }
            //}
            #endregion
            return harmonicData.Sum(hd => hd.FilledBins);
        }


        private int BinarySearchWithIntervals(int left, int right, List<HarmonicData> bins, double item)
        {
            if(right >= left)
            {
                int mid = left + (right - left) / 2;

                switch (bins[mid].BinInterval.CheckValue(item))
                {
                    case 0: return mid;
                    case 1: return BinarySearchWithIntervals(left, mid, bins, item);
                    case -1: return BinarySearchWithIntervals(mid, right, bins, item);
                }
            }
            return -1;
        }

        private List<HarmonicData> GenerateHarmonicData()
        {
            var data = new List<HarmonicData>();
            for(int k = 1; k < M; k++)
            {
                data.Add(new HarmonicData(k, BinCapacity, new Interval(1.0 / (k + 1), 1.0 / k)));
            }
            data.Add(new HarmonicData(M, BinCapacity, new Interval(0.0, 1.0 / M)));
            return data;
        }
    }

}
