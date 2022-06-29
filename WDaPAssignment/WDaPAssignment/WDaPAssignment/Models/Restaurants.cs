using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WDaPAssignment.Models
{
    public class Restaurants
    {
        public Restaurants()
        {
           
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RestaurantId { get; set; }
        [Required]
        [Column(TypeName = "varchar(250)")]
      
        public string Name { get; set; }
    }
}
