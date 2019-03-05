using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_7.CSharp7._3
{
    //https://github.com/dotnet/csharplang/issues/190
    class tuples_equality
    {
        public static void Run()
        {
            var tuple1 = (15, 20);
            var tuple2 = (15, 20);
            var tuple3 = (15, 10);
            
            //existing in 7.0 
            if (tuple1.Equals(tuple2))
            {
                //This is true
                Console.WriteLine("Equals");
            }

            //Shallow equality checking
            //New to 7.3
            if (tuple1 == tuple2)
            {
                Console.WriteLine(("Equals"));
            }


            int x = 1;
            int y = 2;

            //New to 7.3
            if ((x, y) == (1, 2))
            {
                Console.WriteLine("Equals");
            }

        }
    }
}
