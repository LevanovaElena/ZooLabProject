﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLabApplication.Animals
{
    public class Snake : Reptile
    {
        public override int RequiredSpaceSqFt { get; }
        public Snake(int id) : base(id)
        {
            RequiredSpaceSqFt = 2;
        }
        public override bool IsFriendlyWith(Animal animal)
        {
            if (animal.GetType().Equals(this.GetType())) return true;
            else return false;
        }
    }
}