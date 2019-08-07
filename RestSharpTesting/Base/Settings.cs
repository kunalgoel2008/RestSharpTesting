using RestSharp;
using RestSharpTesting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTesting.Base
{
    public class Settings
    {
        public Uri BaseUrl { get; set; }
        public IRestResponse<Posts> Response { get; set; } 
        public IRestRequest Request { get; set; }
        public RestClient Client { get; set; } = new RestClient();

        public int StatusCode { get; set; }
    }
}
