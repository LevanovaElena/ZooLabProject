using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ZooLabApplication.Employees;

namespace ZooLabApplication.Test
{
    public class VeterinarianTests
    {
        [Fact]
        public void ShouldBeCreateVeterinarian()
        {
            Veterinarian veterinarian = new("name", "lastname");

            Assert.Equal("name", veterinarian.FirstName);
            Assert.Equal("lastname", veterinarian.LastName);
            Assert.Empty(veterinarian.AnimalExperiences);
        }

        [Fact]
        public void ShouldBeAddAnimalExperiences()
        {
            Veterinarian veterinarian = new("name", "lastname");

            veterinarian.AddAnimalExperience(new Elephant(15));
            Assert.NotEmpty(veterinarian.AnimalExperiences);
            Assert.Equal("Elephant", veterinarian.AnimalExperiences[0]);
        }
        [Fact]
        public void ShouldHasAnimalExperiences()
        {
            Veterinarian zooKeeper = new("name", "lastname");
            Assert.False(zooKeeper.HasAnimalExerience(new Elephant(15)));
            zooKeeper.AddAnimalExperience(new Elephant(15));
            Assert.True(zooKeeper.HasAnimalExerience(new Elephant(15)));
            Assert.False(zooKeeper.HasAnimalExerience(new Lion(15)));
        }
        [Fact]
        public void ShouldHealAnimal()
        {
            Veterinarian veterinarian = new("name", "lastname");
            Elephant elephant = new Elephant(15);
            veterinarian.AddAnimalExperience(elephant);
            Assert.True(elephant.IsSeek());
            Assert.True(veterinarian.HealAnimal(elephant));
            Assert.False(veterinarian.HealAnimal(elephant));
        }
    }
}
