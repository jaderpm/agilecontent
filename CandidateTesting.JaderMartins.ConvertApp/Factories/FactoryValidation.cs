using CandidateTesting.JaderMartins.Exceptions;
using CandidateTesting.JaderMartins.Interfaces;
using CandidateTesting.JaderMartins.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.JaderMartins.Factories
{
    public static class FactoryValidation
    {
        public enum E_ValidationType
        {
            ThreeParameters = 1
        }
        public static IValidate Criar(E_ValidationType p_validation)
        {
            if (p_validation == E_ValidationType.ThreeParameters)
            {
                var instancia = new FirstInputValidations();
                return new InputValidation(instancia, instancia);
            }
            throw new ExceptionFactory();
        }
    }
}
