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

            Console.WriteLine($"Имя и фамилия до перестановки - {fullName}.");
            string validSurname = firstName;
            firstName = surname;
            string swapFullName = firstName + " " + validSurname;
            Console.WriteLine($"Имя и фамилия после перестановки - {swapFullName}.");

        }
    }
}
