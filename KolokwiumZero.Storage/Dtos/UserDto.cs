using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumZero.Storage.Dtos
{
    public class UserDto : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        [StringLength(128, ErrorMessage = "Imię nie może przekraczać 128 znaków")]
        public string Name { get; set; }
        [Required]
        [StringLength(128, ErrorMessage = "Nazwisko nie może przekraczać 128 znaków")]
        public string LastName { get; set; }
        [Required]
        [StringLength(128, ErrorMessage = "Adres nie może przekraczać 128 znaków")]
        public string Adress { get; set; }
        [Required]
        [StringLength(128, ErrorMessage = "Numer telefonu nie może przekraczać 128 znaków")]
        public string PhoneNumber { get; set; }
        [Required]
        public bool Under18 { get; set; }
        [StringLength(256, ErrorMessage = "Imię i nazwisko nie może przekraczać 256 znaków")]
        public string? KeeperNameAndLastName { get; set; }
        [StringLength(11, ErrorMessage = "Numer telefonu nie może przekraczać 128 znaków")]
        public string? KeeperPhoneNumber { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int TripId { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Under18 && (string.IsNullOrEmpty(KeeperNameAndLastName) || string.IsNullOrEmpty(KeeperPhoneNumber)))
            {
                yield return new ValidationResult("Imię i nazwisko oraz numer telefonu opiekuna są wymagane dla osób poniżej 18 roku życia");
            }
        }
    }
}
