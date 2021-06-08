using System;
using System.Runtime.Serialization;

namespace ZooLabApplication
{
    [Serializable]
    public class AnimalHasAlreadyBeenFedTwoTimesAnimalExeption : Exception
    {


        public AnimalHasAlreadyBeenFedTwoTimesAnimalExeption(string message) : base(message)
        {
        }

       
    }
}