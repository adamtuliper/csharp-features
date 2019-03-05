using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_7.CSharp7
{
    public static class LocalFunctions
    {

        // Lambdas create a delegate and execute it.
        // Local functions are direct methods, less memory.
        // You can call locals before defined.
        // Local functions are more efficient for the case when you want
        //   to write a function that is called only from the context of another method.
        // Lambdas? Func, Action: ref, out, pointer, or params parameters aren't supported
        //          Not valid generic, so Func<int, int> can't be used
        //Anonymous methods - can't use params in the parameter list
        //                    can't capture ref or out parameters of the enclosing method. 

        //Great discussion on 'cant we do something like this already'
        //https://github.com/dotnet/roslyn/issues/259
        public static int Fibonacci(int x)
        {
            if (x < 0) throw new ArgumentException("Fibonacci sequence must start with 0 or positive", nameof(x));


            //Note variables are available
            bool processed = false;

            //Note this is a value on the tuple
            return Fib(x).current;


            (int current, int previous) Fib(int i)
            {
                Debug.WriteLine($"Processed:{processed}");
                System.Diagnostics.Debug.WriteLine(x);
                if (i == 0) return (1, 0);
                Console.WriteLine($"Calling with {i-1}");
                var (p, pp) = Fib(i - 1);
                Console.WriteLine((p + pp, p));
                return (p + pp, p);
            }
            
        }

        static public void QuickSort(int[] items, int left, int right)
        {
            // For Recursion
            if (left < right)
            {
                int pivot = Partition(items, left, right);

                if (pivot > 1)
                    QuickSort(items, left, pivot - 1);

                if (pivot + 1 < right)
                    QuickSort(items, pivot + 1, right);
            }


            int Partition(int[] numbers, int start, int end)
            {
                int pivot = numbers[start];
                while (true)
                {
                    while (numbers[start] < pivot)
                        start++;

                    while (numbers[end] > pivot)
                        end--;

                    if (start < end)
                    {
                        int temp = numbers[end];
                        numbers[end] = numbers[start];
                        numbers[start] = temp;
                    }
                    else
                    {
                        return end;
                    }
                }
            }
        }
    

       
        public static int LocalFunctionFactorial(int n)
        {
            //can call before defined
            return nthFactorial(n);


            int nthFactorial(int number) => (number < 2) ?
                1 : number * nthFactorial(number - 1);
        }

        //Examine with dotpeek - extra baggage
        public static int LambdaFactorial(int n)
        {
            //Must declare first, then call
            Func<int, int> nthFactorial = default(Func<int, int>);
            nthFactorial = (number) => (number < 2) ?
                1 : number * nthFactorial(number - 1);
            return nthFactorial(n);
        }
    }
}
