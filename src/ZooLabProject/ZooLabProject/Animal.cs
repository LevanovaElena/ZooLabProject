using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLabApplication
{
    /*
     * Animals must be tag in Zoo with Unique ID, int32
Animal should have
Required Space in sq feet
FeedTime to track the last time the animal was fed
FeedSchedule, the time when an animal should be fed
Every time animal is fed we need to track time and who fed the animal
     */
    public abstract class Animal
    {
        public abstract int RequiredSpaceSqFt { get; }
        public abstract int FavoriteFood { get; }
        public List<FeedTime> FeedTimes { get; } = new List<FeedTime>();//время последнего кормления животного.
        public List<int> FeedSchedule { get; } = new List<int>();//время, когда следует кормить животное
        public bool IsSeek { get; } //найден?
        public int Id { get; } //Unique ID

        internal bool isFriendlyWith(Animal animal)
        {
            return true;
        }


    }
}
