using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExcellentTaste.Models
{
    public class ProductOrderModel
    {
        [Key]
        public int ProductOrderId { get; set; }
        public ProductModel Product { get; set; }
        public Status ProductOrderStatus { get; set; }
        public int Quantity { get; set; }
        public enum Status
        {
            Waiting,
            Prepared,
            Delivered
        }
    }
}