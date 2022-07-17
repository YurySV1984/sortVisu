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
                            OnSwop?.Invoke(this, j);
                            if (collection[j].CompareTo(collection[j + 1]) > 0)
                            {
                                Thread.Sleep(SwopDelay);
                                Swop(j, j + 1);
                            }
                        }
                        direction = false;
                        end--;

                        break;
                    case false:
                        for (int j = end; j > start; j--)
                        {
                            OnSwop?.Invoke(this, j);
                            if (collection[j].CompareTo(collection[j - 1]) < 0)
                            {
                                Thread.Sleep(SwopDelay);
                                Swop(j, j - 1);
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

