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
        public List<IEnployees> Enployees { get; private set; } = new List<IEnployees>();
        public string Location { get; private set; }

        public Zoo(string location)
        {
            Location = location;
        }

        public Enclosure AddEnclosure(string name,int squreFeet)
        {
            Enclosure enclosure = new Enclosure(name,squreFeet,this);
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
    }
}
