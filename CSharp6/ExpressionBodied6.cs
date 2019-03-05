using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6
{
    public class ExpressionBodied6
    {
        public class Zombie
        {
            public Zombie(string name, int health)
            {
                Name = name;
                Health = health;
            }
            public string Name { get; set; }
            public int Health { get; set; }

            //public override string ToString()
            //{
            //    return $"Name: {Name}, Health: {Health}";
            //}

            public override string ToString() =>  $"Name: {Name}, Health: {Health}";
        }
    }
}
