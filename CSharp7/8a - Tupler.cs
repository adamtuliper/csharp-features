using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_7.CSharp7
{
    public class Tupler
    {


        /* A WARNING ***********************************
         

                Don't return tuples for public apis 
                You can. Don't.

        ************************************************/







        public void Tally(IEnumerable<int> values, out int sum, out int count)
        {
            sum = 1;
            count = 5;

        }

        public void DoTally(IEnumerable<int> myValues)
        {
            int s, c;
            Tally(myValues, out s, out c);
            Console.WriteLine($"Sum: {s}, count: {c}");
        }

        
        //in REPL to include library reference
        //#r     \c sharp 7\packages\System.ValueTuple.4.0.0-rc3-24212-01\lib\netstandard1.1\System.ValueTuple.dll

        /// <summary>
        /// Azure portal URL.
        /// </summary>
        private const string BaseUrl = "https://westus.api.cognitive.microsoft.com/";
        //private const string BaseUrl = "https://westus2.api.cognitive.microsoft.com/";
        

        /// <summary>
        /// Your account key goes here. This is for the text analytics service.
        /// Use your own key. This is a demo key and will expire shortly.
        /// As of now, you can get keys here (though that may change location) and they can take 10 mins or so to become active
        /// https://www.microsoft.com/cognitive-services/en-us/subscriptions?displayClass=subscription-free-trials
        /// </summary>
        private const string AccountKey = "8ed8046b1787417695ed4ab6d840ad47";

        /// <summary>
        /// Maximum number of languages to return in language detection API.
        /// </summary>
        private const int NumLanguages = 1;

        public async static Task<(string keyPhrases, string language, string sentiment)> ProcessLanguage()
        {

            //No workie - as we're not creating a,b,c, we're creating a tuple named results, hence dont need internal var
            //(var a, var b, var c) results = await MakeRequests();
            //This would work though
            //(string a, string b, string c) results = await MakeRequests();

            var result = await MakeRequests();

            return result;



        }

        static async Task<(string keyPhrases, string language, string sentiment)> MakeRequests()
        {

            //Note usage of default. You can't use 'new' with a tuple type
            var responses = default((string keyPhrases, string languages, string sentiment));

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                // Request headers.
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", AccountKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Request body. Insert your text data here in JSON format.
                byte[] byteData = Encoding.UTF8.GetBytes("{\"documents\":[" +
                    "{\"id\":\"1\",\"text\":\"hello world\"}," +
                    "{\"id\":\"2\",\"text\":\"hello foo world\"}," +
                    "{\"id\":\"three\",\"text\":\"hello my world\"},]}");

                // Detect key phrases
                var uri = "text/analytics/v2.0/keyPhrases";
                var response = await CallEndpoint(client, uri, byteData);
                Console.WriteLine("\nDetect key phrases response:\n" + response);
                responses.keyPhrases = response;

                // Detect language
                uri = "text/analytics/v2.0/languages?numberOfLanguagesToDetect=1";
                response = await CallEndpoint(client, uri, byteData);
                Console.WriteLine("\nDetect language response:\n" + response);
                responses.languages = response;

                // Detect sentiment
                uri = "text/analytics/v2.0/sentiment";
                response = await CallEndpoint(client, uri, byteData);
                Console.WriteLine("\nDetect sentiment response:\n" + response);
                responses.sentiment = response;


                //Return tuple
                return responses;
            }
        }

        static async Task<String> CallEndpoint(HttpClient client, string uri, byte[] byteData)
        {

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(uri, content);
                return await response.Content.ReadAsStringAsync();
            }
        }


    }
}
