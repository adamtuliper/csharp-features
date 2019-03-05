using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_7.CSharp7
{
    public class DigitAndBinary
    {

        [Flags]
        enum Colors
        {
            Red =    0b1,
            Green = 0b10,
            Blue = 0b100
        }

        enum IncorrectColors
        {
            Red,          //Get 0
            Green,        //Gets 1
            Blue = 0b100  //Gets 2
        }

        public static void Process1()
        {

            //var errorCode = 0x8000ffff;
            //throw new Exception("An unknown error has occurred");

            var sb = new StringBuilder();
            
            Int32 bytes1 = 0b01001000_01100101_01101100_01101100;
            Int32 bytes2 = 0b01101111_00100000_01010111_01101111;
            Int32 bytes3 = 0b01110010_01101100_01100100;

            sb.Append((char)((bytes1 & 0xFF000000) >> 24));
            sb.Append((char)((bytes1 & 0x00FF0000) >> 16));
            sb.Append((char)((bytes1 & 0x0000FF00) >> 8));
            sb.Append((char)((bytes1 & 0x000000FF)));


            sb.Append((char)((bytes2 & 0xFF000000) >> 24));
            sb.Append((char)((bytes2 & 0x00FF0000) >> 16));
            sb.Append((char)((bytes2 & 0x0000FF00) >> 8));
            sb.Append((char)((bytes2 & 0x000000FF)));

            sb.Append((char)((bytes3 & 0x00FF0000) >> 16));
            sb.Append((char)((bytes3 & 0x0000FF00) >> 8));
            sb.Append((char)((bytes3 & 0x000000FF)));


            Console.WriteLine(sb.ToString());
            Console.ReadLine();
        }

        public static void Process()
        {
            var sb = new StringBuilder();

            //separator can be used in various places.
            long age_of_universe = 13_082_000_001;
            Console.WriteLine(age_of_universe);


            //Binary literal (with separator)
            Int32 bytes1 = 0b01001000_01100101_01101100_01101100;
            Int32 bytes2 = 0b01101111_00100000_01010111_01101111;
            Int32 bytes3 = 0b01110010_01101100_01100100;

            sb.Append((char)((bytes1 & 0xFF000000) >> 0x18));
            sb.Append((char)((bytes1 & 0x00FF0000) >> 0b10000));
            sb.Append((char)((bytes1 & 0x0000FF00) >> 8));
            sb.Append((char)((bytes1 & 0x000000FF)));

            sb.Append((char)((bytes2 & 0xFF000000) >> (6 * 0x4)));
            sb.Append((char)((bytes2 & 0x00FF0000) >> (0b100 * 4)));
            sb.Append((char)((bytes2 & 0x0000FF00) >> (2 + 5 + (0x10-0b1111))));
            sb.Append((char)((bytes2 & 0x000000FF)));

            sb.Append((char)((bytes3 & 0x00FF0000) >> 5 * 3 + 1));
            sb.Append((char)((bytes3 & 0x0000FF00) >> 2 * 2 + 4));
            sb.Append((char)((bytes3 & 0x000000FF)));


            Console.WriteLine(sb.ToString());
        }

        
    }
}
