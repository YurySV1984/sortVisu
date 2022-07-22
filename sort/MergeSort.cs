using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort
{
    public class MergeSort<T> : BaseClass<T> where T: IComparable<T>
    {
        public MergeSort(int n) : base(n) { }

        public event EventHandler<int> OnSwop;
        public event EventHandler OnFinish;

        public override void Sort()
        {
            if (collection == null || collection.Length <= 1)
            {
                return;
            }
            var extraArray = new T[collection.Length];
            MSort(collection, extraArray, 0, collection.Length - 1);
            OnFinish?.Invoke(this, EventArgs.Empty);
        }

        private T[] MSort(T[] collection, T[] extraArray, int leftIndex, int rightIndex)
        {
            if (leftIndex >= rightIndex)
            {
                return collection;
            }
            var middleIndex = (leftIndex + rightIndex) / 2;
            MSort(collection, extraArray, leftIndex, middleIndex);
            MSort(collection, extraArray, middleIndex + 1, rightIndex);
            var k = leftIndex;
            for (int i = leftIndex, j = middleIndex + 1; i <= middleIndex || j <= rightIndex; )
            {
                if (j > rightIndex || (i <= middleIndex && collection[i].CompareTo(collection[j]) < 0))
                {
                    OnSwop?.Invoke(this, i);
                    extraArray[k] = collection[i];
                    i++;
                }
                else
                {
                    OnSwop?.Invoke(this, j);
                    extraArray[k] = collection[j];
                    j++;
                }
                k++;
            }
            for (int i = leftIndex; i <= rightIndex; i++)
            {
                collection[i] = extraArray[i];
            }                                                               
            return collection;
        }
    }
}
