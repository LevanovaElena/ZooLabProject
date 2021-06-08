using System;
using Xunit;
using ZooLabApplication.Employees;
using ZooLabApplication.Foods;

namespace ZooLabApplication.Test
{
    public class AnimalTest
    {

        private class MockAnimal : Animal
        {
            public override int RequiredSpaceSqFt { get; }

            public override string[] FavoriteFood { get; } = { "Grass", "Fruits" };

            public MockAnimal(int id)
            : base(id)
            {
                this.FeedSchedule.Add(11);
                this.FeedSchedule.Add(19);
            }

            public override bool IsFriendlyWith(Animal animal)
            {
                if (animal.GetType().Equals(this.GetType())) return true;
                else return false;
            }
        }
        private class MockAnimalNotFriend : Animal
        {
            public override int RequiredSpaceSqFt { get; }

            public override string[] FavoriteFood { get; } = { "Meet" };
            public MockAnimalNotFriend(int id)
            : base(id)
            {
                this.FeedSchedule.Add(11);
                this.FeedSchedule.Add(19);
            }

            public override bool IsFriendlyWith(Animal animal)
            {
                if (animal.GetType().Equals(this.GetType())) return true;
                else return false;
            }
        }

        [Fact]
        public void ShouldBeCreateAnimal()
        {
            Animal animal = new MockAnimal(12);
            Assert.NotNull(animal.FeedTimes);
            Assert.NotNull(animal.FeedSchedule);
            Assert.False(animal.Seek);
            Assert.Equal(12, animal.Id);
        }
        [Fact]
        public void ShouldCheckIsFriendlyAnimal()
        {
            Animal animal1 = new MockAnimal(12);
            Animal animal2 = new MockAnimal(13);

            MockAnimalNotFriend animalNotFriendly = new MockAnimalNotFriend(45);

            Assert.True( animal1.IsFriendlyWith(animal2));
            Assert.False(animal2.IsFriendlyWith(animalNotFriendly));
            Assert.False(animalNotFriendly.IsFriendlyWith(animal1));
        }
        [Fact]
        public void ShouldIsSeek()
        {
            Animal animal1 = new MockAnimal(12);
            Assert.False(animal1.Seek);
            Assert.True( animal1.IsSeek());
            animal1.Heal(new Antibiotics());
            Assert.False(animal1.Seek);
        }

        [Fact]
        public void ShouldAddNewFeedTime()
        {
            Animal animal = new MockAnimal(12);// { "Grass", "Fruits" };
            int count= animal.FeedTimes.Count;
            count++;
            ZooKeeper zooKeeper = new ZooKeeper("name", "lastname");
            animal.Feed(new Grass(),zooKeeper, new DateTime(2021,11,23,11,11,11));

            Assert.Equal(count, animal.FeedTimes.Count);
            Assert.Equal(zooKeeper, animal.FeedTimes[count-1].FeedByZooKeeper);

            //error - not favorite food
            Assert.Throws<ImproperFoodAnimalExeption>(() => { animal.Feed(new Meet(), zooKeeper,DateTime.Now); });
            Assert.Throws<ImproperTimeForFedAnimalExeption>(() => { animal.Feed(new Grass(), zooKeeper, DateTime.Now); });
            //error - животное покормлено уже 2 раза
            //animal.Feed(new Grass(), zooKeeper);
            //Assert.Throws<AnimalHasAlreadyBeenFedTwoTimesAnimalExeption>(() => { animal.Feed(new Meet(), zooKeeper); });
        }

        [Fact]
        public void ShouldAddNewFeedShedule()
        {
            Animal animal = new MockAnimal(12);// { "Grass", "Fruits" };
            Assert.Equal(2, animal.FeedSchedule.Count);
            animal.AddFeedSchedule(new System.Collections.Generic.List<int> { 4, 15 });
            Assert.Equal(2, animal.FeedSchedule.Count);
            Assert.Throws<NumberOfFeedsExceededAnimalExeption>(() => { animal.AddFeedSchedule(new System.Collections.Generic.List<int> { 4, 15,23 }); });
        }

        }
}
