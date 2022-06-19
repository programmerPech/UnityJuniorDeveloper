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
                        Console.WriteLine("Введите уникальный номер игрока, которого хотите забанить.");
                        database.BanPlayer(database.GetPlayer());
                        break;
                    case "3":
                        Console.WriteLine("Введите уникальный номер игрока, которого хотите разбанить.");
                        database.UnbanPlayer(database.GetPlayer());
                        break;
                    case "4":
                        Console.WriteLine("Введите уникальный номер игрока, которого хотите удалить.");
                        database.DeletePlayer(database.GetPlayer());
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

        public void BanPlayer(Player player)
        {
            if (player != null)
            {
                player.Ban();
                Console.WriteLine("Игрок с ID " + player.Id + " успешно забанен.");
            }
            else
            {
                Console.WriteLine("Не удалось найти игрока c таким ID.");
            }
        }

        public void UnbanPlayer(Player player)
        {
            if (player != null)
            {
                player.Unban();
                Console.WriteLine("Игрок с ID " + player.Id + " успешно разбанен.");
            }
            else
            {
                Console.WriteLine("Не удалось найти игрока c таким ID.");
            }
        }

        public void DeletePlayer(Player player)
        {
            if (player != null)
            {
                for (int i = 0; i < _players.Count; i++)
                {
                    if (_players[i].Id == player.Id)
                    {
                        _players.Remove(_players[i]);
                        Console.WriteLine("Игрок с ID " + player.Id + " успешно удален.");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Не удалось найти игрока c таким ID.");
            }
        }

        public Player GetPlayer()
        {
            int playerId;

            if (Int32.TryParse(Console.ReadLine(), out playerId))
            {
                for (int i = 0; i < _players.Count; i++)
                {
                    if (_players[i].Id == playerId)
                    {
                        return _players[i];
                    }
                }
            }
            else
            {
                Console.WriteLine("Не удалось выполнить действие, так как вы ввели не числовое значение.");
            }

            return null;
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
                _players.Add(new Player(_players.Count + 1,nickname, resultParse, false));
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
        private string _nickname;
        private int _level;

        public int Id
        {
            get; private set;
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
            get; private set;
        }

        public void Ban()
        {
            Banned = true;
        }

        public void Unban()
        {
            Banned = false;
        }

        public Player(int id, string nickname, int level, bool banned)
        {
            Id = id;
            _nickname = nickname;
            _level = level;
            Banned = banned;
        }
    }
}
