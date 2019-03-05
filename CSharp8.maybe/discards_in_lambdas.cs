using System.Collections.Generic;

namespace csharp_features.CSharp8.maybe
{
    //Not technically a 7.3 feature
    //https://github.com/dotnet/csharplang/issues/111
    class discards_in_lambdas
    {
        public void Run()
        {
            //contrived example
            //we can currently do this. _ is treated as variable name - its a convention
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            int counter = 0;
            //This works, its valid
            //var _ = 600;

            list.ForEach(_ => { counter++; });


            //Coming ... _ in lambdas meaning truly "I dont care"
            //Func<int, int, int> zero = (_, _) => 0;
        }
    }
}
