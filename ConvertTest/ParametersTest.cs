using CandidateTesting.JaderMartins.Exceptions;
using CandidateTesting.JaderMartins.Factories;
using CandidateTesting.JaderMartins.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ConvertTest
{
    [TestClass]
    public class ParametersTest
    {

        private IValidate Validate_;
        private const string Output_ = "./output/minhaCdn1.txt";
        private const string ConvertMethod_ = "convert";
        private const string HttpInput_ = "https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt";
        

        [TestInitialize]
        public void Setup()
        {
            Validate_ = FactoryValidation.Criar(FactoryValidation.E_ValidationType.ThreeParameters);
        }
        [DataRow(new string[] { "1", "1", "1", "1" })]
        [TestMethod]
        public void TestInvalidNumberOfParameters(string[] parameters)
        {
            try
            {
                Validate_.Validate(parameters);
                Assert.Fail();
            }
            catch (ExceptionInvalidNumberOfParameters) { }
        }

        [DataRow(new string[] { ConvertMethod_, HttpInput_, Output_ })]
        [TestMethod]
        public void TestValidNumberOfParameters(string[] parameters)
        {
            Validate_.Validate(parameters);
        }
    }
}
