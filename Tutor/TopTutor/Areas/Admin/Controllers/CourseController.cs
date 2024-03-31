using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TopTutor.DataAcess.Data;
using TopTutor.DataAcess.Repository;
using TopTutor.DataAcess.Repository.IRepository;
using TopTutor.Models;
using TopTutor.Models.ViewModels;
using TopTutor.Utility;

//Miguel Calha
namespace TopTutor.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CourseController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Course> objCourseList = _unitOfWork.Course.GetAll(includeProperties: "Category").ToList();

            return View(objCourseList);
        }

        public IActionResult Upsert(int? id)
        {

            CourseVM courseVM = new CourseVM()
            {
                CategoryList = _unitOfWork.Category.
               GetAll().Select(u => new SelectListItem
               {
                   Text = u.Name,
                   Value = u.Id.ToString()
               }),
                Course = new Course()

            };
            if (id == null || id == 0)
            {
                //this is for create
                return View(courseVM);
            }
            else
            {
                //update
                courseVM.Course = _unitOfWork.Course.Get(u => u.Id == id);
                return View(courseVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(CourseVM courseVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string coursePath = Path.Combine(wwwRootPath, @"images\course\");

                    if (!string.IsNullOrEmpty(courseVM.Course.ImageUrl))
                    {
                        //Delete the old image

                        var oldImagePath =
                             Path.Combine(wwwRootPath, courseVM.Course.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);

                        }

                    }

                    using (var fileStream = new FileStream(Path.Combine(coursePath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    courseVM.Course.ImageUrl = @"\images\course\" + fileName;
                }

                if (courseVM.Course.Id == 0)
                {
                    _unitOfWork.Course.Add(courseVM.Course);
                }
                else
                {
                    _unitOfWork.Course.Update(courseVM.Course);
                }
                _unitOfWork.Save();
                TempData["success"] = "Course Created Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                courseVM.CategoryList = _unitOfWork.Category.
               GetAll().Select(u => new SelectListItem
               {
                   Text = u.Name,
                   Value = u.Id.ToString()
               });
                return View(courseVM);

            }
        }



        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Course> objCourseList = _unitOfWork.Course.GetAll(includeProperties: "Category").ToList();
            return Json(new { data = objCourseList });
        }

        public IActionResult Delete(int? id)
        {
            var courseToBeDeleted = _unitOfWork.Course.Get(u => u.Id == id);
            if (courseToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var oldImagePath =
                           Path.Combine(_webHostEnvironment.WebRootPath,
                           courseToBeDeleted.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Course.Remove(courseToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }


}