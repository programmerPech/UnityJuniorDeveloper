using System;
using System.Collections.Generic;

namespace StorageOfBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();
            Console.WriteLine("Программа для ведения хранилища книг.");
            string userInput = "";

            while(userInput != "5")
            {
                Console.WriteLine("Введите команду:\n1 - Добавить книгу.\n2 - Убрать книгу.\n3 - Поиск по хранилищу.\n4 - Вывести все книги.\n5 - Выход из программы.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        storage.AddBook();
                        break;
                    case "2":
                        storage.DeleteBook();
                        break;
                    case "3":
                        storage.SearchBooksForParameter();
                        break;
                    case "4":
                        storage.ShowAllBooks();
                        break;
                    case "5":
                        Console.WriteLine("Выход из программы.");
                        break;
                    default:
                        Console.WriteLine("Введена неизвестная команда.");
                        break;
                }

                Console.WriteLine("Для продолжения нажмите любую кнопку...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
    class Book
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Author { get; private set; }
        public int Year { get; private set; }

        public Book(int id, string name, string author, int year)
        {
            Id = id;
            Name = name;
            Author = author;
            Year = year;
        }
    }

    class Storage
    {
        private List<Book> _books = new List<Book>();
        private int _deletedBooksCount = 0;

        public Storage()
        {
            _books.Add(new Book((_books.Count + 1 + _deletedBooksCount), "Маленькая жизнь", "Ханья Янагихара", 2022));
            _books.Add(new Book((_books.Count + 1 + _deletedBooksCount), "Бесконечная шутка", "Дэвид Фостер Уоллес", 2019));
            _books.Add(new Book((_books.Count + 1 + _deletedBooksCount), "Чапаев и пустота", "Виктор Пелевин", 2022));
            _books.Add(new Book((_books.Count + 1 + _deletedBooksCount), "Generation \"П\"", "Виктор Пелевин", 2022));
            _books.Add(new Book((_books.Count + 1 + _deletedBooksCount), "Гарри Поттер и методы рационального мышления", "Элиезер Юдковский", 2010));
        }

        public void AddBook()
        {
            string name;
            string author;
            int year;

            Console.WriteLine("Введите название книги: ");
            name = Console.ReadLine();
            Console.WriteLine("Введите автора книги: ");
            author = Console.ReadLine();
            Console.WriteLine("Введите год издания: ");
            year = GetUserInputYear();

            if (year != 0)
            {
                _books.Add(new Book((_books.Count + 1 + _deletedBooksCount), name, author, year));
                Console.WriteLine("Книга добавлена в хранилище");
            }
            else
            {
                Console.WriteLine("Добавить книгу не удалось.");
            }
        }

        public void SearchBooksForParameter()
        {
            Console.WriteLine("Поиск книги по параметру.\nВыберите один из параметров:\n1 - Поиск по названию.\n2 - Поиск по автору.\n3 - Поиск по году издания.");

            switch (Console.ReadLine())
            {
                case "1":
                    SearchBooksForName();
                    break;
                case "2":
                    SearchBooksForAuthor();
                    break;
                case "3":
                    SearchBooksForYear();
                    break;
                default:
                    Console.WriteLine("Введена неверная команда.");
                    break;
            }
        }

        public void DeleteBook()
        {
            Console.WriteLine("Ввкдите идентификатор книги, которую хотите удалить: ");
            int idBook;

            if(Int32.TryParse(Console.ReadLine(),out idBook))
            {
                _deletedBooksCount++;
                _books.Remove(GetBook(idBook));
                Console.WriteLine("Книга успешно удалена из хранилища.");
            }
            else
            {
                Console.WriteLine("Не удалось выполнить удаление. Ожидалось числовое значение.");
            }
        }

        public void ShowAllBooks()
        {
            foreach (var book in _books)
            {
                Console.WriteLine(book.Id+ ". Название: "+book.Name+" Автор: "+book.Author+" Год издания: "+book.Year);
            }
        }

        private int GetUserInputYear()
        {
            int bookYear;

            if (Int32.TryParse(Console.ReadLine(), out bookYear))
            {
                return bookYear;
            }
            else
            {
                Console.WriteLine("Год издания указан неверно.");
                return 0;
            }
        }

        private Book GetBook(int id)
        {
            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].Id == id)
                {
                    return _books[i];
                }
            }

            return null;
        }

        private void SearchBooksForName()
        {
            Console.WriteLine("Введите название: ");
            string name = Console.ReadLine();
            Console.WriteLine("Результаты поиска: ");
            bool isFind = false;

            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].Name.ToLower().Contains(name.ToLower()))
                {
                    isFind = true;
                    Console.WriteLine(_books[i].Id + ". Название: " + _books[i].Name + " Автор: " + _books[i].Author + " Год издания: " + _books[i].Year);
                }
            }

            if (isFind == false)
            {
                Console.WriteLine("По вашему запросу ничего не найдено.");
            }
        }

        private void SearchBooksForAuthor()
        {
            Console.WriteLine("Введите автора: ");
            string author = Console.ReadLine();
            Console.WriteLine("Результаты поиска: ");
            bool isFind = false;

            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].Author.ToLower().Contains(author.ToLower()))
                {
                    isFind = true;
                    Console.WriteLine(_books[i].Id + ". Название: " + _books[i].Name + " Автор: " + _books[i].Author + " Год издания: " + _books[i].Year);
                }
            }

            if (isFind == false)
            {
                Console.WriteLine("По вашему запросу ничего не найдено.");
            }
        }

        private void SearchBooksForYear()
        {
            Console.WriteLine("Введите год издания: ");
            int year = GetUserInputYear();
            Console.WriteLine("Результаты поиска: ");
            bool isFind = false;

            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].Year == year)
                {
                    isFind = true;
                    Console.WriteLine(_books[i].Id + ". Название: " + _books[i].Name + " Автор: " + _books[i].Author + " Год издания: " + _books[i].Year);
                }
            }

            if (isFind == false)
            {
                Console.WriteLine("По вашему запросу ничего не найдено.");
            }
        }
    }
}
