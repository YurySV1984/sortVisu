using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort
{
    public class BubbleSort<T> : BaseClass<T> where T : IComparable<T>
    {
        public BubbleSort(int n) : base(n) { }

        public event EventHandler<int> OnSwop;
        public event EventHandler OnFinish;        

        public override void Sort()
        {
            for (int j = 0; j < collection.Length; j++)
            {
                for (int i = 0; i < collection.Length - j - 1; i++)
                {
                    
                    if (collection[i].CompareTo(collection[i + 1]) > 0)
                    {
                        Swop(i, i + 1);      
                    }
                    OnSwop?.Invoke(this, i);
                }
            }
            OnFinish?.Invoke(this, EventArgs.Empty);
        }

    }
}
