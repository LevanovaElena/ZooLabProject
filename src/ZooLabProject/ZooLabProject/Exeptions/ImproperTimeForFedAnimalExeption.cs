using System;
using System.Runtime.Serialization;

namespace ZooLabApplication
{
    [Serializable]
    public class ImproperTimeForFedAnimalExeption : Exception
    {


        public ImproperTimeForFedAnimalExeption(string message) : base(message)
        {
        }


    }
}