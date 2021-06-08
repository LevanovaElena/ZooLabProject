using System;
using Xunit;
using ZooLabApplication;


namespace ZooLabApplication.Test
{
    public class ZooAppTest
    {
        [Fact]
        public void ShouldBeCreateZooApp()
        {
            ZooApp zooApp = new ZooApp();
        }
        [Fact]
        public void ShouldBeAddZoo()
        {
            ZooApp zooApp = new ZooApp();
            zooApp.AddZoo(new Zoo("Canada"));
            Assert.Single(zooApp.Zoos);
            zooApp.AddZoo(new Zoo("NewZoo"));
            Assert.Equal(2,zooApp.Zoos.Count);
        }

    }
}
