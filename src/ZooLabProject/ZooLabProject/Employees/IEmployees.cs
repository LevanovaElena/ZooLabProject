using System.Collections.Generic;

namespace ZooLabApplication
{
    public interface IEmployees
    {
        public string FirstName { get; }
        public string LastName { get; }

        public List<string> AnimalExperiences { get; }

        public void AddAnimalExperience(Animal animal);

    }
}