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
    public class TreeSortTests
    {
        [TestMethod()]
        public void SortTest()
        {
            //arrange
            TreeSort<int> treeSort = new TreeSort<int>(10);
            treeSort.collection = new int[] { 6, 1, 7, 11, 76, 12, 52, 73, -1, 0 };
            var expected = new int[] { -1, 0, 1, 6, 7, 11, 12, 52, 73, 76 };
            //act
            treeSort.Sort();
            var act = treeSort.collection;
            //assert
            Assert.AreEqual(expected, act);
        }
    }
}