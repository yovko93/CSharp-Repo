using _6.ValidPerson.Exceptions;
using System;

namespace _6.ValidPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person pesho = new Person("Pesho", "Peshev", 24);


            // Person noName = new Person(string.Empty, "Goshev", 31);
            //Person noLastName = new Person("Ivan", null, 63);
            //Person negativeAge = new Person("Stoyan", "Kolev", -1);
            //Person tooOldForThisProgram = new Person("Iskren", "Ivanov", 123);

            try
            {
                Student person = new Student("Gincho", "ginchev@gmail.com");

                throw new InvalidPersonNameException("Gincho", "The name is not valid");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Exception thrown: {0}", ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
            }
            catch (InvalidPersonNameException ipe)
            {
                Console.WriteLine($"{ipe.Name} {ipe.Message}");
            }


        }
    }
}
