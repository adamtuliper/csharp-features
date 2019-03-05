using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_7.CSharp7._2
{
    class in_keyword
    {

        //Differs only by ref/in/out. No can do.But can do byval and in
        //At compile time treated the same
        //private static void Test(ref PlayerData playerData) => throw null;
        private static void Test(in PlayerData playerData) => throw null;
        private static void Test(PlayerData playerData) => throw null;


        public void Main()
        {
            PlayerData playerData = new PlayerData();

            Test(playerData);
            //Using in at call site forces Test(in) to be used.
            //Without the overloads, in isn't required.
            Test(in playerData);
        }

        //.method private hidebysig static void  PassStructByRef(valuetype ConsoleApp2.PlayerData& playerData) cil managed
        private static void PassStructByRef(ref PlayerData playerData)
        {
            playerData.Health = 100;
            Console.WriteLine(playerData.Health);
        }

        //.method private hidebysig static void  PassStructByIn([in] valuetype ConsoleApp2.PlayerData& playerData) cil managed
        //{
        //  //Note the local readonly variable created
        //  .param[1]
        //  .custom instance void[System.Runtime] System.Runtime.CompilerServices.IsReadOnlyAttribute::.ctor() = ( 01 00 00 00 ) 

        private static void PassStructByIn(in PlayerData playerData)
        {
            //no can do 
            //playerData.Health = 100;
            Console.WriteLine(playerData.Health);
        }

        //Now note that a local variable is created. 
        private static void PassStructByIn<T>(in T genericType) 
        {
            Console.WriteLine(genericType);
        }

        public void Process(in string name)
        {

            // out: we set the argument value to return
            // ref: we can change the argument value passed by ref
            // in:  expresses intent that a method won't change it.READONLY

            //Can't send it to anything that has "ref" or "out" either.
            // this fails:   
            //DoSomething(out name);
            //OK
            //DoSomething(name);
            Console.WriteLine(name);

            //CS8331 Cannot assign to variable 'in string' because it is a readonly variable 
            //name = "Jane";

        }

        public void DoSomething(ref string name)
        {
            Console.WriteLine(name);
        }
    }
}
