using System.Collections;
using System.Collections.Generic;

namespace Memo.Core
{
    public class Option<T> : IEnumerable<T>
    {
        private readonly T[] _data;

        private Option(T[] data)
        {
            _data = data;
        }

        public static Option<T> Create(T element)
        {
            return new Option<T>(new T[]{element});
        }
        
        public static Option<T> CreateEmpty()
        {
            return new Option<T>(new T[0]);
        }
        
        public Option(T element) : this(new []{element})
        {
            
        }

        public Option() : this(new T[0])
        {
            
        }

        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>) _data).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}