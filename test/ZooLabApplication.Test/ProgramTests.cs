using System;
using Xunit;
using ZooLabApplication;


namespace ZooLabApplication.Test
{
    public class ProgramTests
    {
        [Fact]
        public void ShouldBeCreateMain()
        {
            Program program = new Program();
            Assert.NotNull(program);
            Program.Main(new string[0]);

        }
        [Fact]
        public void ShouldBeCreateAndInitMyProgram()
        {
            MyProgram myProgram = new MyProgram();
            Assert.NotNull(myProgram.myConsole);
            Assert.NotNull(myProgram.zooApp);
            myProgram.InitialZooCorp();
            Assert.Equal(2, myProgram.zooApp.Zoos.Count);
            Assert.Equal("Welcome to ZooCorp.", myProgram.myConsole.Messages[0]);
            //Assert.Equal(20, myProgram.myConsole.Messages.Count);
            Assert.Equal(2, myProgram.zooApp.Zoos.Count);

            //added enclousers in zoos
            //myProgram.AddEnclousersInZoo(myProgram.zooApp.Zoos[0]);
            Assert.Equal(5, myProgram.zooApp.Zoos[0].Enclosures.Count);
            Assert.Equal(5, myProgram.zooApp.Zoos[1].Enclosures.Count);

            //added animals 
            Assert.Equal(3, myProgram.zooApp.Zoos[0].Enclosures[0].Animals.Count);
            Assert.Equal(2, myProgram.zooApp.Zoos[0].Enclosures[1].Animals.Count);
            Assert.Equal(3, myProgram.zooApp.Zoos[0].Enclosures[2].Animals.Count);
            Assert.Equal(3, myProgram.zooApp.Zoos[0].Enclosures[3].Animals.Count);
            Assert.Equal(2, myProgram.zooApp.Zoos[0].Enclosures[4].Animals.Count);

            Assert.Equal(3, myProgram.zooApp.Zoos[1].Enclosures[0].Animals.Count);
            Assert.Equal(5, myProgram.zooApp.Zoos[1].Enclosures[1].Animals.Count);
            Assert.Equal(2, myProgram.zooApp.Zoos[1].Enclosures[2].Animals.Count);
            Assert.Equal(3, myProgram.zooApp.Zoos[1].Enclosures[3].Animals.Count);
            Assert.Equal(2, myProgram.zooApp.Zoos[1].Enclosures[4].Animals.Count);

        }

        [Fact]
        public void ShouldBeHireEmploee()
        {
            MyProgram myProgram = new MyProgram();
            myProgram.InitialZooCorp();
            myProgram.HireEmpoloyeers(myProgram.zooApp.Zoos[0],true);
            Assert.Equal(3, myProgram.zooApp.Zoos[0].Enployees.Count);
            myProgram.HireEmpoloyeers(myProgram.zooApp.Zoos[1], false);
            Assert.Equal(3, myProgram.zooApp.Zoos[1].Enployees.Count);
        }

        [Fact]
        public void ShouldBeHealAnimals()
        {
            MyProgram myProgram = new MyProgram();
            myProgram.InitialZooCorp();
            myProgram.HireEmpoloyeers(myProgram.zooApp.Zoos[0], true);
            myProgram.HealAnyAnimals(myProgram.zooApp.Zoos[0]);
            Assert.Equal(70, myProgram.myConsole.Messages.Count);
        }
    }
}
