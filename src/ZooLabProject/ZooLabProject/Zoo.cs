using System;
using System.Collections.Generic;
using ZooLabApplication.Common;
using ZooLabApplication.Employees;

namespace ZooLabApplication
{
    public class Zoo
    {
        public List<Enclosure> Enclosures { get; private set; } = new List<Enclosure>();
        public List<IEmployees> Enployees { get; private set; } = new List<IEmployees>();
        public string Location { get; private set; }
        public ZooConsole myConsole { get; set; }
        public int NumberOfAnimal { get; private set; } = 0;

        public Zoo(string location,ZooConsole console=null)
        {
            Location = location;
            myConsole = console;
        }

        public Enclosure AddEnclosure(string name,int squreFeet)
        {
            Enclosure enclosure = new Enclosure(name,squreFeet,this,myConsole);
            this.Enclosures.Add(enclosure);
            myConsole?.WriteLine("Enclosure  with a name \""+name+ "\" added in zoo " + this.Location);
            return enclosure;
        }

        public Enclosure FindAvailableEnclosure(Animal animal)//If Enclose is not available throw NoAvailableEclosureException
        {
            Enclosure enclosure = null;
            int itemNumber = 0;

            foreach (Enclosure enclosureItem in this.Enclosures)
            {
                itemNumber++;
                try
                {
                    NumberOfAnimal = NumberOfAnimal + 1;
                    animal.Id = NumberOfAnimal;
                    animal.myConsole = myConsole;
                    enclosureItem.AddAnimals(animal);
                    enclosure = enclosureItem;
                    break;
                        
                }
                catch (NotFriendlyAnimalException ex)
                {
                    NumberOfAnimal = NumberOfAnimal - 1;
                    if (itemNumber < this.Enclosures.Count) continue;
                    else throw new NoAvailableEclosureException(ex.Message);//"No enclosures with friendly animals!"
                }
                catch (NoAvailableSpaceException ex)
                {
                    NumberOfAnimal = NumberOfAnimal - 1;
                    if (itemNumber < this.Enclosures.Count) continue;
                    else throw new NoAvailableEclosureException("Not available enclosure,because "+ ex.Message);
                }
                    
            }

            
            return enclosure;
        }

        public void HireEmployee(IEmployees employee)

        {
            bool isHire = false;

            if (employee.AnimalExperiences.Count > 0)
            {
                //проверка опыта
                foreach(string animalExperience in employee.AnimalExperiences)
                {
                    foreach(Enclosure enclosure in this.Enclosures)
                    {
                        foreach(Animal animal in enclosure.Animals)
                        {
                            if (animalExperience == animal.GetType().Name)
                            {
                                this.Enployees.Add(employee);
                                isHire = true;
                                break;
                            }
                            
                        }
                        if (isHire) break;
                    }
                    if (isHire) break;}
                if (!isHire) throw new NoNeededExperienceException("No needed expiriense!");

            }
            else throw new NoNeededExperienceException("No needed expiriense!");
        }

        public void FeedAnimals(DateTime dateTime)
        {
            Queue<ZooKeeper> keepersWichFeed = new Queue<ZooKeeper>();
            foreach (Enclosure enclosure in this.Enclosures)
            {
                foreach (Animal animal in enclosure.Animals)
                {
                    //проверяем кормили ли уже 2 раза
                    if (animal.FeedTimes.Count >= 2 && animal.FeedTimes[animal.FeedTimes.Count - 2].FeedOfTime.Date == dateTime.Date)
                    {
                        continue;
                    }
                    else
                    {
                        //ищем подходящих работников
                        List<ZooKeeper> listKeeper = this.GetListOfAvaliableKeepers(animal.GetType().Name);
                        if (listKeeper.Count == 1)
                        { // кормим животное
                            listKeeper[0].FeedAnimal(animal,dateTime);
                        }
                        else if (listKeeper.Count >= 2)
                        {
                            //проверяем кормил ли уже 
                            if (keepersWichFeed.Count == listKeeper.Count)//число кормивших равно числу существующих-начинаем заново
                            {
                                keepersWichFeed.Dequeue().FeedAnimal(animal, dateTime);
                            }
                            else if (keepersWichFeed.Count == 0)//число кормивших меньше числа существующих-берем того,кто еще не кормил
                            {
                                listKeeper[0].FeedAnimal(animal, dateTime);
                                keepersWichFeed.Enqueue(listKeeper[0]);
                            }
                            else if (keepersWichFeed.Count < listKeeper.Count)//число кормивших меньше числа существующих-берем того,кто еще не кормил
                            {
                                listKeeper[keepersWichFeed.Count].FeedAnimal(animal, dateTime);
                                keepersWichFeed.Enqueue(listKeeper[keepersWichFeed.Count]);
                            }
                        }
                    }
                }
            }


        }

        public void HealAnimals()
        {
            foreach (Enclosure enclosure in this.Enclosures)
            {
                foreach (Animal animal in enclosure.Animals)
                {
                    if (animal.Seek)
                    {
                        List<Veterinarian> listVeterinar = this.GetListOfAvaliableVeterinarian("oneForAll");
                        listVeterinar[0].HealAnimal(animal);
                    }
                }
            }

        }
        public List<ZooKeeper> GetListOfAvaliableKeepers(string nameExpiriens)
        {
            List<ZooKeeper> list = new List<ZooKeeper>();
            foreach(IEmployees zooKeeper in this.Enployees)
            {
                if(zooKeeper.GetType().Name=="ZooKeeper")
                {
                    foreach (string animalExperience in zooKeeper.AnimalExperiences)
                    {
                        if (animalExperience == nameExpiriens) list.Add((ZooKeeper)zooKeeper);
                    }

                }
            }
            return list;
        }

        public List<Veterinarian> GetListOfAvaliableVeterinarian(string nameExpiriens)
        {
            List<Veterinarian> list = new List<Veterinarian>();
            foreach (IEmployees veterinarian in this.Enployees)
            {
                if (veterinarian.GetType().Name == "Veterinarian")
                {
                    if (nameExpiriens != "oneForAll")
                    {
                        foreach (string animalExperience in veterinarian.AnimalExperiences)
                        {
                            if (animalExperience == nameExpiriens) list.Add((Veterinarian)veterinarian);
                        }
                    }
                    else list.Add((Veterinarian)veterinarian);

                }
            }
            return list;
        }


    }
}
