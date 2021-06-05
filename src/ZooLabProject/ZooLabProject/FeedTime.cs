using System;
using ZooLabApplication.Employees;

namespace ZooLabApplication
{
    public class FeedTime
    {
        public DateTime FeedOfTime { get; private set; }
        public ZooKeeper FeedByZooKeeper { get; private set; }

        public FeedTime(DateTime feedOfTime,ZooKeeper zooKeeper)
        {
            FeedOfTime = feedOfTime;
            FeedByZooKeeper = zooKeeper;
        }
    }
}