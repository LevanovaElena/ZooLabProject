using System;
using Xunit;
using ZooLabApplication;
using ZooLabApplication.Common;

namespace ZooLabApplication.Test
{
    public class ConsoleTests
    {
        [Fact]
        public void ShouldBeAbleToWriteToConsole()
        {
            ZooApp zooApp = new ZooApp();
            Assert.Empty(zooApp.Zoos);
            var console = new ZooConsole();
            console.WriteLine("Zoo was create!");
            Assert.Equal("Zoo was create!", console.Messages[0]);
        }


    }
}
