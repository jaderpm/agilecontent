using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.JaderMartins.Interfaces
{
    public class InputValidation : IValidate
    {
        private IValidadeMethod validateMethod_ { get; set; }
        private IValidadeParameters validadeParameters_ { get; set; }
        public InputValidation(IValidadeMethod validateMethod, IValidadeParameters validadeParameters)
        {
            validateMethod_ = validateMethod;
            validadeParameters_ = validadeParameters;
        }

        public void Validate(string[] parameters)
        {
            validadeParameters_.ValidateParameters(parameters);
            validateMethod_.ValidateMethod(parameters);
        }
    }
}
