using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_7.CSharp6
{
    public class IndexInitializer
    {
        public void InitIt()
        {
            //Same old
            var intList = new List<int>(5) { 1, 2, 3, 4, 5 };

            //New
            var intList2 = new List<int>(5) { [4] = 5 };
        }
    }
}
