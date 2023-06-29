using KolokwiumZero.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumZero.Storage.Service
{
    public static class DbInitializer
    {
        public static void Init(UserContext context)
        {
            if(!context.TripTypes.Any())
            {
                var entity1 = new TripType() { Id = 1, Name = "Wycieczka zagraniczna" };
                var entity2 = new TripType() { Id = 2, Name = "Wycieczka jednodniowa" };
                var entity3 = new TripType() { Id = 3, Name = "Wycieczka z noclegiem" };

                context.TripTypes.AddRange(entity1, entity2, entity3);
                context.SaveChanges();
            }
        }
    }
}