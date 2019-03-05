using System;
using System.Collections.Generic;
using System.Text;
using csharp_features.CSharp7;

namespace csharp_features.CSharp8
{
    public class switch_changes
    {
        public void ASwitchExpression()
        {

        }

        public enum Rainbow
        {
            Red,
            Orange,
            Yellow,
            Blue,
            Indigo,
            Violet
        }

        static string Display(object o) => o switch
        {
            Point { X: 0, Y: 0 } => "origin",
            _ => "unknown"
        };

        static string Display1(object o)
        {
            switch (o)
            {
                case Point p when p.X == 0 && p.Y == 0:
                    return "origin";
                case Point p:
                    return $"({p.X}, {p.Y})";
                default:
                    return "unknown";
            }
        }

        //static string Display(object o) => o switch
        //{
        //    Point { X: 0, Y: 0 } p => "origin",
        //    Point { X: var x, Y: var y } p => $"({x}, {y})",
        //    _ => "unknown"
        //};


        public enum State
        {
            NotSet = 0,
            Opened,
            Closed,
            Locked,
        }

        public enum Transition
        {
            NotSet = 0,
            Open,
            Close,
            Lock,
            Unlock
        }


        //static State ChangeState(State current, Transition transition, bool hasKey) 
        //    =>
        //    int  switch
        //{
        //    (Opened, Close) => Closed,
        //    (Closed, Open) => Opened,
        //    (Closed, Lock) when hasKey => Locked,
        //    (Locked, Unlock) when hasKey => Closed,
        //    _ => throw new InvalidOperationException($"Invalid transition")
        //};

        //public void SwitchAdditions()
        //{
        //    var tuple = ("john", "mary");
        //    switch (tuple)
        //    {
        //        case (_, "mary") t:
        //        case var t when t == ("john", "mary"):
        //            Console.WriteLine("John/Mary");
        //            break;
        //    }
        //}
    }
}
