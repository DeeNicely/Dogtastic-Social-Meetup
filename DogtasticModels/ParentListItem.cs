using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogtastic.Models
{
    public class ParentListItem
    {
        public Guid UserID { get; set; }
        public int DogID { get; set; }
        public int ParentID { get; set; }
        public string ParentName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Zipcode { get; set; }
        [Display(Name = "How many events have you attended?")]
        public int NumberOfEventsAttended { get; set; }
        [Display(Name = "How many dogs do you own?")]
        public int NumberOfDogsOwned { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
