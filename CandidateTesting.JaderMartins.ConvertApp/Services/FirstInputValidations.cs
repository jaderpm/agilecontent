using CandidateTesting.JaderMartins.Exceptions;
using CandidateTesting.JaderMartins.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.JaderMartins.Services
{
    public class FirstInputValidations : IValidadeParameters, IValidadeMethod
    {
        public void ValidateMethod(string[] parameters)
        {
            if (!parameters[0].ToUpper().Equals("CONVERT"))
                throw new ExceptionUnknownMethod();
        }

        public void ValidateParameters(string[] parameters)
        {
            if (parameters.Count() != 3)
                throw new ExceptionInvalidNumberOfParameters();
        }
    }
}
