namespace ExcellentTaste.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ExcellentTaste.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<ExcellentTaste.DAL.ETContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExcellentTaste.DAL.ETContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var products = new List<ProductModel>
            {
                new ProductModel{ProductId=0, Name="pasta",Price=10.06, ProductType=ProductModel.Type.Hoofd, Availability = 10},
                new ProductModel{ProductId=1, Name="lasagna",Price=13.37, ProductType=ProductModel.Type.Voor, Availability = 10}
            };

            products.ForEach(s => context.Products.AddOrUpdate(s));
            context.SaveChanges();


            var users = new List<UserModel>
            {
                new UserModel{UserId=0, Email="henk@henk.nl", Password="123"}
            };
            users.ForEach(s => context.Users.AddOrUpdate(s));
            context.SaveChanges();

            var tables = new List<TableModel>
            {
                new TableModel{TableStatus=TableModel.TableStat.Vrij},
                new TableModel{TableStatus=TableModel.TableStat.Bezet},
                new TableModel{TableStatus=TableModel.TableStat.Gereserveerd},
                new TableModel{TableStatus=TableModel.TableStat.Vrij}
            };
            tables.ForEach(s => context.Tables.AddOrUpdate(s));
            context.SaveChanges();
        }
    }
}
