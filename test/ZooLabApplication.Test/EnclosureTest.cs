using System;
using Xunit;

namespace ZooLabApplication.Test
{
    public class EnclosureTest
    {
        [Fact]
        public void ShouldBeCreateEnclosure()
        {
            Enclosure enclosure = new Enclosure("Name", 200, new Zoo("location"));
            Assert.NotNull(enclosure);
            Assert.NotNull(enclosure.ParentZoo);
            Assert.Equal("Name", enclosure.Name);
            Assert.Equal(200, enclosure.SqureFeet);
            Assert.Equal("location", enclosure.ParentZoo.Location);
        }
        [Fact]
        public void ShouldAddAnimal()
        {
            Enclosure enclosure = new Enclosure("Name", 200, new Zoo("location"));
            Animal lion = new Lion();
            Animal zebra = new Bison();
            int count = enclosure.Animals.Count;
            /*//return NoAvailableSpaceException если в вольер нельзя добавить животное из-за вольера
            Assert.Throws<NoAvailableSpaceException>(() => { enclosure.AddAnimals(lion); });

            //return NotFriendlyAnimalException если пытаемся добавить недружелюбное животное
            Assert.Throws<NotFriendlyAnimalException>(() => { enclosure.AddAnimals(zebra); });
            enclosure.AddAnimals(lion);
            Assert.Equal(count + 1, enclosure.Animals.Count);*/

        }
    }
}
