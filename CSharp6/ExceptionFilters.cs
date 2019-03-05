using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_7.CSharp6
{
    public class ExceptionFilters
    {
        public void Process()
        {
            try
            {
                CalculateHealth();
            }
            //Custom exception types
            catch (HealthException ex) when (ex.HealthExceptionId == 10)
            {
                //
            }
            catch (Exception ex) when (Log(ex, "An error occurred"))
            {
                // never reached, but exception logged without an unwind.
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                System.Diagnostics.Debugger.Break();
            }

        }

        private void CalculateHealth()
        {
            int health = 100;
            int heatIndex = 0;

            health = health / heatIndex;
        }

        static bool Log(Exception ex, string message, params object[] args)
        {
            Console.WriteLine(message + ex.ToString(), args);
            return false;
        }
    }

    [Serializable]
    internal class HealthException : Exception
    {
        public HealthException()
        {
        }

        public HealthException(string message) : base(message)
        {
        }

        public HealthException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HealthException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public int HealthExceptionId { get; internal set; }
    }
}

