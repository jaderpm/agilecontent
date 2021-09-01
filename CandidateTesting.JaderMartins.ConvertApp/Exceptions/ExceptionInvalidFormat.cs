using System;
using System.Runtime.Serialization;

namespace CandidateTesting.JaderMartins.Exceptions
{
    [Serializable]
    public class ExceptionInvalidFormat : Exception
    {
        public ExceptionInvalidFormat():base("Invalid format.")
        {
        }

        public ExceptionInvalidFormat(string message) : base("Invalid format. ("+message+")")
        {
        }

        public ExceptionInvalidFormat(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExceptionInvalidFormat(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}