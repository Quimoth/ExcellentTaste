using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExcellentTaste.Models
{
    public enum FoodType
    {
        //Drank
        Warm,
        Koud,
        Alcoholisch,
        //Eten
        Lunch,
        Borrelhapjes,
        Voor,
        Hoofd,
        Na
    }
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public FoodType ProductType { get; set; }
        public int Availability { get; set; }
    }
}