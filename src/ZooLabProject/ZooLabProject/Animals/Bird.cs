using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLabApplication.Animals
{
    public abstract class Bird : Animal
    {
        public Bird(int id) : base(id)
        {
            this.FeedSchedule.Add(9);
            this.FeedSchedule.Add(17);
        }

    }
}
