using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.CustomCollections
{
    public sealed class Queue<T> : AbstractCollection<T> where T : class
    {
        public override IEnumerator<T> GetEnumerator()
        {
            int index = _tail;
            int counter = Length;
            while (counter != 0)
            {
                yield return _arr[index--];
                --counter;
            }
        }
        public override T Peek()
        {
            if (Length == 0)
                throw new IndexOutOfRangeException("there is nothing to peek");
            return _arr[_tail];
        }

        public T Dequeue()
        {
            if (Length-- == -1)
                throw new IndexOutOfRangeException("there is nothing to pop");

            T temp = _arr[_tail];
            _arr[_tail--] = null;

            return temp;
        }
        public void Enqueue(T item)
        {
            if (--_head <= -1)
                _resize();

            _arr[_head] = item;
            ++Length;
        }
        private void _resize()
        {
            T[] tempArr = new T[_capacity * 2];
            for (int i = 0; i < Length; ++i)
            {
                tempArr[i + _capacity] = _arr[i];
            }

            _head += _capacity;
            _tail += _capacity;
            _arr = tempArr;
            _capacity *= 2;
        }

        private int _tail = 0;
        private int _head = 0;
    }
}
