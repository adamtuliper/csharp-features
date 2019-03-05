using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_7.CSharp7._1
{
    class limited_nullable_enhanced_common_type
    {

        //https://github.com/dotnet/csharplang/blob/master/proposals/nullable-enhanced-common-type.md
        public void Run()
        {
            bool compare = false;

            //Scenario - Figuring out the common type when between
            // *Non nullable value type T 
            // *null literal
#if CSharp_Future
            int? result = compare ? 1 : null;
#endif

            /*
                This is expected to affect the following aspects of the language:

                the ternary expression (see above)
                implicitly typed array creation expression
                    (note arrays are ref types to null is ok here)

                inferring the return type of a lambda for type inference
                cases involving generics, such as invoking M<T>(T a, T b) as M(1, null).
            */
        }
    }
}
