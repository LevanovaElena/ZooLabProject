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
        public void ShouldAddFriendlyAnimalInBigEnclosure()
        {
            Enclosure enclosure = new Enclosure("Name", 2000, new Zoo("location"));
            Elephant elephant = new Elephant(12);
            Bison bison = new Bison(23);
            int count = enclosure.Animals.Count;
            enclosure.AddAnimals(elephant);
            count = count + 1;
            Assert.Equal(count ++, enclosure.Animals.Count);
            enclosure.AddAnimals(bison);
            count = count + 1;
            Assert.Equal(count, enclosure.Animals.Count);
           
        }

        [Fact]
        public void ShouldAddFirstAnimalInSmollEnclosure()
        {
            Enclosure enclosure = new Enclosure("Name", 150, new Zoo("location"));
            Elephant elephant = new Elephant(12);
            Assert.Throws<NoAvailableSpaceException>(() => { enclosure.AddAnimals(elephant); });
        }
        [Fact]
        public void ShouldAddFriendlyAnimalInSmollEnclosure()
        {
            Enclosure enclosure = new Enclosure("Name", 1500, new Zoo("location"));
            Elephant elephant = new Elephant(12);
            Bison bison = new Bison(23);
            int count = enclosure.Animals.Count;
            enclosure.AddAnimals(elephant);
            count = count + 1;
            Assert.Equal(count, enclosure.Animals.Count);
            Assert.Throws<NoAvailableSpaceException>(() => { enclosure.AddAnimals(bison); });
        }

        [Fact]
        public void ShouldAddNotFriendlyAnimalInBigEnclosure()
        {
            Enclosure enclosure = new Enclosure("Name", 2000, new Zoo("location"));
            Elephant elephant = new Elephant(12);
            Lion lion = new Lion(23);
            int count = enclosure.Animals.Count;
            enclosure.AddAnimals(elephant);
            count = count + 1;
            Assert.Equal(count, enclosure.Animals.Count);
            Assert.Throws<NotFriendlyAnimalException>(() => { enclosure.AddAnimals(lion); });
        }
    }
}
