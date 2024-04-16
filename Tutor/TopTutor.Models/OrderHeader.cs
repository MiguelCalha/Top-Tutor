using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTutor.Models
{
    public class OrderHeader
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public double OrderTotal { get; set; }

        public string? OrderStatus { get; set; }
        public string? PaymentStatus { get; set; }
        public string? meetingLink { get; set; }

        public DateTime PaymentDate { get; set; }

        public string? PaymentIntentId { get; set; }

        [Required]
        public string? StudentName { get; set; }
        [Required]
        public string? StudentEmail { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Platform { get; set; }
        [Required]
        public DateTime? LessonDate { get; set; }
    }
}
