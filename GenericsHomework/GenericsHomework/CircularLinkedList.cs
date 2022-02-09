using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsHomework
{
    public class CircularLinkedList<TList>
    {
        public class Node<TNode>
        {
            public TNode Value { get; set; }
            public Node<TNode>? Next { get; private set; } 
            
            public Node(TNode value)
            {
                Value = value;
                Next = this;
            }
        }

        private Node<TList>? Head;
        private Node<TList>? Tail;

        public CircularLinkedList()
        {
            Head = null;
            Tail = null;
        }
        public Boolean isEmpty()
        {
            return Head == null;
        }

        public void Append(TList value)
        {
            Node<TList> newNode = new(value);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Node<TList> temp = Head;
                //newNode.Next = temp;
            }
        }
    }
}
