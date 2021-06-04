using System;
using ZooLabApplication.Animals;
using Xunit;

namespace ZooLabApplication.Test
{
   public class ReptileTests
    {
        [Fact]
        public void ShoudBeCreateTurtle()
        {
            Turtle parrot = new Turtle(1);
            Assert.Equal(1, parrot.Id);
            Assert.Equal(5, parrot.RequiredSpaceSqFt);
            //Assert.NotNull(lion.FavoriteFood);
            Assert.NotNull(parrot.FeedSchedule);
            Assert.NotNull(parrot.FeedTimes);
        }

        [Fact]
        public void ShouldCheckIsFriendlyWithTurtle()
        {
            Turtle parrot = new Turtle(1);

            Assert.False(parrot.IsFriendlyWith(new Lion(12)));
            Assert.True(parrot.IsFriendlyWith(new Bison(13)));
            Assert.True(parrot.IsFriendlyWith(new Turtle(13)));
        }
        [Fact]
        public void ShoudBeCreateSnake()
        {
            Snake bison = new Snake(1);
            Assert.Equal(1, bison.Id);
            Assert.Equal(2, bison.RequiredSpaceSqFt);
            //Assert.NotNull(lion.FavoriteFood);
            Assert.NotNull(bison.FeedSchedule);
            Assert.NotNull(bison.FeedTimes);
        }

        [Fact]
        public void ShouldCheckIsFriendlyWithBison()
        {
            Snake animal1 = new Snake(12);

            Assert.False(animal1.IsFriendlyWith(new Lion(12)));
            Assert.True(animal1.IsFriendlyWith(new Snake(13)));


        }
    }
}
