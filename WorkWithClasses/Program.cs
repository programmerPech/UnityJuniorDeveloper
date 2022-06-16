using System;

namespace WorkWithClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Player[] players = { new Player("HyperLine2000",14,2,969), new Player("Sonic", 22,9,534), new Player("HarryPotter1337",18,23,34), new Player("Guts666", 27,14,288) };
            Console.WriteLine("Информация об игроках:\n");

            for (int i = 0; i < players.Length; i++)
            {
                players[i].ShowInfo();
            }
        }
    }

    class Player
    {
        private string _nickname;
        private int _age;
        private int _level;
        private int _rank;

        public Player(string nickname, int age, int level, int rank)
        {
            _nickname = nickname;
            _age = age;
            _level = level;
            _rank = rank;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Никнейм: "+_nickname+"\nВозраст: "+_age+"\nУровень: "+_level+"\nРанг: "+_rank+"\n");
        }
    }
}
