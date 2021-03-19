using Pre_DevIncubator.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_DevIncubator.UserCollections
{
    public class CustomQueue<T> : IEnumerable<T>
    {
        private class Element<T>
        {
            public T item;
            public Element<T> next;
        }

        public int Count { get; private set; }

        private Element<T> head;
        private Element<T> tail;

        public CustomQueue()
        {
            Count = 0;
            this.head = null;
            this.tail = null;
        }

        public CustomQueue(IEnumerable<T> elements) : this()
        {
            foreach (T element in elements)
                Enqueue(element);
        }

        public void Enqueue(T item)
        {
            Element<T> element = new Element<T> { item = item, next = null };
            if (tail != null)
                tail.next = element;
            tail = element;
            if (head == null)
                head = tail;
            ++Count;
        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            T item = head.item;
            head = head.next;
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
                Dequeue();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Element<T> element = head;
            while(element != null)
            {
                yield return element.item;
                element = element.next;
            }
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
