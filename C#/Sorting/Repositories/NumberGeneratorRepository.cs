using Sort.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sort.Repositories
{
    public class NumberGeneratorRepository
    {
        public NumberRangeModel numberRange { get; set; }
        public NumberGeneratorRepository() {
            numberRange = new NumberRangeModel();
        }
        public NumberGeneratorRepository(short minValue, short maxValue, byte step)
        {
            numberRange = new NumberRangeModel(minValue, maxValue, step);
        }
        
        private short[] GetNumberArray()
        {                  
            var result = new short[numberRange.numberQty];          
            for (ushort i = 0; i < numberRange.numberQty; i++)
            {                
                result[i] = (short)(numberRange.minValue + (i * numberRange.step));
            }                
            return result;
        }

        private short[] GenerateNumberWithDuplicates(ushort numberQty)
        {
            var result = new short[numberQty];
            Random generator = new Random();
            for (int i=0; i < numberQty; i++)
                result[i] = (short)generator.Next(numberRange.minValue, numberRange.maxValue);
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
                tempNumbersArray[position] = tempNumbersArray[tempNumbersArray.Length - (1 + i)];                       
            }

            return result;
        }

        public short[] GetNumber(ushort numberQty, bool withDuplicates = false)
        {
            if (withDuplicates)
                return GenerateNumberWithDuplicates(numberQty);
            else
                if(numberQty <= numberRange.numberQty)
                    return GenerateNumberWithoutDuplicates(numberQty);
                else
                    throw new System.ArgumentException("Parameter cannot be less then range number qty", "numberQty");
        }


    }
}
