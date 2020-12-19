using System;

namespace LinkedListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            for (int i = 0; i < 10; i++)
            {
                list.AddHead(new Node(i));
            }


            list.PrintList();
            list.ReversePrintList();

            Node currentHead = list.Head;

            while (currentHead != null)
            {
                Console.WriteLine(currentHead.Value);
                currentHead = currentHead.Next;
            }

            Console.WriteLine(currentHead.Value);
            Console.WriteLine(currentHead.Next.Value);
            Console.WriteLine(currentHead.Next.Next.Value);
        }
    }
}
