using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.JaderMartins.Exceptions
{
    [Serializable]
    public class ExceptionFactory : Exception
    {
        public ExceptionFactory() : base("Factory type does not exist.")
        {
        }
        public ExceptionFactory(string message) : base(message)
        {
        }

        public ExceptionFactory(string message, Exception innerException) : base(message, innerException)
        {
        }
        public ExceptionFactory(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
