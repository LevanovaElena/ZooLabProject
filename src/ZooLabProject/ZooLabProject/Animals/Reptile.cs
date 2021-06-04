using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLabApplication.Animals
{
    public abstract class Reptile : Animal
    {
        public override string[] FavoriteFood { get; }
        public Reptile(int id) : base(id)
        {
        }


    }
}
