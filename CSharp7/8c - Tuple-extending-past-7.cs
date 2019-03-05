using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_7.CSharp7._1
{
    class tuple_extending_past_7
    {
        //This example just shows what happens when you have
        //a tuple over 7 items. Item 8+ is a nested tuple in the IL
        //Just something interesting :)
        public void LongTuples()
        {
            //Let's dotpeek this.
            //Note ildasm, element 8 over is a nested tuple declaration
            /*
              IL_002c:  call       instance void valuetype [System.ValueTuple]System.ValueTuple`8<int32,int32,int32,int32,int32,int32,int32,valuetype [System.ValueTuple]System.ValueTuple`5<int32,int32,int32,int32,int32>>::.ctor(!0,
                                                                                                                                                                                                                                                !1,
            */
            var longTuple = (1, 2, 3, 4, 5, 6, 7, 8);
                        var longerTuple = (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
                    }
                }
            }
