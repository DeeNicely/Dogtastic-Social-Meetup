using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogtasticData
{ 
    public enum PlaydateType { OneOnOne, ParkAndPlay, GroupPlay, HikingTrail };

    public class Playdate
    {
        [Key]
        [Required]
        public int PlaydateID { get; set; }

        [Required]
        public DateTimeOffset EventDate { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public PlaydateType TypeOfPlaydate { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
