using System;
using System.Runtime.Serialization;

namespace ZooLabApplication
{
    [Serializable]
    public class ImproperFoodAnimalExeption : Exception
    {


        public ImproperFoodAnimalExeption(string message) : base(message)
        {
        }


    }
}