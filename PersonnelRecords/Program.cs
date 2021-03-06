using System;

namespace PersonnelRecords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fullnameArray = new string[3] { "Иванов Иван Иванович", "Петров Петр Петрович", "Семенов Семен Семенович" };
            string[] positionArray = new string[3] { "Геймдизайнер", "C#-программист", "Unity-программист" };
            string userInput = "";

            while (userInput != "5")
            {
                Console.WriteLine("Программа Кадровый учёт.");
                Console.WriteLine("1-добавить запись.");
                Console.WriteLine("2-вывести все записи.");
                Console.WriteLine("3-удалить запись.");
                Console.WriteLine("4-поиск по фамилии.");
                Console.WriteLine("5-выход из программы.");
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
                        SearchByLastname(fullnameArray, positionArray);
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда.");
                        break;
                }
            }
        }

        static void AddRecord(ref string[] fullnameArray, ref string[] positionArray)
        {
            string fullname;
            string position;

            Console.WriteLine("Введите ФИО");
            fullname = Console.ReadLine();
            Console.WriteLine("Введите должность");
            position = Console.ReadLine();
            fullnameArray = ExpandArray(fullnameArray);
            fullnameArray[fullnameArray.Length - 1] = fullname;
            positionArray = ExpandArray(positionArray);
            positionArray[positionArray.Length - 1] = position;
            Console.WriteLine("Запись с ФИО " + fullname + " и должностью " + position + " успешно добавлена.");
            EndAction();
        }

        static string[] ExpandArray(string[] array)
        {
            string[] temporaryArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                temporaryArray[i] = array[i];
            }

            array = temporaryArray;
            return array;
        }

        static void EndAction()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();
        }

        static void ShowAllRecords(string[] fullnameArray, string[] positionArray)
        {
            for (int i = 0; i < fullnameArray.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + fullnameArray[i] + " - " + positionArray[i]);
            }

            EndAction();
        }

        static void DeleteRecord(ref string[] fullnameArray, ref string[] positionArray)
        {
            if (fullnameArray.Length > 0 && positionArray.Length > 0)
            {
                string fullname = fullnameArray[fullnameArray.Length - 1];
                string position = positionArray[positionArray.Length - 1];
                fullnameArray = ReduceArray(fullnameArray);
                positionArray = ReduceArray(positionArray);
                Console.WriteLine("Запись с ФИО " + fullname + " и должностью " + position + " успешно удалена.");
                EndAction();
            }
            else
            {
                Console.WriteLine("Ошибка! Список пуск.");
            }
        }

        static string[] ReduceArray(string[] array)
        {
            string[] temporaryArray = new string[array.Length - 1];

            for (int i = 0; i < array.Length - 1; i++)
            {
                temporaryArray[i] = array[i];
            }

            array = temporaryArray;
            return array;
        }

        static void SearchByLastname(string[] fullnameArray, string[] positionArray)
        {
            string lastname;
            bool isFind = false;

            Console.WriteLine("Поиск по фамилии. Введите фамилию:");
            lastname = Console.ReadLine();
            Console.WriteLine("Результат поиска:");

            for (int i = 0; i < fullnameArray.Length; i++)
            {
                if (fullnameArray[i].Substring(0, lastname.Length).ToUpper() == lastname.ToUpper())
                {
                    isFind = true;
                    Console.WriteLine((i + 1) + ". " + fullnameArray[i] + " - " + positionArray[i]);
                }
            }

            if (isFind == false)
            {
                Console.WriteLine("Нет записей по данному запросу.");
            }

            EndAction();
        }
    }
}
