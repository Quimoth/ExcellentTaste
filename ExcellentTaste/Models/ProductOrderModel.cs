using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExcellentTaste.Models
{
    public enum Status
    {
        Preparing,
        Done,
        Delivered
    }
    public class ProductOrderModel
    {
        [Key]
        public int ProductOrderId { get; set; }
        public ProductModel Product { get; set; }
        public Status ProductOrderStatus { get; set; }
    }

}