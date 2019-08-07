using NUnit.Framework;
using RestSharp;
using RestSharpTesting.Base;
using RestSharpTesting.Model;
using RestSharpTesting.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace RestSharpTesting.Steps
{
    [Binding]
    class GetUserSteps
    {
        private Settings _settings;
        public GetUserSteps(Settings settings)
        {
            _settings = settings;
        }

        //public RestClient client = new RestClient("http://localhost:63812/");
        //public RestRequest request = new RestRequest();
        //public IRestResponse<Posts> response = new RestResponse<Posts>();

        [Given(@"I perform GET operation for ""(.*)""")]
        public void GivenIPerformGETOperationFor(string url)
        {
            _settings.Request = new RestRequest(url, Method.GET);
        }

        [Given(@"I perform operation for ID ""(.*)""")]
        public void GivenIPerformOperationForID(String userID)
        {
            _settings.Request.AddUrlSegment("id", userID);
            _settings.Response = _settings.Client.Execute<Posts>(_settings.Request);//.GetAwaiter().GetResult();

        }

        [Then(@"I should see the ""(.*)"" as ""(.*)""")]
        public void ThenIShouldSeeTheAs(String key, int value)
        {
            _settings.StatusCode = (int)_settings.Response.StatusCode;
            Assert.That(_settings.StatusCode, Is.EqualTo(value), $"The {key} is not {value}");
        }

        [Given(@"I execute operation")]
        public void GivenIPerformGETOperation()
        {
            _settings.Response = _settings.Client.Execute<Posts>(_settings.Request);
        }

        [Given(@"I perform POST operation for ""(.*)""")]
        public void GivenIPerformPOSTOperationFor(string url)
        {
            _settings.Request = new RestRequest(url, Method.POST);
        }


    }
}
