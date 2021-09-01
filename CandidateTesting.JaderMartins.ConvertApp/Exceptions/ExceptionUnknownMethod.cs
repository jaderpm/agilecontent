using System;
using System.Runtime.Serialization;

namespace CandidateTesting.JaderMartins.Exceptions
{
    [Serializable]
    public class ExceptionUnknownMethod : Exception
    {
        public ExceptionUnknownMethod():base("Unknown method.")
        {
        }

        public ExceptionUnknownMethod(string message) : base(message)
        {
        }

        public ExceptionUnknownMethod(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExceptionUnknownMethod(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}