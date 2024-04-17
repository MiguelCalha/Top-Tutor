using Microsoft.AspNetCore.Mvc;

namespace TopTutor.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class StudyProrgessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
