using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLabApplication.Employees;
using Xunit;

namespace ZooLabApplication.Test
{
   public class FeedTimeTests
    {
        [Fact]
        public void ShouldBeCreateFeedTime()
        {
            DateTime now = DateTime.Now;
            ZooKeeper zooKeeper = new ZooKeeper("name","lastname");
            FeedTime feed = new(now,zooKeeper );
            Assert.Equal(now, feed.FeedOfTime);
            Assert.Equal(now, feed.FeedOfTime);
        }

        }
}
