namespace GenericsHomework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Node<string> newNode1 = new Node<string>("10");
            //newNode1.Append("30");
            //newNode1.Append("50");
            ////newNode1.Append("60");
            ////Node<string> newNode3 = newNode2.Append("50");
            ////newNode1.Append("50");
            //Console.WriteLine(newNode1);
            //Console.WriteLine(newNode1.Next);
            //Console.WriteLine(newNode1.Next.Next);
            //Console.WriteLine(newNode1.Next.Next.Next);
            ////Console.WriteLine(newNode1.Next.Next.Next.Next);
            ////Console.WriteLine(newNode1.Next.Next.Next.Next.Next);
            ///
            Node<string> newNode = new("first");
            newNode.Append("Second");
            Console.WriteLine(newNode.ToString());
            Console.WriteLine(newNode.Next.ToString());
            Console.WriteLine(newNode.Exists("first"));
            Console.WriteLine(newNode.Exists("Second"));
        }
    }
}
