using Microsoft.AspNetCore.Mvc.Rendering;

namespace KolokwiumZero.UI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public bool Under18 { get; set; }
        public string? KeeperNameAndLastName { get; set; }
        public string? KeeperPhoneNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TripId { get; set; }
        public string TripName { get; set; }
        public List <SelectListItem> TripTypes { get; set; }
    }
}
