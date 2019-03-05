using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_7.CSharp8
{

    //Eventually
#if CSharp8
    interface ILogger
    {
        void Log(LogLevel level, string message);
        void Log(Exception ex) => Log(LogLevel.Error, ex.ToString()); // New overload
    }

    internal enum LogLevel
    {
        None,
        Debug,
        Error
    }

    class ConsoleLogger : ILogger
    {
        public void Log(LogLevel level, string message)
        {
            throw null;
        }

        // Log(Exception) gets default implementation
    }
#endif
}
