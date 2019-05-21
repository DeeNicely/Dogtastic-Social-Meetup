using Dogtastic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogtasticModels
{
    public class ParentIndex
    {
        public IEnumerable<ParentListItem> Parents { get; set; }
        public Guid UserID { get; set; }
        public ParentIndex(Guid userId, IEnumerable<ParentListItem> parents)
        {
            Parents = parents;
            UserID = userId;
        }
    }
}
