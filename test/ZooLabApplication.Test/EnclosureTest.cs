using System;
using Xunit;
using ZooLabApplication.Animals;

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

            int count = 0;
            enclosure.AddAnimals(elephant);
            count = count + 1;
            Assert.Equal(count, enclosure.Animals.Count);
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
            Parrot parrot = new Parrot(15);

            int count = 0;
            enclosure.AddAnimals(elephant);
            count = count + 1;
            Assert.Equal(count, enclosure.Animals.Count);
            Assert.Throws<NoAvailableSpaceException>(() => { enclosure.AddAnimals(bison); });

            enclosure.AddAnimals(parrot);
            count = count + 1;
            Assert.Equal(count, enclosure.Animals.Count);
            Assert.Throws<NoAvailableSpaceException>(() => { enclosure.AddAnimals(bison); });
        }

        [Fact]
        public void ShouldAddNotFriendlyAnimalInBigEnclosure()
        {
            Zoo zoo = new Zoo("location");


            Enclosure enclosure = new Enclosure("Name", 2000, zoo);

            Elephant elephant = new Elephant(12);
            Lion lion = new Lion(23);
            int count = enclosure.Animals.Count;
            enclosure.AddAnimals(elephant);
            count = count + 1;
            Assert.Equal(count, enclosure.Animals.Count);
            Assert.Throws<NotFriendlyAnimalException>(() => { enclosure.AddAnimals(lion); });


            
        }

        [Fact]

        public void ShoulReturnNumberOfSquereFeet()
        {
            Enclosure enclosure = new Enclosure("Name", 2000, new Zoo("location"));
            Assert.Equal(0, enclosure.GetFillSqureFeet());

            Elephant elephant = new Elephant(12);
            enclosure.AddAnimals(elephant);
            Assert.Equal(1000, enclosure.GetFillSqureFeet());
            enclosure.AddAnimals(elephant);
            Assert.Equal(2000, enclosure.GetFillSqureFeet());
        }
    }
}
