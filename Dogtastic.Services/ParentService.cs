using Dogtastic.Data;
using DogtasticData;
using DogtasticModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogtastic.Services
{
    public class ParentService
    {
        private readonly Guid _parentID;
        public ParentService(Guid ParentID)
        {
            _parentID = ParentID;
        }
        public bool CreateParent(ParentCreate model)
        {
            var entity =
                    new Parent()
                    {
                        ParentID = _parentID,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Zipcode = model.Zipcode,
                        NumberOfEventsAttended = model.NumberOfEventsAttended,
                        NumberOfDogsOwned = model.NumberOfDogsOwned
                    };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Parents.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ParentListItem> GetParent()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Parents
                        .Where(e => e.ParentID == _parentID)
                        .Select(
                            e =>
                                new ParentListItem
                                {
                                    ParentID = e.ParentID,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Zipcode = e.Zipcode,
                                    NumberOfEventsAttended = e.NumberOfEventsAttended,
                                    NumberOfDogsOwned = e.NumberOfDogsOwned
                                }
                        );

                return query.ToArray();
            }
        }
        public ParentDetail GetParentByID(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Parents
                        .Single(e => e.ParentID == id && e.ParentID == _parentID);
                return
                    new ParentDetail
                    {
                        ParentID = entity.ParentID,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Zipcode = entity.Zipcode,
                        NumberOfEventsAttended = entity.NumberOfEventsAttended,
                        NumberOfDogsOwned = entity.NumberOfDogsOwned

                    };
            }
        }
        public bool UpdateParent(ParentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Parents
                        .Single(e => e.ParentID == model.ParentID && e.ParentID == _parentID);

                entity.ParentID = model.ParentID;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Zipcode = model.Zipcode;
                entity.NumberOfEventsAttended = model.NumberOfEventsAttended;
                entity.NumberOfDogsOwned = model.NumberOfDogsOwned;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteParent(Guid ParentID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Parents
                        .Single(e => e.ParentID == ParentID && e.UserId == _parentID);

                ctx.Parents.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
