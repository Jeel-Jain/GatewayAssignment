using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace SourceControlAssignment1
{
    public class GlobleVariables
    {
        public static HttpClient WebApiClient = new HttpClient();
        static GlobleVariables()
        {
            WebApiClient.BaseAddress = new Uri("https://localhost:44385/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    
}
}