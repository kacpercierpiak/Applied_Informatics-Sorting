using System;
using System.Collections.Generic;
using System.Text;

namespace Sort.Models
{
    public class NumberRangeModel
    {
        public short maxValue { get; private set; } = 10;
        public short minValue { get; private set; } = 0;
        public byte step { get; private set; } = 1;
        public ushort numberQty 
        { 
            get
            {        
                return (ushort)(maxValue == minValue ? 1 : (ushort)(maxValue - minValue));
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

            this.minValue = minValue;
            this.maxValue = maxValue;            
            this.step = step;
        }
    }
}
