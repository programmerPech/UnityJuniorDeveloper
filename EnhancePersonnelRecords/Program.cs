using System;
using System.Collections.Generic;

namespace EnhancePersonnelRecords
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> dataEmployee = new List<string>() { "Иванов Иван Иванович", "Геймдизайнер", "Петров Петр Петрович", "C#-программист", "Семенов Семен Семенович", "Unity-программист" };
            string userInput = "";

            while (userInput != "4")
            {
                Console.WriteLine("Программа Кадровый учёт.");
                Console.WriteLine("1-добавить запись.");
                Console.WriteLine("2-вывести все записи.");
                Console.WriteLine("3-удалить запись.");
                Console.WriteLine("4-выход из программы.");
                Console.WriteLine("Выберите пункт меню, введя соответствующую цифру:");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddRecord(ref dataEmployee);
                        break;
                    case "2":
                        ShowAllRecords(dataEmployee);
                        break;
                    case "3":
                        DeleteRecord(ref dataEmployee);
                        break;
                    case "4":
                        Console.WriteLine("Выход из программы.");
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда.");
                        EndAction();
                        break;
                }
            }
        }

        static void AddRecord(ref List<string> dataEmployee)
        {
            string fullname;
            string position;

            Console.WriteLine("Введите ФИО");
            fullname = Console.ReadLine();
            Console.WriteLine("Введите должность");
            position = Console.ReadLine();
            dataEmployee.Add(fullname);
            dataEmployee.Add(position);
            Console.WriteLine("Запись с ФИО " + fullname + " и должностью " + position + " успешно добавлена.");
            EndAction();
        }

        static void EndAction()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();
        }

        static void ShowAllRecords(List<string> dataEmployee)
        {
            int countEmployee = 1;

            for (int i = 0; i < dataEmployee.Count; i++)
            {
                Console.WriteLine((countEmployee++) + ". " + dataEmployee[i] + " - " + dataEmployee[i++]);
            }

            EndAction();
        }

        static void DeleteRecord(ref List<string> dataEmployee)
        {
            if (dataEmployee.Count > 0)
            {
                string fullname = dataEmployee[dataEmployee.Count - 2];
                string position = dataEmployee[dataEmployee.Count - 1];
                dataEmployee.RemoveAt(dataEmployee.Count - 2);
                dataEmployee.RemoveAt(dataEmployee.Count - 1);
                Console.WriteLine("Запись с ФИО " + fullname + " и должностью " + position + " успешно удалена.");
                EndAction();
            }
            else
            {
                Console.WriteLine("Ошибка! Список пуск.");
            }
        }
    }
}
