﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApp.Data.Models
{
    public class Invoice
    {
        [Key]
        public string InvoiceID { get; set; }
        public string UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public virtual ApplicationUser User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime PaymentDue { get; set; }
        public string Description { get; set; }
        public int PaymentTerms { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public string Status { get; set; }
        public int SenderAddressID { get; set; }
        [ForeignKey(nameof(SenderAddressID))]
        public virtual Address SenderAddress { get; set; }
        public int ClientAddressID { get; set; }
        [ForeignKey(nameof(ClientAddressID))]
        public virtual Address ClientAddress { get; set; }
        public decimal Total { get; set; }
        public List<Item> Items { get; set; }
    }
}
