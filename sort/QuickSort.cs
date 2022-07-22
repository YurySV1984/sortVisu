using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort
{
    public class QuickSort<T> : BaseClass<T> where T : IComparable<T>
    {
        public QuickSort(int n) : base(n) { }

        public event EventHandler<int> OnSwop;
        public event EventHandler OnFinish;

        public override void Sort()
        {
            if (collection.Length <= 1 || collection == null)
            {
                return;
            }
            QSort(collection, 0, collection.Length - 1);
            OnFinish?.Invoke(this, EventArgs.Empty);
        }

        private void QSort(T[] collection, int left, int right)
        {
            if (left >= right)
            {
                return;
            }
            var bearing = collection[right];
            var indexToChange = left;
            for (int i = left; i < right; i++)
            {
                if (collection[i].CompareTo(bearing) <= 0)
                {
                    Swop(i, indexToChange);
                    OnSwop?.Invoke(this, i);
                    indexToChange++;
                }
            }
            Swop(right, indexToChange);
            OnSwop?.Invoke(this, right);
            QSort(collection, left, indexToChange - 1);
            QSort(collection, indexToChange + 1, right);
        }
    }
}