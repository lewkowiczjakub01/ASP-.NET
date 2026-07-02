using Microsoft.AspNetCore.Mvc;
using ProjektASP.Models;
using ProjektASP.Infrastructure;

namespace ProjektASP.Controllers {
    public class OwnerController : Controller {
        private CarContext context;
        private IWebHostEnvironment hostingEnvironment;
        public OwnerController(CarContext context, IWebHostEnvironment environment) {
            this.context = context;
            this.hostingEnvironment = environment;
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Owner o) {
            if (ModelState.IsValid) {
                context.Add(o);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
                return View();
        }

        public IActionResult Index(int id) {
            int pageSize = 5;

            PagingInfo pagingInfo = new PagingInfo();
            pagingInfo.CurrentPage = id == 0 ? 1 : id;
            pagingInfo.TotalItems = context.Owner.Count();
            pagingInfo.ItemsPerPage = pageSize;

            var skip = pageSize * (Convert.ToInt32(id) - 1);
            if (skip < 0)
                skip = 0;
            ViewBag.PagingInfo = pagingInfo;
            var o = context.Owner.Skip(skip).Take(pageSize).ToList();

            return View(o);
        }

        public IActionResult Update(int id) {
            var pc = context.Owner.Where(a => a.Id == id).FirstOrDefault();
            return View(pc);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Owner o) {
            if (ModelState.IsValid) {
                context.Update(o);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            } else
                return View(o);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id) {
            var o = context.Owner.Where(a => a.Id == id).FirstOrDefault();
            context.Remove(o);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult OwnerCars(int id) {
            var ownerCars = context.Car.Where(a => a.OwnerId == id).ToList();
            var owner = context.Owner.Where(o => o.Id == id).FirstOrDefault().Name +" "+ context.Owner.Where(o => o.Id == id).FirstOrDefault().Surname;
            ViewBag.Owner = owner;

            return View(ownerCars);
        }
    }
}
