using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogtastic.Models
{
    public class ParentEdit
    {
        public Guid UserID { get; set; }
        public int ParentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Zipcode { get; set; }
        public int NumberOfEventsAttended { get; set; }
        public int NumberOfDogsOwned { get; set; }
    }
}
