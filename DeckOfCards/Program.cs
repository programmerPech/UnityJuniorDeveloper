using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            int countPullCards = 0;
            Console.WriteLine("Введите ваше имя: ");
            Player player = new Player(Console.ReadLine());
            Console.WriteLine(player.GetName() + ", сколько карт вы хотите взять?");
            userInput = Console.ReadLine();
            Deck deck = new Deck();
            deck.Shuffle(100);

            if(Int32.TryParse(userInput, out countPullCards) && countPullCards <= deck.GetCardsCount())
            {
                List<string> handCards = new List<string>(countPullCards);

                for(int i = 0; i < countPullCards; i++)
                {
                    handCards.Add(deck.Deal().ShowCardInfo());
                }

                Console.WriteLine(player.GetName() + ", вы вытянули следующие карты: ");

                foreach(var card in handCards)
                {
                    Console.WriteLine(card+ " ");
                }
            }
            else if(countPullCards >= deck.GetCardsCount())
            {
                Console.WriteLine(player.GetName()+", вы не можете вытянуть такое количество карт.");
            }
            else
            {
                Console.WriteLine("Ошибка! Кажется вы ввели не числовое значение!");
            }
        }
    }

    class Deck
    {
        private const int CARDSCOUNT = 52;
        private const int SUITSCOUNT = 4;
        private const int RANKSCOUNT = 13;
        private Card[] _cards;
        private int _currentCard;
        private Random _randomNumber;

        public Deck()
        {
            _cards = new Card[CARDSCOUNT];
            int index = 0;

            for (int suit = 0; suit < SUITSCOUNT; suit++)
            {
                for(int rank = 0; rank < RANKSCOUNT; rank++)
                {
                    _cards[index++] = new Card(suit, rank);
                }
            }

            _currentCard = 0;
        }

        public int GetCardsCount()
        {
            return CARDSCOUNT;
        }

        public void Shuffle(int count)
        {
            int index1, index2;
            _randomNumber = new Random();

            for (int k = 0; k < count; k++)
            {
                index1 = _randomNumber.Next(CARDSCOUNT);
                index2 = _randomNumber.Next(CARDSCOUNT);
                Card tempCard = _cards[index1];
                _cards[index1] = _cards[index2];
                _cards[index2] = tempCard;
            }

            _currentCard = 0;
        }

        public Card Deal()
        {
            if (_currentCard < CARDSCOUNT)
            {
                return _cards[_currentCard++];
            }
            else
            {
                return null;
            }
        }
    }

    class Card
    {
        private string[] _suits = new string[] { "Spades", "Hearts", "Clubs", "Diamonds" };
        private string[] _ranks = new string[] { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };

        private int _cardSuit;
        private int _cardRank;

        public Card(int suit, int rank)
        {
            _cardSuit = suit;
            _cardRank = rank;
        }

        public string ShowCardInfo()
        {
            return _ranks[_cardRank] + " of " + _suits[_cardSuit];
        }
    }

    class Player
    {
        private string _name;

        public Player(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }
    }
}
