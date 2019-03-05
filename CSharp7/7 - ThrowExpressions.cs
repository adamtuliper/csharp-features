using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp7
{
    public class Person
    {

        private string _name = String.Empty;
        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException();
        }
        public int Age { get; set; }

        public Person()
        {

        }
        //Previously we didn't support throwing exceptions on expression bodied items.
        public Person(string name) => Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(name) : name;



        public string GetFirstName()
        {
            var parts = Name.Split(' ');
            return (parts.Length > 0) ? parts[0] : throw new InvalidOperationException("No name!");
        }

        //Note we use the throw null for all ref assemblies where appropriate
        //ex https://github.com/dotnet/corefx/blob/33df5e0560f006e8298fd42b441b92b2d5eac671/src/System.Collections.Concurrent/ref/System.Collections.Concurrent.cs
        public string GetLastName() => throw new NotImplementedException();




        private ConfigResource loadedConfig = LoadConfigResourceOrDefault() ??
            throw new InvalidOperationException("Could not load config");



        private static ConfigResource LoadConfigResourceOrDefault()
        {
            throw new NotImplementedException();
        }

        internal class ConfigResource
        {
        }
    }
}
