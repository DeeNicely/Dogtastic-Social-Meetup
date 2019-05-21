using Dogtastic.Data;
using Dogtastic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogtasticModels
{
    public class DogIndex
    {
        public IEnumerable<DogListItem> Dogs { get; set; }
        public Guid UserID { get; set; }
        public DogIndex(Guid userId, IEnumerable<DogListItem> dogs)
        {
            Dogs = dogs;
            UserID = userId;
        }
    }
}
