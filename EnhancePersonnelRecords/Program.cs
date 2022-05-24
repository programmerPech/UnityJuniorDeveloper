using System;
using System.Collections.Generic;

namespace EnhancePersonnelRecords
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> fullnameArray = new List<string>(3) { "Иванов Иван Иванович", "Петров Петр Петрович", "Семенов Семен Семенович" };
            List<string> positionArray = new List<string>(3) { "Геймдизайнер", "C#-программист", "Unity-программист" };
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
                        AddRecord(ref fullnameArray, ref positionArray);
                        break;
                    case "2":
                        ShowAllRecords(fullnameArray, positionArray);
                        break;
                    case "3":
                        DeleteRecord(ref fullnameArray, ref positionArray);
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

        static void AddRecord(ref List<string> fullnameArray, ref List<string> positionArray)
        {
            string fullname;
            string position;

            Console.WriteLine("Введите ФИО");
            fullname = Console.ReadLine();
            Console.WriteLine("Введите должность");
            position = Console.ReadLine();
            fullnameArray.Add(fullname);
            positionArray.Add(position);
            Console.WriteLine("Запись с ФИО " + fullname + " и должностью " + position + " успешно добавлена.");
            EndAction();
        }

        static void EndAction()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();
        }

        static void ShowAllRecords(List<string> fullnameArray, List<string> positionArray)
        {
            for (int i = 0; i < fullnameArray.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + fullnameArray[i] + " - " + positionArray[i]);
            }

            EndAction();
        }

        static void DeleteRecord(ref List<string> fullnameArray, ref List<string> positionArray)
        {
            if (fullnameArray.Count > 0 && positionArray.Count > 0)
            {
                string fullname = fullnameArray[fullnameArray.Count - 1];
                string position = positionArray[positionArray.Count - 1];
                fullnameArray.RemoveAt(fullnameArray.Count - 1);
                positionArray.RemoveAt(positionArray.Count - 1);
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
