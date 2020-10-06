namespace Sort.Models
{
    public class NumberRangeModel
    {
        public short MaxValue { get; private set; } = 10;
        public short MinValue { get; private set; } = 0;
        public byte Step { get; private set; } = 1;
        public ushort NumberQty 
        { 
            get
            {        
                return (ushort)(MaxValue == MinValue ? 1 : (ushort)(MaxValue - MinValue));
            } 
        }
        public NumberRangeModel() { }
        public NumberRangeModel(short minValue, short maxValue, byte step)
        {
            if (minValue > maxValue)
                throw new System.ArgumentException("Parameter cannot be greaten than maxValue", "minValue");

            if (step <= 0)
                throw new System.ArgumentException("Parameter cannot be equal or less 0", "step");

            if((maxValue - minValue) % step != 0)
                throw new System.ArgumentException("Range is undivided by step ", "step");

            this.MinValue = minValue;
            this.MaxValue = maxValue;            
            this.Step = step;
        }
    }
}
