using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLabApplication.Common;
using ZooLabApplication.Employees;
using ZooLabApplication.Foods   ;


namespace ZooLabApplication
{

    public abstract class Animal
    {
        public abstract int RequiredSpaceSqFt { get; }
        public abstract string[] FavoriteFood { get;} 
        public List<FeedTime> FeedTimes { get; } = new List<FeedTime>();//время последнего кормления животного.
        public List<int> FeedSchedule { get; } = new List<int>();//время, когда следует кормить животное
        public  bool Seek { get; private set; }  //болен или нет
        public int Id { get; set; } //Unique ID

        public abstract bool IsFriendlyWith(Animal animal);
        public ZooConsole myConsole { get; set; }


        public Animal(int id,ZooConsole console=null)
        {
            Id = id;
            myConsole = console;
        }
        //Добавляем кормление в FeedTimes,если еда не подходит, выдаем исключение
        public void Feed(Food food, ZooKeeper zooKeeper,DateTime date)
        {

            if (Array.IndexOf(FavoriteFood, food.GetType().Name) != -1)
            {
                this.FeedTimes.Add(new FeedTime(date, zooKeeper));
                myConsole?.WriteLine("Animal " + this.GetType().Name + " id=" + this.Id +
                    " was fed by zooKeeper "+zooKeeper.LastName+ " with "+food.GetType().Name+" at "+ date.Date);
            }
            else throw new ImproperFoodAnimalExeption("Time for feed not correct!This animal should feed in " + this.FeedSchedule[0] + " or in " + this.FeedSchedule[1]);
            
        }

        public bool IsSeek()
        {
            Seek = Seek ? false : true;
            if(Seek)myConsole?.WriteLine("Animal " + this.GetType().Name + " id=" + this.Id + " got sick!");
            return Seek;
          
        }

        public void AddFeedSchedule(List<int> hours)
        {
            if (hours.Count == 2) {
                this.FeedSchedule[0] = hours[0];
                this.FeedSchedule[0] = hours[0];
            }
            else
            {
                throw new NumberOfFeedsExceededAnimalExeption("Number of feeds exceeded!Must be two times!");
            }

        }
        public void Heal(Medicine medicine)
        {
            this.IsSeek();
            myConsole?.WriteLine("Animal " + this.GetType().Name + " id=" + this.Id + " recovered!");
        }



    }
}
