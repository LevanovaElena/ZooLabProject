using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLabApplication.HireValidator
{
    public interface IHireValidator
    {
    }
    public abstract class HireValidator
    {
        public abstract List<ValiationError> ValidateEmployee(IEmployees employee); 
    }

    public class ValiationError
    {

    }

    /* public class VeterinarianHireValidator : HireValidator, IHireValidator
     {
         public override List<ValiationError> ValidateEmployee(IEmployees employee)
         {
             throw new NotImplementedException();
         }
     }
     public class ZooKeeperHireValidator : HireValidator, IHireValidator
     {
         public override List<ValiationError> ValidateEmployee(IEmployees employee)
         {
             throw new NotImplementedException();
         }
     }

     public class HireValidatorProvider : IHireValidator
     {
         IEmployeeHireValidator GetHireValidator(IEmployees employees)
         {
             throw new NotImplementedException();
         }
     }*/

    internal interface IEmployeeHireValidator
    {
    }
}
