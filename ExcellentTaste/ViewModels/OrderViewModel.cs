using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using ExcellentTaste.Models;
using ExcellentTaste.DAL;
using System.ComponentModel.DataAnnotations;

namespace ExcellentTaste.ViewModels
{
    public class OrderViewModel : OrderModel
    {
        public OrderViewModel(){}
        public OrderViewModel(OrderModel order)
        {
            this.OrderId = order.OrderId;
            this.OrderStatus = order.OrderStatus;
            this.Products = order.Products;
            this.Table = order.Table;
            this.Tables = order.Tables;
            this.TimeStamp = order.TimeStamp;
        }        
        public List<int> TableIds { get; set; } 
        public List<int> ProductIds { get; set; }
        public List<ProductModel> AllProducts { get; set; }
        public List<TableModel> AllTables { get; set; }
    }
}