using System;
using Xunit;
using ZooLabApplication.Foods;

namespace ZooLabApplication.Test
{
     public class FoodTests
    {
        [Fact]

        public void ShouldBeCreateGrass()
        {
            Grass grass = new Grass();
        }
        [Fact]

        public void ShouldBeCreateVegetable()
        {
            Vegetable vegetable = new Vegetable();
        }
        [Fact]

        public void ShouldBeCreateMeet()
        {
            Meet meet = new Meet();
        }
    }
}
