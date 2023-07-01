using Bulky_Web.Data;
using Bulky_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky_Web.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _dbbContext;
        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbbContext = dbContext;
        }

        public IActionResult Index()
        {

            //retrieving the data
            List<Category> retrievedCategoryData = _dbbContext.Categories.ToList();
            Console.WriteLine(retrievedCategoryData.ToString());
            return View();
        }
    }
}
