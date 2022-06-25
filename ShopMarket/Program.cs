using System;
using System.Collections.Generic;

namespace ShopMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Trader trader = new Trader();
            string userInput = "";

            while(userInput != "4")
            {
                Console.WriteLine("Добро пожаловать в магазин: \nВведите команду\n1 - Купить товар.\n2 - Посмотреть список товаров торговца.\n3 - Посмотреть ваши товары в сумке.\n4 - Выйти из магазина.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        player.BuyProduct(trader);
                        break;
                    case "2":
                        trader.ShowProducts();
                        break;
                    case "3":
                        player.ShowBagProducts();
                        break;
                    case "4":
                        Console.WriteLine("Выход из магазина.");
                        break;
                    default:
                        Console.WriteLine("Введена неверная команда.");
                        break;
                }

                Console.WriteLine("Для продолжения нажмите любую кнопку...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Player
    {
        List<Product> _bag = new List<Product>();
        public double Money { get; private set; }

        public Player()
        {
            Money = 200.00;
        }

        public void BuyProduct(Trader trader)
        {
            Console.WriteLine("Введите идетификатор товара, который хотите купить.");
            Product product = null;
            int productId = -1;
            trader.ShowProducts();

            if(Int32.TryParse(Console.ReadLine(),out productId))
            {
                product = trader.GetProduct(productId);

                if (product != null)
                {
                    if(product.Cost < Money)
                    {
                        Money -= product.Cost;
                        _bag.Add(product);
                        Console.WriteLine("Вы успешно купили "+ product.Name+". Ваши деньги: "+Money);
                        trader.SellProduct(product);
                    }
                    else
                    {
                        Console.WriteLine("У вас недостаточно денег для покупки этого товара.");
                    }
                }
                else
                {
                    Console.WriteLine("Такого товара нет в наличии.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка! Ожидалось числовое значение.");
            }
        }
        
        public void ShowBagProducts()
        {
            if (_bag.Count > 0)
            {
                Console.WriteLine("В вашей сумке имеется: ");

                foreach (var product in _bag)
                {
                    Console.WriteLine(product.Name);
                }
            }
            else
            {
                Console.WriteLine("Ваша сумка пуста.");
            }
        }
    }

    class Human
    {
        private List<Product> _listOfProducts = new List<Product>();
        public double Money { get; private set; }
        public void ShowProducts()
        {
            if (_listOfProducts.Count > 0)
            {
                Console.WriteLine("У вас имеется: ");

                foreach (var product in _listOfProducts)
                {
                    Console.WriteLine(product.Name);
                }
            }
            else
            {
                Console.WriteLine("У вас нет продуктов.");
            }
        }

    }

    class Trader
    {
        private List<Product> _listOfProducts = new List<Product>();
        public double Balance { get; private set; }

        public Trader()
        {
            _listOfProducts.Add(new Product(1, "Зелье Здоровья", 5.5));
            _listOfProducts.Add(new Product(2, "Зелье Магии", 4.5));
            _listOfProducts.Add(new Product(3, "Меч Тысячи Истин", 99999999.99));
            _listOfProducts.Add(new Product(4, "Стальной Кинжал", 50));
            _listOfProducts.Add(new Product(5, "Яблоко", 0.5));
        }

        public Product GetProduct(int id)
        {
            foreach (var product in _listOfProducts)
            {
                if(product.Id == id)
                {
                    return product;
                }
            }

            return null;
        }

        public void ShowProducts()
        {
            if (_listOfProducts.Count > 0)
            {
                foreach (var product in _listOfProducts)
                {
                    Console.WriteLine(product.Id+". "+product.Name+" по цене "+product.Cost);
                }
            }
            else
            {
                Console.WriteLine("Сейчас у вас нет товаров на продажу.");
            }
        }

        public void SellProduct(Product product)
        {
            Balance += product.Cost;
            _listOfProducts.Remove(product);
            Console.WriteLine("Баланс продавца - " + Balance);
        }
    }

    class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Cost { get; private set; }

        public Product(int id, string name, double cost)
        {
            Id = id;
            Name = name;
            Cost = cost;
        }
    }
}
