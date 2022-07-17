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
            if (left >= right) return;
            
            var middle = collection[right];
            var lessIndex = left;
            for (int i = left; i < right; i++)
            {
                if (collection[i].CompareTo(middle) <= 0)
                {
                    OnSwop?.Invoke(this, i);
                    Swop(i, lessIndex);
                    lessIndex++;
                }
            }
            Swop(lessIndex, right);
            var root = lessIndex;

            //int root = Part(collection, left, right);            
            QSort(collection, left, root - 1);
            QSort(collection, root + 1, right);
        }

        private int Part(T[] collection, int left, int right)
        {
            var middle = collection[right];
            var lessIndex = left;
            for (int i = left; i < right; i++)
            {
                if (collection[i].CompareTo(middle) <= 0)
                {
                    OnSwop?.Invoke(this, i);
                    Swop(i, lessIndex);
                    lessIndex++;
                }
            }
            Swop(lessIndex, right);
            return lessIndex;
        }
    }
}
