using Dogtastic.Data;
using Dogtastic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogtastic.Services
{
    public class DogService
    {
        private readonly Guid _userId;
        public DogService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateDog(DogCreate model)
        {
            var entity =
                    new Dog()
                    {
                        UserID = _userId,
                        //   DogID = model.DogID,
                        DogName = model.DogName,
                        AgeLevel = model.AgeLevel,
                        DogSize = model.DogSize
                    };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Dogs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<DogListItem> GetDogs()
        {
                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx
                            .Dogs
                           // .Where(e => e.UserID == _userId)
                            .Select(
                                e =>
                                    new DogListItem
                                    {
                                        UserID = e.UserID,
                                        DogID = e.DogID,
                                        DogName = e.DogName,
                                        DogSize = e.DogSize,
                                        AgeLevel = e.AgeLevel
                                    }
                            );

                    return query.ToArray();
                }
        }
        public DogDetail GetDogsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dogs
                        .Single(e => e.DogID == id);
                return
                    new DogDetail
                    {
                        UserID = entity.UserID,
                        DogID = entity.DogID,
                        DogName = entity.DogName,
                        DogSize = entity.DogSize,
                        AgeLevel = entity.AgeLevel

                    };
            }
        }
        public bool UpdateDog(DogEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dogs
                        .Single(e => e.DogID == model.DogID && e.UserID == _userId);
                entity.UserID = model.UserID;
                entity.DogName = model.DogName;
                entity.DogSize = model.DogSize;
                entity.AgeLevel = model.AgeLevel;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteDog(int DogID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Dogs
                        .Single(e => e.DogID == DogID && e.UserID == _userId);

                ctx.Dogs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
