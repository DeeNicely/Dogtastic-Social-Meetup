using DogtasticData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogtasticModels
{
    public class DogListItem
    {
        public int DogID { get; set; }

        [Display(Name ="Dog's name")]
        public string DogName { get; set; }

        
        [Display(Name = "What size is your dog?")]
        public SizeOfDog DogSize { get; set; }

        
        [Display(Name = "How old is your dog?")]
        public DogAge AgeLevel { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
