using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogtastic.Data
{
    //public enum SizeOfDog { Toy, Small, Medium, Large };
    //public enum DogAge { Puppy, Young, GettingUpThere, Senior }
    public enum PlaydateType { OneOnOne, ParkAndPlay, GroupPlay, HikingTrail };

    public class Playdate
    {
        [Key]
        public int PlaydateID {get; set;}
        [Display(Name = "Parent Name")]
        public Guid UserID { get; set; }
        public int DogID { get; set; }
        
        
        [Required]
        [Display(Name = "Date and Time of playdate.")]
        public DateTime EventDate { get; set; }

        [Required]
        public string AddressOfEvent { get; set; }

        [Required]
        public PlaydateType TypeOfPlaydate { get; set; }

        [Display(Name = "Leave a message for Host Parent")]
        [StringLength(100, ErrorMessage = "Do not enter more than 100 characters")]

        public string LeaveAMessage { get; set; }

        //virtual key
        public virtual Dog Dog { get; set; }
        public virtual Parent Parent { get; set; }

    }
}
