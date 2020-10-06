using System;
using Sort.Controllers;
using Sort.Repositories;

namespace Sort
{
    class Program
    {
        private static SortController _sortController = new SortController();
        
        static void Main(string[] args)
        {
            _sortController.SetGeneratorSettings(new NumberGeneratorRepository(-100, 100, 1));
            var numbers = _sortController.GenerateAndSortNumbers(50);

            foreach (var el in numbers )
                Console.Write(el + " ");           
        }
    }
}
