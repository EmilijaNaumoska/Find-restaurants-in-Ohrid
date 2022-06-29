using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WDaPAssignment.Helper;
using WDaPAssignment.Service;
using WDaPAssignment.ViewModel;

namespace WDaPAssignment.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerReviewService customerReviewService;
        private readonly UserManager<IdentityUser<int>> userManager;
        private readonly ILogger logger;


        public CustomerController(ICustomerReviewService _customerReviewService, UserManager<IdentityUser<int>> userManager,
            ILogger<CustomerController> logger)
        {
            this.customerReviewService = _customerReviewService;
            this.logger = logger;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            CustomerViewModel customer = new CustomerViewModel();
            customer.CustomerList = customerReviewService.GetAllReview();
            return View(customer);
        }
        [HttpGet]
        public IActionResult AddReview()
        {
            CustomerViewModel customer = new CustomerViewModel();
            customer.Date = DateTime.Now;
            customer.Name = User.UserName();
            customer.RestaurentList = customerReviewService.GetRestaurentList();
            return View(customer);
        }
        [HttpGet]
        public IActionResult EditReview(int id)
        {
            CustomerViewModel customer = customerReviewService.CustomerReviewById(id);
            customer.Name = User.UserName();
            return View(customer);
        }
        [HttpGet]
        public IActionResult ReviewDetail(int id)
        {
            CustomerViewModel customer = customerReviewService.CustomerReviewById(id);
            return View(customer);
        }
        [HttpGet]
        public IActionResult DeleteReview(int id)
        {
            CustomerViewModel customer = customerReviewService.CustomerReviewById(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult DeleteReview(CustomerViewModel model)
        {
            customerReviewService.DeleteReview(model.CustomerId);
            return RedirectToAction("Index", "Customer");
        }
        [HttpPost]
        public async Task<IActionResult> AddReviewAsync(CustomerViewModel model)
        {
            try
            {
                ModelState.Remove("CustomerId");
                ModelState.Remove("UserId");
                ModelState.Remove("Agree");
                ModelState.Remove("Disagree");
                if (ModelState.IsValid)
                {
                    var user = await userManager.GetUserAsync(User);
                    model.UserId = user.Id;
                    customerReviewService.CreateReview(model);
                    return RedirectToAction("Index","Customer");
                }
                else
                {
                    CustomerViewModel customer = new CustomerViewModel();
                    customer.Date = DateTime.Now;
                    customer.Name = User.UserName();
                    customer.RestaurentList = customerReviewService.GetRestaurentList();
                    return View(customer);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
          
           
        }
        [HttpPost]
        public async Task<IActionResult> EditReviewAsync(CustomerViewModel model)
        {
            try
            {               
                ModelState.Remove("UserId");              
                if (ModelState.IsValid)
                {
                    var user = await userManager.GetUserAsync(User);
                    model.UserId = user.Id;
                    customerReviewService.EditReview(model);
                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpGet]
        public IActionResult Aggree(int id)
        {
           
            HttpContext.Session.SetString("CustomerId", id.ToString());
            customerReviewService.AggreeUp(id);
            return RedirectToAction("Index", "Customer");
        }
        [HttpGet]
        public IActionResult Disagree(int id)
        {
          
            HttpContext.Session.SetString("CustomerId", id.ToString());
         
            customerReviewService.DisagreeUp(id);
            return RedirectToAction("Index", "Customer");
        }
    }
}
