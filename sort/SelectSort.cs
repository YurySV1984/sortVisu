using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort
{
    public class SelectSort<T> : BaseClass<T> where T: IComparable<T>
    {
        public SelectSort(int n) : base(n) { }

        public event EventHandler<int> OnSwop;
        public event EventHandler OnFinish;

        public override void Sort()
        {
            var count = collection.Length - 1;
            for (int i = 0; i < collection.Length; i++)
            {
                var max = collection[0];
                var maxIndex = 0;
                
                for (int j = 0; j <= count; j++)
                {
                    if (collection[j].CompareTo(max) > 0)
                    {
                        max = collection[j];
                        maxIndex = j;
                    }
                }
                OnSwop?.Invoke(this, maxIndex);
                Swop(count, maxIndex);
                count--;
            }
            OnFinish?.Invoke(this, EventArgs.Empty);
        }
    }
}
