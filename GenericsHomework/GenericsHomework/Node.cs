using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsHomework
{
    public class Node<TValue>
    {
        public TValue Value { get; set; }
        public Node<TValue> Next { get; private set; }

        public Node<TValue>? Head = null;
        public Node<TValue>? Tail = null;

        public Node(TValue value)
        {
            Value = value;
            Next = this;
        }
        public void Append(TValue value)
        {
            if(Head is null || Tail is null)
            {
                Head = this;
                Tail = this;
            }
            Node<TValue> newNode = new Node<TValue>(value);
            Tail.Next = newNode;
            Tail = newNode;
            Tail.Next = Head;
        }

        public override string? ToString()
        {
            if(Value is null)
            {
                throw new ArgumentNullException(nameof(Value));
            }
            return Value.ToString();
        }
    }
}
