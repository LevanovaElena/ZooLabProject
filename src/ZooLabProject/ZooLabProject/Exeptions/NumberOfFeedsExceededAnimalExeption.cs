using System;
using System.Runtime.Serialization;

namespace ZooLabApplication
{
    [Serializable]
    public class NumberOfFeedsExceededAnimalExeption : Exception
    {
        public NumberOfFeedsExceededAnimalExeption()
        {
        }

        public NumberOfFeedsExceededAnimalExeption(string message) : base(message)
        {
        }

        public NumberOfFeedsExceededAnimalExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NumberOfFeedsExceededAnimalExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}