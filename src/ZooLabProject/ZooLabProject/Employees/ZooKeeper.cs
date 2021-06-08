using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLabApplication.Common;
using ZooLabApplication.Foods;

namespace ZooLabApplication.Employees
{
    public class ZooKeeper : IEmployees
    {
        public string FirstName { get; }

        public string LastName { get; }
        public List<string> AnimalExperiences { get; set; } = new List<string>();

        public ZooConsole myConsole { get; set; }

        public ZooKeeper(string firstName,string lastName,ZooConsole console=null)
        {
            FirstName = firstName;
            LastName = lastName;
            myConsole = console;
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

        public bool FeedAnimal(Animal animal,DateTime dateTime)
        {
            try
            {
                //выберем еду
                int max = animal.FavoriteFood.Length-1;
                int randonFoodNumber = 0;
                Food food;
                if (max > 0)
                {
                    Random rnd = new Random();
                    //выберем еду рандомно
                    randonFoodNumber = rnd.Next(0, max);
                }
                Type TestType = Type.GetType("ZooLabApplication.Foods." + animal.FavoriteFood[randonFoodNumber]);
                //получаем конструктор
                object instance = Activator.CreateInstance(TestType);
                food = (Food)instance;
                animal.myConsole = myConsole;
                animal.Feed(food, this,dateTime);
                return true;
            }
            catch(AnimalHasAlreadyBeenFedTwoTimesAnimalExeption) 
            {
                myConsole?.WriteLine($"Animal {animal.GetType().Name} id={animal.Id} yet feed tow times!");
                return false; 
            }
            catch (ImproperTimeForFedAnimalExeption ex)
            {
                myConsole?.WriteLine($"Time for feed not correct!Animal {animal.GetType().Name} id={animal.Id} "+ex.Message);
                return false;
            }
        }
    }
}
