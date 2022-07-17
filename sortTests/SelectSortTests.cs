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
    public class SelectSortTests
    {
        [TestMethod()]
        public void SortTest()
        {
            SelectSort<int> selectSort = new SelectSort<int>(10);
            selectSort.collection = new int[] { 6, 1, 7, 11, 76, 12, 52, 73, -1, 0 };
            selectSort.Sort();
        }
    }
}