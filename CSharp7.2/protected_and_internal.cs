using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/private-protected
public class BaseClass
{

    //For context: 
    //We had 
    //protected internal int myValue = 0;
    //This was EITHER derived classes OR internal.

    //limits access to only derived types AND types must
    //be declared in the same assembly (ie internal)
    private protected int myValue = 0;
}


public class DerivedClass1 : BaseClass
{
    void Access()
    {
        BaseClass baseObject = new BaseClass();

        // Error CS1540, because myValue can only be accessed by
        // classes derived from BaseClass.
         //baseObject.myValue = 5;  



        // OK, accessed through the current derived class instance
        //HOWEVER this CANNOT be accessed by a derived class in another assembly.
        myValue = 5;
    }
}
