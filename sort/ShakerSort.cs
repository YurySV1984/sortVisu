using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort
{
    public class ShakerSort<T> : BaseClass<T> where T : IComparable<T>
    {
        public ShakerSort(int n) : base(n) { }

        public event EventHandler<int> OnSwop;
        public event EventHandler OnFinish;
        
        public override void Sort()
        {
            var direction = true;
            var start = 0;
            var end = collection.Length - 1;
            while (start != end)
            {
                switch (direction)
                {
                    case true:
                        for (int j = start; j < end; j++)
                        {
                            
                            if (collection[j].CompareTo(collection[j + 1]) > 0)
                            {
                                Swop(j, j + 1);
                                OnSwop?.Invoke(this, j);
                            }
                        }
                        direction = false;
                        end--;

                        break;
                    case false:
                        for (int j = end; j > start; j--)
                        {
                            
                            if (collection[j].CompareTo(collection[j - 1]) < 0)
                            {
                                Swop(j, j - 1);
                                OnSwop?.Invoke(this, j);
                            }
                        }
                        direction = true;
                        start++;
                        break;
                }
            }
            OnFinish?.Invoke(this, EventArgs.Empty);
        }



    }
}

