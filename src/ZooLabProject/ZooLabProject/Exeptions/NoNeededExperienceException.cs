using System;
using System.Runtime.Serialization;

namespace ZooLabApplication
{
    public class NoNeededExperienceException: Exception
    {
        public NoNeededExperienceException(string message) : base(message)
        {
        }
    }
}