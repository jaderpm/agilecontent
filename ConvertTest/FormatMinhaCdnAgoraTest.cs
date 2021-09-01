using CandidateTesting.JaderMartins.Exceptions;
using CandidateTesting.JaderMartins.Factories;
using CandidateTesting.JaderMartins.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ConvertTest
{
    [TestClass]
    public class FormatMinhaCdnAgoraTest
    {

        private IOutFormat Format_;
        private const string Output_ = "./output/minhaCdn1.txt";
        private const string HttpInput_ = "https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt";

        [TestInitialize]
        public void Setup()
        {
            Format_ = FactoryFormat.Criar(FactoryFormat.E_In.MinhaCdn, FactoryFormat.E_Out.Agora);
        }


        [DataRow("teste arquivo erro",Output_)]
        [TestMethod]
        public void TestInvalidFormat(string arquivoComErro, string output)
        {
            try
            {
                File.WriteAllText(output, arquivoComErro);
                Format_.GetStringFormattedFromUrl(output);
                Assert.Fail();
            }
            catch (ExceptionInvalidFormat) { }
            finally{
                File.Delete(output);
            }
        }
        [DataRow(HttpInput_, Output_)]
        [TestMethod]
        public void TestExport(string httpInput,string output)
        {
            Format_.ExportFileFromUrl(httpInput, output);
            var existFile = File.Exists(output);
            File.Delete(output);
            Assert.IsTrue(existFile);
        }
    }
}
