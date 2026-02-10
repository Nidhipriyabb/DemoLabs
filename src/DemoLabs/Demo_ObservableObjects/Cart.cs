using System.Collections.Specialized;

namespace Demo_ObservableObjects
{
    internal class Cart
        : System.Collections.Specialized.INotifyCollectionChanged
    {

        #region System.Collections.Specialized.INotifyCollectionChanged members

        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        #endregion

        public int OrderNo { get; private set; }
        public DateTime OrderDate { get; set; }

        private List<OrderItem>? orderItems { get; set; }        // aggregated collection!

        private static int counter;

        static Cart()
        {
            counter = 0;
        }

        public Cart() 
        {
            OrderNo = ++counter;
            orderItems = null;          // late-instantiation pattern
        }


        public override string ToString()
        {
            string orderDetails = "";
            orderDetails += "Order Number: " + this.OrderNo + "\n";
            orderDetails += "Order Date  : " + this.OrderDate.ToString("dd-MMM-yyyy") + "\n";
            if (orderItems is not null)
            {
                foreach (var item in orderItems)
                {
                    orderDetails += item + "\n";        // implictly calls item.ToString()
                }
            }
            else
            {
                orderDetails += "(no items in cart)" + "\n";
            }
            return orderDetails;
        }


        public void Add(OrderItem item)
        {
            // Late-Instantiation Design Pattern (instantiate the first time it is needed)
            if( orderItems is null)
            {
                orderItems = new List<OrderItem>();
            }

            orderItems.Add(item);

            if(this.CollectionChanged is not null)
            {
                var e 
                    = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item);
                this.CollectionChanged(this, e);
            }
        }
    }
}
