using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ZooLabApplication.Employees
{
    public class ZooKeeper : IEmployees
    {
        public string FirstName { get; }

        public string LastName { get; }
        public List<string> AnimalExperiences { get; set; } = new List<string>();

        public ZooKeeper(string firstName,string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
       public void AddAnimalExperience(Animal animal) {
            AnimalExperiences.Add(animal.GetType().Name);
        }

       public bool HasAnimalExerience(Animal animal)
        {
            if (AnimalExperiences.Count > 0)
            {
                return AnimalExperiences.Contains(animal.GetType().Name);
            }
            else return false;
        }

        public bool FeedAnimal(Animal animal)
        {
            try
            {
                //выберем еду
                /*string[] str = animal.FavoriteFood;
                int max = str.Count - 1;
                //Food food=new 
                animal.Feed(food, this);*/
            }
            catch { }
            finally {  }
            return true;
        }
    }
}
