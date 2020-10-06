using System;
using System.Collections.Generic;
using System.Text;
using Sort.Repositories;
using Sort.Services;

namespace Sort.Controllers
{
    class SortController
    {
        private NumberGeneratorRepository _numberGeneratorRepository { get; set; }
        public SortController()
        {
            _numberGeneratorRepository = new NumberGeneratorRepository();
        }
        public short[] GenerateAndSortNumbers(short NumberQty)
        {
            var result = new SortService();
            var numbers = _numberGeneratorRepository.GetNumber(15);            
            return result.SortArray(numbers);
        }
        public void SetGeneratorSettings(NumberGeneratorRepository numberGeneratorRepository)
        {
            _numberGeneratorRepository = numberGeneratorRepository;
        }
    }
}
