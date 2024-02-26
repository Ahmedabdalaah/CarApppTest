using CarApppTest.Data;
using CarApppTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarApppTest.Controllers
{
    public class CarsController : Controller
    {
        private readonly AppDBContext _dbContext;
        public CarsController(AppDBContext db)
        {
            _dbContext = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Car> carList = _dbContext.cars.ToList();
            return View(carList);
        }
        //Get 
        public ActionResult Add()
        {
            selectCategory();
            return View();
        }
        //Post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Car car)
        {
            if(ModelState.IsValid)
            {
                _dbContext.cars.Add(car);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }
        public void selectCategory(int selectedId=0)
        {
            List<Category> categories = new List<Category>
            {
                new Category { Id=0 , Name="BMW"},
                new Category { Id=1 , Name="NISSAN"},
                new Category { Id=2 , Name="TOYTA"},
                new Category { Id=3 , Name="BMW"}
            };
            SelectList listItems = new SelectList(categories, "Id", "Name", selectedId);
            ViewBag.CategoryList = listItems;
        }
        //Get 
        public ActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var car = _dbContext.cars.Find(id);
            if(car == null)
            {
                return NotFound();
            }
            selectCategory();
            return View(car);
        }
        //Post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                _dbContext.cars.Update(car);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(car);
            }
        }
        //Get 
        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var car = _dbContext.cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }
            selectCategory();
            return View(car);
        }
        //Post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Car car)
        {
         
                _dbContext.cars.Remove(car);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
        }
    }
}
