using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WDaPAssignment.ViewModel;

namespace WDaPAssignment.Service
{
    public interface ICustomerReviewService
    {
        IEnumerable<SelectListItem> GetRestaurentList();
        void CreateReview(CustomerViewModel model);
        void EditReview(CustomerViewModel model);
        void DeleteReview(int id);
        List<CustomerViewModel> GetAllReview();
        CustomerViewModel CustomerReviewById(int id);
        void AggreeUp(int id);
        void DisagreeUp(int id);
    }
}
