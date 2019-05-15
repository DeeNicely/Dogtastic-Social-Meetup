using Dogtastic.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogtastic.Models
{
    public class DogDetail
    {
        public int DogID { get; set; }

        [Display(Name = "Your dog's name.")]
        public string DogName { get; set; }
       
        [Display(Name = "What size is your dog?")]
        public SizeOfDog DogSize { get; set; }

        [Display(Name = "How old is your dog?")]
        public DogAge AgeLevel { get; set; } 

        [Display(Name = "Registration Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        
        public override string ToString() => $"[{DogID}] {DogName}";
    }
}

