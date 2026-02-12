namespace Demo_Linq.Demo03
{

    /// <summary>
    ///     using LET
    /// </summary>
    internal static class Demo
    {
        internal static void RunThis()
        {
            var products = new List<Product>()
            {
                new Product { ProductName = "Rice", Price = 100M },
                new Product { ProductName = "Wheat", Price = 20M },
                new Product { ProductName = "Sugar", Price = 3000M },
            };

            var query = 
                from p in products
                let priceWithTax = p.Price * 1.2m           // LET creates a temp variable
                let taxPercent = 0.2m
                let taxAmount = p.Price * taxPercent
                // orderby priceWithTax descending
                // where priceWithTax > 200
                select new
                {
                   Name = p.ProductName,
                   p.Price,                 // SAME AS Price = p.Price
                   TaxAmount = taxAmount,
                   FinalPrice = priceWithTax
                };

            Console.WriteLine("{0,-20} {1,10}  {2,10} {3,10}", "PRODUCT NAME", "PRICE", "TAX", "WITH TAX");
            foreach (var item in query)
            {
                Console.WriteLine($"{item.Name,-20} {item.Price,10:C}  {item.TaxAmount,10:C}  {item.FinalPrice, 10:C}");
            }
            Console.WriteLine();

        }
    }

    internal class Product
    {
        internal string ProductName { get; set; } = string.Empty;
        internal decimal Price { get; set; }
    }
}
