using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort
{
    public class BaseClass<T> where T : IComparable<T>
    {
        public T[] collection { get; set; }
        public int SwopDelay { get; set; } = 200;

        public BaseClass(int n)
        {
            collection = new T[n];
        }
        
        public virtual void Sort()
        {
            Array.Sort(collection);            
        }
        public void Swop(int posEl1, int posEl2)
        {
            if (posEl1 == posEl2)
            {
                return;
            }
            if (posEl1 < collection.Length && posEl2 < collection.Length)
            {
                (collection[posEl1], collection[posEl2]) = (collection[posEl2], collection[posEl1]);
            }
            else throw new ArgumentOutOfRangeException("shit happened");
        }
    }
}
