using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_features.MiscImportant
{
    class SpanGoodness
    {
        public static void SpanWork()
        {
            string contentLength = "content-length:123";

            //WARNING: If .NET Framework: Install-Package System.Memory -Version 4.5.0-preview1-26216-02
            //As of 4.7.2 package is included automatically (No System.Memory required, though earlier versions need it)


            //This allocates
            int length = int.Parse(contentLength.Substring(15));

            //This doesn't!! Note it returns a ReadOnlySpan
            //Also note mouse-over yields the string :)
            ReadOnlySpan<char> output = contentLength.AsSpan().Slice(15);

            //ToString DOES allocate
            //https://github.com/dotnet/coreclr/blob/master/src/System.Private.CoreLib/shared/System/ReadOnlySpan.Fast.cs
            /*
             *
            public override string ToString()
            {
                if (typeof(T) == typeof(char))
                {
                    unsafe
                    {
                        fixed (char* src = &Unsafe.As<T, char>(ref _pointer.Value))
                            return new string(src, 0, _length);
                    }
                }
                return string.Format("System.ReadOnlySpan<{0}>[{1}]", typeof(T).Name, _length);
            }
             */
            Console.WriteLine(output.ToString());


            //Fixed record processing
            string name = "MARY      DOE       ";
            var span = name.AsSpan();
            //Allocates
            string firstNameAlloc = name.Substring(startIndex: 0, length: 10);

            //No allocation. Can write directly to (for ex) file
            var firstNameChars = span.Slice(start: 0, length: 10);

        }

    }
}
