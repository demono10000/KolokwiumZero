using KolokwiumZero.Storage.Dtos;
using KolokwiumZero.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumZero.Storage.Service
{
    public interface IUserService
    {
        List<UserDto> Read();
        void Create(UserDto user);
        List<TripType> ReadTripTypes();
        void Delete(int id);
        UserDto Get(int id);
    }
}
