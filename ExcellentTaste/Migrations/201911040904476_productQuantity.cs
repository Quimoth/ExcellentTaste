﻿namespace ExcellentTaste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productQuantity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductOrderModel", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductOrderModel", "Quantity");
        }
    }
}