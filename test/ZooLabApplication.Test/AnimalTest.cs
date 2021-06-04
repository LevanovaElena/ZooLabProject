using System;
using Xunit;


namespace ZooLabApplication.Test
{
    public class AnimalTest
    {

        private class MockAnimal : Animal
        {
            public override int RequiredSpaceSqFt { get; }

            public override string[] FavoriteFood { get; }

            public MockAnimal(int id)
            : base(id)
            {
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

            public override string[] FavoriteFood { get; }
            public MockAnimalNotFriend(int id)
            : base(id)
            {
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
            Assert.True( animal1.IsSeek());
        }

    }
}
