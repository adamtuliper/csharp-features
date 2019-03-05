using System;
using System.Linq;

namespace c_sharp_7.CSharp7._3
{

    public class SomeBase
    {
        //1. Outvar in field initializer
        public static int Magic = int.TryParse("123", out var i) ? i : 0;

        //2. Out var in constructor
        public SomeBase(int i, out int j)
        {
            j = i;
        }

        //3 Query clauses
        void OutVarsInQueries()
        {
            var content = new string[] {"1", "2", "3"};

            var r = from s in content
                    select int.TryParse(s, out var i);
        }
    }

    public class SomeClass : SomeBase
    {
        public SomeClass(int i) : base(i, out int j)
        {
            Console.WriteLine($"The value of 'j' is {j}");
        }
    }

    //Thanks JetBrains
    //https://blog.jetbrains.com/dotnet/2018/07/12/declaration-expressions-in-initializers-and-queries/
    public class DeclarationExpressionsExample
    {
        public bool inputIsPositiveNumber = int.TryParse(ReadString(), out int input) && input > 0;

        public bool ObjectIsPositiveNumber { get; } = ReadObject() is string str
                                                    && int.TryParse(str, out int input)
                                                    && input > 0;

        public static string ReadString() => Console.ReadLine();
        public static object ReadObject() => Console.ReadLine();
    }

}
