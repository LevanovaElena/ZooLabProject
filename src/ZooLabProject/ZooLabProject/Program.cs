using System;
using ZooLabApplication.Common;
using ZooLabApplication;
using ZooLabApplication.Animals;
using System.Collections.Generic;
using ZooLabApplication.Employees;

namespace ZooLabApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MyProgram myProgram = new MyProgram();
            myProgram.InitialZooCorp();
            myProgram.HireEmpoloyeers(myProgram.zooApp.Zoos[0],true);
            myProgram.HireEmpoloyeers(myProgram.zooApp.Zoos[1], false);
            myProgram.HealAnyAnimals(myProgram.zooApp.Zoos[0]);
            myProgram.HealAnyAnimals(myProgram.zooApp.Zoos[1]);
            myProgram.FeedAllAnimals(myProgram.zooApp.Zoos[0]);
            myProgram.FeedAllAnimals(myProgram.zooApp.Zoos[1]);

        }
    }

    public class MyProgram
    {
        public ZooConsole myConsole { get; set; } = new ZooConsole();
        public ZooApp zooApp { get; set; }
        public List<Animal> listAnimal1 { get; set; }
        public List<Animal> listAnimal2 { get; set; } = new List<Animal>();

        public MyProgram()
        {
            zooApp = new ZooApp(myConsole);

        }
        public void InitialZooCorp()
        {
            myConsole.WriteLine("Welcome to ZooCorp.");
            Zoo zooRussia = new Zoo("Russia", myConsole);
            zooApp.AddZoo(zooRussia);
            Zoo zooUSA = new Zoo("USA", myConsole);
            zooApp.AddZoo(zooUSA);
            this.AddEnclousersInZoo(zooRussia, true);
            this.AddEnclousersInZoo(zooUSA, false);
            //added animals
            myConsole.WriteLine("\n/////Animals for Zoo Russia/////////////");
            listAnimal1 = new List<Animal>() { new Lion(0), new Lion(0), new Lion(0), new Elephant(0), new Elephant(0), new Bison(0), new Snake(0), new Snake(0), new Turtle(0), new Parrot(0), new Parrot(0), new Penguin(0), new Lion(0), new Penguin(0) };
            this.AddAnimalsInZoo(zooRussia, listAnimal1, true);
            myConsole.WriteLine("\n/////Animals for Zoo USA/////////////");
            listAnimal2 = new List<Animal>() { new Bison(0), new Elephant(0), new Bison(0), new Lion(0), new Lion(0), new Lion(0), new Turtle(0), new Parrot(0), new Snake(0), new Snake(0), new Turtle(0), new Parrot(0), new Parrot(0), new Penguin(0), new Lion(0), new Penguin(0), new Bison(0) };
            this.AddAnimalsInZoo(zooUSA, listAnimal2, true);
        }

        public void AddEnclousersInZoo(Zoo zoo, bool init)
        {
            myConsole.WriteLine("\n/////Enclousers for Zoo "+zoo.Location+" /////////////");
            zoo.AddEnclosure("Enclouser for lion size 3000", 3000);
            zoo.AddEnclosure("Enclouser for snake size 100", 100);
            zoo.AddEnclosure("Enclouser for penguin size 300", 300);
            if (init)
            {
                zoo.AddEnclosure("Enclouser for elephant size 5000", 5000);
                zoo.AddEnclosure("Enclouser for birds size 100", 100);
            }
            else
            {
                zoo.AddEnclosure("Enclouser for bison size 3000", 3000);
                zoo.AddEnclosure("Enclouser for turtle size 100", 100);
            }
        }
        public void AddAnimalsInZoo(Zoo zoo, List<Animal> listAnimal1, bool init)
        {
            int item = 0;
            foreach (Animal animal in listAnimal1)
            {
                item++;
                try
                {
                    zoo.FindAvailableEnclosure(animal);
                }
                catch (Exception ex)
                {

                    myConsole.WriteLine("----Animal " + animal.GetType().Name + " not added, becouse " + ex.Message);
                    item--;
                    continue;

                }
            }
            myConsole.WriteLine("*****Added " + item.ToString() + "animals of " + listAnimal1.Count + " in Zoo " + zoo.Location + "********" + '\n');
        }

        public void HireEmpoloyeers(Zoo zoo, bool init)//AnyAnimalsIsSeek
        {
            myConsole.WriteLine("\n/////Hire Empoloyeers for Zoo " + zoo.Location + " /////////////");
            List<IEmployees> employees;
            if (init)
            {
                employees = new List<IEmployees> { new Veterinarian("Andrey", "Sokolov"), new ZooKeeper("Ivan", "Rublev"), new ZooKeeper("Elena", "Ivanova"), new Veterinarian("Elena", "Kudrina") };
                employees[0].AddAnimalExperience(new Lion(0));
                employees[0].AddAnimalExperience(new Bison(0));
                employees[1].AddAnimalExperience(new Lion(0));
                employees[1].AddAnimalExperience(new Elephant(0));
                employees[1].AddAnimalExperience(new Parrot(0));
                employees[1].AddAnimalExperience(new Penguin(0));
                employees[2].AddAnimalExperience(new Lion(0));
                employees[2].AddAnimalExperience(new Bison(0));
                employees[2].AddAnimalExperience(new Turtle(0));
                employees[1].AddAnimalExperience(new Snake(0));
            }
            else
            {
                employees = new List<IEmployees> { new Veterinarian("Jack", "Nilson"), new ZooKeeper("Michael", "Caine"), new ZooKeeper("Liam", "Neeson"), new ZooKeeper("Sean", "Connery") };
                employees[0].AddAnimalExperience(new Lion(0));
                employees[0].AddAnimalExperience(new Bison(0));
                employees[1].AddAnimalExperience(new Lion(0));
                employees[1].AddAnimalExperience(new Elephant(0));
                employees[1].AddAnimalExperience(new Parrot(0));
                employees[1].AddAnimalExperience(new Penguin(0));
                employees[3].AddAnimalExperience(new Lion(0));
                employees[3].AddAnimalExperience(new Bison(0));
                employees[3].AddAnimalExperience(new Turtle(0));
                employees[3].AddAnimalExperience(new Snake(0));
            }

            int item = 0;
            foreach (IEmployees employee in employees)
            {
                item++;
                try
                {
                    zoo.HireEmployee(employee);
                }
                catch (Exception ex)
                {

                    myConsole.WriteLine("---- " + employee.GetType().Name + " " + employee.LastName + " not hired, because " + ex.Message);
                    item--;
                    continue;

                }
            }
            myConsole.WriteLine("*****Were hired " + item.ToString() + "employee of " + employees.Count + " in Zoo " + zoo.Location + "********" + '\n');

        }

        public void HealAnyAnimals(Zoo zoo)
        {
            myConsole.WriteLine("\n/////Healing animals in Zoo " + zoo.Location + " /////////////");
            foreach (Enclosure enclosure in zoo.Enclosures)
            {
                int item = 0;
                foreach (Animal animal in enclosure.Animals)
                {
                    if (item % 2 == 0) animal.IsSeek();
                    item++;
                }
            }
            zoo.HealAnimals();        
        }
        public void FeedAllAnimals(Zoo zoo)
        {
            myConsole.WriteLine("\n/////Feeding Mammal in Zoo " + zoo.Location + " /////////////");
            zoo.FeedAnimals(new DateTime(2021, 12, 23, 11, 11, 11));
            myConsole.WriteLine("\n/////Feeding Snakes in Zoo " + zoo.Location + " /////////////");
            zoo.FeedAnimals(new DateTime(2021, 12, 23, 6, 11, 11));
            myConsole.WriteLine("\n/////Feeding Birds in Zoo " + zoo.Location + " /////////////");
            zoo.FeedAnimals(new DateTime(2021, 12, 23, 9, 11, 11));
            zoo.FeedAnimals(new DateTime(2021, 12, 23, 9, 11, 11));
            zoo.FeedAnimals(new DateTime(2021, 12, 23, 9, 11, 11));
        }
    }
}
