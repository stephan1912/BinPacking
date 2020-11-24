using System;
using System.Collections.Generic;
using System.Text;

namespace BinPackingComparison.Algorithms.DataStructures
{
    public class HarmonicData
    {
        public int BinIndex { get; set; }
        public double Capacity { get; set; }
        public double RemainingCapacity { get; set; }
        public int FilledBins { get; set; }
        public Interval BinInterval { get; set; }
        public List<Bin> BinsList { get; set; }

        public HarmonicData(int binIndex, double capacity, Interval binInterval)
        {
            BinIndex = binIndex;
            RemainingCapacity = Capacity = capacity;
            FilledBins = 0;
            BinInterval = binInterval;
            BinsList = new List<Bin>();
        }

        public void HandleItemInsertion(double item)
        {
            if (item > RemainingCapacity)
            {
                FilledBins++;
                BinsList.Add(new Bin { Name = $"Bin I{BinIndex}-{FilledBins}", Values = new List<double>() });
                RemainingCapacity = Capacity - item;
            }
            else
            {
                if (FilledBins == 0)
                {
                    FilledBins++;
                    BinsList.Add(new Bin { Name = $"Bin I{BinIndex}-{FilledBins}", Values = new List<double>() });
                }
                RemainingCapacity -= item;
            }
            BinsList[FilledBins - 1].Values.Add(item);
        }
    }
}
