using System;
using Sort.Models;

namespace Sort.Repositories
{
    public class NumberGeneratorRepository
    {
        public NumberRangeModel NumberRange { get; set; } = new NumberRangeModel();

        public NumberGeneratorRepository() {}

        public NumberGeneratorRepository(short minValue, short maxValue, byte step)
        {
            NumberRange = new NumberRangeModel(minValue, maxValue, step);
        }
        
        private short[] GetNumberArray()
        {                  
            var result = new short[NumberRange.NumberQty];          
            for (ushort i = 0; i < NumberRange.NumberQty; i++)
            {                
                result[i] = (short)(NumberRange.MinValue + (i * NumberRange.Step));
            }                
            return result;
        }

        private short[] GenerateNumberWithDuplicates(ushort numberQty)
        {
            var result = new short[numberQty];
            Random generator = new Random();
            for (int i=0; i < numberQty; i++)
                result[i] = (short)generator.Next(NumberRange.MinValue, NumberRange.MaxValue);
            return result;
        }

        private short[] GenerateNumberWithoutDuplicates(ushort numberQty)
        {
            var result = new short[numberQty];
            Random generator = new Random();
            var tempNumbersArray = GetNumberArray();
            for (int i = 0; i < numberQty; i++)
            {
                var position = generator.Next(tempNumbersArray.Length-(1+i));
                result[i] = tempNumbersArray[position];
                tempNumbersArray[position] = tempNumbersArray[^(1 + i)];                       
            }

            return result;
        }

        public short[] GetNumber(ushort numberQty, bool withDuplicates = false)
        {
            if (withDuplicates)
                return GenerateNumberWithDuplicates(numberQty);
            else
                if(numberQty <= NumberRange.NumberQty)
                    return GenerateNumberWithoutDuplicates(numberQty);
                else
                    throw new System.ArgumentException("Parameter cannot be less then range number qty", "numberQty");
        }


    }
}
