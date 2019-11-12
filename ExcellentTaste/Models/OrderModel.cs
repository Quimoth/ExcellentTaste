using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExcellentTaste.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }
        public virtual List<TableModel> Tables { get; set; }
        public OrderStat OrderStatus { get; set; }
        public enum OrderStat
        {
            Preparing,
            Paid
        }
        [DataType(DataType.Time)]
        public DateTime? TimeStamp { get; set; }
        //Producten, ofwel eten en drinken.
        public virtual List<ProductOrderModel> Products { get; set; }

        [NotMapped]
        public string Table { get; set; }
    }
}