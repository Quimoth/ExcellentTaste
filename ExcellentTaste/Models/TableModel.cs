using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExcellentTaste.Models
{
    public class TableModel
    {
        [Key]
        public int TableId { get; set; }
        public TableStat TableStatus { get; set; }
        public virtual List<OrderModel> Order { get; set; }
        public enum TableStat
        {
            Vrij,
            Bezet,
            Gereserveerd
        }
        public override string ToString()
        {
            return $"{TableId}";
        }
    }
}