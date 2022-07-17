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
    public class QuickSortTests
    {
        [TestMethod()]
        public void QuickSortTest()
        {
            QuickSort<int> quickSort = new QuickSort<int>(10);
            quickSort.collection = new int[] { 6, 1, 7, 11, 76, 12, 52, 73, -1, 0 };
            quickSort.Sort();
        }
    }
}