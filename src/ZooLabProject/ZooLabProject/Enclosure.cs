using System;
using System.Collections.Generic;
using ZooLabApplication.Common;

namespace ZooLabApplication
{
    public class Enclosure
    {
        public string Name { get; private set; }
        public List<Animal> Animals { get; private set; } = new List<Animal>();
        public Zoo ParentZoo { get; private set; }
        public int SqureFeet { get; private set; }
        public ZooConsole myConsole { get; set; }

        public Enclosure(string name,int squreFeet,Zoo parentZoo,ZooConsole console=null)
        {
            Name = name;
            SqureFeet = squreFeet;
            ParentZoo = parentZoo;
            myConsole = console;
        }

        public void AddAnimals(Animal animal)
        {
            if(Animals.Count>0)//animals is in this
            {

                foreach (Animal animalItem in Animals)
                {
                    if (animalItem.IsFriendlyWith(animal))
                    {
                        break;
                    }
                    else
                    {
                        //return NotFriendlyAnimalException если пытаемся добавить недружелюбное животное
                        //myConsole?.WriteLine("In enclosure is not friendly animal");
                        throw new NotFriendlyAnimalException("In enclosure is not friendly animal");
                    }
                }
                if(this.SqureFeet-this.GetFillSqureFeet()>=animal.RequiredSpaceSqFt)
                {
                    Animals.Add(animal);
                    myConsole?.WriteLine("Animal " + animal.GetType().Name + " id=" + animal.Id +" was added in enclouser "+this.Name);
                }
                else
                {
                    //return NoAvailableSpaceException если в вольер нельзя добавить животное из-за вольера
                  //myConsole?.WriteLine("Enclosure is too small");
                    throw new NoAvailableSpaceException("Enclosure is too small");
                }

            }
            else
            {
                if (SqureFeet >= animal.RequiredSpaceSqFt)
                {
                    Animals.Add(animal);
                    myConsole?.WriteLine("Animal " + animal.GetType().Name + " id=" + animal.Id + " was added in enclouser " + this.Name);
                }
                else
                {
                    //return NoAvailableSpaceException если в вольер нельзя добавить животное из-за вольера
                    //myConsole?.WriteLine("Enclosure is too small");
                    throw new NoAvailableSpaceException("Enclosure is too small");
                }
            }
         }

        public int GetFillSqureFeet()
        {
            if (Animals.Count > 0)//animals is in this
            {
                int fillSqureFeet = 0;

                foreach (Animal animalItem in Animals)
                {
                    fillSqureFeet += animalItem.RequiredSpaceSqFt;
                }
                return fillSqureFeet;
            }
            else return 0;
        }
    }
}