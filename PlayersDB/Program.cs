using System;
using System.Collections.Generic;

namespace PlayersDB
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();
            Console.WriteLine("Программа для ведения базы игроков." );
            string userInput = "";

            while (userInput != "6")
            {
                Console.WriteLine("Введите команду:\n1 - Добавить игрока.\n2 - Забанить игрока.\n3 - Разбанить игрока.\n4 - Удалить игрока.\n5 - Вывести информацию по всем игрокам на экран.\n6 - Выход из программы.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        dataBase.AddPlayer();
                        Clear();
                        break;
                    case "2":
                        dataBase.BanPlayer();
                        Clear();
                        break;
                    case "3":
                        dataBase.UnbanPlayer();
                        Clear();
                        break;
                    case "4":
                        dataBase.DeletePlayer();
                        Clear();
                        break;
                    case "5":
                        dataBase.ShowAllPlayers();
                        Clear();
                        break;
                    case "6":
                        Console.WriteLine("Выход из программы.");
                        break;
                    default: 
                        Console.WriteLine("Введена неизвестная команда");
                        Clear();
                        break;
                }
            }
        }

        public static void Clear()
        {
            Console.WriteLine("Нажмите любую клавишу чтобы продолжить... ");
            Console.ReadKey();
            Console.Clear();
        }
    }

    class DataBase
    {
        List<Player> players = new List<Player>();

        public void AddPlayer()
        {
            Console.WriteLine("Введите уникальный игрока:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите никнейм игрока:");
            string nickname = Console.ReadLine();
            Console.WriteLine("Введите текущий уровень игрока:");
            int level = Convert.ToInt32(Console.ReadLine());
            players.Add( new Player(id, nickname, level, false));
            Console.WriteLine("Новый игрок успешно добавлен в базу.");
        }

        public void BanPlayer()
        {
            Console.WriteLine("Введите уникальный номер игрока, которого хотите забанить.");
            int banId = Convert.ToInt32(Console.ReadLine());

            foreach (var player in players)
            {
                if (player.Id == banId && player.Banned == false)
                {
                    player.Banned = true;
                    Console.WriteLine("Игрок с ID "+player.Id+" успешно забанен.");
                }
                else
                {
                    Console.WriteLine("Не удалось найти игрока с таким ID");
                }
            }
        }

        public void UnbanPlayer()
        {
            Console.WriteLine("Введите уникальный номер игрока, которого хотите разбанить.");
            int unbanId = Convert.ToInt32(Console.ReadLine());

            foreach (var player in players)
            {
                if (player.Id == unbanId && player.Banned == true)
                {
                    player.Banned = false;
                    Console.WriteLine("Игрок с ID " + player.Id + " успешно разбанен.");
                }
                else
                {
                    Console.WriteLine("Не удалось найти игрока с таким ID");
                }
            }
        }

        public void DeletePlayer()
        {
            Console.WriteLine("Введите уникальный номер игрока, которого хотите удалить.");
            int deleteId = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Id == deleteId)
                {
                    players.Remove(players[i]);
                    Console.WriteLine("Игрок с ID "+deleteId+" удален.");
                }
                else
                {
                    Console.WriteLine("Не удалось найти игрокас таким ID");
                }
            }
        }

        public void ShowAllPlayers()
        {
            if (players.Count < 1)
            {
                Console.WriteLine("Список пуст.");
            }

            foreach (var player in players)
            {
                Console.WriteLine("База данных всех игроков:");
                Console.WriteLine("ID: "+player.Id+" Nickname: "+player.Nickname+" Level: "+player.Level+" Banned: "+player.Banned);
            }
        }
    }

    class Player
    {
        private int _id;
        private string _nickname;
        private int _level;
        private bool _banned;

        public int Id
        {
            get { return _id; }
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

        public Player(int id, string nickname, int level, bool banned)
        {
            _id = id;
            _nickname = nickname;
            _level = level;
            _banned = banned;
        }
    }
}
