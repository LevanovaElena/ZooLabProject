using System;
using System.Runtime.Serialization;

namespace ZooLabApplication
{
    [Serializable]
    public class NumberOfFeedsExceededAnimalExeption : Exception
    {


        public NumberOfFeedsExceededAnimalExeption(string message) : base(message)
        {
        }


    }
}