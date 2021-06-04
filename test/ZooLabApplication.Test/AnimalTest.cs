using System;
using Xunit;


namespace ZooLabApplication.Test
{
    public class AnimalTest
    {

        private class MockAnimal : Animal
        {
            public override int RequiredSpaceSqFt { get; }

            public override int FavoriteFood { get; }
        }

        [Fact]
        public void ShouldBeCreateAnimal()
        {
            Animal animal = new MockAnimal();
            Assert.NotNull( animal.FeedTimes);
            Assert.NotNull(animal.FeedSchedule);
        }
    }
}
