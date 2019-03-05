using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_7.CSharp6
{
    public class Attendees
    {
        public Attendees()
        {
            //Old
            var list = new Dictionary<int, Attendee>();
            list.Add(1029188, new Attendee() { FirstName = "Ravi", LastName = "Shankaran" });

            //New
            var attendees = new Dictionary<int, Attendee>
            {
                [181212] = new Attendee { FirstName = "Mary", LastName = "Jones" },
                [2121] = new Attendee { FirstName = "Doogie", LastName = "Abbott" },
                [312412] = new Attendee { FirstName = "Lemon", LastName = "McOrangeFace" }
            };
        }
    }

    public class Attendee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
