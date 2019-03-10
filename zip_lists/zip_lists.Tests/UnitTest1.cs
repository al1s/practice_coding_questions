using System;
using Xunit;
using zip_lists.App;
using System.Collections.Generic;

namespace zip_lists.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void givenListsWithOneElementOfInt_returnsZippedList()
        {
            // arange
            List<List<int>> inputList = new List<List<int>>()
            {
                new List<int>(new int[] { 1 }),
                new List<int>(new int[] { 9 })
            };
            List<int> expectedResult = new List<int>(new int[] { 1, 9 });

            // act
            var result = Zipper<int>.Zip_lists(inputList);

            // assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void givenListsWithEqualNumberOfInt_returnsZippedList()
        {
            // arange
            List<List<int>> inputList = new List<List<int>>()
            {
                new List<int>(new int[] { 1, 2, 3, 4, 5 }),
                new List<int>(new int[] { 9, 8, 7, 6, 5 })
            };
            List<int> expectedResult = new List<int>(new int[] { 1, 9, 2, 8, 3, 7, 4, 6, 5, 5 });

            // act
            var result = Zipper<int>.Zip_lists(inputList);

            // assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void givenListsWithNonEqualNumberOfInt_returnsZippedList()
        {
            // arange
            List<List<int>> inputList = new List<List<int>>()
            {
                new List<int>(new int[] { 1, 2, 3, 4, 5 }),
                new List<int>(new int[] { 9 })
            };
            List<int> expectedResult = new List<int>(new int[] { 1, 9, 2, 3, 4, 5 });

            // act
            var result = Zipper<int>.Zip_lists(inputList);

            // assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void given3ListsWithNonEqualNumberOfInt_returnsZippedList()
        {
            // arange
            List<List<int>> inputList = new List<List<int>>()
            {
                new List<int>(new int[] { 1, 2, 3, 4, 5 }),
                new List<int>(new int[] { 9 }),
                new List<int>(new int[] { 100, 200, 300, 400 })
            };
            List<int> expectedResult = new List<int>(new int[] { 1, 9, 100, 2, 200, 3, 300, 4, 400, 5 });

            // act
            var result = Zipper<int>.Zip_lists(inputList);

            // assert
            Assert.Equal(expectedResult, result);
        }
    }
}
