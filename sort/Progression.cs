using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort
{
    public class Progression : IEnumerable<int>
    {
        private readonly int _count;
        public Progression(int itemCount)
        {
            _count = itemCount;
        }
        public IEnumerator<int> GetEnumerator()
        {
            int cur = 1;
            for (int i = 0; i < _count; i++)
            {
                if (i == 0)
                {
                    yield return 1;
                }
                cur += 3;
                yield return cur;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }        
    }

    public class ProgressionIterator : IEnumerator<int>
    {
        private readonly int _itemCount;
        private int _position;
        private int _current;
        public ProgressionIterator(int count)
        {
            _itemCount = count;
            _position = 0;
            _current = 1;
        }
        public int Current => _current ;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_position > 0)
            {
                _current += 1;
            }
            if (_position < _itemCount)
            {
                _position++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _position = 0;
            _current = 1;
        }
    }

}
