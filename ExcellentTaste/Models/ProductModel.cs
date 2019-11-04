using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExcellentTaste.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Type ProductType { get; set; }
        public int Availability { get; set; }
        public enum Type
        {
            //Drank
            Warm,
            Koud,
            Alcoholisch,
            //Eten
            Lunch,
            Borrel,
            Voor,
            Hoofd,
            Na
        }
    }
}