using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace c_sharp_7.CSharp7
{
    public static class OutVars
    {
        public static void Process()
        {

            Console.WriteLine("What's the answer to life the universe and everything  (hint its 42)");
            var input = Console.ReadLine();

            int orderId;
            if (int.TryParse(input, out orderId)) { }

            //** Note new formatting options when you format doc
            //Must enable in Text Editor / C# / Code Style / Formatting / General
            //Or search for 'cleanup' in quick launch
            int customerId; 
            if (int.TryParse(input, out customerId)) { }



            //locally (in the function) scoped
            //can also use: var int answer
            if (int.TryParse(input, out var answer))
            {
                if (answer == 42)
                {
                    Draw();
                }

            }

            //available outside of if()
            answer++;

            //Out vars can be used anywhere you need out variables
            GetMonthAndYear(out string month, out string year);

            //I don't really care about the year
            GetMonthAndYear(out string theMonth, out _);
        }

        private static void GetMonthAndYear(out string month, out string year)
        {
            Console.WriteLine("Enter the month");
            month = Console.ReadLine();
            Console.WriteLine("Enter the year");
            year = Console.ReadLine();
        }




        //http://stackoverflow.com/questions/2725529/how-to-create-ascii-animation-in-windows-console-application-using-c
        static void ConsoleDraw(IEnumerable<string> lines, int x, int y)
        {
            if (x > Console.WindowWidth) return;
            if (y > Console.WindowHeight) return;

            var trimLeft = x < 0 ? -x : 0;
            int index = y;

            x = x < 0 ? 0 : x;
            y = y < 0 ? 0 : y;

            var linesToPrint =
                from line in lines
                let currentIndex = index++
                where currentIndex > 0 && currentIndex < Console.WindowHeight
                select new
                {
                    Text = new String(line.Skip(trimLeft).Take(Math.Min(Console.WindowWidth - x, line.Length - trimLeft)).ToArray()),
                    X = x,
                    Y = y++
                };

            Console.Clear();
            foreach (var line in linesToPrint)
            {
                Console.SetCursorPosition(line.X, line.Y);
                Console.Write(line.Text);
            }
        }

        static void Draw()
        {
            Console.CursorVisible = false;

            var arr = new[]
            {
            @"        ________________.  ___     .______  ",
            @"       /                | /   \    |   _  \",
            @"      |   (-----|  |----`/  ^  \   |  |_)  |",
            @"       \   \    |  |    /  /_\  \  |      /",
            @"  .-----)   |   |  |   /  _____  \ |  |\  \-------.",
            @"  |________/    |__|  /__/     \__\| _| `.________|",
            @"   ____    __    ____  ___     .______    ________.",
            @"   \   \  /  \  /   / /   \    |   _  \  /        |",
            @"    \   \/    \/   / /  ^  \   |  |_)  ||   (-----`",
            @"     \            / /  /_\  \  |      /  \   \",
            @"      \    /\    / /  _____  \ |  |\  \---)   |",
            @"       \__/  \__/ /__/     \__\|__| `._______/"
 };

            var maxLength = arr.Aggregate(0, (max, line) => Math.Max(max, line.Length));
            var x = Console.BufferWidth / 2 - maxLength / 2;
            for (int y = -arr.Length; y < Console.WindowHeight + arr.Length; y++)
            {
                ConsoleDraw(arr, x, y);
                Thread.Sleep(50);
            }
        }
    }
}

