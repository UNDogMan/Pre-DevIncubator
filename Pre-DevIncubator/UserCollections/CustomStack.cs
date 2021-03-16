using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_DevIncubator.UserCollections
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private class Element<T>
        {
            public T item;
            public Element<T> previous;
        }

        public int Count { get; private set; }

        private Element<T> head;

        public CustomStack()
        {
            head = null;
            Count = 0;
        }

        public CustomStack(IEnumerable<T> elements) : this()
        {
            foreach(T element in elements)
                Push(element);
        }

        public void Push(T item)
        {
            head = new Element<T> { item = item, previous = head };
            ++Count;
        }

        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            T item = head.item;
            head = head.previous;
            --Count;
            return item;
        }

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            return head.item;
        }

        public void Clear()
        {
            while (Count > 0)
                Pop();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Element<T> element = head;
            while (element != null)
            {
                yield return element.item;
                element = element.previous;
            }
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
