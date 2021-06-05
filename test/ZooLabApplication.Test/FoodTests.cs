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
        [Fact]
        public void ShouldBeCreateFish()
        {
            Fish fish = new Fish();
        }
        [Fact]
        public void ShouldBeCreateSeeds()
        {
            Seeds seeds = new Seeds();
        }
        [Fact]
        public void ShouldBeCreateFruits()
        {
            Fruits fruit = new Fruits();
        }
    }
}
