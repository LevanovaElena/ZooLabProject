using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLabApplication.Employees;

namespace ZooLabApplication.HireValidator
{
    public interface IHireValidator
    {
        List<ValidationError> ValidateEmployee(IEmployees employee,Zoo zoo);
    }
    public abstract class HireValidator
    {
        public abstract List<ValidationError> ValidateEmployee(IEmployees employee,Zoo zoo); 
    }

    public class ValidationError
    {
        public string Message { get; }

        public ValidationError(string message)
        {
            Message = message;
        }
    }

     public class VeterinarianHireValidator : HireValidator, IHireValidator
     {
         public override List<ValidationError> ValidateEmployee(IEmployees employee,Zoo zoo)
         {
            List<ValidationError> listErrors = new List<ValidationError>();
            Veterinarian veterinarian = employee as Veterinarian;

            bool isHire = false;

            foreach (Enclosure enclosure in zoo.Enclosures)
            {
                foreach (Animal animal in enclosure.Animals)
                {
                    if (veterinarian.HasAnimalExerience(animal))
                    {
                        isHire = true;
                        break;
                    }
                    else continue;
                }
                if (isHire) break;
            }
            if (!isHire) listErrors.Add(new ValidationError("No needed expiriense!"));
            return listErrors;
        }
     }
     public class ZooKeeperHireValidator : HireValidator, IHireValidator
     {
         public override List<ValidationError> ValidateEmployee(IEmployees employee,Zoo zoo)
         {
            List<ValidationError> listErrors = new List<ValidationError>();
            ZooKeeper zooKeeper = employee as ZooKeeper;

            bool isHire = false;


            foreach (Enclosure enclosure in zoo.Enclosures)
            {
                foreach (Animal animal in enclosure.Animals)
                {
                    if (zooKeeper.HasAnimalExerience(animal))
                    {
                        isHire = true;
                        break;
                    }
                    else continue;
                }
                if (isHire) break;
            }
            if (!isHire) listErrors.Add(new ValidationError("No needed expiriense!"));
            return listErrors;
         }
     }

     public class HireValidatorProvider 
     {
         public static IHireValidator GetHireValidator(IEmployees employee)
         {
            string typeOfEmployee = employee.GetType().Name;

            if (typeOfEmployee == "ZooKeeper")
            {
                return new ZooKeeperHireValidator();
            }
            else //if (typeOfEmployee == "Veterinarian")
            {
                return new VeterinarianHireValidator();
            }

     }

    }

}
