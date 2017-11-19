using System;
using System.Collections;
using System.Collections.Generic;

namespace Zad2
{
    public class GenericList<T> : IGenericList<T>
    {
        private T[] _internalStorage;
        private int _count = -1;

        public int Count
        {
            get
            {
                return _count + 1;
            }
        }

        public GenericList()
        {
            _internalStorage = new T[4];
        }

        public GenericList(int initialSize)
        {
            if (initialSize < 0)
            {
                initialSize = Math.Abs(initialSize);
            }
            _internalStorage = new T[initialSize];
        }

        #region IGenericList

        public void Add(T item)
        {
            _count++;
            if (_count >= _internalStorage.Length)
            {
                Array.Resize(ref _internalStorage, _internalStorage.Length * 2);
            }
            _internalStorage[_count] = item;
        }

        public void Clear()
        {
            _count = -1;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i <= _count; i++)
            {
                if (_internalStorage[i].Equals(item))
                    return true;
            }
            return false;
        }

        public T GetElement(int index)
        {
            if (index <= _count)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i <= _count; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return (RemoveAt(i));
                }
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index > _count)
            {
                throw new IndexOutOfRangeException();
            }
            _count--;
            for (int i = index; i <= _count; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            return true;
        }
        #endregion IGenericList

        public IEnumerator<T> GetEnumerator()
        {
            return new GenericListEnumerator<T> (this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
