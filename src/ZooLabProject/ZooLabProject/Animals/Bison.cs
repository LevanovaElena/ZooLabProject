namespace ZooLabApplication.Test
{
    public class Bison : Mammal
    {
        public Bison(int id) : base(id)
        {

        }

        public override bool IsFriendlyWith(Animal animal)
        {
            string friendlyAnimals = "Elephant";
            string typeAnimal = animal.GetType().Name;
            if (typeAnimal.Equals(this.GetType().Name) ||typeAnimal== friendlyAnimals) return true;
            else return false;
        }
    }
}