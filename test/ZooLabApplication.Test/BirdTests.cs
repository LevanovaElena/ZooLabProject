using System;
using ZooLabApplication.Animals;
using Xunit;

namespace ZooLabApplication.Test
{
   public class BirdTests
    {
        [Fact]
        public void ShoudBeCreateParrot()
        {
            Parrot parrot = new Parrot(1);
            Assert.Equal(1, parrot.Id);
            Assert.Equal(5, parrot.RequiredSpaceSqFt);
            //Assert.NotNull(lion.FavoriteFood);
            Assert.NotNull(parrot.FeedSchedule);
            Assert.NotNull(parrot.FeedTimes);
        }

        [Fact]
        public void ShouldCheckIsFriendlyWithParrot()
        {
            Parrot parrot = new Parrot(1);

            Assert.False(parrot.IsFriendlyWith(new Lion(12)));
            Assert.True(parrot.IsFriendlyWith(new Bison(13)));
            Assert.True(parrot.IsFriendlyWith(new Parrot(13)));
        }
        [Fact]
        public void ShoudBeCreatePenguin()
        {
            Penguin bison = new Penguin(1);
            Assert.Equal(1, bison.Id);
            Assert.Equal(10, bison.RequiredSpaceSqFt);
            //Assert.NotNull(lion.FavoriteFood);
            Assert.NotNull(bison.FeedSchedule);
            Assert.NotNull(bison.FeedTimes);
        }

        [Fact]
        public void ShouldCheckIsFriendlyWithBison()
        {
            Penguin animal1 = new Penguin(12);

            Assert.False(animal1.IsFriendlyWith(new Lion(12)));
            Assert.True(animal1.IsFriendlyWith(new Penguin(13)));


        }
    }
}
