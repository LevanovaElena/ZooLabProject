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
            Turtle turtle = new Turtle(1);
            Assert.Equal(1, turtle.Id);
            Assert.Equal(5, turtle.RequiredSpaceSqFt);
            Assert.Equal(string.Join("", new string[] { "Grass", "Fruits", "Vegetable" }), string.Join("", turtle.FavoriteFood));
            Assert.NotNull(turtle.FeedSchedule);
            Assert.NotNull(turtle.FeedTimes);
        }

        [Fact]
        public void ShouldCheckIsFriendlyWithTurtle()
        {
            Turtle turtle = new Turtle(1);

            Assert.False(turtle.IsFriendlyWith(new Lion(12)));
            Assert.True(turtle.IsFriendlyWith(new Bison(13)));
            Assert.True(turtle.IsFriendlyWith(new Turtle(13)));
        }
        [Fact]
        public void ShoudBeCreateSnake()
        {
            Snake bison = new Snake(1);
            Assert.Equal(1, bison.Id);
            Assert.Equal(2, bison.RequiredSpaceSqFt);
            Assert.Equal(string.Join("", new string[] { "Meet" }), string.Join("", bison.FavoriteFood));
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
