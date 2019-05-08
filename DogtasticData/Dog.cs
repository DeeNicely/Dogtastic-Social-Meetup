using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogtasticData
{
    public enum SizeOfDog { Small, Medium, Large };
    public enum DogAge { Puppy, Young, GettingUpThere, Senior }
    public class Dog
    {
        [Key]
        public Guid UserID { get; set; }
        public int DogID { get; set; }

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

