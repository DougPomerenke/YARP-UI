using MathNet.Numerics;
using MathNet.Numerics.Statistics;

namespace StatisticalTools
{
    public class HistogramBucket
    {
        //  Experimenting with Math.Net library, not displaying 'cause its properties are doubles.
        protected MathNet.Numerics.Statistics.RunningStatistics runningStats;
        protected int bucketWidth;
        protected int numberOfBuckets;
        protected int lowestBucket;
        //  All data points are stored in here.
        public List<decimal> data;
        protected decimal min;
        protected decimal max;
        protected decimal mean;  // average
        protected decimal median;
        protected decimal minusOneSigma;    // 84% above this value

        //  Data points are stored in buckets for display, some data points may be outside this range.
        public List<IntegerBucket> buckets;

        public int NumberOfElements { get { return data.Count(); } }
        public int NumberOfBuckets { get { return this.numberOfBuckets; } }
        public decimal Min { get { return this.min; } }
        public decimal Max { get { return this.max; } }
        public decimal Mean {  get { return this.mean;} }
        public decimal Median { get { return this.median; } }
        public decimal MinusOneSigma {
            get {
                // Set breakpoint here for checking values produced by Math.Net library. This version does not have the Median property, the documentation shows it. WTF?????
                double minimumMDN = this.runningStats.Minimum;
                double maximumMDN = this.runningStats.Maximum;
                double meanMDN = this.runningStats.Mean;
                double skewnessMMDN = this.runningStats.Skewness;
                double countMDN = this.runningStats.Count;
                double standardDeviationMDN = this.runningStats.StandardDeviation;
                double minusOneSigmaMDN = meanMDN - standardDeviationMDN;

                // Ignore the Math.Net lib results and keep using what we had.
                return this.minusOneSigma; 
            }
        }

        public HistogramBucket(int lowestBucket, int numberOfBuckets, int bucketWidth)
        {
            runningStats = new RunningStatistics();

            this.lowestBucket = lowestBucket;
            this.numberOfBuckets = numberOfBuckets;
            this.min = 0;
            this.max = 0;
            this.mean = 0;
            this.median = 0;
            this.data = new List<decimal>();
            this.buckets = new List<IntegerBucket>();
            this.bucketWidth = bucketWidth;
            int i1 = this.lowestBucket;

            if (this.bucketWidth == 1)
            {
                for (int i = 0; i < this.numberOfBuckets; i++)
                {

                    int i2 = i1 + this.bucketWidth - 1;
                    IntegerBucket newBucket = new IntegerBucket(i1.ToString(), i1, i1);
                    this.buckets.Add(newBucket);
                    i1 = i1 + this.bucketWidth;
                }

            }
            else if (this.bucketWidth == 2)
            {
                // bucket labels = { "73-74", "75-76", "77-78", "79-80", "81-82", "83-84", "85-86", "87-88", "89-90", "91-92", "93-94", "95-96", "97-98", "99-100", "101-102" };
                for (int i = 0; i < this.numberOfBuckets; i++)
                {
                    int i2 = i1 + 1;
                    IntegerBucket newBucket = new IntegerBucket(i1.ToString() + "-" + i2.ToString(), i1, i2);
                    this.buckets.Add(newBucket);
                    i1 = i1 + this.bucketWidth;
                }
            }
            else
            {
                // TODO throw exception or something.
            }

        }

        public void AddElement(decimal value)
        {
            //if (value > _max) {  _max = value; }
            //if (value < _min) { _min = value; }
            this.data.Add(value);

            runningStats.Push((double)value);
            AddDataPointToBucket(value);

            this.data.Sort();
            decimal sum = 0;
            foreach (decimal member in this.data)
            {
                sum += member;
            }
            if (this.data.Count > 0)
            {
                this.mean = Math.Truncate(sum / this.data.Count);
            }
            this.min = this.data.Min();
            this.max = this.data.Max();

            int remainder;

            int middleIndex = Math.DivRem(this.data.Count(), 2, out remainder);
            if (remainder == 0)
            {
                this.median = this.data.ToArray()[middleIndex];
            }
            else
            {
                if (this.data.Count > 1)
                {
                    this.median = this.data.ToArray()[middleIndex + 1];
                }
                else
                {
                    this.median = this.data.ToArray()[middleIndex];
                }

            }
            this.minusOneSigma = this.data.ToArray()[(int)(this.data.Count() * .16)];
        }

        void AddDataPointToBucket(decimal datapoint)
        {

            foreach (IntegerBucket bucket in this.buckets)
            {
                if (datapoint >= bucket.LowerBoundary && datapoint <= bucket.UpperBoundary)
                {
                    bucket.Count++;
                    break;
                }
            }
        }
        public class IntegerBucket
        {
            public string DisplayLabel { get; set; }
            public int LowerBoundary { get; set; }
            public int UpperBoundary { get; set; }
            public int Count { get; set; }

            public IntegerBucket(string displayLabel, int lowerBoundary, int upperBoundary)
            {
                this.DisplayLabel = displayLabel;
                this.LowerBoundary = lowerBoundary;
                this.UpperBoundary = upperBoundary;
            }
        }


    }
}
