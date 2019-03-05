using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_7.CSharp7
{

    /// <summary>
    /// We can now use accessors, constructors, finalizers
    /// </summary>
    public class OrderProcessor
    {
        private Dictionary<Guid, Order> _orders = new Dictionary<Guid, Order>();

        //Expression bodied constructor
        public OrderProcessor(List<Order> orders)  => orders.ForEach(o => _orders.Add(o.Key, o));


        //Destructor / finalizer can support it as well
        ~OrderProcessor() => CleanUpUnmanagedResources();

        private void CleanUpUnmanagedResources()
        {
            //File handles, connections, etc
        }


    }
    public class Order
    {
        private DateTime _orderDate;
        public Order()
        {
            Key = Guid.NewGuid();
            _orderDate = DateTime.Now;
        }
        public DateTime OrderDate
        {
            get => _orderDate;
            set => _orderDate = EnsureValidDateRange(value);

        }

        private DateTime EnsureValidDateRange(DateTime value)
        {
            //assume logic to clamp date range.
            return value;
        }

        public Guid Key { get; private set; }
        public int OrderId { get; private set; }

    }
}
