
namespace GenericsHomework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Node<string> newNode1 = new Node<string>("10");
            Node<string> newNode2 = new Node<string>("5");
            Console.WriteLine(newNode1.Value);
        }
    }
}
