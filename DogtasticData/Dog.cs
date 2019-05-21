using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogtastic.Data
{
    public enum SizeOfDog { Toy, Small, Medium, Large };
    public enum DogAge { Puppy, Young, GettingUpThere, Senior }

    public class Dog
    {
        
        public int DogID { get; set; }
        public Guid UserID { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Dog's Name")]
        public string DogName { get; set; }

        [Required]
        [Display(Name = "What size is your dog?")]
        public SizeOfDog DogSize { get; set; }

        [Required]
        [Display(Name = "How old is your dog?")]
        public DogAge AgeLevel { get; set; }
    }
}

