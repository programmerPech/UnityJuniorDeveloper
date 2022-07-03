using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в супермаркет.\nВведите количество клиентов в очереди.");
            int clientsCount = -1;

            while (Int32.TryParse(Console.ReadLine(), out clientsCount) == false)
            {
                Console.WriteLine("Ожидалось число!\nПовторите попытку еще раз: ");
            }

            Supermarket supermarket = new Supermarket(clientsCount);
            supermarket.ShowQueue();
        }
    }

    class Client
    {
        private List<Product> _cartProducts = new List<Product>();
        public double Money { get; private set; }

        public Client(double money, List<Product> products)
        {
            Money = money;
            _cartProducts = products;
        }

        public double GetTotalPrice()
        {
            double totalPrice = 0;

            foreach (var product in _cartProducts)
            {
                totalPrice += product.Cost;
            }

            return totalPrice;
        }

        public void GetProducts()
        {
            if (_cartProducts.Count == 0)
            {
                Console.WriteLine("Покупатель ничего не купил.");
            }
            else
            {
                foreach (var product in _cartProducts)
                {
                    Console.WriteLine($"{product.Name} по цене {product.Cost}");
                }
            }
        }

        public void DeleteProduct(int id)
        {
            Console.WriteLine($"Продукт {_cartProducts[id].Name} удален из корзины.");
            _cartProducts.RemoveAt(id);
        }

        public int GetProductsCount()
        {
            return _cartProducts.Count;
        }
    }

    class Product
    {
        public string Name { get; private set; }
        public double Cost { get; private set; }

        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }
    }

    class Supermarket
    {
        private Queue<Client> _clients = new Queue<Client>();
        private List<Product> _products = new List<Product>();

        public Supermarket(int clientsCount)
        {
            SetProducts();
            CreateQueue(clientsCount);
            ServiceClients();
        }

        public void ShowQueue()
        {
            foreach (var client in _clients)
            {
                Console.WriteLine($"{client.Money} {client.GetTotalPrice()}");
            }
        }

        private void ServiceClients()
        {
            while (_clients.Count != 0)
            {
                GetInfo();

                if (_clients.Peek().Money >= _clients.Peek().GetTotalPrice())
                {
                    Console.WriteLine("Клиент успешно оплатил покупку.");
                    _clients.Dequeue();
                    Console.WriteLine();
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("\nПокупателю не хватило денег, удаляем случайные товары из корзины.");
                    Random random = new Random();

                    while (_clients.Peek().Money < _clients.Peek().GetTotalPrice())
                    {
                        int productCount = _clients.Peek().GetProductsCount();
                        int randomProductId = random.Next(productCount);
                        _clients.Peek().DeleteProduct(randomProductId);
                    }

                    Console.WriteLine("\nПокупатель смог себе позволить:");
                    GetInfo();

                    if (_clients.Peek().GetTotalPrice() != 0)
                    {
                        Console.WriteLine("Клиент успешно оплатил покупку.");
                    }

                    _clients.Dequeue();
                    Console.WriteLine();
                    Console.ReadKey();
                }
            }

            Console.WriteLine("Магазин обслужил всех клиентов и закрывается.");
        }

        private void GetInfo()
        {
            Console.WriteLine("Товары покупателя: ");
            _clients.Peek().GetProducts();
            Console.WriteLine($"Товаров на сумму: {_clients.Peek().GetTotalPrice()}");
            Console.WriteLine($"Денег у покупателя: {_clients.Peek().Money} ");
        }

        private void SetProducts()
        {
            _products.Add(new Product("Молоко", 60.5));
            _products.Add(new Product("Сухарики", 25.5));
            _products.Add(new Product("Хлеб", 30.6));
            _products.Add(new Product("Шоколад", 105.99));
            _products.Add(new Product("Колбаса", 259.99));
            _products.Add(new Product("Сыр", 220.89));
            _products.Add(new Product("Соус", 55.5));
            _products.Add(new Product("Сметана", 70.49));
            _products.Add(new Product("Мармелад", 85.67));
            _products.Add(new Product("Арахис", 45.2));
        }

        private void CreateQueue(int clientsCount)
        {
            Random random = new Random();
            int minimumCount = 0;
            int maximumCount = 10;
            int minimumMoney = 500;
            int maximumMoney = 1000;


            for (int i = 0; i < clientsCount; i++)
            {
                List<Product> clientProductCart = new List<Product>();
                int productCount = random.Next(minimumCount+1, _products.Count);

                for (int j = 0; j < productCount; j++)
                {
                    int productId = random.Next(minimumCount, maximumCount);
                    clientProductCart.Add(_products[productId]);
                }

                double clientMoney = Math.Round(random.NextDouble() * random.Next(minimumMoney, maximumMoney),2);
                _clients.Enqueue(new Client(clientMoney, clientProductCart));
            }
        }
    }
}
