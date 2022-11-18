using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.CustomCollections
{
    public abstract class AbstractCollection<T> : IEnumerable<T> where T : class
    {
        public int Length { get; protected set; } = 0;
        public AbstractCollection() 
        {
            _arr = new T[_capacity];
        }
        public abstract T Peek();
        public void Clear() => _arr = new T[0];
        public bool Contains(T item) => _arr.Contains(item);
        public abstract IEnumerator<T> GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        protected int _capacity = 2;

        protected T[] _arr;
    }
}
