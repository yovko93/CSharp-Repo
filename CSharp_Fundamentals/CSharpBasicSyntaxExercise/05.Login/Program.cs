using System;

namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = Console.ReadLine();
            string correctPass = string.Empty;

            for (int i = user.Length - 1; i >= 0; i--)
            {
                correctPass += user[i];
            }
            //bool isBlocked = true;

            for (int i = 1; i <= 4; i++)
            {
                string pass = Console.ReadLine();
                if (correctPass == pass)
                {
                    //isBlocked = false;
                    Console.WriteLine($"User {user} logged in.");
                    break;
                }
                if (i == 4)
                {
                    Console.WriteLine($"User {user} blocked!");
                    break;
                }
                Console.WriteLine("Incorrect password. Try again.");
            }
        }
    }
}
