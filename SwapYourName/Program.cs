using System;

namespace SwapYourName
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = "Doe";
            string surname = "John";

            string fullName = firstName + " " + surname;
            string swapFullName = surname + " " + firstName;
            Console.WriteLine($"Имя и фамилия до перестановки - {fullName}.");
            Console.WriteLine($"Имя и фамилия после перестановки - {swapFullName}.");

        }
    }
}
