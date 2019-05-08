using DogtasticData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogtastic.Models
{
    public class DogCreate
    {
        public int UserID { get; set; }

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

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
