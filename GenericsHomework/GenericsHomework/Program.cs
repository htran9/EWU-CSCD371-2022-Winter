using System.IO;
using System;
namespace GenericsHomework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Node<string> newNode1 = new Node<string>("10");
            newNode1.Append("30");
            newNode1.Append("50");
            //newNode1.Append("60");
            //Node<string> newNode3 = newNode2.Append("50");
            //newNode1.Append("50");
            Console.WriteLine(newNode1);
            Console.WriteLine(newNode1.Next);
            Console.WriteLine(newNode1.Next.Next);
            Console.WriteLine(newNode1.Next.Next.Next);
            //Console.WriteLine(newNode1.Next.Next.Next.Next);
            //Console.WriteLine(newNode1.Next.Next.Next.Next.Next);

            //Console.WriteLine(newNode2.Next);
            //Console.WriteLine(newNode3.Value);
            //Console.WriteLine(newNode3.Next);
            //Console.WriteLine(newNode1.Next);
            //Console.WriteLine(newNode2.Next);
            /* bool temp = newNode1.Exists("35");
             if(temp == true)
             {
                 Console.WriteLine("KEY FOUNDDD");
             }
             else
             {
                 Console.WriteLine("KEY NOT FOUND");
             }*/
        }
    }
}
