using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_7.CSharp8
{
    class nullable_reference_types
    {

        class Person
        {
            public string FirstName;   // Not null
            public string? MiddleName; // May be null
            public string LastName;    // Not null
        }

        void M(string? ns)            // ns is nullable
        {
            Console.WriteLine(ns.Length);     // WARNING: may be null
            if (ns != null)
            {
                Console.WriteLine(ns.Length); // ok, not null here 
            }
            if (ns == null)
            {
                return;               // not null after this
            }
            Console.WriteLine(ns.Length);     // ok, not null here
            ns = null;                // null again!
            Console.WriteLine(ns.Length);     // WARNING: may be null
        }
    }
}
