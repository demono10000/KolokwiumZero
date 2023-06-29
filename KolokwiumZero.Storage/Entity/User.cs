using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumZero.Storage.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(128)]
        public string Adress { get; set; }
        [Required]
        [MaxLength(128)]
        public string PhoneNumber { get; set; }
        [Required]
        public bool Under18 { get; set; }
        [MaxLength(256)]
        public string KeeperNameAndLastName { get; set; }
        [MaxLength(11)]
        public string KeeperPhoneNumber { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int TripId { get; set; }
        public TripType TripType { get; set; }
        
    }
}
