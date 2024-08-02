using System.Collections;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using DataStructures;

namespace DataStructures {
    

    public class LinkedArrayList<T> : ICollection<T>
    {
        internal ArrayNode<T> head;

        public int Count => 10;
        public bool IsReadOnly => throw new NotImplementedException();

        public LinkedArrayList()
        {
            head = new ArrayNode<T>();
        }

        public void Add(T item) => head.Add(item);

        public void Clear() => head = new ArrayNode<T>();

        public bool Contains(T item)
            => head.Contains(item);

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
           return new ArrayLinkedListEnumerator<T>(head);
        }

        public bool Remove(T item) => head.Remove(item);

        IEnumerator IEnumerable.GetEnumerator() 
            => GetEnumerator();




        public class ArrayNode<T> {
            const int maxSize = 32;
            private int size = 0;
            public ArrayNode<T>? Next { get; private set; }

            public T[] DataArray = new T[maxSize];

            public int Count() => size;

            public void Add(T value) {
                if (size == maxSize ) {
                    Next ??= new ArrayNode<T>();
                    
                    if (Next != null)
                        Next.Add(value);

                    return;
                }

                DataArray[size++] = value;
            }

            public bool Contains(T value) {
                if (DataArray.Contains(value)) {
                    return true;
                }

                return Next != null ? Next.Contains(value) : false;
            }
            
            public bool Remove(T value) {
                for (int i = 0; i < DataArray.Length; i++) {
                    if (DataArray[i]?.Equals(value) ?? false) {
                        for (int  j = i; j < DataArray.Length-1; j++) {
                            DataArray[j] = DataArray[j+1];
                        }
                        
                        return true;
                    }
                }

                return Next?.Remove(value) ?? false;
            }

            public bool HasNext(int index) {
                return index+1 < Count();
            }

        }


        public class ArrayLinkedListEnumerator<T> : IEnumerator<T>
        {
            private ArrayNode<T> startingElement;
            private ArrayNode<T> currentNode;
            int currentIndex = -1;
            public T Current => currentNode.DataArray[currentIndex] ?? throw new IndexOutOfRangeException();

            object IEnumerator.Current => Current;

            public void Dispose() {}

            public bool MoveNext()
            {
                if (currentNode.HasNext(currentIndex)) {
                    currentIndex++;
                    return true;
                }

                while (currentNode.Next != null) {
                    currentNode = currentNode.Next;
                    currentIndex = -1;

                    if (currentNode.HasNext(currentIndex)) {
                        currentIndex++;
                        return true;
                    }
                }

                return false;
            }

            public void Reset()
            {
                currentNode = startingElement;
                currentIndex = -1;
            }

            public ArrayLinkedListEnumerator(ArrayNode<T> head)
            {
                this.currentNode = head;
                this.startingElement = head;
            }
        }
    }

}

