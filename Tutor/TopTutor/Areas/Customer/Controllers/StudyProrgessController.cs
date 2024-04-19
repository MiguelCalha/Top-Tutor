using Microsoft.AspNetCore.Mvc;

namespace TopTutor.Areas.Customer.Controllers
{
    // Author: Miguel Calha
    // This controller handles the actions related to the Whiteboard for customers.
    // The customer can view the Whiteboard and the details of a specific Whiteboard.

    [Area("Customer")]
    public class StudyProrgessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
