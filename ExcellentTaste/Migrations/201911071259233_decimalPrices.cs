﻿namespace ExcellentTaste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class decimalPrices : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductModel", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductModel", "Price", c => c.Double(nullable: false));
        }
    }
}
