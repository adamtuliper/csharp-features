using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_7.CSharp7._2
{
    class non_trailing_named_arguments
    {
        public void Process()
        {
            FormatCustomer(firstName: "jane", lastName: "jones", age: 31, address: "555 Main St");

            //jumbled = ok
            FormatCustomer(lastName: "jones", address: "555 Main St", age: 31, firstName: "jane");


            //7.2 adds: missing name on argument age but proper order means now OK
            //Ex lastname is in correct order, but don't need name. We then add address.
            FormatCustomer(firstName: "jane", "jones", 31, address: "555 Main St");

            //NOT ok
            //FormatCustomer(firstName: "jane", 31, lastName:"jones", address: "555 Main St");


        }

        public string FormatCustomer(string firstName, string lastName,
            int age, string address, string category = "Retail", string campaign = "Web")
        {
            return $"Placeholder";
        }
    }
}
