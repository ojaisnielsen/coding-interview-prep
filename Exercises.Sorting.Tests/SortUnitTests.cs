using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Exercises.Sorting.Tests
{
    [TestClass]
    public abstract class SortUnitTests<TSort, T> where TSort : ISort<T> where T: IComparable<T>
    {
        [TestMethod]
        public void Sort_OnNonEmptyArray_ArraySorted()
        {
            var sort = this.CreateSort();
            var testData = this.GenerateData();        
            sort.Sort(testData);
                
            Assert.IsTrue(testData.Select((e, i) => i == 0 || e.CompareTo(testData[i - 1]) >= 0).All(x => x));
        }

        [TestMethod]
        public void Sort_OnNonEmptyArray_ArrayContainsSameElements()
        {
            var sort = this.CreateSort();
            var testData = this.GenerateData();
            var testDataList = new Stack<T>(testData);
            sort.Sort(testData);
            var sortedDataList = new List<T>(testData);

            while (testDataList.Any())
            {
                var element = testDataList.Pop();
                Assert.IsTrue(sortedDataList.Remove(element));
            }

            Assert.IsTrue(!sortedDataList.Any());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Sort_OnNullArray_ThrowsArgumentNullException()
        {
            var sort = this.CreateSort();
            sort.Sort(null);            
        }

        protected abstract ISort<T> CreateSort();
        protected abstract T[] GenerateData();  
    }
}
