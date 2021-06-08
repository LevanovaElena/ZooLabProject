using System;
using ZooLabApplication.Common;
using ZooLabApplication;
using ZooLabApplication.Animals;
using System.Collections.Generic;

namespace ZooLabApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MyProgram myProgram = new MyProgram();
            myProgram.InitialZooCorp();
        }
    }

    public class MyProgram
    {
        public ZooConsole myConsole { get; set; } = new ZooConsole();
        public ZooApp zooApp { get; set; }
        public List<Animal> listAnimal1 { get; set; } = new List<Animal>();
        public List<Animal> listAnimal2 { get; set; } = new List<Animal>();

        public MyProgram()
        {
            zooApp = new ZooApp(myConsole);
        }
        public void InitialZooCorp()
        {
            myConsole.WriteLine("Welcome to ZooCorp.");
            Zoo zooRussia = new Zoo("Russia",myConsole);
            zooApp.AddZoo(zooRussia);
            Zoo zooUSA = new Zoo("USA", myConsole);
            zooApp.AddZoo(zooUSA);
            this.AddEnclousersInZoo(zooRussia, true);
            this.AddEnclousersInZoo(zooUSA, false);
            //added animals
            myConsole.WriteLine("/////Animals for Zoo Russia/////////////");

            this.AddAnimalsInZoo(zooRussia, true);
        }

        public void AddEnclousersInZoo(Zoo zoo, bool init)
        {
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
        public void AddAnimalsInZoo(Zoo zoo, bool init)
        {
           
                zoo.FindAvailableEnclosure(new Lion(0));
                zoo.FindAvailableEnclosure(new Lion(0));
                zoo.FindAvailableEnclosure(new Lion(0));
                zoo.FindAvailableEnclosure(new Elephant(0));
                zoo.FindAvailableEnclosure(new Elephant(0));
                zoo.FindAvailableEnclosure(new Bison(0));
               // if (init) zoo.FindAvailableEnclosure(new Lion(0));
                zoo.FindAvailableEnclosure(new Snake(0));
                zoo.FindAvailableEnclosure(new Snake(0));
                zoo.FindAvailableEnclosure(new Penguin(0));
                zoo.FindAvailableEnclosure(new Penguin(0));
                zoo.FindAvailableEnclosure(new Turtle(0));
                zoo.FindAvailableEnclosure(new Parrot(0));

        }
    }
}
