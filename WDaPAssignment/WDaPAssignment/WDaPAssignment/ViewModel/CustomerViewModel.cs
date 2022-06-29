using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WDaPAssignment.ViewModel
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
       
        [Display(Name = "Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Date { get; set; }
        [Required]
        
        [Display(Name = "Heading")]
        public string Heading { get; set; }
        [Required]

        [Display(Name = "Restaurent")]
        public int RestaurentId { get; set; }
        [Required]
        [Display(Name = "Comment")]
        public string Comment { get; set; }
        [Required]
        [Display(Name = "Rating")]
  
        public int Rating { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Restaurant name")]
        public string RestaurentName { get; set; }
        public IEnumerable<SelectListItem> RestaurentList { get; set; }
        [Required]
        [Display(Name = "Agree")]
        public int Agree { get; set; }
        [Required]
        [Display(Name = "Disagree")]
        public int Disagree { get; set; }
        public List<CustomerViewModel> CustomerList { get; set; }
    }
}
