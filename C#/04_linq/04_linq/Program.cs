using System.Text;

namespace _04_linq
{
    class ShopItemDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }

    class ShopItem : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        //public int CompareTo(ShopItem? other)
        //{
        //    if(other == null) return 1;

        //    return Price.CompareTo(other.Price);
        //}

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;

            if (obj is ShopItem)
            {
                return Price.CompareTo(((ShopItem)obj).Price);
            }
            else if (obj is decimal)
            {
                return Price.CompareTo((decimal)obj);
            }

            return 1;
        }

        public override string ToString()
        {
            return $"{Id}: {Name} - Price: {Price}; Quantity: {Quantity}";
        }
    }

    internal class Program
    {
        static void Query()
        {
            // Query syntax

            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var shopItems = new List<ShopItem>
            {
                new ShopItem { Id = 1, Name = "Хліб", Price = 25.50m, Quantity = 100 },
                new ShopItem { Id = 2, Name = "Молоко", Price = 32.00m, Quantity = 80 },
                new ShopItem { Id = 3, Name = "Яйця", Price = 60.00m, Quantity = 50 },
                new ShopItem { Id = 4, Name = "Сир", Price = 120.75m, Quantity = 40 },
                new ShopItem { Id = 5, Name = "Масло", Price = 85.30m, Quantity = 35 },
                new ShopItem { Id = 6, Name = "Цукор", Price = 28.90m, Quantity = 70 },
                new ShopItem { Id = 7, Name = "Сіль", Price = 15.00m, Quantity = 90 },
                new ShopItem { Id = 8, Name = "Кава", Price = 210.00m, Quantity = 25 },
                new ShopItem { Id = 9, Name = "Чай", Price = 95.50m, Quantity = 45 },
                new ShopItem { Id = 10, Name = "Шоколад", Price = 55.99m, Quantity = 60 }
            };

            var evenNumbers = from num in numbers
                              where num % 2 == 0
                              orderby num descending
                              select num * 2;

            //var orderedItems = from item in shopItems
            //                   where item.Price >= 50m && item.Quantity < 50
            //                   orderby item.Price descending
            //                   select item;

            var orderedItems = from item in shopItems
                               where item.Price >= 50m && item.Quantity < 50
                               orderby item descending
                               select item;

            foreach (var item in orderedItems)
            {
                Console.WriteLine(item);
            }
        }

        static void Methods()
        {
            // Method syntax
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var shopItems = new List<ShopItem>
            {
                new ShopItem { Id = 1, Name = "Хліб", Price = 25.50m, Quantity = 100 },
                new ShopItem { Id = 2, Name = "Молоко", Price = 32.00m, Quantity = 80 },
                new ShopItem { Id = 3, Name = "Яйця", Price = 60.00m, Quantity = 50 },
                new ShopItem { Id = 4, Name = "Сир", Price = 120.75m, Quantity = 40 },
                new ShopItem { Id = 5, Name = "Масло", Price = 85.30m, Quantity = 35 },
                new ShopItem { Id = 6, Name = "Цукор", Price = 28.90m, Quantity = 70 },
                new ShopItem { Id = 7, Name = "Сіль", Price = 15.00m, Quantity = 90 },
                new ShopItem { Id = 8, Name = "Кава", Price = 210.00m, Quantity = 25 },
                new ShopItem { Id = 9, Name = "Чай", Price = 95.50m, Quantity = 45 },
                new ShopItem { Id = 10, Name = "Шоколад", Price = 55.99m, Quantity = 60 }
            };

            //int a = 5;
            //int res = a.Power(3);
            //Console.WriteLine(res);

            //string s = "Hello";
            //Console.WriteLine(s.Multiply(5));


            //numbers.Print(false);

            // All
            bool res = numbers.All(n => n > 0);
            Console.WriteLine($"All numbers > 0: {res}");
            res = numbers.All(n => n > 0 && n != 10);
            Console.WriteLine($"All numbers > 0 and != 10: {res}");

            // Any
            res = numbers.Any(n => n % 2 == 0);
            Console.WriteLine($"Any even numbers: {res}");
            res = numbers.Any(n => n < 0);
            Console.WriteLine($"Any numbers < 0: {res}");

            if (shopItems.Any(i => i.Name == "Масло"))
            {
                var i = shopItems.First(i => i.Name == "Масло");
                i.Quantity += 100;
            }
            else
            {
                shopItems.Add(new ShopItem { Id = 11, Name = "Масло", Price = 85.30m, Quantity = 100 });
            }

            res = shopItems.Any(); // поверне true, якщо колекція не порожня
            res = shopItems.Count > 0;

            // Aggregate - обрахунок значення на основі послідовності

            int mul = numbers.Aggregate(1, (n, s) => n * s);
            Console.WriteLine(mul);

            int sum = numbers.Sum();

            // Append - додає елемент в кінець послідовності
            numbers = numbers.Append(11).ToList();

            // Contains - перевіряє наявність елемента в послідовності
            res = numbers.Contains(5);
            Console.WriteLine(res);

            // Count - підраховує кількість елементів в послідовності
            int cnt = numbers.Count(n => n % 2 != 0);
            Console.WriteLine(cnt);

            // Fist, Last - отримує перший або останній елемент послідовності
            // FirstOrDefault, LastOrDefault - отримує перший або останній елемент послідовності або значення за замовчуванням, якщо послідовність порожня
            ShopItem item = shopItems.First(i => i.Price >= 50);
            Console.WriteLine(item);
            ShopItem? item2 = shopItems.FirstOrDefault(i => i.Price >= 100);
            if (item2 != null)
            {
                Console.WriteLine(item2);
            }
            else
            {
                Console.WriteLine("Item not found");
            }
            Console.WriteLine(shopItems.Last(i => i.Price >= 50));
            shopItems.LastOrDefault(i => i.Price >= 100);


            // OrderBy, OrderByDescending - сортує послідовність за зростанням або за спаданням
            Console.WriteLine();
            Console.WriteLine();
            var ordered = shopItems.OrderByDescending(i => i.Quantity);
            ordered.Print();
            Console.WriteLine();

            // Select - проєктує послідовність в нову форму
            var doubleNumber = numbers.Select(n => n * 2);

            var selectRes = shopItems.Select(i => i.Price);
            selectRes.Print();

            List<ShopItemDto> dtos = shopItems
                .Select(i => new ShopItemDto { Name = i.Name, Price = i.Price })
                .ToList();

            // Where - фільтрує послідовність на основі умови
            Console.WriteLine();
            Console.WriteLine();
            var items = shopItems.Where(i => i.Price < 50 && i.Quantity > 100);
            if (items.Count() > 0)
            {
                items.Print();
            }
            else
            {
                Console.WriteLine("Items not found");
            }


            // Take - бере певну кількість елементів з початку послідовності
            // Skip - пропускає певну кількість елементів з початку послідовності

            Console.WriteLine();
            var firstFive = shopItems.Take(5);
            var secondFive = shopItems.Skip(5).Take(5);
            Console.WriteLine("First");
            firstFive.Print();
            Console.WriteLine("Second");
            secondFive.Print();
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //Methods();

            var shopItems = new List<ShopItem>
            {
                new ShopItem { Id = 1, Name = "Хліб", Price = 25.50m, Quantity = 100 },
                new ShopItem { Id = 2, Name = "Молоко", Price = 32.00m, Quantity = 80 },
                new ShopItem { Id = 3, Name = "Яйця", Price = 60.00m, Quantity = 50 },
                new ShopItem { Id = 4, Name = "Сир", Price = 120.75m, Quantity = 40 },
                new ShopItem { Id = 5, Name = "Масло", Price = 85.30m, Quantity = 35 },
                new ShopItem { Id = 6, Name = "Цукор", Price = 28.90m, Quantity = 70 },
                new ShopItem { Id = 7, Name = "Сіль", Price = 15.00m, Quantity = 90 },
                new ShopItem { Id = 8, Name = "Кава", Price = 210.00m, Quantity = 25 },
                new ShopItem { Id = 9, Name = "Чай", Price = 95.50m, Quantity = 45 },
                new ShopItem { Id = 10, Name = "Шоколад", Price = 55.99m, Quantity = 60 }
            };


            var res = shopItems
                .Where(i => i.Price >= 50)
                .OrderBy(i => i.Price)
                .Select(i => (i.Name, i.Price))
                .ToList();

            var lowPrice = shopItems
                .OrderBy(i => i.Price)
                .First();

            foreach (var item in res)
            {
                Console.WriteLine($"{item.Name} - {item.Price}");
            }




            // Garbage Collector
            //Console.WriteLine("Total memoty before collect: " + GC.GetTotalMemory(false));
            //GC.Collect();
            //Console.WriteLine("Total memoty after collect: " + GC.GetTotalMemory(false));
        }
    }
}
