﻿using DogtasticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogtasticModels
{
    public class DogEdit
    {
        public int DogID { get; set; }
        public string DogName { get; set; }
        public SizeOfDog DogSize { get; set; }
        public DogAge AgeLevel { get; set; }
    }
}