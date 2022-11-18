using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.CustomCollections
{
    public sealed class Stack<T> : AbstractCollection<T> where T : class
    {
        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = Length - 1; i >= 0; ++i)
            {
                yield return _arr[i];
            }
        }
        public override T Peek()
        {
            if (Length == 0)
                throw new IndexOutOfRangeException("there is nothing to peek");

            return _arr[Length];
        }
        public T Pop()
        {
            if (Length-- == 0)
                throw new IndexOutOfRangeException("there is nothing to pop");

            T temp = _arr[Length];
            _arr[Length] = null;
            return temp;
        }
        public void Push(T item)
        {
            if (++Length == _capacity)
                _resize();
            _arr[Length - 1] = item;
        }
        private void _resize()
        {
            T[] tempArr = new T[_capacity * 2];
            for (int i = 0; i < _capacity; ++i)
                tempArr[i] = _arr[i];

            _arr = tempArr;
            _capacity *= 2;
        }
    }
}
