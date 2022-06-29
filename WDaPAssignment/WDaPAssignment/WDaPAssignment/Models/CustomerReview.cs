using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WDaPAssignment.Models
{
    public class CustomerReview
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CustomerId { get; set; }
        public int UserId { get; set; }
        [Required]
        [Column(TypeName = "smalldatetime")]
        public DateTime Date { get; set; }
        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Heading { get; set; }
        public int RestaurentId { get; set; }
        [Required]
        [Column(TypeName = "varchar(450)")]
        public string Comment { get; set; }
        public int Rating { get; set; }
        public int Agree { get; set; }
        public int Disagree { get; set; }
    }
}
