using System;
using System.Runtime.Serialization;

namespace ZooLabApplication
{
    [Serializable]
    public class ImproperFoodAnimalExeption : Exception
    {
        public ImproperFoodAnimalExeption()
        {
        }

        public ImproperFoodAnimalExeption(string message) : base(message)
        {
        }

        public ImproperFoodAnimalExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ImproperFoodAnimalExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}