using System;
using Xunit;
using Sort.Repositories;
using Sort.Models;
using System.Linq;
using System.Collections.Generic;

namespace SortTest.RepositoriesTest
{

    public class NumberGeneratorRepositoryModelsTest
    {
        public static TheoryData<short, short, byte, ushort, bool> NumberRangeModelContructorData =>
            new TheoryData<short, short, byte, ushort, bool>
                {                    
                    { 0, 10, 1, 10, true },
                    { 10, 16, 2, 6, false }             
                };
        public static TheoryData<short, short, byte> NumberRangeModelValidationData =>
            new TheoryData<short, short, byte>
                {
                    { 10, 5, 1},
                    { 5, 10, 0},
                    { 5, 10, 2}
                };

        [Theory]
        [MemberData(nameof(NumberRangeModelContructorData))]
        public void NumberRangeModelContructorTest(short minValue, short maxValue, byte step, ushort expectedQty, bool isEmptyConstructor)
        {
            var numberRange = new NumberRangeModel();
            if (!isEmptyConstructor)
                numberRange = new NumberRangeModel(minValue, maxValue, step);
            Assert.Equal(minValue, numberRange.MinValue);
            Assert.Equal(maxValue, numberRange.MaxValue);
            Assert.Equal(step, numberRange.Step);       
            Assert.Equal(expectedQty, numberRange.NumberQty);           
        }
        [Theory]
        [MemberData(nameof(NumberRangeModelContructorData))]
        public void NumberGeneratorRepositoryConstructorTest(short minValue, short maxValue, byte step, ushort expectedQty, bool isEmptyConstructor)
        {
            var numberGenerator = new NumberGeneratorRepository();
            if (!isEmptyConstructor)
                numberGenerator = new NumberGeneratorRepository(minValue, maxValue, step);
            Assert.Equal(minValue, numberGenerator.NumberRange.MinValue);
            Assert.Equal(maxValue, numberGenerator.NumberRange.MaxValue);
            Assert.Equal(step, numberGenerator.NumberRange.Step);
            Assert.Equal(expectedQty, numberGenerator.NumberRange.NumberQty);
        }

        [Theory]
        [MemberData(nameof(NumberRangeModelValidationData))]
        public void NumberRangeModelValidationTest(short minValue, short maxValue, byte step)
        {
            Assert.Throws<ArgumentException>(() => new NumberRangeModel(minValue, maxValue, step));
        }
    }
    public class NumberGeneratorRepositoryTest
    {
        public static TheoryData<short, short, byte, ushort, bool, bool> NumberGeneratorRepositoryData =>
            new TheoryData<short, short, byte, ushort, bool, bool>
            {
                { 1, 10, 1, 10, true,false },
                 { 1, 1, 1, 1, false,false },
                { short.MinValue, short.MaxValue, 1, ushort.MaxValue-1, false, false },
                { short.MinValue, short.MaxValue, 1, ushort.MaxValue-1, false, true },
               
            };

        [Theory]
        [MemberData(nameof(NumberGeneratorRepositoryData))]
        public void GenerateNumberTest(short minValue, short maxValue, byte step, ushort expectedQty, bool isEmptyConstructor, bool withDuplicates)
        {
            var numberGenerator = new NumberGeneratorRepository();
            if (!isEmptyConstructor)
                numberGenerator = new NumberGeneratorRepository(minValue, maxValue, step);

            var result = numberGenerator.GetNumber(expectedQty, withDuplicates);
            var temp = result.GroupBy(x => x).Where(g => g.Count() > 1);
            if (!withDuplicates)
                Assert.True(result.Distinct().Count() == result.Length, "Array should not contain duplicates");
            
            Assert.Equal(expectedQty, (uint)result.Length);
         }

    }
}
