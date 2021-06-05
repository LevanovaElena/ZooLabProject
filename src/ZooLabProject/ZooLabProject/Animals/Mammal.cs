namespace ZooLabApplication
{
    public abstract class Mammal : Animal
    {
        public override int RequiredSpaceSqFt { get; }


         public Mammal(int id) : base(id)
        {
            RequiredSpaceSqFt = 1000;
            this.FeedSchedule.Add(11);
            this.FeedSchedule.Add(19);
        }

    }
}