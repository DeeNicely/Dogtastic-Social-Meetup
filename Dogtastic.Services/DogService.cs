using Dogtastic.Data;
using Dogtastic.Models;
using DogtasticData;
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
    }
}
