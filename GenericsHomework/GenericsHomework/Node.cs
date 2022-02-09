namespace GenericsHomework
{
    public class Node<TValue>
    {
        public TValue? Value { get; set; }
        public Node<TValue> Next { get; private set; }

        public Node<TValue>? Head = null;
        public Node<TValue>? Tail = null;
        public Node<TValue>? Root = null;
        public int anint = 10;

        public Node(TValue value)
        {
            Value = value;
            Next = this;
            Root = this;
        }
        public void Append(TValue value)
        {
            if (Head is null || Tail is null)
            {
                Head = this;
                Tail = this;
            }
            bool keyExists = Exists(value);
            if (keyExists == true)
            {
                throw new ArgumentException("Cannot add duplicate value");
            }
            Node<TValue> newNode = new Node<TValue>(value);
            Tail.Next = newNode;
            Tail = newNode;
            Tail.Next = Head;
        }
        public void Clear()
        {
            if (Tail is null)
            {
                throw new NullReferenceException("Empty list");
            }
            Tail.Next = Tail;

        }
        public Boolean Exists(TValue key)
        {
            if (Root is not null && key is not null)
            {
                Node<TValue> currentNode = Root;
                do
                {
                    if (key.Equals(currentNode.Value))
                        return true;
                } while (currentNode.Next != Root);
            }
            return false;
        }


        //if(Head is null)
        //{
        //    return false;
        //}
        //Node<TValue> temp = Head;
        //do
        //{
        //    if((temp.Value is not null) && (temp.Value.Equals(key)))
        //    {
        //        return true;
        //    }
        //    temp = temp.Next;
        //}
        //while(temp != Head);
        //return false;
    }
    public override string? ToString()
    {
        if (Value is null)
        {
            throw new ArgumentNullException(nameof(Value));
        }
        return Value.ToString();
    }
}
}
