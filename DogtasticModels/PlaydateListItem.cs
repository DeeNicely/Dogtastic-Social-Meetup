using Dogtastic.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogtastic.Models
{
    //public enum SizeOfDog { Toy, Small, Medium, Large };
    //public enum DogAge { Puppy, Young, GettingUpThere, Senior }
    //public enum PlaydateType { OneOnOne, ParkAndPlay, GroupPlay, HikingTrail };

    public class PlaydateListItem
    {
        public Guid UserID { get; set; }
        public int PlaydateID { get; set; }
        public int DogID { get; set; }

        [Required]
        [Display(Name = "Parent's Name")]
        public string ParentName { get => FirstName + " " + LastName;  }

        [Display(Name = "Dog's name")]
        public string DogName { get; set; }

        [Display(Name = "What size is your dog?")]
        public SizeOfDog DogSize { get; set; }

        [Display(Name = "How old is your dog?")]
        public DogAge AgeLevel { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "Date of playdate")]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}")]
        [Display(Name = "Time of Playdate")]
        [DataType(DataType.Time)]
        public DateTime Timer { get; set; }

        [Required]
        public string AddressOfEvent { get; set; }

        [Required]
        public PlaydateType TypeOfPlaydate { get; set; }

        [Display(Name = "Leave a message for Host Parent")]
        [StringLength(100, ErrorMessage = "Do not enter more than 100 characters")]
        public string LeaveAMessage { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
