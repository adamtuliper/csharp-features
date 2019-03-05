using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_7.CSharp7._1
{
    class tuple_mixing_fresh_and_existing_deconstruction
    {
        public void Run()
        {
            int existingVar = 10;
#if CSharp_FUTURE
            (int newVar, existingVar) = (5, 2);
#endif
        }
    }
}
