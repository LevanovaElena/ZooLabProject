using System;
using System.Runtime.Serialization;

namespace ZooLabApplication
{
    [Serializable]
    public class NoAvailableEclosureException : Exception
    {
        public NoAvailableEclosureException()
        {
        }

        public NoAvailableEclosureException(string message) : base(message)
        {
        }

        public NoAvailableEclosureException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoAvailableEclosureException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}