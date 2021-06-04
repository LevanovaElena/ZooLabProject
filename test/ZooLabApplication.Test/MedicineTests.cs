using System;
using Xunit;

namespace ZooLabApplication.Test
{
     public class MedicineTests
    {
        [Fact]

        public void ShouldBeCreateAntibiotics()
        {
            Antibiotics antibiotics = new Antibiotics();
        }
        [Fact]

        public void ShouldBeCreateAntiDepression()
        {
            AntiDepression antiDepression = new AntiDepression();
        }
        [Fact]

        public void ShouldBeCreateAntiInflammatory()
        {
            AntiInflammatory antiInflammatory = new AntiInflammatory();
        }
    }
}
