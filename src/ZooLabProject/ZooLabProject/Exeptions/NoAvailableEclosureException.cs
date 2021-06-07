using System;
using System.Runtime.Serialization;

namespace ZooLabApplication
{
    [Serializable]
    public class NoAvailableEclosureException : Exception
    {


        public NoAvailableEclosureException(string message) : base(message)
        {
        }


    }
}