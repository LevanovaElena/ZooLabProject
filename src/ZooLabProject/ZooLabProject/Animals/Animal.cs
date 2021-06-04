using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLabApplication
{

    public abstract class Animal
    {
        public abstract int RequiredSpaceSqFt { get; }
        public abstract string[] FavoriteFood { get; }
        public List<FeedTime> FeedTimes { get; } = new List<FeedTime>();//время последнего кормления животного.
        public List<int> FeedSchedule { get; } = new List<int>();//время, когда следует кормить животное
        public  bool Seek { get; private set; }  //болен или нет
        public int Id { get; } //Unique ID

        public abstract bool IsFriendlyWith(Animal animal);


        public Animal(int id)
        {
            Id = id;
                                                                  }
        public void Feed(Food food)
        {

        }

        public bool IsSeek()
        {
            return Seek = Seek ? false : true;
        }

        public void AddFeedSchedule(List<int> hours)
        {

        }
        public void Heal(Medicine medicine)
        {

        }



    }
}
