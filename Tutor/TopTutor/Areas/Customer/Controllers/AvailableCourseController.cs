using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TopTutor.DataAcess.Repository;
using TopTutor.DataAcess.Repository.IRepository;
using TopTutor.Models;

namespace TopTutor.Areas.Customer.Controllers
{
    // Author: Miguel Calha
    // This controller handles the actions related to available courses for customers.
    // The customer can view the list of available courses and the details of a specific course.

    [Area("Customer")]
    public class AvailableCourseController : Controller
    {
        private readonly ILogger<AvailableCourseController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public AvailableCourseController(ILogger<AvailableCourseController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            IEnumerable<Course> courseList = _unitOfWork.Course.GetAll(includeProperties: "Category");
            return View(courseList);
        }

        public IActionResult Details(int courseId)
        {
            var course = _unitOfWork.Course.Get(c => c.Id == courseId, includeProperties: "Category");
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
