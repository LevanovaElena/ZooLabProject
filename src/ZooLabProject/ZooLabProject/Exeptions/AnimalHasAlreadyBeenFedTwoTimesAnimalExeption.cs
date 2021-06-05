using System;
using System.Runtime.Serialization;

namespace ZooLabApplication
{
    [Serializable]
    public class AnimalHasAlreadyBeenFedTwoTimesAnimalExeption : Exception
    {
        public AnimalHasAlreadyBeenFedTwoTimesAnimalExeption()
        {
        }

        public AnimalHasAlreadyBeenFedTwoTimesAnimalExeption(string message) : base(message)
        {
        }

        public AnimalHasAlreadyBeenFedTwoTimesAnimalExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AnimalHasAlreadyBeenFedTwoTimesAnimalExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}