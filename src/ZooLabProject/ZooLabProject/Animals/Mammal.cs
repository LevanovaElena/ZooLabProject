namespace ZooLabApplication
{
    public abstract class Mammal : Animal
    {
        public override int RequiredSpaceSqFt { get; }

        public override string[] FavoriteFood { get; }

         public Mammal(int id) : base(id)
        {
            RequiredSpaceSqFt = 1000;
        }

    }
}