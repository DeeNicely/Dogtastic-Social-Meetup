using Dogtastic.Data;
using Dogtastic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogtastic.Services
{
    public class ParentService
    {
        private readonly Guid _userId;
        public ParentService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateParent(ParentCreate model)
        {
            var entity =
                    new Parent()
                    {
                        UserID = _userId,
                        ParentID = model.ParentID,
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
                        .Where(e => e.UserID == _userId)
                        .Select(
                            e =>
                                new ParentListItem
                                {
                                    UserID = e.UserID,
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
        public ParentDetail GetParentByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Parents
                        .Single(e => e.ParentID == id && e.UserID == _userId);
                return
                    new ParentDetail
                    {
                        UserID = entity.UserID,
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
                        .Single(e => e.UserID == model.UserID && e.UserID == _userId);
                entity.UserID = model.UserID;
                entity.ParentID = model.ParentID;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Zipcode = model.Zipcode;
                entity.NumberOfEventsAttended = model.NumberOfEventsAttended;
                entity.NumberOfDogsOwned = model.NumberOfDogsOwned;
                     return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteParent(int UserID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Parents
                        .Single(e => e.ParentID == UserID && e.UserID == _userId);

                ctx.Parents.Remove(entity);


                return ctx.SaveChanges() == 1;
            }
        }
    }
}
