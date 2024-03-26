using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTutor.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Title { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public String TutorName { get; set; }
        [Display(Name="List Price")]
        [Range(1, 1000)]
        public double ListPrice { get; set; }
    }
}
