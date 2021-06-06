using System;

using Xunit;
using ZooLabApplication.Animals;
using ZooLabApplication.Employees;

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
            Enclosure enclosure = zoo.AddEnclosure("Enclosure for Lion", 2000);
            Assert.Single(zoo.Enclosures);
            Assert.Equal(1, zoo.Enclosures.Count);

            //нашли контейнер и добавили животное
            Enclosure enclosureForLion = zoo.FindAvailableEnclosure(new Lion(45));
            Assert.NotNull(enclosureForLion);
            Assert.Equal(1, enclosureForLion.Animals.Count);

            //нашли но не добавили,тк животные не дружелюбны
            Assert.Throws<NoAvailableEclosureException>(() => { zoo.FindAvailableEnclosure(new Bison(15)); });
            Assert.Equal(1, enclosureForLion.Animals.Count);

            Assert.NotNull(zoo.FindAvailableEnclosure(new Lion(25)));
            Assert.Equal(2, enclosureForLion.Animals.Count);

            //нашли но не добавили,тк места нет
            Assert.Throws<NoAvailableEclosureException>(() => { zoo.FindAvailableEnclosure(new Lion(15)); });
        }

        [Fact]

        public void ShouldHireEmplooyee()
        {
            Zoo zoo = new Zoo("location");

            IEmployees zooKeeper = new ZooKeeper("firstName","lastName");
            //нет опыта
            Assert.Throws<NoNeededExperienceException>(() => { zoo.HireEmployee(zooKeeper); });
            IEmployees vet = new Veterinarian("firstName", "lastName");
            //нет опыта
            Assert.Throws<NoNeededExperienceException>(() => { zoo.HireEmployee(vet); });

            //add animals
            Enclosure enclosure = zoo.AddEnclosure("Enclosure for Lion", 2000);
            Enclosure enclosureForLion = zoo.FindAvailableEnclosure(new Lion(45));

            zooKeeper.AddAnimalExperience(new Lion(45));
            zoo.HireEmployee(zooKeeper);
            Assert.Single(zoo.Enployees);

        }
    }
}
