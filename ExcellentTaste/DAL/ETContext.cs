using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using ExcellentTaste.Models;

namespace ExcellentTaste.DAL
{
    public class ETContext : DbContext
    {
        public ETContext() : base("ETContext")
        {
            Database.SetInitializer<ETContext>(new DropCreateDatabaseIfModelChanges<ETContext>());
        }

        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ProductOrderModel> ProductOrders { get; set; }
        public DbSet<TableModel> Tables { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<ExcellentTaste.ViewModels.OrderViewModel> OrderModels { get; set; }
    }
}