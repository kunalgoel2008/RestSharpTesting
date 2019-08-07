using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpTesting.Model;
using System;

namespace RestSharpDemo
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("employees/{id}", Method.GET);
            request.AddUrlSegment("id", 1);
            var content = client.Execute(request).Content;
            Console.Write(content);
            var response = client.Execute<Posts>(request);
            NUnit.Framework.Assert.That(response.Data.first_name, Is.EqualTo("Keaton"), "First Name is Incorrect");


            //var deserial = new JsonDeserializer();
            //var response = client.Execute(request);
            //var output = deserial.Deserialize<Dictionary<string, string>>(response);
            //var result = output["first_name"];
            //NUnit.Framework.Assert.That(result, Is.EqualTo("Lemuel"), "Author is not Correct");
        }
        /*
        [Test]
        public void PostWithTypeClassBody()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("employees", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new Posts() { id = 58, first_name = "Raja", last_name = "Singh", email = "raj.singh@gmail.com" });
            var response = client.Execute<Posts>(request);
        }

        [Test]
        public void PostWithAnonymousBody()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("employees", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { id = "54", first_name = "Raja", last_name = "Singh", email = "raj.singh@gmail.com" });

            client.Execute(request);

        }*/
    }

}
