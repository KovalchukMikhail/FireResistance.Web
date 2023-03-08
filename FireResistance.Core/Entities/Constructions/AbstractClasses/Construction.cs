﻿using FireResistance.Core.Entities.Materials.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireResistance.Core.Entities.Constructions.AbstractClasses
{
    internal abstract class Construction
    {
        public virtual Armature Armature { get; set; }
        public virtual Concrete Concrete { get; set; }
        public virtual double Height { get; set; }
        public virtual double Width { get; set;}
        public virtual double Length { get; set; }
        public virtual double Moment { get; set; }
        public virtual double Strength { get; set; }
        public double workHeight { get; set; }


    }
}
