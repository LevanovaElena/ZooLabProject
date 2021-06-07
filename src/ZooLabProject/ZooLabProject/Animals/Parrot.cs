using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLabApplication.Animals
{
    public class Parrot : Bird
    {
        public override string[] FavoriteFood { get; } = { "Fruits", "Seeds" };
        public override int RequiredSpaceSqFt { get; }
        public Parrot(int id) : base(id)
        {
            RequiredSpaceSqFt = 5;
        }
        public override bool IsFriendlyWith(Animal animal)
        {
            List<string> friendlyAnimals = new List<string>() { "Bison", "Elephant", "Turtle" };
            string typeAnimal = animal.GetType().Name;
            if (typeAnimal.Equals(this.GetType().Name) || friendlyAnimals.IndexOf(typeAnimal) != -1) return true;
            else return false;
        }
    }
}
