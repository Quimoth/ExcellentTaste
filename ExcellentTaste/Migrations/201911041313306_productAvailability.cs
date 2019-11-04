namespace ExcellentTaste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productAvailability : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductModel", "Availability", c => c.Int(nullable: false));
            AddColumn("dbo.ProductModel", "OrderViewModel_OrderId", c => c.Int());
            CreateIndex("dbo.ProductModel", "OrderViewModel_OrderId");
            AddForeignKey("dbo.ProductModel", "OrderViewModel_OrderId", "dbo.OrderModel", "OrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductModel", "OrderViewModel_OrderId", "dbo.OrderModel");
            DropIndex("dbo.ProductModel", new[] { "OrderViewModel_OrderId" });
            DropColumn("dbo.ProductModel", "OrderViewModel_OrderId");
            DropColumn("dbo.ProductModel", "Availability");
        }
    }
}
