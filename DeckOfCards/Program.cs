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
            Console.WriteLine(player.Name + ", сколько карт вы хотите взять?");
            userInput = Console.ReadLine();
            Deck deck = new Deck();
            deck.Shuffle(100);

            if(Int32.TryParse(userInput, out countPullCards) && countPullCards <= deck.GetCardsCount())
            {
                List<Card> handCards = new List<Card>(countPullCards);

                for(int i = 0; i < countPullCards; i++)
                {
                    handCards.Add(deck.Deal());
                }

                player.SetHandCards(handCards);
                Console.WriteLine(player.Name + ", вы вытянули следующие карты: ");

                foreach(var card in player.HandCards)
                {
                    Console.WriteLine(card.ShowCardInfo() + " ");
                }
            }
            else if(countPullCards >= deck.GetCardsCount())
            {
                Console.WriteLine(player.Name+", вы не можете вытянуть такое количество карт.");
            }
            else
            {
                Console.WriteLine("Ошибка! Кажется вы ввели не числовое значение!");
            }
        }
    }

    class Deck
    {
        private const int CardsCount = 52;
        private string[] _suits = new string[] { "Spades", "Hearts", "Clubs", "Diamonds" };
        private string[] _ranks = new string[] { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };
        private Card[] _cards;
        private int _currentCard;
        private Random _randomNumber;

        public Deck()
        {
            _cards = new Card[CardsCount];
            int index = 0;

            for (int suit = 0; suit < _suits.Length; suit++)
            {
                for(int rank = 0; rank < _ranks.Length; rank++)
                {
                    _cards[index++] = new Card(_suits[suit], _ranks[rank]);
                }
            }

            _currentCard = 0;
        }

        public int GetCardsCount()
        {
            return CardsCount;
        }

        public void Shuffle(int count)
        {
            int index1, index2;
            _randomNumber = new Random();

            for (int k = 0; k < count; k++)
            {
                index1 = _randomNumber.Next(CardsCount);
                index2 = _randomNumber.Next(CardsCount);
                Card tempCard = _cards[index1];
                _cards[index1] = _cards[index2];
                _cards[index2] = tempCard;
            }

            _currentCard = 0;
        }

        public Card Deal()
        {
            if (_currentCard < CardsCount)
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
        private string _cardSuit;
        private string _cardRank;

        public Card(string suit, string rank)
        {
            _cardSuit = suit;
            _cardRank = rank;
        }

        public string ShowCardInfo()
        {
            return _cardRank + " of " + _cardSuit;
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public List<Card> HandCards { get; private set; }

        public Player(string name)
        {
            Name = name;
        }

        public void SetHandCards (List<Card> cards)
        {
            HandCards = cards;
        }
    }
}
