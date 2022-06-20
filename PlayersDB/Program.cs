using System;
using System.Collections.Generic;

namespace PlayersDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            Console.WriteLine("Программа для ведения базы игроков.");
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
                        database.BanPlayer();
                        break;
                    case "3":
                        database.UnbanPlayer();
                        break;
                    case "4":
                        database.DeletePlayer();
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
        private int _deletePlayersCount = 0;

        public void BanPlayer()
        {
            Console.WriteLine("Введите уникальный номер игрока, которого хотите забанить.");
            Player banPlayer = GetPlayer();

            if (banPlayer != null)
            {
                banPlayer.Ban();
                Console.WriteLine("Игрок с ID " + banPlayer.Id + " успешно забанен.");
            }
            else
            {
                Console.WriteLine("Не удалось найти игрока c таким ID.");
            }
        }

        public void UnbanPlayer()
        {
            Console.WriteLine("Введите уникальный номер игрока, которого хотите разбанить.");
            Player unbanPlayer = GetPlayer();

            if (unbanPlayer != null)
            {
                unbanPlayer.Unban();
                Console.WriteLine("Игрок с ID " + unbanPlayer.Id + " успешно разбанен.");
            }
            else
            {
                Console.WriteLine("Не удалось найти игрока c таким ID.");
            }
        }

        public void DeletePlayer()
        {
            Console.WriteLine("Введите уникальный номер игрока, которого хотите удалить.");
            Player deletePlayer = GetPlayer();

            if (deletePlayer != null)
            {
                _players.Remove(deletePlayer);
                _deletePlayersCount++;
                Console.WriteLine("Игрок с ID " + deletePlayer.Id + " успешно удален.");
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

            if (Int32.TryParse(level, out resultParse))
            {
                _players.Add(new Player(_players.Count + 1 +_deletePlayersCount, nickname, resultParse, false));
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
        public int Id { get; private set; }
        public string Nickname { get; private set; }
        public int Level { get; private set; }
        public bool Banned { get; private set; }

        public Player(int id, string nickname, int level, bool banned)
        {
            Id = id;
            Nickname = nickname;
            Level = level;
            Banned = banned;
        }

        public void Ban()
        {
            Banned = true;
        }

        public void Unban()
        {
            Banned = false;
        }
    }
}
