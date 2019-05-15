using Dogtastic.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogtastic.Models
{
    public class PlaydateCreate
    {
        [Key]
        public Guid UserID { get; set; }
        public int PlaydateID { get; set; }
        [Required]
        [Display(Name = "Parent's Full Name")]
        public string ParentName { get; set; }

        [Required]
        [Display(Name = "Dog's Name")]
        public string DogName { get; set; }
        [Required]
        [Display(Name = "What size is your dog?")]
        public SizeOfDog DogSize { get; set; }
        [Required]
        [Display(Name = "How old is your dog?")]
        public DogAge AgeLevel { get; set; }
        [Required]
        public DateTimeOffset EventDate { get; set; }

        [Required]
        public string AddressOfEvent { get; set; }

        [Required]
        public PlaydateType TypeOfPlaydate { get; set; }

        [Display(Name = "Leave a message for Host Parent")]
        [StringLength(100, ErrorMessage = "Do not enter more than 100 characters")]

        public string LeaveAMessage { get; set; }

    }
}
