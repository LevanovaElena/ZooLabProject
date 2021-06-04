using System;

using Xunit;

namespace ZooLabApplication.Test
{
    public class ZooTests
    {
        [Fact]
        public void ShouldBeCreateZoo()
        {
            Zoo zoo = new("Canada");

            Assert.Equal("Canada", zoo.Location);
            Assert.NotNull(zoo.Enclosures);
            Assert.NotNull(zoo.Enployees);
        }
        [Fact]
        public void ShouldAddEnclosure()
        {
            Zoo zoo = new("Canada");
            Enclosure enclosure= zoo.AddEnclosure("Enclosure for Lion", 200);
            Assert.NotNull(enclosure);
            Assert.Equal("Enclosure for Lion", enclosure.Name);
            Assert.Equal(200, enclosure.SqureFeet);
            Assert.Equal(zoo, enclosure.ParentZoo);
        }
        [Fact]
        public void ShouldFindAvailableEnclosure()
        {
            Zoo zoo = new Zoo("location");
            Enclosure enclosure = zoo.FindAvailableEnclosure(new Lion(45));
        }
    }
}
