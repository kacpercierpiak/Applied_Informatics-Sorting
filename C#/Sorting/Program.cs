using System;

namespace Sort
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var numbers = new int[] { 6,5,4,8,51,82,8,5,4,7,8,4,8,4,8,4,7,4,8,54,8,3,2,1,54,5,6,9,8,7,4,5,6,55,5,5,5,5,5,4,8 };
            var count = 0;
            for (int p = 0; p < numbers.Length; p++)
            {
                var min_value = numbers[p];
                var min_pos = p;
                for (int e = p+1; e < numbers.Length; e++)
                {
                    count++;
                    if (numbers[e] < min_value)
                    {
                        min_value = numbers[e];
                        min_pos = e;
                    }
                }

                numbers[min_pos] = numbers[p];
                numbers[p] = min_value;

            }

            foreach(var el in numbers )
                Console.WriteLine(el);
            Console.WriteLine("Hello World!");
        }
    }
}
