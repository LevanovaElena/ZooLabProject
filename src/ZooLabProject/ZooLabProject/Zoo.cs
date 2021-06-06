using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLabApplication
{
    public class Zoo
    {
        public List<Enclosure> Enclosures { get; private set; } = new List<Enclosure>();
        public List<IEmployees> Enployees { get; private set; } = new List<IEmployees>();
        public string Location { get; private set; }

        public Zoo(string location)
        {
            Location = location;
        }

        public Enclosure AddEnclosure(string name,int squreFeet)
        {
            Enclosure enclosure = new Enclosure(name,squreFeet,this);
            this.Enclosures.Add(enclosure);
            return enclosure;
        }

        public Enclosure FindAvailableEnclosure(Animal animal)//If Enclose is not available throw NoAvailableEclosureException
        {
            Enclosure enclosure = null;
            try
            {
                foreach (Enclosure enclosureItem in this.Enclosures)
                {
                    enclosureItem.AddAnimals(animal);
                    enclosure = enclosureItem;
                }
            }
            catch(NotFriendlyAnimalException ex)
            {
                throw new NoAvailableEclosureException(ex.Message);//"No enclosures with friendly animals!"
            }
            catch (NoAvailableSpaceException ex)
            {
                throw new NoAvailableEclosureException(ex.Message);
            }
            return enclosure;
        }

        public void HireEmployee(IEmployees employee)
        {
            if (employee.AnimalExperiences.Count > 0)
            {
                //проверка опыта
                //foreach(Animal animal in )
                this.Enployees.Add(employee);

            }
            else throw new NoNeededExperienceException("No needed expiriense!");
        }
    }
}
