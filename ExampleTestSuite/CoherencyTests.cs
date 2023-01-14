using AutoMapper;
using ExampleBusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            var assembly = typeof(ExampleApi.Program).Assembly;
            var modelTypes = new List<Type>();
            foreach (var cls in assembly.GetTypes())
            {
                if (cls.IsSubclassOf(typeof(ControllerBase)))
                {
                    Console.WriteLine(cls.FullName);

                    // Iterate through all methods on this class and make sure they have necessary documentation
                    // But only if they have an [HttpGet] or similar annotation on them
                    foreach (var method in (from m in cls.GetMethods() where m.GetCustomAttributes<HttpMethodAttribute>().Any() select m))
                    {
                        Console.WriteLine(method.Name);
                    }
                }
            }

            // Check all data model types
        }

        [TestMethod]
        public void TestSearchlightEngine()
        {
            // Make sure all Searchlight models are configured correctly
        }
    }
}