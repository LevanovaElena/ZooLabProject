using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLabApplication.Animals
{
    public class Turtle : Reptile
    {
        public override string[] FavoriteFood { get; } = { "Grass", "Fruits", "Vegetable" };
        public override int RequiredSpaceSqFt { get; }
        public Turtle(int id) : base(id)
        {
            RequiredSpaceSqFt = 5;
            this.FeedSchedule.Add(8);
            this.FeedSchedule.Add(20);
        }
        public override bool IsFriendlyWith(Animal animal)
        {
            List<string> friendlyAnimals = new List<string>() { "Bison", "Elephant", "Parrot" };
            string typeAnimal = animal.GetType().Name;
            if (typeAnimal.Equals(this.GetType().Name) || friendlyAnimals.IndexOf(typeAnimal) != -1) return true;
            else return false;
        }
    }
}
