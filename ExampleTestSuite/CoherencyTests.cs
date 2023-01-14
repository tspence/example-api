using AutoMapper;
using ExampleBusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            // A test to make sure all models and entities are fully mapped to each other
        }

        [TestMethod]
        public void TestSearchlightEngine()
        {
            // Make sure all Searchlight models are configured correctly
        }
    }
}