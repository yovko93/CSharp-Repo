using System;

namespace CustomDataStructure
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //CustomList myCustomList = new CustomList();

            //for (int i = 1; i <= 4; i++)
            //{
            //    myCustomList.Add(i);
            //}

            //myCustomList.RemoveAt(2);

            //Console.WriteLine(myCustomList.Contains(1));

            //Console.WriteLine(myCustomList);


            //-------------------------------


            CustomStack myCustomStack = new CustomStack();

            for (int i = 1; i <= 5; i++)
            {
                myCustomStack.Push(i);
            }

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(myCustomStack.Pop());
                Console.WriteLine(myCustomStack.Peek());
            }

            myCustomStack.Pop();   //Exception
            myCustomStack.Peek();  //Exception
        }
    }
}
