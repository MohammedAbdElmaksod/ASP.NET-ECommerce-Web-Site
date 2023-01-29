using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace E_CommerceWebSite.Models
{
    public class TbOrderInvoice
    {
        [Key]
        public int InvoiceId { get; set; }
        [Required]
        public string clientName { get; set; }
        [Required]
        public decimal unitPrice { get; set; }
        public decimal totalPrice { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string UserId { get; set; }
        public virtual ExtendIdentity User { get; set; }
    }
}
