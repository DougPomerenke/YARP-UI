namespace StatisticalTools
{
    public class HistogramBucket
    {


        protected int numberOfBuckets;
        protected List<decimal> data;
        protected decimal min;
        protected decimal max;
        protected decimal mean;  // average
        protected decimal median;
        protected decimal minusOneSigma;    // 84% above this value

        public int NumberOfElements { get { return data.Count(); } }
        public int NumberOfBuckets {  get { return this.numberOfBuckets; } }
        public decimal Min { get { return this.min; } }
        public decimal Max { get { return this.max; } }
        public decimal Mean { get { return this.mean; } }
        public decimal Median { get { return this.median; } }
        public decimal MinusOneSigma{  get { return this.minusOneSigma; } }

        public HistogramBucket(int numberOfBuckets)
        {
            this.numberOfBuckets = numberOfBuckets;
            this.min = 0 ;
            this.max = 0;
            this.mean = 0;
            this.median = 0;

            this.data = new List<decimal>();
        }

        public void AddElement(decimal value)
        {
            //if (value > _max) {  _max = value; }
            //if (value < _min) { _min = value; }
            this.data.Add(value);

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
            if(remainder ==0)
            {
                this.median = this.data.ToArray()[middleIndex];
            }
            else
            {
                if(this.data.Count>1)
                {
                    this.median = this.data.ToArray()[middleIndex + 1];
                }
                else
                {
                    this.median = this.data.ToArray()[middleIndex];
                }

            }
            this.minusOneSigma = this.data.ToArray()[(int)(this.data.Count()*.16)];
        }





    }
}
