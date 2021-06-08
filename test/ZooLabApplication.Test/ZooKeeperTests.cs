using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ZooLabApplication.Employees;

namespace ZooLabApplication.Test
{
    public class ZooKeeperTests
    {
        [Fact]
        public void ShouldBeCreateZooKeeper()
        {
            ZooKeeper zooKeeper = new("name", "lastname");

            Assert.Equal("name", zooKeeper.FirstName);
            Assert.Equal("lastname", zooKeeper.LastName);
            Assert.Empty(zooKeeper.AnimalExperiences);
        }

        [Fact]
        public void ShouldBeAddAnimalExperiences()
        {
            ZooKeeper zooKeeper = new("name", "lastname");

            zooKeeper.AddAnimalExperience(new Elephant(15));
            Assert.NotEmpty(zooKeeper.AnimalExperiences);
            Assert.Equal("Elephant", zooKeeper.AnimalExperiences[0]);
        }
        [Fact]
        public void ShouldHasAnimalExperiences()
        {
            ZooKeeper zooKeeper = new("name", "lastname");
            Assert.False(zooKeeper.HasAnimalExerience(new Elephant(15)));
            zooKeeper.AddAnimalExperience(new Elephant(15));
            Assert.True(zooKeeper.HasAnimalExerience(new Elephant(15)));
            Assert.False(zooKeeper.HasAnimalExerience(new Lion(15)));
        }
        [Fact]
        public void ShouldFeedAnimal()
        {
            ZooKeeper zooKeeper = new("name", "lastname");
            Elephant elephant = new Elephant(15);
            zooKeeper.AddAnimalExperience(elephant);
            Assert.True(zooKeeper.FeedAnimal(elephant, new DateTime(2021, 11, 23, 11, 11, 11)));
            Assert.True(zooKeeper.FeedAnimal(elephant, new DateTime(2021, 11, 23, 11, 11, 11)));
           // Assert.True(zooKeeper.FeedAnimal(elephant, new DateTime(2021, 11, 23, 11, 11, 11)));
            Assert.False(zooKeeper.FeedAnimal(elephant, new DateTime(2021, 11, 23, 11, 11, 11)));
        }
    }
}
