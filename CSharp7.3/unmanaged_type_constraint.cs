using System.IO;
using System.Security.Cryptography;

namespace csharp_features.CSharp7._3
{

    //New "unmanaged" word as a constraint.
    //A type MUST be a struct and ALL fields must be one of:
    // sbyte, byte, short, ushort, int, uint, long, 
    // ulong, char, float, double, decimal, bool, IntPtr or UIntPtr.
    // enum, pointer


    // Unmanaged type
    struct UnmanagedPoint
    {
        int X;
        int Y { get; set; }
    }

    // Not an unmanaged type
    struct Student
    {
        string FirstName;
        string LastName;
    }


    class unmanaged_type_constraint
    {

        public static void RunMe()
        {
            ComputeHash(new UnmanagedPoint()); // Meets criteria 
            ComputeHash(42); // Same
            //ComputeHash(new Student());
            //ComputeHash("hello"); // Error: Type string does not satisfy the unmanaged constraint
        }

        public static unsafe byte[] ComputeHash<T>(T data) where T : unmanaged
        {
            byte* bytes = (byte*)(&data);
            using (var sha1 = SHA1.Create())
            {
                var size = sizeof(T);
                using (var ms = new UnmanagedMemoryStream(bytes, size))
                {
                    return sha1.ComputeHash(ms);
                }
            }
        }
    }
}
