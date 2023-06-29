using KolokwiumZero.Storage.Dtos;
using KolokwiumZero.Storage.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumZero.Storage.Service
{
    public class UserService : IUserService
    {
        private readonly UserContext _dbContext;
        public UserService(UserContext dbContext)
        {
            _dbContext = dbContext;
            DbInitializer.Init(_dbContext);
        }

        public void Create(UserDto user)
        {
            if (user.Under18 && (string.IsNullOrEmpty(user.KeeperNameAndLastName) || string.IsNullOrEmpty(user.KeeperPhoneNumber)))
            {
                throw new Exception("Dane opiekuna są wymagane dla osób poniżej 18 lat");
            }

            var entity = new User()
            {
                Name = user.Name,
                LastName = user.LastName,
                Adress = user.Adress,
                PhoneNumber = user.PhoneNumber,
                Under18 = user.Under18,
                KeeperNameAndLastName = user.KeeperNameAndLastName,
                KeeperPhoneNumber = user.KeeperPhoneNumber,
                StartDate = user.StartDate,
                EndDate = user.EndDate,
                TripId = user.TripId
            };

            _dbContext.Set<User>().Add(entity);
            _dbContext.SaveChanges();
        }


        public List<UserDto> Read()
        {
            var result = _dbContext.Users.Include(x => x.TripType).Select(x =>
            new UserDto()
            {
                Name = x.Name,
                LastName = x.LastName,
                Adress = x.Adress,
                PhoneNumber = x.PhoneNumber,
                Under18 = x.Under18,
                KeeperNameAndLastName = x.KeeperNameAndLastName,
                KeeperPhoneNumber = x.KeeperPhoneNumber,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Id = x.Id,
            }).ToList();
            return result;
        }

        public List<TripType> ReadTripTypes()
        {
            var result = _dbContext.TripTypes.ToList();
            return result;
        }
        public void Delete(int id)
        {
            var user = _dbContext.Users.Find(id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }
        public UserDto Get(int id)
        {
            var user = _dbContext.Users.Find(id);
            if (user != null)
            {
                return new UserDto()
                {
                    Id = user.Id,
                    Name = user.Name,
                    LastName = user.LastName,
                    Adress = user.Adress,
                    PhoneNumber = user.PhoneNumber,
                    Under18 = user.Under18,
                    KeeperNameAndLastName = user.KeeperNameAndLastName,
                    KeeperPhoneNumber = user.KeeperPhoneNumber,
                    StartDate = user.StartDate,
                    EndDate = user.EndDate,
                    TripId = user.TripId
                };
            }

            return null;
        }
    }
}
