using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLabApplication.Animals
{
    public class Penguin : Bird
    {
        public override int RequiredSpaceSqFt { get; }
        public Penguin(int id) : base(id)
        {
            RequiredSpaceSqFt = 10;
        }
        public override bool IsFriendlyWith(Animal animal)
        {
            if (animal.GetType().Equals(this.GetType())) return true;
            else return false;
        }
    }
}
