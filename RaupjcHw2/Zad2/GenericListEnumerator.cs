using System.Collections;
using System.Collections.Generic;


namespace Zad2
{
    public class GenericListEnumerator<T> : IEnumerator<T>
    {

        private GenericList<T> _genericList;

        public int Count { get; private set; }

        public GenericListEnumerator(GenericList<T> genericList)
        {
            this._genericList = genericList;
            Count = 0;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (Count < _genericList.Count)
            {
                Count++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            Count = 0;
        }

        public T Current
        {
            get { return _genericList.GetElement(Count - 1); }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}