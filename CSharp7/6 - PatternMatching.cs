using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace c_sharp_7.CSharp7
{
    public interface IShape
    {
        double GetArea();
    }

    public struct Square
    {
        public double Side { get; }

        public Square(double side)
        {
            Side = side;
        }
    }

    public class Circle : IShape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; set; }

        public double GetArea()
        {
            return Math.PI * (Radius * Radius);
        }
    }
    class Rectangle : IShape
    {

        public Rectangle(double length, double height)
        {
            Length = length;
            Height = height;
        }

        public double Length { get; set; }
        public double Height { get; set; }
        public double GetArea()
        {
            return Length * Height;
        }
    }
    public class PatternMatching
    {
        /* https://github.com/dotnet/roslyn/blob/future/docs/features/patterns.md
            pattern
                : type_pattern        Tests and casts if succeeds into new local variable
                | constant_pattern    Constant check either a==b (integral types) or object.Equals(a, b)
                | wildcard_pattern
                | var_pattern
                | recursive_pattern
                ;
        */
        //Notice we'll get autocomplete suggestions to generate properties too
        //ex when Length or Height doesn't exist, right click on them in: case Rectangle s when (s.Length == s.Height):
        public void MatchSomething(IShape shape)
        {

            // Previously on Lost & battlestar galactica....
            // if/is with variables
            if (shape is Rectangle)
            {
                var rectangle = shape as Rectangle;
                var rectArea = rectangle.GetArea();
            }
            else if (shape is Circle)
            {
                var circle = shape as Circle;
                var circleArea = circle.Radius * circle.Radius * Math.PI;
            }




            if (shape is Rectangle rect)
            {
                //I only care about a rectangle
                Console.WriteLine($"Rectangle {rect.GetArea()}");
            }
            //Note rect is valid but may be null
            //rect.Length++;
            //Since is does variable 
            if (shape.GetArea() is var theArea && theArea > 5)
            {
                WriteLine($"Area is >5 {theArea}");
            }
            Console.WriteLine(theArea);
            switch (shape)
            {
                //case Square s:
                    //not a shape!!

                case Circle c:
                    WriteLine($"Circle with radius {c.Radius}");
                    break;
                case IEnumerable<int> ieInt:
                    WriteLine("IEnumerable<int>");
                    break;
                case Rectangle s when (s.Length == s.Height):
                    WriteLine($"Square {s.Length} x {s.Height}");
                    break;
                case Rectangle r:
                    WriteLine($"Rectangle {r.Length} x {r.Height}");
                    break;
                case null:
                    //we're null or empty
                    throw new ArgumentNullException(nameof(shape));
                default: //Executed last - always.
                    WriteLine("<unknown shape>");
                    break;
                
            }
            
        }


        /// <summary>
        /// Prints a number
        /// </summary>
        /// <param name="o"></param>
        public void PrintStars(object o)
        {
            if (o is null) return;     // constant pattern "null"
            if (o == null) return;     // not the same - why?

            /* Ignore, future 'to investigate' note
             * Why the extra moves to memory? Seems we could just movzx eax,eax since al contains 0 or 1
                        if (o is null) return;     // constant pattern "null"
            02C4338F 8B 4D C0             mov         ecx,dword ptr [ebp-40h]  
            02C43392 33 D2                xor         edx,edx  
            02C43394 E8 37 9A 29 70       call        72EDCDD0  
            02C43399 89 45 88             mov         dword ptr [ebp-78h],eax  
            02C4339C 0F B6 45 88          movzx       eax,byte ptr [ebp-78h]  
            02C433A0 89 45 BC             mov         dword ptr [ebp-44h],eax  
            02C433A3 83 7D BC 00          cmp         dword ptr [ebp-44h],0  
            02C433A7 74 06                je          02C433AF  
            02C433A9 90                   nop  
            02C433AA E9 89 02 00 00       jmp         02C43638  
                        if (o == null) return;     // not the same
            02C433AF 83 7D C0 00          cmp         dword ptr [ebp-40h],0  
            02C433B3 0F 94 C0             sete        al  
            02C433B6 0F B6 C0             movzx       eax,al  
            02C433B9 89 45 B8             mov         dword ptr [ebp-48h],eax  
            02C433BC 83 7D B8 00          cmp         dword ptr [ebp-48h],0  
            02C433C0 74 06                je          02C433C8  
            02C433C2 90                   nop  
            02C433C3 E9 70 02 00 00       jmp         02C43638  
            */
            //Previously valid way to get an int or string number
            //and initialize string from it

            //If int, write that many *s
            if (o is int)
            {
                WriteLine(new string('*', (int)o));
            }

            //also can avoid cast above and use a new var
            if (o is int j)
            {
                WriteLine(new string('*', j));

            }
            else
            {
                WriteLine("Not an int");
                return; // type pattern "int i" 
            }

            //All in one
            if (o is int i || (o is string s && int.TryParse(s, out i)))
            {
                WriteLine(new string('*', i));
            }


            //If string, parse. Note use of outvars as 'count' (could use int count as well)
            if (o is string)
            {
                if (int.TryParse((string)o, out var counter))
                {
                    WriteLine(new string('*', counter));
                }
            }


            //But we want to be smarter about multiple types
            if (o is int count || (o is string input && int.TryParse(input, out count)))
            {
                //note we'll always use the int value here based on expression above.
                WriteLine(new string('*', count));
            }


            //Uncomment and see issue
            //if (!(o is int k1))
            //{
            //    //Note this syntax will yield i never as an int, so we can't access it
            //    //if you uncomment you'll see compile error on k1 being unassigned, though 
            //    //if ! is removed up top it works since the expression could evaluate to true
            //    WriteLine(k1);
            //}


        }
    }
}
