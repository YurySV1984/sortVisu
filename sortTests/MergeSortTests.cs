using Microsoft.VisualStudio.TestTools.UnitTesting;
using sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort.Tests
{
    [TestClass()]
    public class MergeSortTests
    {


        [TestMethod()]
        public void SortTest()
        {
            //arrange
            MergeSort<int> mergeSort = new MergeSort<int>(10);
            mergeSort.collection = new int[] { 6, 1, 7, 11, 76, 12, 52, 73, -1, 0 };
            //act
            mergeSort.Sort();
            //assert
            Assert.AreEqual(mergeSort.collection, new int[] { -1, 0, 1, 6, 7, 11, 12, 52, 73, 76});
        }
    }
}