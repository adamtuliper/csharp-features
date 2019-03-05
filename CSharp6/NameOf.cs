using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_7.CSharp6
{
    public class NameOf
    {
        public void Process(string customerId)
        {
            //No strings required.
            //throw new ArgumentException("customerId");
            throw new ArgumentException(nameof(customerId));

            //More specifically 
            throw new ArgumentException("Order cannot be processed without a customer id", nameof(customerId));
        }
    }
}
