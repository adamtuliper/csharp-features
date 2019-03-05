using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_features.CSharp8
{
    class RangeAndIndices
    {
        public static void Process()
        {
            var x = 3..10;
            Index i1 = 3;  // number 3 from beginning
            Index i2 = ^4; // number 4 from end
            int[] a = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Console.WriteLine($"{a[i1]}, {a[i2]}"); // "3, 6"

            string[] names =
            {
                "mary", "john", "vikram", "julia", "rita"
            };

            foreach (var name in names[1..^0])
            {
                Console.WriteLine(name);
            }


        }
    }
}
