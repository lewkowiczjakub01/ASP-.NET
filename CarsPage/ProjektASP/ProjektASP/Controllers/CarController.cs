using Microsoft.AspNetCore.Mvc;
using ProjektASP.Models;
using ProjektASP.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektASP.Models;
using ProjektASP.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ProjektASP.Controllers {
    public class CarController : Controller {
        private CarContext context;
        private IWebHostEnvironment hostinngEnvironment;
        public CarController(CarContext context, IWebHostEnvironment environment) {
            this.context = context;
            this.hostinngEnvironment = environment;
        }

        public IActionResult Create() {
            GetOwner();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Car c) {
            GetOwner();

            if (ModelState.IsValid) {
                if (context.Car.Any(e => e.Plate == c.Plate)) {
                    ModelState.AddModelError("Plate", "This Plate is already taken");
                    return View();
                }



                context.Add(c);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            } else
                return View();
        }

        void GetOwner() {
            List<SelectListItem> owner = new List<SelectListItem>();
            owner = context.Owner.Select(x => new SelectListItem { Text = x.Name + " " + x.Surname, Value = x.Id.ToString() }).ToList();
            ViewBag.Owner = owner;
        }


        public IActionResult Index(int id) {
            GetOwner();
            int pageSize = 5;

            PagingInfo pagingInfo = new PagingInfo();
            pagingInfo.CurrentPage = id == 0 ? 1 : id;
            pagingInfo.TotalItems = context.Owner.Count();
            pagingInfo.ItemsPerPage = pageSize;

            var skip = pageSize * (Convert.ToInt32(id) - 1);
            if (skip < 0)
                skip = 0;
            ViewBag.PagingInfo = pagingInfo;
            var c = context.Car.Skip(skip).Take(pageSize).Include(s => s.Owner_R).ToList();

            return View(c);
        }

        public IActionResult Update(int id) {
            var car = context.Car.Where(a => a.Id == id).Include(s => s.Owner_R).FirstOrDefault();
            GetOwner();

            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Car car) {
            GetOwner();


            if (ModelState.IsValid) {
                if (context.Car.Any(e => e.Plate == car.Plate)) {
                    ModelState.AddModelError("Plate", "This Plate is already taken");
                    return View();
                }
                context.Update(car);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            } else
                return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id) {
            var movie = context.Car.Where(a => a.Id == id).FirstOrDefault();
            context.Remove(movie);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Search(string plate) {
            GetOwner();
            List<Car> cars = new List<Car>();
            //var c = context.Car.Skip(skip).Take(pageSize).Include(s => s.Owner_R).ToList();

            var c = from m in context.Car.Include(s => s.Owner_R)
                    select m;
            if (!String.IsNullOrEmpty(plate)) {
                c = c.Where(s => s.Plate!.Contains(plate));
            }

            return View(c);
        }
    }
}
