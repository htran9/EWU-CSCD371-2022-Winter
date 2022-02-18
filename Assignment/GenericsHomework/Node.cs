using System.Collections;

namespace GenericsHomework;
public class Node<TValue> : IEnumerable<Node<TValue>>
{
    public TValue Value { get; }
    public Node<TValue> Next { get; private set; }
    public Node<TValue> Root;

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

    public Node<TValue> GetLast()
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
        // so removing the 'Next' reference to a node would allow the garbage collector to
        // delete it, and subsequently delete the node it WAS pointing to because that
        // node no longer has a reference to it and etc...
        // 
        // Removing a Node's Next reference effectively removes all items from that Node's list except
        // the current node itself, because the list is now only pointing to a single node circularly (itself)
        Root.Next = this;
    }
    public Boolean Exists(TValue key)
    {
        Node<TValue> currentNode = Root;
        do
        {
            if (key is null)
            {
                if (currentNode.Value is null)
                    return true;
            }
            else if (key.Equals(currentNode.Value))
                return true;
            currentNode = currentNode.Next;
        } while (currentNode != Root);

        return false;
    }

    public override string? ToString()
    {
        return Convert.ToString(Value);
    }

    public IEnumerable<Node<TValue>> ChildItems(int maximum) // i think this is what is needed for assignment5+6?
    {
        List <Node<TValue>> children = new();
        Node<TValue> currentNode = Root;

        int counter = 1;
        do
        {
            children.Add(currentNode);
            counter++;
            currentNode = currentNode.Next;
        } while (currentNode != Root && counter < maximum);
        return children;
    }

    public IEnumerator<Node<TValue>> GetEnumerator()
    {
        Node<TValue> current = this;

        do
        {
            yield return current;

            current = current.Next;
        } while (current != this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator) GetEnumerator(); 
 
    }
}


