using AutoMapper;
using ExampleApi;
using ExampleBusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Hosting;
using Moq;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.TestHost;
using System.Reflection.Metadata;
using Azure;

namespace ExampleTestSuite
{
    [TestClass]
    public class CoherencyTests
    {
        [TestMethod]
        public void TestAutomapperSetup()
        {
            // A test to make sure all models and entities are fully mapped to each other
            var mem = new ModelEntityMapper();
            mem.GetConfiguration().AssertConfigurationIsValid();
        }

        [TestMethod]
        public void TestSwashbuckleDocumentation()
        {
            // Fetch the OpenAPI specification for this site and assert that all methods and models
            // have documentation.  We do this by scanning for controllers and parameters.
            var server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());

            // Fetch the swagger provider
            var swagger = server.Services.GetService<ISwaggerProvider>();
            Assert.IsNotNull(swagger);

            // Generate swagger
            var openApiDoc = swagger.GetSwagger("v1");
            Assert.IsNotNull(openApiDoc);

            // Assert that everything has the necessary documentation
            foreach (var path in openApiDoc.Paths)
            {
                foreach (var method in path.Value.Operations)
                {
                    Assert.IsFalse(String.IsNullOrWhiteSpace(method.Value.Summary), $"Method {method.Key} for path {path.Key} does not have a <summary> xmldoc.");
                    Assert.IsFalse(String.IsNullOrWhiteSpace(method.Value.Description), $"Method {method.Key} for path {path.Key} does not have a <remarks> xmldoc.");
                    foreach (var parameter in method.Value.Parameters)
                    {
                        Assert.IsFalse(String.IsNullOrWhiteSpace(parameter.Description), $"Method {method.Key} for path {path.Key} does not have a <param name=\"{parameter.Name}\"> xmldoc.");
                    }
                    foreach (var response in method.Value.Responses)
                    {
                        Assert.IsFalse(String.IsNullOrWhiteSpace(response.Value.Description), $"Method {method.Key} for path {path.Key} does not have a <returns> xmldoc for return type {response.Key}.");
                    }
                    if (method.Value.RequestBody != null)
                    {
                        Assert.IsFalse(String.IsNullOrWhiteSpace(method.Value.RequestBody.Description), $"Method {method.Key} for path {path.Key} does not have a <param> xmldoc for the request body.");
                    }
                }
            }
        }

        [TestMethod]
        public void TestSearchlightEngine()
        {
            // Make sure all Searchlight models are configured correctly
        }
    }
}