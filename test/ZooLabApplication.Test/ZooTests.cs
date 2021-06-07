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
            //Assert.Equal(1, zoo.Enclosures.Count);

            //нашли контейнер и добавили животное
            Enclosure enclosureForLion = zoo.FindAvailableEnclosure(new Lion(45));
            Assert.NotNull(enclosureForLion);
            //Assert.Equal(1, enclosureForLion.Animals.Count);

            //нашли но не добавили,тк животные не дружелюбны
            Assert.Throws<NoAvailableEclosureException>(() => { zoo.FindAvailableEnclosure(new Bison(15)); });
            //Assert.Equal(1, enclosureForLion.Animals.Count);

            Assert.NotNull(zoo.FindAvailableEnclosure(new Lion(25)));
            Assert.Equal(2, enclosureForLion.Animals.Count);

            //нашли но не добавили,тк места нет
            Assert.Throws<NoAvailableEclosureException>(() => { zoo.FindAvailableEnclosure(new Lion(15)); });

            //проверка когда вольеров несколько
            Enclosure enclosure2 = zoo.AddEnclosure("Enclosure for Elefant", 2000);
            Enclosure enclosureForElephant=zoo.FindAvailableEnclosure(new Elephant(45));
            Assert.Equal(1, enclosureForElephant.Animals.Count);
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

            IEmployees zooKeeper2 = new ZooKeeper("firstName", "lastName");
            zooKeeper2.AddAnimalExperience(new Parrot(45));
            Assert.Equal(1, zooKeeper2.AnimalExperiences.Count);

            Enclosure enclosure2 = zoo.AddEnclosure("Enclosure for Elefant", 3000);

            Enclosure enclosureForElephant=zoo.FindAvailableEnclosure(new Elephant(45));
            zoo.FindAvailableEnclosure(new Parrot(45));
            Assert.Equal(2, enclosureForElephant.Animals.Count);
            zoo.HireEmployee(zooKeeper2);
            Assert.Equal(2, zoo.Enployees.Count);
        }

        [Fact]
        public void ShouldFeedAnimals() 
        {
            Zoo zoo = new("Canada");
            Lion lion = new Lion(12);
            Enclosure enclosure = zoo.AddEnclosure("Enclosure for Lion", 3000);
            zoo.FindAvailableEnclosure(lion);
            IEmployees zooKeeper = new ZooKeeper("firstName", "lastName");
            zooKeeper.AddAnimalExperience(lion);
            zoo.HireEmployee(zooKeeper);
            zoo.FeedAnimals(DateTime.Now);
            Assert.Equal(zooKeeper, lion.FeedTimes[0].FeedByZooKeeper);

            //добавим еще льва и похожего работника
            Lion lion2 = new Lion(13);
            zoo.FindAvailableEnclosure(lion2);
            IEmployees zooKeeper2 = new ZooKeeper("firstName2", "lastName2");
            zooKeeper2.AddAnimalExperience(lion2);
            zoo.HireEmployee(zooKeeper2);
            zoo.FeedAnimals(DateTime.Now);
            Assert.Equal(zooKeeper, lion.FeedTimes[0].FeedByZooKeeper);
            Assert.Equal(zooKeeper2, lion2.FeedTimes[0].FeedByZooKeeper);

            //покормим 2й раз
            zoo.FeedAnimals(DateTime.Now);
            Assert.Equal(2, lion.FeedTimes.Count);
            Assert.Equal(2, lion2.FeedTimes.Count);
            Assert.Equal(zooKeeper, lion.FeedTimes[1].FeedByZooKeeper);
            Assert.Equal(zooKeeper, lion2.FeedTimes[1].FeedByZooKeeper);

            //льва 3 а работников 2
            Lion lion3 = new Lion(13);
            zoo.FindAvailableEnclosure(lion3);
            zoo.FeedAnimals(DateTime.Today.AddDays(1));
            Assert.Equal(zooKeeper, lion.FeedTimes[0].FeedByZooKeeper);
            Assert.Equal(zooKeeper2, lion2.FeedTimes[0].FeedByZooKeeper);
            Assert.Equal(zooKeeper, lion3.FeedTimes[0].FeedByZooKeeper);

            //льва 3 и работников 3
            IEmployees zooKeeper3 = new ZooKeeper("firstName3", "lastName3");
            zooKeeper3.AddAnimalExperience(lion3);
            zoo.HireEmployee(zooKeeper3);
            zoo.FeedAnimals(DateTime.Today.AddDays(1));
            Assert.Equal(zooKeeper, lion.FeedTimes[1].FeedByZooKeeper);
            //Assert.Equal(zooKeeper2, lion2.FeedTimes[1].FeedByZooKeeper);
            //Assert.Equal(zooKeeper3, lion3.FeedTimes[1].FeedByZooKeeper);
        }


        [Fact]
        public void ShouldGetListOfZooKeeper()
        {
            Zoo zoo = new("Canada");

           Assert.Equal(0, zoo.GetListOfAvaliableKeepers("Lion").Count);

            Enclosure enclosure = zoo.AddEnclosure("Enclosure for Lion", 2000);
            zoo.FindAvailableEnclosure(new Lion(12));
            IEmployees zooKeeper = new ZooKeeper("firstName", "lastName");
            Assert.Equal(0, zoo.GetListOfAvaliableKeepers("Lion").Count);

            zooKeeper.AddAnimalExperience(new Lion(12));
            zoo.HireEmployee(zooKeeper);
            Assert.Equal(1, zoo.GetListOfAvaliableKeepers("Lion").Count);

            Enclosure enclosure1 = zoo.AddEnclosure("Enclosure for Elephant", 3000);
            zoo.FindAvailableEnclosure(new Elephant(12));

            IEmployees zooKeeper1 = new ZooKeeper("firstName1", "lastName1");
            zooKeeper1.AddAnimalExperience(new Lion(12));
            zoo.HireEmployee(zooKeeper1);
            Assert.Equal(2, zoo.GetListOfAvaliableKeepers("Lion").Count);

            IEmployees zooKeeper2 = new ZooKeeper("firstName2", "lastName2");
            zooKeeper2.AddAnimalExperience(new Elephant(12));
            zoo.HireEmployee(zooKeeper2);
            Assert.Equal(1, zoo.GetListOfAvaliableKeepers("Elephant").Count);

        }
    }
}
