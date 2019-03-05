using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_7.CSharp7._3
{
    public class array_initializer_for_stackalloc
    {
        public static void Run()
        {
            //Prior to 7.3
            byte data = 0;
            Span<byte> stackSpan = stackalloc byte[100];
            for (int ctr = 0; ctr < stackSpan.Length; ctr++)
                stackSpan[ctr] = data++;

            UnsafeStackCode();

            //Note local function is unsafe.
            unsafe void UnsafeStackCode()
            {
                int* pArr2 = stackalloc int[] { 1, 2, 4, 8 };
                //7.3 - initializers for stackalloc
                int* items = stackalloc int[] { 1, 2, 3 };

                //first int
                items[0] = 10;
                //same
                *items = 11;

                //long live the bits.
                int* mask = stackalloc[] {
                    0b_0000_0000_0000_0001,
                    0b_0000_0000_0000_0010,
                    0b_0000_0000_0000_0100,
                    0b_0000_0000_0000_1000,
                    0b_0000_0000_0001_0000,
                    0b_0000_0000_0010_0000,
                    0b_0000_0000_0100_0000,
                    0b_0000_0000_1000_0000,
                    0b_0000_0001_0000_0000,
                    0b_0000_0010_0000_0000,
                    0b_0000_0100_0000_0000,
                    0b_0000_1000_0000_0000,
                    0b_0001_0000_0000_0000,
                    0b_0010_0000_0000_0000,
                    0b_0100_0000_0000_0000,
                    0b_1000_0000_0000_0000
                };

                //Did you know? If you buffer overrun, proc will terminate.
                for (int i = 0; i < 16; i++)
                    Console.WriteLine(mask[i]);

                //Terminate after we dump a bunch of our stack.
                //Windows CLR stacks are around 1MB
                for (int i = 0; i < 4 * 1024 * 1024; i++)
                {
                    //This will eventually crash.
                    //It's UNSAFE code.
                    var temp = mask[i];
                }
                    

            }
        }
    }
}
