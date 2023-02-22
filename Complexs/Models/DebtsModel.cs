using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Complexs.Models
{
    public class DebtsModel
    {
        public int DebtId { get; set; }
        [Required(ErrorMessage = "It is mandatory to fill in the debt amount section.")]
        public decimal DebtAmount { get; set; }
        public int DebtMaturity { get; set; }
        public string DebtSituation { get; set; }
        public int CostumerId { get; set; }
        public int PaymentId { get; set; }
    }
}