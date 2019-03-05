using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_7.CSharp7._2
{
    class Span_T
    {
        public void Process()
        {
            string contentLength = "content-length:123";
            //Preview package now, System.Memory

            int length = int.Parse(contentLength.Substring(15)); // this allocates

            var output = contentLength.AsSpan().Slice(15);

            
             
        //public struct Span<T>
        //{
        //    internal IntPtr _pointer;
        //    internal object _relocatableObject;
        //    internal int _length;
        //}
    }


    }
   

}
