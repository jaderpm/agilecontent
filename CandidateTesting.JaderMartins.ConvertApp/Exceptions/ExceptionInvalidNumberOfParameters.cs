using System;
using System.Runtime.Serialization;

namespace CandidateTesting.JaderMartins.Exceptions
{
    [Serializable]
    public class ExceptionInvalidNumberOfParameters : Exception
    {
        public ExceptionInvalidNumberOfParameters():base("Invalid number of parameters.")
        {
        }

        public ExceptionInvalidNumberOfParameters(string message) : base(message)
        {
        }

        public ExceptionInvalidNumberOfParameters(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExceptionInvalidNumberOfParameters(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}