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
        public string ParentName { get; set; }

        [Display(Name = "Dog's name")]
        public string DogName { get; set; }

        [Display(Name = "What size is your dog?")]
        public SizeOfDog DogSize { get; set; }

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

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
