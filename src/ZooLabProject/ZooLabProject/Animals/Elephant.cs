using System.Collections.Generic;

namespace ZooLabApplication
{
    public class Elephant : Mammal
    {
        public Elephant(int id) : base(id)
        {
        }
        public override bool IsFriendlyWith(Animal animal)
        {
            List<string> friendlyAnimals = new List<string>(){ "Bison", "Parrots", "Turtle" };
            string typeAnimal = animal.GetType().Name;
            if (typeAnimal.Equals(this.GetType().Name) || friendlyAnimals.IndexOf(typeAnimal)!=-1) return true;
            else return false;
        }
    }
}