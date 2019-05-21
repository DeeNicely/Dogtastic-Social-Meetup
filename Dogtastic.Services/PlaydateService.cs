using Dogtastic.Data;
using Dogtastic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogtastic.Services
{
    public class PlaydateService
    {
        private readonly Guid _userId;
        public PlaydateService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreatePlaydate(PlaydateCreate model)
        {
            var entity =
                    new Playdate()
                    {
                        UserID = _userId,
                        PlaydateID = model.PlaydateID,
                        DogID = model.DogID,
                        //ParentName = model.ParentName,
                        //DogName = model.DogName,
                        //AgeLevel = model.AgeLevel,
                        //DogSize = model.DogSize,
                        EventDate = model.EventDate,
                        AddressOfEvent = model.AddressOfEvent,
                        TypeOfPlaydate = model.TypeOfPlaydate,
                        LeaveAMessage = model.LeaveAMessage

                    };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.PlayDates.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PlaydateListItem> GetPlaydates()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .PlayDates
                        .Where(e => e.UserID == _userId)
                        .Select(
                            e =>
                                new PlaydateListItem
                                {
                                    UserID = e.UserID,
                                    PlaydateID = e.PlaydateID,
                                    DogID = e.DogID,
                                    FirstName = e.Parent.FirstName,
                                    LastName = e.Parent.LastName,
                                    DogName = e.Dog.DogName,
                                    //DogSize = e.DogSize,
                                    //AgeLevel = e.AgeLevel,
                                    EventDate = e.EventDate,
                                    AddressOfEvent = e.AddressOfEvent,
                                    TypeOfPlaydate = e.TypeOfPlaydate,
                                    LeaveAMessage = e.LeaveAMessage
                                }
                        );

                return query.ToArray();
            }
        }
        public PlaydateDetail GetPlaydatesById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PlayDates
                        .Single(e => e.PlaydateID == id && e.UserID == _userId);
                return
                    new PlaydateDetail
                    {
                        PlaydateID = entity.PlaydateID,
                        

                    };
            }
        }
        public bool UpdatePlaydate(PlaydateEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PlayDates
                        .Single(e => e.PlaydateID == model.PlaydateID && e.UserID == _userId);
                        entity.UserID = model.UserID;
                        entity.PlaydateID = model.PlaydateID;
                        entity.DogID = model.DogID;
                        //entity.ParentName = model.ParentName;
                        //entity.DogName = model.DogName;
                        //entity.DogSize = model.DogSize;
                        //entity.AgeLevel = model.AgeLevel;
                        entity.EventDate = model.EventDate;
                        entity.AddressOfEvent = model.AddressOfEvent;
                        entity.TypeOfPlaydate = model.TypeOfPlaydate;
                        entity.LeaveAMessage = model.LeaveAMessage;
                        return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePlaydate(int PlaydateID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PlayDates
                        .Single(e => e.PlaydateID == PlaydateID && e.UserID == _userId);

                ctx.PlayDates.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
