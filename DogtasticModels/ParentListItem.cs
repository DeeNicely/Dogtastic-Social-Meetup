﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogtasticModels
{
    public class ParentListItem
    {
        public Guid ParentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Zipcode { get; set; }
        [Display(Name = "How many events have you attended?")]
        public int NumberOfEventsAttended { get; set; }
        [Display(Name = "How many dogs do you own?")]
        public int NumberOfDogsOwned { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}