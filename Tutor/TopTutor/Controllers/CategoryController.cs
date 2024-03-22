using Microsoft.AspNetCore.Mvc;
using TopTutor.Data;
using TopTutor.Models;

//Miguel Calha
namespace TopTutor.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View();
        }
    }
}
