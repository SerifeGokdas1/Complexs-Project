using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Complexs.Models
{
    public class PaymentsModel
    {
        public int PaymentId { get; set; }
        public string PaymentType { get; set; }
        [Required(ErrorMessage = "It is mandatory to fill in the payment amount section.")]
        public decimal PaymentAmount { get; set; }
    }
}