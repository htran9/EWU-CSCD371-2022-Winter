namespace GenericsHomework;
public class Node<TValue>
{
    public TValue? Value { get; }
    public Node<TValue> Next { get; private set; }
    private Node<TValue> Root;

    public Node(TValue value)
    {
        Value = value;
        Next = this;
        Root = this;
    }
    public Node(TValue value, Node<TValue> node)
    {
        Value = value;
        Next = node;
        Root = this;
    }
    public void Append(TValue value)
    {

        bool keyExists = Exists(value);
        if (keyExists == true)
        {
            throw new ArgumentException("Cannot add duplicate value");
        }

        Node<TValue> lastNode = GetLast();
        lastNode.Next = new Node<TValue>(value, Root);
    }

    private Node<TValue> GetLast()
    {
        Node<TValue> currentNode = Root;
        while (currentNode.Next != Root)
        {
            currentNode = currentNode.Next;
        }
        return currentNode;
    }
    public void Clear()
    {
        // The garbage collecter picks up objects once they are no longer referenced,
        // so removing the Next reference to a node would allow the garbage collector to
        // delete it,and subsequently delete the node it WAS pointing to because that
        // node no longer has a reference to it and etc...
        // 
        // Removing the Next reference effectively removes all items from a list except
        // the current node, because the list is now only pointing to a single node
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
                currentNode = currentNode.Next;
            } while (currentNode.Next != Root);
        }
        return false;
    }

    public override string? ToString()
    {
        return Convert.ToString(Value);
    }
}


