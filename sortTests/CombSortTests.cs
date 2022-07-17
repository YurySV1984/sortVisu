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
    public class CombSortTests
    {
        [TestMethod()]
        public void SortTest()
        {
            CombSort<int> combSort = new CombSort<int>(10);
            combSort.collection = new int[]{ 6,1,7,11,76,12,52,73,-1,0};
            combSort.Sort();
            Assert.Fail();
        }
    }
}