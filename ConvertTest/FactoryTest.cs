using CandidateTesting.JaderMartins.Exceptions;
using CandidateTesting.JaderMartins.Factories;
using CandidateTesting.JaderMartins.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CandidateTesting.JaderMartins.ConvertTest
{
    [TestClass]
    public class FactoryTest
    {
        private const int ErrorFormatEnum = 999999;

        [TestInitialize]
        public void Setup()
        {
            
        }
        [DataRow((FactoryValidation.E_ValidationType)ErrorFormatEnum)]
        [TestMethod]
        public void TestValidate(FactoryValidation.E_ValidationType validationTypeError)
        {
            try
            {
                FactoryValidation.Criar(validationTypeError);
                Assert.Fail();
            }
            catch (ExceptionFactory) { }
        }

        [DataRow((FactoryFormat.E_In)ErrorFormatEnum, FactoryFormat.E_Out.Agora)]
        [TestMethod]
        public void TestFormatIn(FactoryFormat.E_In formatIn, FactoryFormat.E_Out formatOut)
        {
            try
            {
                FactoryFormat.Criar(formatIn, formatOut);
                Assert.Fail();
            }
            catch (ExceptionFactory) { }
        }
        [DataRow(FactoryFormat.E_In.MinhaCdn, (FactoryFormat.E_Out)ErrorFormatEnum)]
        [TestMethod]
        public void TestFormatOut(FactoryFormat.E_In formatIn, FactoryFormat.E_Out formatOut)
        {
            try
            {
                FactoryFormat.Criar(formatIn, formatOut);
                Assert.Fail();
            }
            catch (ExceptionFactory) { }
        }

    }
}
