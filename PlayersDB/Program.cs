using System;
using System.Collections.Generic;

namespace PlayersDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            Console.WriteLine("Программа для ведения базы игроков." );
            string userInput = "";

            while (userInput != "6")
            {
                Console.WriteLine("Введите команду:\n1 - Добавить игрока.\n2 - Забанить игрока.\n3 - Разбанить игрока.\n4 - Удалить игрока.\n5 - Вывести информацию по всем игрокам на экран.\n6 - Выход из программы.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        database.AddPlayer();
                        break;
                    case "2":
                        database.ModifyPlayer(userInput);
                        break;
                    case "3":
                        database.ModifyPlayer(userInput);
                        break;
                    case "4":
                        database.ModifyPlayer(userInput);
                        break;
                    case "5":
                        database.ShowAllPlayers();
                        break;
                    case "6":
                        Console.WriteLine("Выход из программы.");
                        break;
                    default: 
                        Console.WriteLine("Введена неизвестная команда");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу чтобы продолжить... ");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Database
    {
        private List<Player> _players = new List<Player>();

        public void ModifyPlayer(string userInput)
        {
            bool isFindID = false;
            int modifyId;

            if (userInput == "2")
            {
                Console.WriteLine("Введите уникальный номер игрока, которого хотите забанить.");
            }
            else if(userInput == "3")
            {
                Console.WriteLine("Введите уникальный номер игрока, которого хотите разбанить.");
            }
            else
            {
                Console.WriteLine("Введите уникальный номер игрока, которого хотите удалить.");
            }

            if (Int32.TryParse(Console.ReadLine(), out modifyId))
            {
                for (int i = 0; i < _players.Count; i++)
                {
                    if (_players[i].Id == modifyId && _players[i].Banned == false && userInput =="2")
                    {
                        _players[i].Banned = true;
                        isFindID = true;
                        break;
                    }
                    else if (_players[i].Id == modifyId && _players[i].Banned == true && userInput == "3")
                    {
                        _players[i].Banned = false;
                        isFindID = true;
                        break;
                    }
                    else if (_players[i].Id == modifyId && userInput=="4")
                    {
                        _players.Remove(_players[i]);
                        isFindID = true;
                        break;
                    }
                }

                if (isFindID == true &&userInput =="2")
                {
                    Console.WriteLine("Игрок с ID " + modifyId + " успешно забанен.");
                }
                else if(isFindID == true && userInput == "3")
                {
                    Console.WriteLine("Игрок с ID " + modifyId + " успешно разбанен.");
                }
                else if(isFindID == true && userInput == "4")
                {
                    Console.WriteLine("Игрок с ID " + modifyId + " успешно удален.");
                }
                else
                {
                    Console.WriteLine("Не удалось найти игрока м таким ID.");
                }
            }
            else
            {
                Console.WriteLine("Не удалось выполнить действие, так как вы ввели не числовое значение.");
            }
        }
        public void AddPlayer()
        {
            Console.WriteLine("Введите никнейм игрока:");
            string nickname = Console.ReadLine();
            Console.WriteLine("Введите текущий уровень игрока:");
            string level = Console.ReadLine();
            int resultParse = -1;

            if(Int32.TryParse(level, out resultParse))
            {
                _players.Add(new Player(nickname, Convert.ToInt32(level), false));
                Console.WriteLine("Новый игрок успешно добавлен в базу.");
            }
            else
            {
                Console.WriteLine("Не удалось добавить игрока. Вы ввели не числовое значение в уровень.");
            }
        }
  
        public void ShowAllPlayers()
        {
            if (_players.Count < 1)
            {
                Console.WriteLine("Список пуст.");
            }
            else
            {
                foreach (var player in _players)
                {
                    Console.WriteLine("База данных всех игроков:");
                    Console.WriteLine("ID: " + player.Id + " Nickname: " + player.Nickname + " Level: " + player.Level + " Banned: " + player.Banned);
                }
            }
        }
    }

    class Player
    {
        private static int _ids = 0;
        private string _nickname;
        private int _level;
        private bool _banned;

        public int Id
        {
            get; set;
        }

        public string Nickname
        {
            get { return _nickname; }
        }

        public int Level
        {
            get { return _level; }
        }

        public bool Banned
        {
            get { return _banned; }
            set { _banned = value; }
        }

        public Player(string nickname, int level, bool banned)
        {
            Id= ++_ids;
            _nickname = nickname;
            _level = level;
            _banned = banned;
        }
    }
}
