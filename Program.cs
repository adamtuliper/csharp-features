using c_sharp_7.CSharp6;
using c_sharp_7.CSharp7;
using c_sharp_7.CSharp7._3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using csharp_features.CSharp7;
using csharp_features.MiscImportant;
using CSharp7;

namespace csharp_features
{
    public class Program
    {
       
        static async Task Main(string[] args)
        {
            tuples_equality.Run();
            array_initializer_for_stackalloc.Run();
            SpanGoodness.SpanWork();
            

            var result = await Tupler.ProcessLanguage();

            //Review 1 Null Conditional
            var nullConditional = new NullConditional();
            nullConditional.PurchaseProduct();

            //Nifty way of checking argument length
            switch (args?.Length)
            {
                case 1:
                    //one arg passed in
                    break;
                case 2:
                    //you get the idea
                    break;
            }


            //2 Interpolation
            Interpolation.InterpolateDemo();


            //3 Null conditional
            var nc = new NullConditional();
            nc.PurchaseProduct();

            //As you see fit...

            //*****************************************************
            //1. Binary Literal and digit separator
            DigitAndBinary.Process();

            //*****************************************************
            //2. Ref returns - pointer to a structure

            //Cannot use with async. Compiler can't know if ref'd variable is set before it returns
            var refReturns = new RefReturnsAndLocal();
            refReturns.TestRefs();

            //*****************************************************
            //3. Expression bodied accessors, constructors, destructor/finalizer
            // C# 6 
            var zombie = new CSharp6.ExpressionBodied6.Zombie("Fred", 30);
            Console.WriteLine(zombie.ToString());

            //3a. Note C#6 collection initialization
            List<Order> orders = new List<Order>() { new Order(), new Order(), new Order() };
            var processor = new OrderProcessor(orders);

            //4
            //Throw expressions - allow throw in expression bodied methods
            //                        (these could be used all throughout api stubs, like reference assemblies for compilation)
            //Also allows null coalescing (single line function calls)
            try
            {
                var person = new Person(null);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Caught throw expression:{ex}");
            }

            //*****************************************************
            //4. Local Functions
            int[] numbers = { 3, 8, 7, 5, 2, 1, 9, 6, 4 };
            LocalFunctions.QuickSort(numbers, 0, numbers.Length - 1);
            Console.WriteLine("Sorted items");
            numbers.ToList().ForEach(o => Console.WriteLine(o));

            //Ex 2
            LocalFunctions.Fibonacci(5);


            //*****************************************************
            //5. Out vars
            OutVars.Process();

            //*****************************************************
            //6. Pattern Matching

            var pm = new PatternMatching();
            pm.MatchSomething(new Circle(3.5d));
            pm.MatchSomething(new Rectangle(2d, 4d));


            //Int
            pm.PrintStars(5);

            //String
            pm.PrintStars("5");

            //Shape
            pm.PrintStars(new Rectangle(3, 4));


            //*****************************************************
            //8. Tuples

            //Now a valuetuple - NO GC PRESSURE. Stack based!

            //Lets check it out
            //https://docs.microsoft.com/en-us/dotnet/api/?view=netframework-4.6.2&term=ValueTuple
            //https://docs.microsoft.com/en-us/dotnet/api/?view=netframework-4.5&term=System.Tuple



            //Literals - note IL is optimized 
            // [130 13 - 130 53]
            // IL_01c3: ldc.i4.1
            // IL_01c4: stloc.s a
            // IL_01c6: ldc.i4.2
            // IL_01c7: stloc.s b

            var (a, b, c, c1, c2) = (1, 2, 3, 4, 5);

            //We have variables now
            var addThemUp = a + b + c;


            //Tuple compatibility with System.Tuple
            (var userName, var pass) = Tuple.Create("adam", "91281821JASJHDAHssh2#h4H#H@#Hh2h3H#H");

            //Type inference - note right hand side intellisense
            (float i, int j, int k) = (1, 2, 3);

            //named
            (int p, int q, int r) theTup = (2, 3, 4);

            theTup = (5, 6, 7);
            theTup.p = 8;

            //adam
            var adam = ("adam", "m", "tuliper");

            //123-44-1234
            (string firstName, string middleName, string lastName) cestMoi = adam;

            //If we don't care about names

            (string, string, string) stringTuple = default((string tup1, string tup2, string tup3));

            stringTuple.Item1 = "Mary";


            //var result = task.Result;


            Console.WriteLine($"{result.keyPhrases}\r\n{result.sentiment}\r\n{result.language}");


            //named type inference
            var speedAndHealth = (health: 100, speed: 10);

            //This isn't meant to be hungarian notation :)
            (int id1, int id2, int id3) t = (2, 3, 4);
            Console.WriteLine($"{t.id1} {t.id2} {t.id3}");


            //can't convert dbl to float, and also a:1 - 'a' will be ignored
            //(int a1, float b1, int c20) conversions = (a: 1, 2d, 3);


            var item = (num: 1f, count: 2f, name: "hello", person: new Person() { Name = "Mary" });
            item.Item1 = item.Item2 * item.Item1;

            //Tuple.Create("item1", "item2", "item", "item", "item", "item", "item7", Tuple.Create("item 8"))
            //     .Set(out var item1, out var item2, out var item3, out var item4, out var item5, out var item6, out var item7)
            //     .Set(out var item8);




            //8b. Deconstruction
            var point = new Point(5, 4);
            var (p1, p2) = point;

            //overloaded deconstruction
            var (x1, y1, q1) = point;

            //Note can't have a single value deconstruction or tuple
            //(int aqqqq) = (5);

            //Deconstruction, I only want one item
            (int a10, _, _, _, _) = (1, 2, 3, 4, 5);
            var (x, _) = point;

            //Equality - checks
            var (first, address) = ("1", "2");
            return;
        }
    }
}
