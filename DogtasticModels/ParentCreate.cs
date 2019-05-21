using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogtastic.Models
{
    public class ParentCreate
    {
        [Key]
        public Guid UserID { get; set; }
        public int ParentID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Enter zipcode for location purposes.")]
        public int Zipcode { get; set; }

        [Required]
        [Display(Name = "How many events have you attended?")]
        public int NumberOfEventsAttended { get; set; }

        [Required]
        [Display(Name = "How many dogs do you have?")]
        public int NumberOfDogsOwned { get; set; }

        [Display(Name = "Full Name")]
        public string ParentName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
