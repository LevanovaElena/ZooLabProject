using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ZooLabApplication.Test
{
    public class MammalTests
    {
        [Fact]
        public void ShoudBeCreateLion()
        {
            Lion lion = new Lion(1);
            Assert.Equal(1, lion.Id);
            Assert.Equal(1000, lion.RequiredSpaceSqFt);
            //Assert.NotNull(lion.FavoriteFood);
            Assert.NotNull(lion.FeedSchedule);
            Assert.NotNull(lion.FeedTimes);
        }

        [Fact]
        public void ShouldCheckIsFriendlyWithLion()
        {
            Lion animal1 = new Lion(12);

            Assert.True(animal1.IsFriendlyWith(new Lion(12)));
            Assert.False(animal1.IsFriendlyWith(new Bison(13)));
        }
        [Fact]
        public void ShoudBeCreateBison()
        {
            Bison bison = new Bison(1);
            Assert.Equal(1, bison.Id);
            Assert.Equal(1000, bison.RequiredSpaceSqFt);
            //Assert.NotNull(lion.FavoriteFood);
            Assert.NotNull(bison.FeedSchedule);
            Assert.NotNull(bison.FeedTimes);
        }

        [Fact]
        public void ShouldCheckIsFriendlyWithBison()
        {
            Bison animal1 = new Bison(12);

            Assert.False(animal1.IsFriendlyWith(new Lion(12)));
            Assert.True(animal1.IsFriendlyWith(new Elephant(13)));
            Assert.True(animal1.IsFriendlyWith(new Bison(13)));
            
        }
        [Fact]
        public void ShoudBeCreateElefant()
        {
            Elephant elephant = new Elephant(1);
            Assert.Equal(1, elephant.Id);
            Assert.Equal(1000, elephant.RequiredSpaceSqFt);
            //Assert.NotNull(lion.FavoriteFood);
            Assert.NotNull(elephant.FeedSchedule);
            Assert.NotNull(elephant.FeedTimes);
        }

        [Fact]
        public void ShouldCheckIsFriendlyWithElephant()
        {
            Elephant animal1 = new Elephant(12);

            Assert.False(animal1.IsFriendlyWith(new Lion(12)));
            Assert.True(animal1.IsFriendlyWith(new Elephant(13)));
            Assert.True(animal1.IsFriendlyWith(new Bison(13)));

        }
    }
}
