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
                //Hoofdgerechten
                new ProductModel{Name="Pasta",Price=13.37m, ProductType=Models.FoodType.Hoofd, Availability = 10},
                new ProductModel{Name="Kalkoen",Price=13.37m, ProductType=Models.FoodType.Hoofd, Availability = 10},
                new ProductModel{Name="Kindermenu",Price=13.37m, ProductType=Models.FoodType.Hoofd, Availability = 10},
                //Voorgerechten
                new ProductModel{Name="Salade",Price=13.37m, ProductType=Models.FoodType.Voor, Availability = 10},
                new ProductModel{Name="Lasagna",Price=13.37m, ProductType=Models.FoodType.Voor, Availability = 10},
                new ProductModel{Name="Asperge Soep",Price=13.37m, ProductType=Models.FoodType.Voor, Availability = 10},
                //Nagerechten
                new ProductModel{Name="Tiramisu",Price=13.37m, ProductType=Models.FoodType.Na, Availability = 10},
                new ProductModel{Name="Sorbeeeeeeeeet",Price=13.37m, ProductType=Models.FoodType.Na, Availability = 10},
                new ProductModel{Name="Irish Coffee",Price=13.37m, ProductType=Models.FoodType.Na, Availability = 10},
                //Luch
                new ProductModel{Name="Uitsmeiter",Price=13.37m, ProductType=Models.FoodType.Lunch, Availability = 10},
                new ProductModel{Name="Tosti",Price=13.37m, ProductType=Models.FoodType.Lunch, Availability = 10},
                new ProductModel{Name="Gekookt ei",Price=13.37m, ProductType=Models.FoodType.Lunch, Availability = 10},
                //warme dranken
                new ProductModel{Name="Koffie",Price=13.37m, ProductType=Models.FoodType.Warm, Availability = 10},
                new ProductModel{Name="Thee",Price=13.37m, ProductType=Models.FoodType.Warm, Availability = 10},
                new ProductModel{Name="Cappuccino",Price=13.37m, ProductType=Models.FoodType.Warm, Availability = 10},
                //Koude dranken
                new ProductModel{Name="Gola",Price=13.37m, ProductType=Models.FoodType.Koud, Availability = 10},
                new ProductModel{Name="Appelsap",Price=13.37m, ProductType=Models.FoodType.Koud, Availability = 10},
                new ProductModel{Name="Sinasappelsap",Price=13.37m, ProductType=Models.FoodType.Koud, Availability = 10},
                //Alcoholische dranken
                new ProductModel{Name="Bierrrrrrr",Price=13.37m, ProductType=Models.FoodType.Alcoholisch, Availability = 10},
                new ProductModel{Name="Wijn",Price=13.37m, ProductType=Models.FoodType.Alcoholisch, Availability = 10},
                new ProductModel{Name="Vodka",Price=13.37m, ProductType=Models.FoodType.Alcoholisch, Availability = 10},
                new ProductModel{Name="Odka",Price=13.37m, ProductType=Models.FoodType.Alcoholisch, Availability = 10},
                //borrel
                new ProductModel{Name="Russian roulette",Price=13.37m, ProductType=Models.FoodType.Borrelhapjes, Availability = 100},
                new ProductModel{Name="Bitterballen",Price=13.37m, ProductType=Models.FoodType.Borrelhapjes, Availability = 100},
                new ProductModel{Name="Knakworstjes",Price=13.37m, ProductType=Models.FoodType.Borrelhapjes, Availability = 100},
                new ProductModel{Name="Pinda's",Price=13.37m, ProductType=Models.FoodType.Borrelhapjes, Availability = 100},
                new ProductModel{Name="Chips Naturel",Price=13.37m, ProductType=Models.FoodType.Borrelhapjes, Availability = 100},
                new ProductModel{Name="Chips Paprika",Price=13.37m, ProductType=Models.FoodType.Borrelhapjes, Availability = 100},
                new ProductModel{Name="Chips Kaas & Ui",Price=13.37m, ProductType=Models.FoodType.Borrelhapjes, Availability = 100},
                new ProductModel{Name="Kaasblokjes",Price=13.37m, ProductType=Models.FoodType.Borrelhapjes, Availability = 100},
            };

            products.ForEach(s => context.Products.AddOrUpdate(s));
            context.SaveChanges();


            var users = new List<UserModel>
            {
                new UserModel{Email="henk@henk.nl", Password="123"}
            };
            users.ForEach(s => context.Users.AddOrUpdate(s));
            context.SaveChanges();

            var tables = new List<TableModel>
            {
                new TableModel{TableStatus=TableModel.TableStat.Bezet},
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
