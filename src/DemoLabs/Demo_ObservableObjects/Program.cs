using System.Collections.Specialized;

namespace Demo_ObservableObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cart cart1 = new Cart()
            {
                OrderDate = DateTime.Now
            };

            OrderItem item1 = new OrderItem()
            {
                SlNo = 1,
                ProductName = "Sugar",
                Price = 45M,
                Quantity = 5
            };
            cart1.Add(item1);

            Console.WriteLine("--- Details of shopping cart #1");
            Console.WriteLine(cart1);                    // implicitly calls cart1.ToString()
            Console.WriteLine();


            // Subscribe to the event INotifyCollectionChanged
            cart1.CollectionChanged
                += new NotifyCollectionChangedEventHandler(cart_Changed);

            Console.WriteLine("Adding another item to Cart #1");
            cart1.Add(new OrderItem()
            {
                SlNo = 2,
                ProductName = "Wheat",
                Price = 30M,
                Quantity = 10
            });


            Console.WriteLine("--- Details of shopping cart #1");
            Console.WriteLine(cart1);                    // implicitly calls cart1.ToString()
            Console.WriteLine();
                               
        }


        private static void cart_Changed(
            object? sender, 
            NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("--- The following item(s) were ADDED to the cart:");
                if (e.NewItems is not null)
                {
                    foreach (var item in e.NewItems)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
                
                Console.WriteLine();
            }
        }
    }
}
