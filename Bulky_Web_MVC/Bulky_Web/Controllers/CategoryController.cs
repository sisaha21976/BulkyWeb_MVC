using Bulky_Web.Data;
using Bulky_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky_Web.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {

            //retrieving the data
            List<Category> retrievedCategoryData = _dbContext.Categories.ToList();
            Console.WriteLine(retrievedCategoryData.ToString());
            return View(retrievedCategoryData);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            try
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
            }catch(Exception e)
            {
                
            }
           
            return RedirectToAction("Index");
        }
    }
}
