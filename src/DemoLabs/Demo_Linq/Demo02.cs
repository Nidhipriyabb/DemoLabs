using Demo_Linq.Demo03;

namespace Demo_Linq.Demo02
{
    internal static class Demo
    {
        internal static void RunThis()
        {
            List<Product> products = new List<Product>()
            {
                new Product() { Id = 2, Name = "Rice", Price = 10.0M, Quantity = 5 },
                new Product() { Id = 4, Name = "Sugar", Price = 20.0M, Quantity = 10 },
                new Product() { Id = 1, Name = "Wheat", Price = 30.0M, Quantity = 20 },
                new Product() { Id = 3, Name = "Dal", Price = 1.75M, Quantity = 18 },
                new Product() { Id = 5, Name = "Salt", Price = 18.3M, Quantity = 19 }
            };


            Console.WriteLine("{0,3} {1,-15} {2,10} {3,10} {4,12}",
                "ID", "NAME", "PRICE", "QUANTITY", "COST");
            foreach (var product in products)
            {
                Console.WriteLine("{0,3} {1,-15} {2,10:C} {3,10} {4,12:C}",
                    product.Id, product.Name, product.Price, product.Quantity, product.Price * product.Quantity);
            }
            Console.WriteLine();


            Console.WriteLine("--- After Sorting using the IComparable implementation for ID");

            products.Sort();

            Console.WriteLine("{0,3} {1,-15} {2,10} {3,10} {4,12}",
                "ID", "NAME", "PRICE", "QUANTITY", "COST");
            foreach (var product in products)
            {
                Console.WriteLine("{0,3} {1,-15} {2,10:C} {3,10} {4,12:C}",
                    product.Id, product.Name, product.Price, product.Quantity, product.Price * product.Quantity);
            }
            Console.WriteLine();


            Console.WriteLine("--- Using LINQ, sorting on NAME DESC");

            var query =
                from product in products
                orderby product.Name descending
                select product;

            Console.WriteLine("{0,3} {1,-15} {2,10} {3,10} {4,12}",
                "ID", "NAME", "PRICE", "QUANTITY", "COST");
            foreach (Product product in query)          // (var product in query)
            {
                Console.WriteLine("{0,3} {1,-15} {2,10:C} {3,10} {4,12:C}",
                    product.Id, product.Name, product.Price, product.Quantity, product.Price * product.Quantity);
            }
            Console.WriteLine();


            Console.WriteLine("--- Using LINQ and PROJECTION");

            var query2 =
                from product in products
                orderby product.Name descending
                where (product.Price * product.Quantity) > 250
                select new                                  // PROJECTION
                {
                    product.Id,
                    product.Name,
                    product.Price,
                    product.Quantity,
                    Cost = product.Price * product.Quantity
                };

            Console.WriteLine("{0,3} {1,-15} {2,10} {3,10} {4,12}",
                "ID", "NAME", "PRICE", "QUANTITY", "COST");
            foreach (var product in query2)
            {
                Console.WriteLine("{0,3} {1,-15} {2,10:C} {3,10} {4,12:C}",
                    product.Id, product.Name, product.Price, product.Quantity, product.Cost);
            }
            Console.WriteLine();


            var query3 =
                from product in products
                orderby product.Name descending
                select new                                  // PROJECTION
                {
                    product.Id,
                    product.Name,
                    product.Price,
                    product.Quantity,
                    Cost = product.Price * product.Quantity
                };

            var query4 = from product in query3
                         where product.Cost > 250
                         select product;

            Console.WriteLine("{0,3} {1,-15} {2,10} {3,10} {4,12}",
                "ID", "NAME", "PRICE", "QUANTITY", "COST");
            foreach (var product in query4)
            {
                Console.WriteLine("{0,3} {1,-15} {2,10:C} {3,10} {4,12:C}",
                    product.Id, product.Name, product.Price, product.Quantity, product.Cost);
            }
            Console.WriteLine();

        }
    }

    class Product : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set;  }
        public int Quantity { get; set; }

        public int CompareTo(object? obj)
        {
            Product? otherProduct = obj as Product;
            if (otherProduct is not null)
            {
                return this.Id.CompareTo(otherProduct.Id);
            }
            return 0;
        }
    }
}
