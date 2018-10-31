using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft;


namespace DailyActivityProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            string DailyActivityGoogleFormUrl = "your google form url goes here";

            PostToGoogleForm(DailyActivityGoogleFormUrl).Wait();
        }

        private static async Task PostToGoogleForm(string url)
        {
            try
            {
                var client = new HttpClient();
                var table = new Dictionary<string, string>
                {
                    { "entry.2005620554", "NAME INPUT1" },
                    { "entry.1045781291", "EMA2ILINPUT@em.com" },
                    { "entry.1065046570", "Address INPUT2" },
                    { "entry.1166974658", "PHONE INPUT3" },
                    { "entry.839337160", "Comments INPUT4" }
                };
                var formContent = new FormUrlEncodedContent(table);
                var response = await client.PostAsync(url, formContent).ConfigureAwait(false);
                Console.WriteLine(response.Headers.ToString());
                Console.WriteLine("SENDING SUCCESSFULLY: " + response.IsSuccessStatusCode.ToString().ToUpper());
                Console.ReadLine();


            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR CHECK OUT: ", ex);
                Console.ReadLine();

            }
        }

        private static void CollectDataForPost()
        {

        }
   
    }
}

//function loop(e)              javascrpt code for finding the names of input fields
//{
//    if (e.children)
//        for (let i = 0; i < e.children.length; i++)
//        {
//            let c = e.children[i], n = c.getAttribute('name');
//            if (n) console.log(`${ c.getAttribute('aria-label')}: ${ n}`);
//    loop(e.children[i]);
//}
//}; loop(document.body);