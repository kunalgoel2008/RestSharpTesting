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
using TechTalk.SpecFlow.Assist;

namespace RestSharpTesting.Steps
{
    [Binding]
    class PostUserSteps
    {
        private Settings _settings;
        public PostUserSteps(Settings settings)
        {
            _settings = settings;
        }
        [Given(@"I perform POST operation for ""(.*)"" with body")]
        public void GivenIPerformPOSTOperationForWithBody(string url, Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            _settings.Request = new RestRequest(url, Method.POST);
            _settings.Request.RequestFormat = DataFormat.Json;
            _settings.Request.AddBody(new Posts() {
                id = data.id,
                first_name = data.first_name.ToString(),
                last_name = data.last_name.ToString(),
                position_id = data.position_id,
                organisation_id = data.organisation_id,
                address_id = data.address_id,
                mob_no = data.mob_no.ToString(),
                alt_mob_no = data.alt_mob_no.ToString(),
                email = data.email.ToString(),
                isDeleted = data.isDeleted,
                address = new Address()
                            {
                                id = 14,
                                address_type = "6411641C-F93C-4923-8D28-21FD0F36ADD6",
                                street = "string",
                                street_2 = "string",
                                state_id = 1,
                                pincode = "string"
                            }

                        });
            _settings.Response = _settings.Client.Execute<Posts>(_settings.Request);
            
        }

        [Then(@"I should see the ""(.*)"" For POST as ""(.*)""")]
        public void ThenIShouldSeeTheForPOSTAs(string key, int value)
        {
            _settings.StatusCode = (int)_settings.Response.StatusCode;
            Assert.That(_settings.StatusCode, Is.EqualTo(value), $"The {key} is not {value}");
        }

        [Given(@"I perform POST operation for ""(.*)"" without body")]
        public void GivenIPerformPOSTOperationForWithoutBody(string url)
        {
            _settings.Request = new RestRequest(url, Method.POST);
            _settings.Request.RequestFormat = DataFormat.Json;
            _settings.Request.AddBody(new Posts(){/*NO BODY*/});
            _settings.Response = _settings.Client.Execute<Posts>(_settings.Request);

        }

        [Given(@"I perform GET operation for ""(.*)"" with body")]
        public void GivenIPerformGETOperationForWithBody(string url, Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            _settings.Request = new RestRequest(url, Method.GET);
            _settings.Request.RequestFormat = DataFormat.Json;
            _settings.Request.AddBody(new Posts()
            {
                id = data.id,
                first_name = data.first_name.ToString(),
                last_name = data.last_name.ToString(),
                position_id = data.position_id,
                organisation_id = data.organisation_id,
                address_id = data.address_id,
                mob_no = data.mob_no.ToString(),
                alt_mob_no = data.alt_mob_no.ToString(),
                email = data.email.ToString(),
                isDeleted = data.isDeleted,
                address = new Address()
                {
                    id = 15,
                    address_type = "6411641C-F93C-4923-8D28-21FD0F36ADD6",
                    street = "string",
                    street_2 = "string",
                    state_id = 1,
                    pincode = "string"
                }

            });
            _settings.Response = _settings.Client.Execute<Posts>(_settings.Request);
        }

        

    }
}
