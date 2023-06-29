using KolokwiumZero.Storage.Dtos;
using KolokwiumZero.Storage.Service;
using KolokwiumZero.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KolokwiumZero.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var users = _userService.Read();
            return View(users);
        }
        public IActionResult Add()
        {
            var model = new UserModel();
            model.TripTypes = _userService.ReadTripTypes().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(UserDto model)
        {
            if (ModelState.IsValid)
            {
                _userService.Create(model);
                return RedirectToAction("Index");
            }
            var userModel = new UserModel
            {
                Name = model.Name,
                LastName = model.LastName,
                Adress = model.Adress,
                PhoneNumber = model.PhoneNumber,
                Under18 = model.Under18,
                KeeperNameAndLastName = model.KeeperNameAndLastName,
                KeeperPhoneNumber = model.KeeperPhoneNumber,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                TripId = model.TripId
                
            };
            userModel.TripTypes = _userService.ReadTripTypes().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            return View(userModel);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Console.WriteLine("Delete" + id);
            var user = _userService.Get(id);
            if (user == null)
            {
                Console.WriteLine("User not found");
                return NotFound();
            }
            Console.WriteLine("User found");

            var currentDate = DateTime.Now;
            var tripStartDate = user.StartDate;

            if (tripStartDate - currentDate >= TimeSpan.FromDays(1))
            {
                _userService.Delete(id);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}
