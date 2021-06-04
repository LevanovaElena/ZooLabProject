using System;
using System.Collections.Generic;

namespace ZooLabApplication
{
    public class Enclosure
    {
        public string Name { get; private set; }
        public List<Animal> Animals { get; private set; } = new List<Animal>();
        public Zoo ParentZoo { get; private set; }
        public int SqureFeet { get; private set; }

        public Enclosure(string name,int squreFeet,Zoo parentZoo)
        {
            Name = name;
            SqureFeet = squreFeet;
            ParentZoo = parentZoo;
        }

        public void AddAnimals(Animal animal)
        {
            if(Animals.Count>0)//animals is in this
            {
                int fillSqureFeet = 0;

                foreach (Animal animalItem in Animals)
                {
                    fillSqureFeet += animalItem.RequiredSpaceSqFt;
                    if (animalItem.IsFriendlyWith(animal))
                    {
                        Animals.Add(animal);
                        break;
                    }
                    else
                    {
                        //return NotFriendlyAnimalException если пытаемся добавить недружелюбное животное
                        throw new NotFriendlyAnimalException("In enclosure is not friendly animal");
                    }
                }
                if(this.SqureFeet-fillSqureFeet>=animal.RequiredSpaceSqFt)
                {
                    Animals.Add(animal);
                }
                else
                {
                    //return NoAvailableSpaceException если в вольер нельзя добавить животное из-за вольера
                    throw new NoAvailableSpaceException("Enclosure is too small");
                }

            }
            else
            {
                if (SqureFeet >= animal.RequiredSpaceSqFt)
                {
                    Animals.Add(animal);
                }
                else
                {
                    //return NoAvailableSpaceException если в вольер нельзя добавить животное из-за вольера
                    throw new NoAvailableSpaceException("Enclosure is too small");
                }
            }
            
            
            

            
      
        }
    }
}