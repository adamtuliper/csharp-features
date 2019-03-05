using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_7.CSharp7
{
    class GeneralizedAsync
    {
        private DateTime _lastUpdate;
        private decimal _lastQuote;

        //Also it can be used for sync or async code ala https://stackoverflow.com/documentation/c%23/1936/c-sharp-7-0-features/28612/valuetaskt#t=201703232043300985004



        public async Task<decimal> GetStockQuoteA<T>()
        {

            if (DateTime.Now.Subtract(_lastUpdate).TotalMilliseconds < 2000)
            {
                return _lastQuote;
            }

            //Here we ALWAYS return a full task object.
            //Requires heap allocation
            //Takes 120ns with JIT
            var quote = await new HttpClient().GetStringAsync("http://quotes");
            return decimal.Parse(quote);
        }

        //Requires package System.Threading.Tasks.Extensions

        public async ValueTask<decimal> GetStockQuoteB()
        {
            //No heap allocation if the result is known synchronously (here it is)
            //Takes 65ns with JIT
            if (DateTime.Now.Subtract(_lastUpdate).TotalMilliseconds < 2000)
            {
                return _lastQuote;
            }
            else
            {
                _lastUpdate = DateTime.Now;
                var quote = await new HttpClient().GetStringAsync("http://quotes");
                _lastQuote = decimal.Parse(quote);
                return _lastQuote;
            }

        }


        /* Demo 2 */
        public ValueTask<int> CachedFunc()
        {
            return (cache) ? new ValueTask<int>(cacheResult) : new ValueTask<int>(LoadCache());
        }
        private bool cache = false;
        private int cacheResult;
        private async Task<int> LoadCache()
        {
            // simulate async work:
            await Task.Delay(100);
            cache = true;
            cacheResult = 100;
            return cacheResult;
        }
    }
}
