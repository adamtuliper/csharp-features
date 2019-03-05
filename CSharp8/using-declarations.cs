using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace csharp_features.CSharp8
{
    class using_declarations
    {
        static void Process(string[] args)
        {
            using var sr = new StreamReader("file1.txt");
            
        } // options disposed here
    }
}
