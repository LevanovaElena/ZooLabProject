using System;
using System.Runtime.Serialization;

namespace ZooLabApplication
{
    [Serializable]
    public class NotFriendlyAnimalException : Exception
    {


        public NotFriendlyAnimalException(string message) : base(message)
        {
        }

    }
}