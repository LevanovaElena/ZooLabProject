using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ZooLabApplication.Employees;
using ZooLabApplication.HireValidator;

namespace ZooLabApplication.Test
{
  
    public class HireValidatorTests
    {
        [Fact]
        public void ShouldBeCreateValidationError()
        {
            ValidationError error = new ValidationError("message");
            Assert.Equal("message", error.Message);
        }

        [Fact]
        public void ShouldGetHireValidationProvider()
        {
            IHireValidator hireValidator = HireValidatorProvider.GetHireValidator(new ZooKeeper("name","lastName"));
            Assert.NotNull(hireValidator);
            Assert.Equal("ZooKeeperHireValidator", hireValidator.GetType().Name);

            IHireValidator hireValidator2 = HireValidatorProvider.GetHireValidator(new Veterinarian("name", "lastName"));
            Assert.NotNull(hireValidator2);
            Assert.Equal("VeterinarianHireValidator", hireValidator2.GetType().Name);
        }

    }
}
