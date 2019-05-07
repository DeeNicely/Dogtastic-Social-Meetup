using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dogtastic.Models
{
    public class Dog
    {
        public int UserID { get; set; }
        public int DogID { get; set; }
        public string DogName { get; set; }
        [Required]
        public string DogSize { get; set; }
        [Required]
        public string AgeLevel { get; set; }
    }
}