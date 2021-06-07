using System;
using System.Runtime.Serialization;

namespace ZooLabApplication
{
    [Serializable]
    public class NoAvailableSpaceException : Exception
    {


        public NoAvailableSpaceException(string message) : base(message)
        {
        }


    }
}