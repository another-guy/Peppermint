namespace System
{
    public struct Range
    {
        public Range(int from, int to, int step)
        {
            if (step == 0)
            {
                step = from <= to ? 1 : -1;
            }
            else if (step > 0)
            {
                if (from > to) throw new InvalidOperationException($"To ({to}) must be greater or equal to From ({from}) for step={step}");
            }
            else
            {
                if (from < to) throw new InvalidOperationException($"From ({from}) must be greater or equal to To ({to}) for step={step}");
            }

            this.from = from;
            this.to = to;
            this.step = step;
        }

        public int from;
        public int to;
        public int step;
    }
}
