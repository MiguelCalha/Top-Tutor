using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using TopTutor.DataAcess.Repository;
using TopTutor.DataAcess.Repository.IRepository;
using TopTutor.Models;
using TopTutor.Utility;

namespace TopTutor.Areas.Customer.Controllers
{
    // Author: Miguel Calha
    // This controller handles the actions related to the Tutor ads cart for customers.
    // The customer can view the Tutor ads cart, add products to the Tutor ads cart, remove products from the Tutor ads cart,
    // increase the quantity of a product in the Tutor ads cart, decrease the quantity of a product in the Tutor ads cart,
    // view the summary of the order and confirm the order.
    // The customer can also view the order confirmation.

    [Area("Customer")]
    public class TutorController : Controller
    {
        private readonly ILogger<TutorController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public TutorController(ILogger<TutorController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return View(productList);
        }

        public IActionResult Details(int productId)
        {
            ShoppingCart cart = new()
            {
                Product = _unitOfWork.Product.Get(u => u.Id == productId, includeProperties: "Category"),
                Count = 1,
                ProductId = productId
            };
               
            return View(cart);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId = userId;

            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.
                Get(u => u.ApplicationUserId == userId && 
                u.ProductId==shoppingCart.ProductId);

            if(cartFromDb != null)
            {
                //ShoppingCart exists
                cartFromDb.Count += shoppingCart.Count;
                _unitOfWork.ShoppingCart.Update(cartFromDb);
                _unitOfWork.Save();
            }
            else
            {
                _unitOfWork.ShoppingCart.Add(shoppingCart);
                _unitOfWork.Save();
                HttpContext.Session.SetInt32(SD.SessionCart,
                _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId).Count());

            }
            TempData["success"] = "Cart Updated Successfully";


            return RedirectToAction(nameof(Index));
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
