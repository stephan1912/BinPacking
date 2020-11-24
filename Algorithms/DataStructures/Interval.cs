using System;
using System.Collections.Generic;
using System.Text;

namespace BinPackingComparison.Algorithms.DataStructures
{
    public class Interval
    {
        public double LowerBound { get; set; }
        public double UpperBound { get; set; }
        public Interval(double lowerBound, double upperBound)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
        }

        public int CheckValue(double value)
        {
            if (value <= LowerBound) return -1;
            if (value > UpperBound) return 1;
            return 0;
        }
    }
}
