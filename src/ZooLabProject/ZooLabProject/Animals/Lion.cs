namespace ZooLabApplication
{
    public class Lion : Mammal
    {
        public override string[] FavoriteFood { get; } = { "Meet" };
        public Lion(int id) : base(id)
        {
        }
        public override bool IsFriendlyWith(Animal animal)
        {
            if (animal.GetType().Equals(this.GetType())) return true;
            else return false;
        }
    }

}