using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_7.CSharp7._1
{
    class async_main
    {

        //Previously
        static void OLDMain(string[] args)
        {
            // Start a task - calling an async function in this example
            Task<string> callTask = Task.Run(() => CallHttp());
            // Wait for it to finish
            callTask.Wait();
            // Get the result
            string astr = callTask.Result;
            // Write it our
            Console.WriteLine(astr);
        }

        static public async Task<string> CallHttp()
        {
            // Just a demo.  Normally my HttpClient is global (see docs)
            HttpClient aClient = new HttpClient();
            // async function call we want to wait on, so wait
            string astr = await aClient.GetStringAsync("http://microsoft.com");
            // return the value
            return astr;
        }

#if CSharp71


        static async Task Main() 
        {
             using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(@"https://api.nasa.gov/planetary/apod");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // You don't need await here
                var result = await client.GetStringAsync("?concept_tags=True&api_key=DEMO_KEY");
            }
        }

        static Task<int> Main() => null;

        static Task Main(string[]) => null;

        static Task<int> Main(string[]) => null;
#endif
    }
}
