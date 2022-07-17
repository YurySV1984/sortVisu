using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort
{
    public class InsertSort<T> : BaseClass<T> where T : IComparable<T>
    {
        public InsertSort(int n): base(n) { }

        public event EventHandler<int> OnSwop;
        public event EventHandler OnFinish;

        public override void Sort()
        {
            for (int i = 1; i < collection.Length; i++)
            {
                var j = i;
                while (j >= 1 && collection[j - 1].CompareTo(collection[j]) > 0)
                {
                    OnSwop?.Invoke(this, j);
                    Swop(j, j - 1);
                    j--;
                }
            }
        OnFinish?.Invoke(this, EventArgs.Empty);
        }

        public void ShellSort()
        {
            int delta = collection.Length / 2;
            while (delta > 0)
            {
                for (int i = 1; i < collection.Length; i++)
                {
                    var j = i;
                    while (j >= delta && collection[j - delta].CompareTo(collection[j]) > 0)
                    {
                        Swop(j, j - delta);
                        OnSwop?.Invoke(this, j);
                        j -= delta;
                    }
                }
                delta /= 2;
            }             
            OnFinish?.Invoke(this, EventArgs.Empty);
        }
    }
}
