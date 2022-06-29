using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WDaPAssignment.Models;
using WDaPAssignment.ViewModel;

namespace WDaPAssignment.Service
{
    public class CustomerReviewService : ICustomerReviewService
    {
        private AppReviewDBContext _context;

        public CustomerReviewService(AppReviewDBContext context,
            ILogger<CustomerReviewService> logger
            )
        {
            this._context = context;
            Logger = logger;
        }
        public ILogger<CustomerReviewService> Logger { get; }

        public void AggreeUp(int id)
        {
            try
            {
                var review = _context.CustomerReview.Where(x => x.CustomerId == id).FirstOrDefault();
                review.Agree = review.Agree + 1;
                var reviewCustomer = _context.CustomerReview.Attach(review);
                reviewCustomer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void DisagreeUp(int id)
        {
            try
            {
                var review = _context.CustomerReview.Where(x => x.CustomerId == id).FirstOrDefault();
                review.Disagree = review.Disagree + 1;
                var reviewCustomer = _context.CustomerReview.Attach(review);
                reviewCustomer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void CreateReview(CustomerViewModel model)
        {
            try
            {
                var review = new CustomerReview
                {
                    RestaurentId = model.RestaurentId,
                    Rating = model.Rating,
                    Date = DateTime.Now,
                    Heading = model.Heading,
                    Comment = model.Comment,
                    UserId = model.UserId,
                    Agree = 0,
                    Disagree = 0
                };
                _context.CustomerReview.Add(review);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public CustomerViewModel CustomerReviewById(int id)
        {
            var userDetail = (from a in _context.Users
                              join b in _context.CustomerReview on a.Id equals b.UserId
                              join c in _context.Restaurants on b.RestaurentId equals c.RestaurantId
                              where b.CustomerId == id
                              select new CustomerViewModel()
                              {
                                  RestaurentId = b.RestaurentId,
                                  Rating = b.Rating,
                                  Date = b.Date,
                                  Heading = b.Heading,
                                  Comment = b.Comment,
                                  UserId = b.UserId,
                                  Name = a.UserName,
                                  CustomerId = b.CustomerId,
                                  Agree = b.Agree,
                                  Disagree = b.Disagree,
                                  RestaurentName=c.Name
                              }
                            ).FirstOrDefault();

            return userDetail;
        }

        public void DeleteReview(int id)
        {
            try
            {
                CustomerReview review = _context.CustomerReview.Find(id);
                if (review != null)
                {
                    _context.CustomerReview.Remove(review);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        public void EditReview(CustomerViewModel model)
        {
            var review = _context.CustomerReview.Where(x => x.CustomerId == model.CustomerId).FirstOrDefault();           
            review.Rating = model.Rating;
            review.Heading = model.Heading;
            review.Comment = model.Comment;
            review.Agree = model.Agree;
            review.Disagree = model.Disagree;
            var reviewCustomer = _context.CustomerReview.Attach(review);
            reviewCustomer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public List<CustomerViewModel> GetAllReview()
        {
            var userDetail = (from a in _context.Users
                              join b in _context.CustomerReview on a.Id equals b.UserId
                              join c in _context.Restaurants on b.RestaurentId equals c.RestaurantId orderby b.Date descending
                              select new CustomerViewModel()
                              {
                                  RestaurentId = b.RestaurentId,
                                  Rating = b.Rating,
                                  Date = b.Date,
                                  Heading = b.Heading,
                                  Comment = b.Comment,
                                  UserId = b.UserId,
                                  Name = a.UserName,
                                  CustomerId = b.CustomerId,
                                  Agree = b.Agree,
                                  Disagree = b.Disagree,
                                  RestaurentName = c.Name
                              }
                           ).ToList();

            return userDetail;
        }

        public IEnumerable<SelectListItem> GetRestaurentList()
        {
            return _context.Restaurants.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.RestaurantId.ToString()
            }).ToList();
        }
    }
}
