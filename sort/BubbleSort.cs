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
            for (int i = 0; i < collection.Length; i++)
            {
                for (int j = 0; j < collection.Length - i - 1; j++)
                {
                    
                    if (collection[j].CompareTo(collection[j + 1]) > 0)
                    {
                        Swop(j, j + 1);      
                    }
                    OnSwop?.Invoke(this, j);
                }
            }
            OnFinish?.Invoke(this, EventArgs.Empty);
        }

    }
}
