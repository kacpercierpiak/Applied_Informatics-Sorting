using System;
using System.Collections.Generic;
using System.Text;

namespace Sort.Services
{
    class SortService
    {
        public short[] OriginalArray { get; private set; } = new short[0];
        private short[] SortedArray { get; set; } = new short[0];

        private void SortArray()
        {
            SortedArray=(short[])OriginalArray.Clone();
            var count = 0;
            for (int p = 0; p < SortedArray.Length; p++)
            {
                var min_value = SortedArray[p];
                var min_pos = p;
                for (int e = p + 1; e < SortedArray.Length; e++)
                {
                    count++;
                    if (SortedArray[e] < min_value)
                    {
                        min_value = SortedArray[e];
                        min_pos = e;
                    }
                }

                SortedArray[min_pos] = SortedArray[p];
                SortedArray[p] = min_value;

            }
        }
        public short[] SortArray(short[] NumberArray)
        {
            if(NumberArray.Length>1)
            {
                OriginalArray = (short[])NumberArray.Clone();
                SortArray();
                return SortedArray;
            }
            else
                throw new System.ArgumentException("Array lenght must be greater than 1", "NumberArray");
        }

    }
}
