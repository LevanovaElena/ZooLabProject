using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLabApplication.Animals
{
    public abstract class Bird : Animal
    {
        public override string[] FavoriteFood { get; }
        public Bird(int id) : base(id)
        {
        }


    }
}
