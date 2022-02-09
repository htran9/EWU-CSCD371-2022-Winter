namespace GenericsHomework;
public class Node<TValue>
{
    public TValue? Value { get; set; }
    public Node<TValue> Next { get; private set; }
    public Node<TValue> Root;

    public Node(TValue value)
    {
        Value = value;
        Next = this;
        Root = this;
    }
    public void Append(TValue value)
    {

        bool keyExists = Exists(value);
        if (keyExists == true)
        {
            throw new ArgumentException("Cannot add duplicate value");
        }

        Node<TValue> newNode = new Node<TValue>(value);

    }

    private Node<TValue> GetLast()
    {
        Node<TValue> currentNode = Root;
        while(currentNode.Next != Root)
        {
            currentNode = currentNode.Next;
        }
        return currentNode;
    }
    public void Clear()
    {
        Root.Next = this;

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

    public override string? ToString()
    {
        if (Value is null)
        {
            throw new ArgumentNullException(nameof(Value));
        }
        return Value.ToString();
    }
}


