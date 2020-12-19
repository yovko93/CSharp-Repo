using System;
using System.IO;
using System.Text;

namespace Demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Hey това е текст in english";

            using (FileStream stream =
                new FileStream("../../../output.txt", FileMode.OpenOrCreate))
            {
                stream.Position = stream.Length;
                Console.WriteLine(stream.Position);

                byte[] byteText = Encoding.UTF8.GetBytes(text);
                stream.Write(byteText, 0, byteText.Length);

                byte[] existingText = new byte[stream.Length];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(existingText, 0, (int)stream.Length);
                Console.WriteLine(Encoding.UTF8.GetString(existingText));
            }
        }
    }
}
