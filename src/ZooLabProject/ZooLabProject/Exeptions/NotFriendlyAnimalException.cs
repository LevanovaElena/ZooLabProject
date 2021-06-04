using System;
using System.Runtime.Serialization;

namespace ZooLabApplication
{
    [Serializable]
    public class NotFriendlyAnimalException : Exception
    {
        public NotFriendlyAnimalException()
        {
        }

        public NotFriendlyAnimalException(string message) : base(message)
        {
        }

        public NotFriendlyAnimalException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFriendlyAnimalException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}