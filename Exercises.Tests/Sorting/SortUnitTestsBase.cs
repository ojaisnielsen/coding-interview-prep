using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Exercises.Sorting;
using Exercises.Sorting.Model;

namespace Exercises.Tests.Sorting
{
    [TestClass]
    public abstract class SortUnitTestsBase<TValue> 
        where TValue: IComparable<TValue>
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
            var testDataList = new Stack<TValue>(testData);
            sort.Sort(testData);
            var sortedDataList = new List<TValue>(testData);

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

        protected abstract ISort<TValue> CreateSort();
        protected abstract TValue[] GenerateData();  
    }
}
