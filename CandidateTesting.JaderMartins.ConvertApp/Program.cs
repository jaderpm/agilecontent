using CandidateTesting.JaderMartins.Factories;
using System;

namespace CandidateTesting.JaderMartins.ConvertApp
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    string inputText = Console.ReadLine();
                    string[] text = inputText.Trim().Split(' ');
                    FactoryValidation.Criar(FactoryValidation.E_ValidationType.ThreeParameters).Validate(text);
                    FactoryFormat.Criar(FactoryFormat.E_In.MinhaCdn, FactoryFormat.E_Out.Agora).ExportFileFromUrl(text[1], text[2]);
                    Console.Write("Successful Conversion!");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true);
        }
    }
}
