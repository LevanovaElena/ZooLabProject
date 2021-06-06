using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLabApplication.Foods;

namespace ZooLabApplication.Employees
{
    public class Veterinarian : IEmployees
    {
        public string FirstName { get; }

        public string LastName { get; }
        public List<string> AnimalExperiences { get; set; } = new List<string>();

        public Veterinarian(string firstName,string lastName)
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

        public bool HealAnimal(Animal animal)
        {
            if (animal.Seek)
            {
                Medicine medicine;
                string[] medicines = { "Antibiotics", "AntiDepression", "AntiInflammatory" };
                Random rnd = new Random();
                //выберем таблетки
                int randonMedNumber = rnd.Next(0, 2);
                Type TestType = Type.GetType("ZooLabApplication." + medicines[randonMedNumber]);
                object instance = Activator.CreateInstance(TestType);
                medicine = (Medicine)instance;
                animal.Heal(medicine);
                return true;
            }
            else return false;
        }
    }
}
