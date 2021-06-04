namespace ZooLabApplication.Test
{
    public class Mammal : Animal
    {
        public override int RequiredSpaceSqFt { get; }

        public override string[] FavoriteFood { get; }

        public override bool IsFriendlyWith(Animal animal)
        {
            return true;
        }

        public Mammal(int id) : base(id)
        {

        }
    }
}