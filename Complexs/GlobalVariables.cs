using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Complexs
{
    public class GlobalVariables
    {
        public static HttpClient WepApiClient = new HttpClient();

        static GlobalVariables()
        {
            WepApiClient.BaseAddress = new Uri("https://localhost:44372/api");
            WepApiClient.DefaultRequestHeaders.Clear();
            WepApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}