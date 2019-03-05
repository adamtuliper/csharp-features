using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_features.CSharp7._3
{
    class enum_type_constraint
    {
        public static TEnum[] GetValues<TEnum>() where TEnum : System.Enum
        {
            return (TEnum[])Enum.GetValues(typeof(TEnum));
        }
    }
}
