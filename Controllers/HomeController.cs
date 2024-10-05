using Microsoft.AspNetCore.Mvc;
using RollsRoyce.Models;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RollsRoyce.Controllers
{
    public class HomeController : Controller
    {
        public AppDbContext _context;
        public IWebHostEnvironment _environment;
        public HomeController(AppDbContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            var contactform = _context.ContactForm.ToList();
            var carfrom = _context.CarForm.ToList();
            var viewModel = new CombineViewModel
            {
                ContactForm = contactform,
                CarForm = carfrom,
            };
            return View(viewModel);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminLogin( string email, string password)
        { var data = _context.Admin.FirstOrDefault(a => a.email == email && a.password == password);
            if(data != null)
            {
                HttpContext.Session.SetString("admin", email);
                return RedirectToAction("AdminPanel");
            }
            else
            {
                TempData["msg"] = "Email and Password is Incorrect";
                return RedirectToAction("AdminLogin");
            }
        }
        public IActionResult AdminPanel()
        {
            if(HttpContext.Session.GetString("admin") == null)
            {
                return RedirectToAction("Index");
            }
            var contactform = _context.ContactForm.ToList();
            var carfrom = _context.CarForm.ToList();
            var viewModel = new CombineViewModel
            {
                ContactForm = contactform,
                CarForm = carfrom,
            };
            return View(viewModel);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CarForm(CarForm c, IFormFile img1, IFormFile img2, IFormFile img3, IFormFile img4, IFormFile img5)
        {
            string folderpath = Path.Combine(_environment.WebRootPath, "upload");
            string filename1 = img1.FileName;
            string filename2 = img2.FileName;
            string filename3 = img3.FileName;
            string filename4 = img4.FileName;
            string filename5 = img5.FileName;

            string filepath1 = Path.Combine(folderpath, filename1);
            var stream1 = new FileStream(filepath1, FileMode.Create);
            string filepath2 = Path.Combine(folderpath, filename2);
            var stream2 = new FileStream(filepath2, FileMode.Create);
            string filepath3 = Path.Combine(folderpath, filename3);
            var stream3 = new FileStream(filepath3, FileMode.Create);
            string filepath4 = Path.Combine(folderpath, filename4);
            var stream4 = new FileStream(filepath4, FileMode.Create);
            string filepath5 = Path.Combine(folderpath, filename5);
            var stream5 = new FileStream(filepath5, FileMode.Create);

            await img1.CopyToAsync(stream1);
            await img2.CopyToAsync(stream2);
            await img3.CopyToAsync(stream3);
            await img4.CopyToAsync(stream4);
            await img5.CopyToAsync(stream5);

            c.img1 = filename1;
            c.img2 = filename2;
            c.img3 = filename3;
            c.img4 = filename4;
            c.img5 = filename5;

            _context.CarForm.Add(c);
            _context.SaveChanges();
            return RedirectToAction("AdminPanel");
        }
        public IActionResult EditCarForm( int id)
        {
            var data = _context.CarForm.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult EditCarForm(CarForm updatedCar)
        {
            // Fetch the existing record
            var existingCar =  _context.CarForm.Find(updatedCar.id);
          
            // Update non-image properties
            existingCar.model = updatedCar.model;
            existingCar.name = updatedCar.name;
            existingCar.price = updatedCar.price;
            existingCar.body_style = updatedCar.body_style;
            existingCar.seating_capacity = updatedCar.seating_capacity;
            existingCar.length = updatedCar.length;
            existingCar.width = updatedCar.width;
            existingCar.height = updatedCar.height;
            existingCar.wheelbase = updatedCar.wheelbase;
            existingCar.curb_weight = updatedCar.curb_weight;
            existingCar.engine = updatedCar.engine;
            existingCar.power_output = updatedCar.power_output;
            existingCar.torque = updatedCar.torque;
            existingCar.transmission = updatedCar.transmission;
            existingCar.speed_in_second = updatedCar.speed_in_second;
            existingCar.top_speed = updatedCar.top_speed;
            existingCar.combined_fuel = updatedCar.combined_fuel;
            existingCar.suspension = updatedCar.suspension;
            existingCar.brakes = updatedCar.brakes;
            existingCar.wheels = updatedCar.wheels;
            existingCar.infotainment = updatedCar.infotainment;
            existingCar.summary = updatedCar.summary;
            existingCar.short_desc = updatedCar.short_desc;

            // Save changes to the database
            _context.CarForm.Update(existingCar);
            _context.SaveChanges();
            return RedirectToAction("AdminPanel");
        }

        public IActionResult Details(int id)
        {
            var data = _context.CarForm.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult ContactForm(ContactForm c)
        {
            _context.ContactForm.Add(c);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult ContactForm_D(ContactForm c)
        {
            _context.ContactForm.Add(c);
            _context.SaveChanges();
            return RedirectToAction("Details");
        }
        public IActionResult DeleteData(int id)
        {
            var data = _context.CarForm.Find(id);
            if (data == null)
            {
                return NotFound(); // Handle the case where the data does not exist
            }

            string folderpath = Path.Combine(_environment.WebRootPath, "upload");

            // Array of image filenames
            string[] filenames = { data.img1, data.img2, data.img3, data.img4, data.img5 };

            foreach (var filename in filenames)
            {
                if (!string.IsNullOrEmpty(filename)) // Check if the filename is not null or empty
                {
                    string filepath = Path.Combine(folderpath, filename);
                    if (System.IO.File.Exists(filepath))
                    {
                        System.IO.File.Delete(filepath);
                    }
                }
            }

            _context.CarForm.Remove(data);
            _context.SaveChanges();

            return RedirectToAction("AdminPanel");
        }
        //Delete Contact Details
        public IActionResult DeleteContact(int id)
        {
            var data = _context.ContactForm.Find(id);
          
            _context.ContactForm.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("AdminPanel");
        }

        ///slider   
        public IActionResult Slider()
        { return View(); }

    }
}
