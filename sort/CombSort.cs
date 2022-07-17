using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort
{
    public class CombSort<T> : BaseClass<T> where T : IComparable<T>
    {
        public CombSort(int n) : base(n) { }

        public event EventHandler<int> OnSwop;
        public event EventHandler OnFinish;

        public override void Sort()
        {
            bool sorted;
            float factor = 1.247F;
            int delta;
            do
            {
                sorted = true;
                delta = Convert.ToInt32(collection.Length / factor);
                for (int j = 0; j + delta < collection.Length; j++)
                {
                    OnSwop?.Invoke(this, j);

                    if (collection[j].CompareTo(collection[j + delta]) > 0)
                    {
                        Swop(j, j + delta);
                        sorted = false;
                    }
                }
                factor *= 1.247F;
            }
            while (!sorted || delta != 1);
            OnFinish?.Invoke(this, EventArgs.Empty);
        }
    }
}
