using System;
using System.Collections.Generic;
using System.Linq;

namespace TopPlayers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            string userInput = "";

            while (userInput != "4")
            {
                Console.WriteLine("Добро пожаловать на сервер.\nВыберите команду:\n1 - Показать всех игроков.\n2 - Показать Топ 3 игроков по уровню." +
                    "\n3 - Показать Топ 3 игроков по силе.\n4 - Выход из программы.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        server.ShowPlayers();
                        break;
                    case "2":
                        server.ShowTopPlayersByLevel();
                        break;
                    case "3":
                        server.ShowTopPlayersByPower();
                        break;
                    case "4":
                        Console.WriteLine("Выход из программы.");
                        break;
                    default:
                        Console.WriteLine("Введена неизвестная команда.");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Server
    {
        private List<Player> _players = new List<Player>();

        public Server()
        {
            _players.Add(new Player("Maksym777", 10, 1000));
            _players.Add(new Player("SPEEECTR", 99, 8540));
            _players.Add(new Player("MrPodySha", 55, 6420));
            _players.Add(new Player("Kirilloo", 60, 6805));
            _players.Add(new Player("ArsheGrif", 61, 6740));
            _players.Add(new Player("MrPROEvil", 12, 1530));
            _players.Add(new Player("Arekusey", 85, 7205));
            _players.Add(new Player("beixodbeu", 90, 7510));
            _players.Add(new Player("IamNotLoh", 91, 7450));
            _players.Add(new Player("KoDi Boss", 98, 8620));
        }
        
        public void ShowPlayers()
        {
            foreach (var player in _players)
            {
                player.ShowInfo();
            }
        }

        public void ShowTopPlayersByLevel()
        {
            var topPlayers = _players.OrderByDescending(player => player.Level).Take(3);

            foreach (var topPlayer in topPlayers)
            {
                topPlayer.ShowInfo();
            }
        }

        public void ShowTopPlayersByPower()
        {
            var topPlayers = _players.OrderByDescending(player => player.Power).Take(3);

            foreach (var topPlayer in topPlayers)
            {
                topPlayer.ShowInfo();
            }
        }
    }

    class Player
    {
        public string Nickname { get; private set; }
        public int Level { get; private set; }
        public int Power { get; private set; }

        public Player(string nickname, int level, int power)
        {
            Nickname = nickname;
            Level = level;
            Power = power;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя: {Nickname} \t Уровень: {Level} \t Сила:{Power}");
        }
    }
}
